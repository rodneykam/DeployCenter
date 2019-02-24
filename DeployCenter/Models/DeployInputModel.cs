using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

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
        public string Id { get; set; }
        public string Name { get; set; }
    }

public class DeployInputModel
    {
        [Required]
        [Display(Name="Environment")]
        public string EnvironmentId { get; set; }

        [Required]
        [Display(Name ="Revision")]
        public string Revision { get; set; }

        [Required]
        [Display(Name ="Servers")]
        public string[] Servers { get; set; }

        [Display(Name = "Deploy Options")]
        public bool[] SelectedDeployOptions { get; set; }

        public List<SelectListItem> RevisionList { get; set; }
        public List<SelectListItem> EnvironmentList { get; set; }
        public List<SelectListItem> ServerList { get; set; }

    }
}
