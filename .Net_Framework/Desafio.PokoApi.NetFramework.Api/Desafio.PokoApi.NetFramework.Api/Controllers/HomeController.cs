using System.Web.Mvc;

namespace Desafio.PokoApi.NetFramework.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}