using Microsoft.AspNetCore.Mvc;

namespace DemoGCS.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
