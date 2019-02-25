using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeployCenter.Models
{
    public class DeployRunModel
    {
        [Display(Name = "Revision")]
        public string Revision { get; set; }
        [Display(Name = "Environment")]
        public string Environment { get; set; }
        [Display(Name = "Selected Servers")]
        public string[] Servers { get; set; }
        [Display(Name = "Selected Deploy Options")]
        public bool[] DeployOptions { get; set; }
    }
}