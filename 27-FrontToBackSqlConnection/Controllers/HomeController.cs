using System.Diagnostics;
using FrontToBackSqlConnection.Data;
using FrontToBackSqlConnection.Models;
using FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBackSqlConnection.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    
    
  
    
    public IActionResult Index()
    {
        
        
        List<Slider> sliders = _context.Sliders
            .OrderBy(s=>s.Order)
            .Where(s => !s.isDeleted)
            .Take(2)
            .ToList();
        
        HomeVM homeVM = new()
        {
            Sliders = sliders
        };

        return View(homeVM);
    }
    
}