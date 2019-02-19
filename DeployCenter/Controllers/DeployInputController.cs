using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeployCenter.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeployCenter.Controllers
{
    public class DeployInputController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public DeployInputController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var deployTargets = new DeployTargets(webRootPath);

            var model = new DeployInputModel();

            var envList = deployTargets.GetEnvironmentList();
            model.EnvironmentList = new List<SelectListItem>();
            foreach (var env in envList)
            {
                var item = new SelectListItem(env, env);
                model.EnvironmentList.Add(item);
            }

            var serverList = deployTargets.GetServerList("Stage");
            model.ServerList = new List<SelectListItem>();
            foreach (var server in serverList)
            {
                var item = new SelectListItem(server.Name, server.Name);
                model.ServerList.Add(item);
            }

            model.RevisionList = new List<SelectListItem>
            {
                new SelectListItem("19.1.5000.1", "1"),
                new SelectListItem("19.2.5100.1", "2"),
                new SelectListItem("19.3.5200.1", "3"),
                new SelectListItem("19.4.5300.1", "4"),
            };

            ViewData["Message"] = "This page displays deployment options.";
        
            return View(model);
        }
    }
}
