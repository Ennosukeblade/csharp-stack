using Microsoft.AspNetCore.Mvc;
namespace RazorFun.Controllers;
public class FoodsController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Foods()
    {

        return View("Index");
    }

}