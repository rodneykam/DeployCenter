using System;
using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeployCenter.Models
{
    public static class DeployOption
    {
        public enum Option
        {
            NoOption,
            [Description("Copy and UnZip Artifacts")]
            Unzip,
            [Description("Disable Load Balancer")]
            DisableLB,
            [Description("Deploy Core Application and Services")]
            Core,
            [Description("Deploy HydroPlatform Services")]
            Hydro,
            [Description("Deploy verification Tests")]
            Verify,
            [Description("Update Switches")]
            Switches,
            [Description("Deploy Direct Messaging Service")]
            DirectMsg,
            [Description("Enable Load Balancer")]
            EnableLB,
            MAX_VALUE
        }

        public static string GetDescription(this Option value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

    }

    public class DeployInputModel
    {
        public string EnvironmentId { get; set; }
        public string Revision { get; set; }
        public string[] Servers { get; set; }
        public bool[] DeployOptions { get; set; }

        public MultiSelectList ServerList { get; set; }
        public SelectList EnvironmentList { get; set; }

        public DeployInputModel()
        {
            DeployOptions = new bool[(int)DeployOption.Option.MAX_VALUE];
        }

        private void ClearOptions()
        {
            for(var i = 0; i < DeployOptions.Length; i++)
            {
                DeployOptions[i] = false;
            }
        }

    }
}
