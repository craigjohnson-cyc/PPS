using Microsoft.AspNetCore.Mvc;

namespace PPS_MVC.Controllers
{
    public class ProgramLibraryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
