using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Keygen
{
    public static class License
    {

        public static string GetKey(string key)
        {
            
            string c = AesEncryption.Decrypt(key);

            string licenseData = "LISANS_" + c;
            return AesEncryption.Encrypt(licenseData); // bu lisans anahtarını müşteriye verirsin

        }

    }
}
