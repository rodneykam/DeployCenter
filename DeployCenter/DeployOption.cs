using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DeployCenter
{ 
    public class DeployOption
    {
        public enum Type
        {
            [Description("Copy and Unzip Artifacts")]
            CopyUnzip,
            [Description("Disable Servers in Load Balancer")]
            DisableLB,
            [Description("Deploy Core Application and Services")]
            DeployCore,
            [Description("Deploy HydroPlatform Services")]
            DeploHydro,
            [Description("Deploy Verification Tests")]
            DeployVerification,
            [Description("Enable Servers in Load Balancer")]
            EnableLB,
            [Description("Update Switches")]
            UpdateSwitches,
            [Description("Deploy Direct Messaging")]
            DeployDirMsg,
            MAX_OPTION
        }

        public static string GetTypeDescription(Type value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

    }

}