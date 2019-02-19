using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DeployCenter
{
    public class DeployTargets
    {
        private Dictionary<string, List<DeployServer>> deployTarget;

        public class DeployServer
        {
            public string Name { get; set; }
        }

        public class DeployTarget
        {
            public string Environment { get; set; }
            public List<DeployServer> Servers { get; set; }
        }

        public class DeployTargetList
        {
            public List<DeployTarget> DeployTargets { get; set; }
        }

        public DeployTargets(string rootPath)
        {
            var jsonPath = Path.Combine(rootPath, "DeployTargets.json");
            string text = File.ReadAllText(jsonPath);

            var dt = JsonConvert.DeserializeObject<DeployTargetList>(text);

            deployTarget = new Dictionary<string, List<DeployServer>>();
            for (int i = 0; i < dt.DeployTargets.Count; i++)
            {
                deployTarget.Add(dt.DeployTargets[i].Environment, dt.DeployTargets[i].Servers);
            }
            
        }

        public IList<DeployServer> GetServerList(string env)
        {
            return deployTarget[env];
        }

        public IList<string> GetEnvironmentList()
        {
            var keys = deployTarget.Keys;
            var keyList = new List<string>();
            foreach(var key in keys)
            {
                keyList.Add(key);
            }
            return keyList;
        }
    }
}
