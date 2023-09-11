using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HealthzController : Controller
    {
        public IActionResult Index()
        {
            return Json(new { Status = "OK" });
        }
    }
}
