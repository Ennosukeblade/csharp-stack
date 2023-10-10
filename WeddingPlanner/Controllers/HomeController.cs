using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity; //? Hashing Password
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

    // POST : Register
    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if (ModelState.IsValid)
        {
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "Email already taken!!");
                return View("Index");
            }
            // Hash Password
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            System.Console.WriteLine(newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            // Add User ID in Session
            HttpContext.Session.SetInt32("userId", newUser.UserId);
            return RedirectToAction("Dashboard");
        }
        return View("Index");
    }

    // POST : Login
    [HttpPost("/users/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid)
        {
            // Login
            // search for a user that match the login email
            var UserFromDB = _context.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);
            if (UserFromDB == null)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return View("Index");
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            //  verify Password 
            var result = hasher.VerifyHashedPassword(loginUser, hashedPassword: UserFromDB.Password, loginUser.LoginPassword);
            if (result == 0)
            {
                ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                return View("Index");
            }
            HttpContext.Session.SetInt32("userId", UserFromDB.UserId);
            return RedirectToAction("Dashboard");
        }
        return View("Index");
    }

    // Log Out
    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
    // GET All Weddings
    [HttpGet("weddings")]
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetInt32("userId") != null)
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            User? user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            ViewBag.CurrentUser = user;
            List<Wedding> AllWeddings = _context.Weddings.Include(u => u.Guests).ToList();
            return View(AllWeddings);
        }
        return RedirectToAction("Index");
    }

    // GET One Wedding by id
    [HttpGet("weddings/{WeddingId}")]
    public IActionResult OneWedding(int WeddingId)
    {
        if (HttpContext.Session.GetInt32("userId") != null)
        {
            Wedding? OneWedding = _context.Weddings.Include(u => u.Guests).ThenInclude(u => u.User).FirstOrDefault(c => c.WeddingId == WeddingId);
            //System.Console.WriteLine($"Guest first Name {OneWedding.Guests[0].User.FirstName}");
            //Guest? OneWedding = _context.Guests.Include(w=>w.Wedding).ThenInclude(g=>g.UserId).Where(t=>t.WeddingId == WeddingId);
            return View(OneWedding);
        }
        return RedirectToAction("Index");
    }

    // GET : Add Wedding
    [HttpGet("weddings/new")]
    public IActionResult NewWedding()
    {
        if (HttpContext.Session.GetInt32("userId") != null)
        {
            return View();
        }
        return RedirectToAction("Index");

    }
    // POST : Add wedding
    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (ModelState.IsValid)
        {
            newWedding.UserId = (int)HttpContext.Session.GetInt32("userId"); //Add userid to quest
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction(actionName: "Dashboard");
        }
        return View(viewName: "NewWedding");
    }

    // Get : Delete one Wedding
    [HttpGet("weddings/{WeddingId}/destroy")]
    public IActionResult DeleteWedding(int WeddingId)
    {
        Wedding? WeddingToDestroy = _context.Weddings.SingleOrDefault(w => w.WeddingId == WeddingId);
        _context.Remove(WeddingToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    // *********** Guest Controller ***********
    [HttpPost("/weddings/attend")]
    public IActionResult BeGuest(Guest newGuest)
    {
        //System.Console.WriteLine($"QuestId = {newTakenQuest.QuestId} ---- completed = {newTakenQuest.completed} CreatorId = {newTakenQuest.UserId}");
        // newOrder.UserId = (int)HttpContext.Session.GetInt32("userId");
        bool isGuest = false;
        //int? userId = HttpContext.Session.GetInt32("userId");
        List<Guest> allReadyGuests = _context.Guests.Where(g => g.UserId == newGuest.UserId).ToList();

        foreach (Guest item in allReadyGuests)
        {
            System.Console.WriteLine(item.UserId);
            //System.Console.WriteLine(item.QuestId);
            if (item.UserId == newGuest.UserId && item.WeddingId == newGuest.WeddingId)
            {
                isGuest = true;
                System.Console.WriteLine(isGuest);
            }
        }
        if (!isGuest)
        {
            _context.Add(newGuest);
            _context.SaveChanges();
        }

        // Craft? craftToUpdate = _context.Crafts.FirstOrDefault(c=>c.CraftId == newOrder.CraftId);
        // craftToUpdate.Quantity -= newOrder.QuantityOrdered;
        // craftToUpdate.UpdatedAt = DateTime.Now;

        return RedirectToAction("Dashboard");
    }
    public IActionResult Index()
    {
        return View();
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
