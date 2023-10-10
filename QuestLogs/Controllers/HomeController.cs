using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuestLogs.Models;
using Microsoft.AspNetCore.Identity; //? Hashing Password
using Microsoft.EntityFrameworkCore;

namespace QuestLogs.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
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

    // GET : User Dashboard
    public IActionResult Dashboard()
    {
        if (HttpContext.Session.GetInt32("userId") != null)
        {
            int? userId = (int)HttpContext.Session.GetInt32("userId");
            User? user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            List<Quest> PostedQuests = _context.Quests.Where(q => q.UserId == userId).ToList();
            List<User> PostedQuestsTest = _context.Users.Include(u => u.MyQuests).Where(u => u.UserId == userId).ToList();
            System.Console.WriteLine($"*******Posted Quest 1: {PostedQuestsTest[0].MyQuests[1].Title}");
            System.Console.WriteLine($"Posted Quest 0: {PostedQuests[0].Title}");
            ViewBag.PostedQuests = PostedQuests;
            List<UserQuest> TakenQuests = _context.UserQuests.Include(a => a.Quest).Where(c => c.UserId == userId).ToList();
            System.Console.WriteLine($"Taken Quests: {TakenQuests}");
            ViewBag.TakenQuests = TakenQuests;
            //System.Console.WriteLine(ViewBag.TakenQuests[0].Quest.Title);
            return View(user);
        }
        return RedirectToAction("Index");
    }
    // Log Out
    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    // *********** Quest Controller ***********
    // GET : Add Quest
    [HttpGet("quests/new")]
    public IActionResult NewQuest()
    {
        if (HttpContext.Session.GetInt32("userId") != null)
        {
            return View();
        }
        return RedirectToAction("Index");

    }
    // POST : Add Quest
    [HttpPost("quests/create")]
    public IActionResult CreateQuest(Quest newQuest)
    {
        if (ModelState.IsValid)
        {
            newQuest.UserId = (int)HttpContext.Session.GetInt32("userId"); //Add userid to quest
            _context.Add(newQuest);
            _context.SaveChanges();
            return RedirectToAction(actionName: "Dashboard");
        }
        return View(viewName: "NewQuest");
    }

    // GET : All Quests
    public IActionResult Quests()
    {
        if (HttpContext.Session.GetInt32("userId") != null)
        {
            //List<Quest> AllQuests = _context.Quests.ToList();
            List<Quest> AllQuests = _context.Quests.Include(u => u.joindUsers).ToList();
            //List<UserQuest> AllQuests1 = _context.UserQuests.Include(q => q.Quest).ThenInclude(u => u.Creator).ToList();
            //System.Console.WriteLine($"***hhh****All Quests 0: {AllQuests1[0].User.User} {AllQuests1[0].Quest.Title}");
            return View(AllQuests);
        }
        return RedirectToAction("Index");
    }

    // *********** Take Quests Controller ***********
    [HttpPost("/quests/take")]
    public IActionResult TakeQuest(UserQuest newTakenQuest)
    {
        System.Console.WriteLine($"QuestId = {newTakenQuest.QuestId} ---- completed = {newTakenQuest.completed} CreatorId = {newTakenQuest.UserId}");
        // newOrder.UserId = (int)HttpContext.Session.GetInt32("userId");
        bool taken = false;
        //int? userId = HttpContext.Session.GetInt32("userId");
        List<UserQuest> allReadyTakenQuests = _context.UserQuests.Where(t => t.UserId == newTakenQuest.UserId).ToList();

        foreach (UserQuest item in allReadyTakenQuests)
        {
            System.Console.WriteLine(item.UserId);
            //System.Console.WriteLine(item.QuestId);
            if (item.UserId == newTakenQuest.UserId && item.QuestId == newTakenQuest.QuestId)
            {
                taken = true;
                System.Console.WriteLine(taken);
            }
        }
        if (!taken)
        {
            _context.Add(newTakenQuest);
            _context.SaveChanges();
        }

        // Craft? craftToUpdate = _context.Crafts.FirstOrDefault(c=>c.CraftId == newOrder.CraftId);
        // craftToUpdate.Quantity -= newOrder.QuantityOrdered;
        // craftToUpdate.UpdatedAt = DateTime.Now;

        return RedirectToAction("Quests");
    }

    // public IActionResult Dashboard()
    // {
    //     if (HttpContext.Session.GetInt32("userId") != null)
    //     {
    //         int? userId = (int)HttpContext.Session.GetInt32("userId");
    //         ViewBag.UserInfos = _context.UserQuests.Include(navigationPropertyPath: q => q.Quest).ThenInclude(o => o.Creator).Where(t => t.Quest.UserId == userId).ToList();
    //         System.Console.WriteLine("--------------UserInfos-------------");
    //         System.Console.WriteLine(ViewBag.UserInfos[0].Quest.Title);
    //         return View();
    //     }
    //     return RedirectToAction("Index");
    // }
    // POST : Leave Taken Quest
    [HttpGet("quests/{UserQuestId}/leave")]
    public IActionResult LeaveQuest(int UserQuestId)
    {
        UserQuest? QuestToLeave = _context.UserQuests.SingleOrDefault(q => q.UserQuestId == UserQuestId);
        _context.Remove(QuestToLeave);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    // Inside HomeController
    [HttpGet("update/{UserQuestId}/completed")]
    public IActionResult UpdateQuestToComplete(int UserQuestId)
    {
        // We must first Query for a single User from our Context object to track changes.
        UserQuest? UserQuestToUpdate = _context.UserQuests.FirstOrDefault(q => q.UserQuestId == UserQuestId);
        // Then we may modify properties of this tracked model object
        UserQuestToUpdate.completed = true;
        UserQuestToUpdate.UpdatedAt = DateTime.Now;

        // Finally, .SaveChanges() will update the DB with these new values
        _context.SaveChanges();

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
