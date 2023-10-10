using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;

namespace ChefsDishes.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost(template: "chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        System.Console.WriteLine(newChef.Birth);
        if (ModelState.IsValid)
        {
            //add
            _context.Add(newChef);
            //save
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
