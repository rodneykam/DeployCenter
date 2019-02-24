using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using DeployCenter.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeployCenter.Controllers
{
    public class DeployInputController : Controller
    {
        public ActionResult Index()
        {
            // Get List of Reivisons from Folder
            string revisionPath = ConfigurationManager.AppSettings["RevisionPath"];
            string[] revisions = Directory.GetDirectories(revisionPath);

            // Get the DeployServers information from the Web Root Path

            string webRootPath = Server.MapPath("~");
            var deployTargets = new DeployTargets(webRootPath);

            var model = new DeployInputModel();

            // Load the list of Environments
            var envList = deployTargets.GetEnvironmentList();
            model.EnvironmentList = new List<SelectListItem>();
            var isFirst = true;
            foreach (var env in envList)
            {
                var item = new SelectListItem { Text = env, Value = env };
                if (isFirst) { item.Selected = true; isFirst = false; }
                else { item.Selected = false; }
                model.EnvironmentList.Add(item);
            }

            // Load the List of Servers
            var serverList = deployTargets.GetServerList(envList[0]);
            model.ServerList = new List<SelectListItem>();
            for (int i = 0; i < serverList.Count; i++)
            {
                var item = new SelectListItem { Text = serverList[i].Name, Value = serverList[i].Name };
                model.ServerList.Add(item);
            }

            // Load the list of Revisions
            revisions = revisions.OrderByDescending(x => x).ToArray();
            model.RevisionList = new List<SelectListItem>();
            for (int i = 0; i < revisions.Length; i++)
            {
                var revs = revisions[i].Split('\\');
                var rev = revs[revs.Length - 1];
                var item = new SelectListItem { Text = rev, Value = rev };
                model.RevisionList.Add(item);
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(DeployInputModel model)
        {

            return View();
        }

        public ActionResult FillServerList(string environmentKey)
        {
            // Load the List of Servers
            var webRootPath = Server.MapPath("~");
            var deployTargets = new DeployTargets(webRootPath);

            var serverList = deployTargets.GetServerList(environmentKey);

            var servers = new List<ServerInfo>();
            foreach (var server in serverList)
            {
                servers.Add(new ServerInfo() { Name = server.Name, Id = server.Id });
            }

            IEnumerable<ServerInfo> serverMatches = servers;
            return Json(serverMatches, JsonRequestBehavior.AllowGet);

        }

    }
}
