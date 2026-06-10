using FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using FrontToBackSqlConnection.Data;
using FrontToBackSqlConnection.Models;
using FrontToBackSqlConnection.Utilities.Enum;
using FrontToBackSqlConnection.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles ="Admin,Moderator")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Where(p => !p.isDeleted)
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Select(p => new ProductGetVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    SKU = p.SKU,
                    Image = p.ProductImages.FirstOrDefault(p => p.IsPrimary == true).Image,
                    CategoryName = p.Category.Name
                })
                .ToListAsync();

            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new()
            {
                Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.isDeleted).ToListAsync()
            };
            return View(productCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync();
            productCreateVM.Tags = await _context.Tags.Where(t => !t.isDeleted).ToListAsync();
            if (!ModelState.IsValid) return View(productCreateVM);

            if (!productCreateVM.MainPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File type must be image");
                return View(productCreateVM);
            }
            if (!productCreateVM.HoverPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File type must be image");
                return View(productCreateVM);
            }

            if (!productCreateVM.MainPhoto.CheckFileSize(FileSize.MB, 2))
            {
                ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File size must be less than 2MB");
                return View(productCreateVM);
            }
            if (!productCreateVM.HoverPhoto.CheckFileSize(FileSize.MB, 2))
            {
                ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File size must be less than 2MB");
                return View(productCreateVM);
            }

            bool exsitCategory = _context.Categories.Any(c => c.Id == productCreateVM.CategoryId);
            if (!exsitCategory)
            {
                ModelState.AddModelError(nameof(productCreateVM.CategoryId), "Category does not exist");
                return View(productCreateVM);
            }
            if (productCreateVM.TagIds is not null)
            {
                bool existTag = productCreateVM.TagIds.Any(tagId => !productCreateVM.Tags.Exists(t => t.Id == tagId));
                if (existTag)
                {
                    ModelState.AddModelError(nameof(productCreateVM.TagIds), "Tag does not exist");
                    return View(productCreateVM);
                }
            }

            ProductImage mainImage = new()
            {
                Image = await productCreateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = true
            };
            ProductImage hoverImage = new()
            {
                Image = await productCreateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = false
            };

            Product product = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                Description = productCreateVM.Description,
                SKU = productCreateVM.SKU,
                CategoryId = productCreateVM.CategoryId.Value,
                ProductImages = new List<ProductImage> { mainImage, hoverImage }
            };

            if (productCreateVM.TagIds is not null)
            {
                product.ProductTags = productCreateVM.TagIds.Select(tagId => new ProductTag { TagId = tagId }).ToList();
            }
            string info = string.Empty;

            if (productCreateVM.AdditionalPhotos is not null)
            {
                foreach (var file in productCreateVM.AdditionalPhotos)
                {
                    if (!file.CheckFileType("image/"))
                    {
                        info += $"<p class=\"text-danger\">{file.FileName} type was not correct</p>";
                        continue;
                    }

                    if (!file.CheckFileSize(FileSize.MB, 2))
                    {
                        info += $"<p class=\"text-danger\">{file.FileName} size was not correct</p>";
                        continue;
                    }
                    product.ProductImages.Add(new ProductImage
                    {
                        Image = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                        IsPrimary = false
                    });
                }
            }
            TempData["FileInfo"] = info;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product is null) return NotFound();

            ProductUpdateVM productUpdateVM = new()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                SKU = product.SKU,
                CategoryId = product.CategoryId,
                TagIds = product.ProductTags.Select(pt => pt.TagId).ToList(),
                Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync(),
                Tags = await _context.Tags.ToListAsync(),
                ProductImages = product.ProductImages

            };
            return View(productUpdateVM);


        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {

            if (id is null || id < 1) return BadRequest();


            Product? product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product is null) return NotFound();

            productUpdateVM.Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync();
            productUpdateVM.Tags = await _context.Tags.Where(t => !t.isDeleted).ToListAsync();

            if (!ModelState.IsValid) return View(productUpdateVM);


            if (productUpdateVM.MainPhoto is not null)
            {
                if (!productUpdateVM.MainPhoto.CheckFileType("image/"))
                {
                    ModelState.AddModelError(nameof(productUpdateVM.MainPhoto), "File type must be image");
                    return View(productUpdateVM);
                }
                if (!productUpdateVM.MainPhoto.CheckFileSize(FileSize.MB, 2))
                {
                    ModelState.AddModelError(nameof(productUpdateVM.MainPhoto), "File size must be less than 2MB");
                    return View(productUpdateVM);
                }

            }
            if (productUpdateVM.HoverPhoto is not null)
            {
                if (!productUpdateVM.HoverPhoto.CheckFileType("image/"))
                {
                    ModelState.AddModelError(nameof(productUpdateVM.HoverPhoto), "File type must be image");
                    return View(productUpdateVM);
                }
                if (!productUpdateVM.HoverPhoto.CheckFileSize(FileSize.MB, 2))
                {
                    ModelState.AddModelError(nameof(productUpdateVM.HoverPhoto), "File size must be less than 2MB");
                    return View(productUpdateVM);
                }

            }

            bool existCategory = _context.Categories.Any(c => c.Id == productUpdateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(productUpdateVM.CategoryId), "Category does not exist");
                return View(productUpdateVM);
            }
            if (productUpdateVM.TagIds is not null)
            {
                bool existTag = productUpdateVM.TagIds.Any(tagId => !productUpdateVM.Tags.Exists(t => t.Id == tagId));
                if (existTag)
                {
                    ModelState.AddModelError(nameof(productUpdateVM.TagIds), "Tag does not exist");
                    return View(productUpdateVM);
                }
            }
            if (productUpdateVM.Tags is null)
            {
                productUpdateVM.TagIds = new();
            }
            if (productUpdateVM.TagIds is not null)
            {
                _context.ProductTags.RemoveRange(product.ProductTags.Where(pTag => !productUpdateVM.TagIds.Exists(tagId => tagId == pTag.TagId)).ToList());
                _context.ProductTags.AddRange(productUpdateVM.TagIds.Where(tId => !product.ProductTags.Exists(pTag => pTag.TagId == tId))
                    .ToList()
                    .Select(tId => new ProductTag { TagId = tId, ProductId = product.Id }));
            }

            if (productUpdateVM.MainPhoto is not null)
            {
                string fileName = await productUpdateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                ProductImage mainImage = product.ProductImages.FirstOrDefault(pi => pi.IsPrimary == true);
                mainImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
                product.ProductImages.Remove(mainImage);
                product.ProductImages.Add(new ProductImage
                {
                    Image = fileName,
                    IsPrimary = true
                });
            }
            if (productUpdateVM.HoverPhoto is not null)
            {
                string fileName = await productUpdateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                ProductImage hoverImage = product.ProductImages.FirstOrDefault(pi => pi.IsPrimary == false);
                hoverImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
                product.ProductImages.Remove(hoverImage);
                product.ProductImages.Add(new ProductImage
                {
                    Image = fileName,
                    IsPrimary = false
                });
            }

            if (productUpdateVM.ImageIds is null)
            {
                productUpdateVM.ImageIds = new List<int>();
            }

            var deleteImages = product.ProductImages.Where(pi => !productUpdateVM.ImageIds.Exists(imgId => imgId == pi.Id) && pi.IsPrimary == false).ToList();
            deleteImages.ForEach(di =>
            {
                di.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
            });
            _context.ProductImages.RemoveRange(deleteImages);



            if (productUpdateVM.AdditionalPhotos is not null)
            {
                string info = string.Empty;
                foreach (var file in productUpdateVM.AdditionalPhotos)
                {
                    if (!file.CheckFileType("image/"))
                    {
                        info += $"<p class=\"text-danger\">{file.FileName} type was not correct</p>";
                        continue;
                    }

                    if (!file.CheckFileSize(FileSize.MB, 2))
                    {
                        info += $"<p class=\"text-danger\">{file.FileName} size was not correct</p>";
                        continue;
                    }
                    product.ProductImages.Add(new ProductImage
                    {
                        Image = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                        IsPrimary = false
                    });
                }
                TempData["FileInfo"] = info;
            }


            product.Name = productUpdateVM.Name;
            product.Description = productUpdateVM.Description;
            product.Price = productUpdateVM.Price;
            product.SKU = productUpdateVM.SKU;
            product.CategoryId = productUpdateVM.CategoryId.Value;


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}