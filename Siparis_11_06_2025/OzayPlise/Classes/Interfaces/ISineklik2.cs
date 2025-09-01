using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Interfaces
{
    internal interface ISineklik2
    {
        double RunMath(string settings_name, params double[] values);

        double GetFiyat(double en, double boy, short tur);

        List<double> Hesapla(double en, double boy, short tur);
    }
}
