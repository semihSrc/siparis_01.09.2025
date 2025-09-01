using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace OzayPlise.Classes.Other
{
    internal class Lisans
    {
        public string GetKey()
        {
            return AesEncryption.Encrypt(GetMacAddress());
        }

        public bool ControlKey(string key)
        {
            string decryptedLicense = AesEncryption.Decrypt(key);

            if (decryptedLicense.Contains(GetMacAddress()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string GetMacAddress()
        {
            string macAddress = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = true");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                macAddress = queryObj["MacAddress"]?.ToString();
                if (!string.IsNullOrEmpty(macAddress))
                {
                    break;
                }
            }

            return macAddress ?? "MAC Adresi Bulunamadı";
        }

    
    }
}
