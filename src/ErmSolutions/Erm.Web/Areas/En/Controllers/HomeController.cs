using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erm.Web.Areas.En.Controllers
{
    [Area("En")]
    public class HomeController:BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
           await  Task.Delay(1);
            return View();
        }
    }
}
