using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Other
{
    public class Ayarlar
    {
        public Ayarlar() { }

        public Ayarlar(int id,string settings_name, string title, string value)
        {
            Id = id;
            SettingsName = settings_name;
            Title = title;
            Value = value;
        }

        public int id { get; set; }
        public string Settings_name { get; set; }
        public string title { get; set; }
        public string value { get; set; }
    }
}
