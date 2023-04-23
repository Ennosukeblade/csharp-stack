using Microsoft.AspNetCore.Mvc;
namespace Portfolio1.Controllers;     //be sure to use your own project's namespace!
public class ProjectsController : Controller   //remember inheritance??
{
    //for each route this controller is to handle:
    [HttpGet]       //type of request
    [Route("projects")]
    public string Projects()
    {
        return "These are my projects!";
    }
}