using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        string message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris sit amet pellentesque eros. Donec congue cursus ex, in convallis ante.";
        return View("Index", message);
    }

    [HttpGet("/numbers")]
    public IActionResult Numbers()
    {
        int[] Numbers = { 1, 2, 3, 10, 43, 5 };
        return View(Numbers);
    }

    [HttpGet("/users")]
    public IActionResult Users()
    {
        List<User> Users = new List<User>(){
            new User("Moose","Phillips"),
            new User("Sarah"),
            new User("Jerry"),
            new User("Rene","Ricky"),
            new User("Barbarah")
        };
        return View(Users);
    }
    [HttpGet("/user")]
    public IActionResult User()
    {
        User newUser = new User("Moose", "Phillips");
        return View(newUser);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
