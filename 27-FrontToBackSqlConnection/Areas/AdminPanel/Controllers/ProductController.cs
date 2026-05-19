using FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Product;
using FrontToBackSqlConnection.Data;
using FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
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
                    Image = p.ProductImages.FirstOrDefault().Image,
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

            Product product = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                Description = productCreateVM.Description,
                SKU = productCreateVM.SKU,
                CategoryId = productCreateVM.CategoryId.Value
            };

            if (productCreateVM.TagIds is not null)
            {
                product.ProductTags = productCreateVM.TagIds.Select(tagId => new ProductTag { TagId = tagId }).ToList();
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products
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
                Tags = await _context.Tags.ToListAsync()
            };
            return View(productUpdateVM);


        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {
            productUpdateVM.Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync();
            if (id is null || id < 1) return BadRequest();
            if (!ModelState.IsValid) return View(productUpdateVM);

            Product? product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product is null) return NotFound();

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


            product.Name = productUpdateVM.Name;
            product.Description = productUpdateVM.Description;
            product.Price = productUpdateVM.Price;
            product.SKU = productUpdateVM.SKU;
            product.CategoryId = productUpdateVM.CategoryId.Value;
            if (productUpdateVM.TagIds is not null)
            {
                product.ProductTags = productUpdateVM.TagIds.Select(tagId => new ProductTag { TagId = tagId }).ToList();
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}