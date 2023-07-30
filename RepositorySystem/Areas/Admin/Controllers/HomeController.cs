using Microsoft.AspNetCore.Mvc;
using RepositorySystemDotNetCore.Filters;

namespace RepositorySystemDotNetCore.Areas.Admin.Controllers
{
    [CustomAttribute]
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
