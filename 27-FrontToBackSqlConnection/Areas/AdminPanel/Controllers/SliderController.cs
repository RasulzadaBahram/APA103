using FrontToBackSqlConnection.Data;
using FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.Where(s => !s.isDeleted).ToListAsync();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {

            if (!ModelState.IsValid) return View();

            if (!slider.Photo.FileName.Contains("image/"))
            {
                ModelState.AddModelError(nameof(slider.Photo), "File type is incorrect");
                return View();
            }
            if (slider.Photo.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError(nameof(slider.Photo), "File size must be less than 2mb!");
                return View();
            }
            string fileName = string.Concat(Guid.NewGuid().ToString(), slider.Photo.FileName);
            string path = Path.Combine(env.WebRootPath, "assets", "images", "website-images", fileName);

            FileStream fileStream = new FileStream(path, FileMode.Create);
            await slider.Photo.CopyToAsync(fileStream);
            fileStream.Close();
            slider.Image = fileName;
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}