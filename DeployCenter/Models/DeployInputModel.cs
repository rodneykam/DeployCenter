using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeployCenter.Models
{
    public class EnvironmentInfo
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public List<ServerInfo> Servers { get; set; }
    }

    public class ServerInfo
    {
        public string Name { get; set; }
    }

    public class DeployInputModel
    {
        [Display(Name="Environment")]
        public string EnvironmentId { get; set; }
        [Display(Name ="Revision")]
        public string Revision { get; set; }
        [Display(Name ="Servers")]
        public string[] Servers { get; set; }
        [Display(Name ="Copy and Unzip Artifacts")]
        public bool Do_CopyUnzip{ get; set; }
        [Display(Name = "Disable Servers in Load Balancer")]
        public bool Do_DisableLB { get; set; }
        [Display(Name = "Deploy Core Application and Services")]
        public bool Do_Core { get; set; }
        [Display(Name = "Deploy HydroPlatform Servicess]")]
        public bool Do_Hydro { get; set; }
        [Display(Name = "Deploy Verification Tests")]
        public bool Do_Verification { get; set; }
        [Display(Name = "Enable Services in Load Balancer")]
        public bool Do_EnableLB { get; set; }
        [Display(Name = "Update Switches")]
        public bool Do_Switches { get; set; }
        [Display(Name = "Ueploy Direct Messaging")]
        public bool Do_DirMsg { get; set; }

        public List<SelectListItem> RevisionList { get; set; }
        public List<SelectListItem> EnvironmentList { get; set; }
        public List<SelectListItem> ServerList { get; set; }

    }
}
