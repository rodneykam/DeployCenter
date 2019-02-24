using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeployCenter.Models
{
    public class DeployRunModel
    {
        public string Revision { get; set; }
        public string Environment { get; set; }
        public string[] Servers { get; set; }
    }
}