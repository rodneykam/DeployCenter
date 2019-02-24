using DeployCenter.Models;
using System.Web.Mvc;

namespace DeployCenter.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            string userName = model.UserName;
            string userPassword = model.UserPassword;

            return RedirectToAction("Index", "DeployInput");
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

    }
}
