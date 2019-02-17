using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeployCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeployCenter.Controllers
{
    public class DeployInputController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new DeployInputModel();

            model.EnvironmentList = new List<SelectListItem> 
                {
                    new SelectListItem { Selected = true, Text = "Stage", Value = "1"},
                    new SelectListItem { Selected = false, Text = "Integration", Value = "2"}
                };

            model.ServerList = new List<SelectListItem>
                {
                    new SelectListItem { Selected = true, Text = "SJSTWEB02", Value = "2"},
                    new SelectListItem { Selected = false, Text = "SJSTWEB03", Value = "3"},
                    new SelectListItem { Selected = false, Text = "SJSTWEB04", Value = "4"},
                    new SelectListItem { Selected = false, Text = "SJSTWEB05", Value = "5"}
                };

            ViewData["Message"] = "This page displays deployment options.";
            return View(model);
        }
    }
}
