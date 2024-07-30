using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FisioTerapias.Controllers
{
    public class AutenticacionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
