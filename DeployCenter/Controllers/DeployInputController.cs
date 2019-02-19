using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DeployCenter.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeployCenter.Controllers
{
    public class DeployInputController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public DeployInputController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // Get List of Reivisons from Folder
            string revisionPath = _configuration.GetValue<string>("FilePath:RevisionPath");
            var revisions = Directory.GetDirectories(revisionPath);

            // Get the DeployServers information from the Web Root Path
            string webRootPath = _hostingEnvironment.WebRootPath;
            var deployTargets = new DeployTargets(webRootPath);

            var model = new DeployInputModel();

            // Load the list of Environments
            var envList = deployTargets.GetEnvironmentList();
            model.EnvironmentList = new List<SelectListItem>();
            var isFirst = true;
            foreach (var env in envList)
            {
                var item = new SelectListItem(env, env);
                if (isFirst) { item.Selected = true;  isFirst = false; }
                else { item.Selected = false; }
                model.EnvironmentList.Add(item);
            }

            // Load the List of Servers
            var serverList = deployTargets.GetServerList(envList[0]);
            model.ServerList = new List<SelectListItem>();
            for (int i = 0; i < serverList.Count; i++)
            {
                var item = new SelectListItem(serverList[i].Name, i.ToString());
                model.ServerList.Add(item);
            }

            // Load the list of Revisions
            revisions = revisions.OrderByDescending(x => x).ToArray();
            model.RevisionList = new List<SelectListItem>();
            for (int i= 0; i < revisions.Length; i++)
            {
                var revs = revisions[i].Split("/"); 
                var path = revs[revs.Length - 1];
                var item = new SelectListItem(path, i.ToString());
                model.RevisionList.Add(item);
            };
        
            return View(model);
        }
    }
}
