using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise
{
    internal interface ISineklik
    {
        double RunMath(string settings_name, params double[] values);

        double GetFiyat(double en, double boy, short tur, string kalinlik);

        List<double> Hesapla(double en, double boy, short tur, string kalinlik);
    }
}
