﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.WebService
{
    internal class UserComputerInfo
    {
        internal static string UserToken { get; set; }
        
        internal static string GetComputerMac()
        {
            ManagementClass mc = null;
            ManagementObjectCollection moc = null;
            try
            {
                string mac = "";
                mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                }
                return mac;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (moc != null)
                {
                    moc.Dispose();
                }
                if (mc != null)
                {
                    mc.Dispose();
                }
            }

        }

        internal static string GetMachineName()
        {
            try
            {
                return System.Environment.MachineName;
            }
            catch
            {
                return "";
            }
        }

        internal static string GetUserName()
        {
            try
            {
                return System.Environment.UserName;
            }
            catch
            {
                return "";
            }
        }

        internal static string GetFreeHttpVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        internal static string GetRuleVersion()
        {
            return ConfigurationData.RuleVersion;
        }

        internal static string GetFreeHttpUser()
        {
            if(string.IsNullOrEmpty(UserToken))
            {
                return string.Format("user={0}&username={1}&machinename={2}", GetComputerMac(), GetUserName(), GetMachineName());
            }
            else
            {
                return string.Format("user={0}&username={1}&machinename={2}&usertoken={3}", GetComputerMac(), GetUserName(), GetMachineName(), UserToken);
            }       
        }

        internal static int GetDotNetRelease()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";
            using (Microsoft.Win32.RegistryKey ndpKey = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry32).OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    return (int)ndpKey.GetValue("Release");
                }
                return 0;
            }
        }



    }
}
