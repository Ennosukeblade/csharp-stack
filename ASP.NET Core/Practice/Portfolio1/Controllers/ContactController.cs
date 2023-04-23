using Microsoft.AspNetCore.Mvc;
namespace Portfolio1.Controllers;     //be sure to use your own project's namespace!
public class ContactController : Controller   //remember inheritance??
{
    //for each route this controller is to handle:
    [HttpGet("contact")]       //type of request
    public string Projects()
    {
        return "This is my Contact!";
    }
}