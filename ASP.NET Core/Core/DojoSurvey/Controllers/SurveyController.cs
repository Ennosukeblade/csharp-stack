using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers;

public class SurveyController : Controller
{
    [HttpGet] // Type of the request
    [Route("")] // associated route (/)
    public ViewResult Form() // ViewResult : Type of the return will be a View (cshtml file)
    {
        return View();
    }
    // [HttpGet("result")] // Type of the request
    // public ViewResult Display() // ViewResult : Type of the return will be a View (cshtml file)
    // {
    //     return View();
    // }
    [HttpPost("process")]
    public IActionResult Process(string YourName, string DojoLocation, string FavLanguage, string Comment)
    {
        Console.WriteLine($"YourName  : {YourName}\n DojoLocation : {DojoLocation}");
        ViewBag.YourName = YourName;
        ViewBag.DojoLocation = DojoLocation;
        ViewBag.FavLanguage = FavLanguage;
        ViewBag.Comment = Comment;
        return View("Display");
    }
}
