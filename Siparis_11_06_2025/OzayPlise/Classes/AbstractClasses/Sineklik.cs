using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace OzayPlise
{
    abstract class Sineklik
    {  
        public double RunMath(string settings_name, params double[] values)
        {
            string mathExpression = DatabaseHelper.GetSetting(settings_name);
            if (mathExpression.Contains("X"))
            {
                mathExpression = mathExpression.Replace("X", values[0].ToString());
            }
            if (mathExpression.Contains("Y"))
            {
                mathExpression = mathExpression.Replace("Y", values[1].ToString());
            }
            if (mathExpression.Contains("Z"))
            {
                mathExpression = mathExpression.Replace("Z", values[2].ToString());
            }
            if (mathExpression.Contains("W"))
            {
                mathExpression = mathExpression.Replace("W", values[3].ToString());
            }

           mathExpression = mathExpression.Replace(",", ".");
            

            return Convert.ToDouble(new Expression(mathExpression).Evaluate());
        }

        public double GetZ(short type, int a, int b, int c)
        {
            return DatabaseHelper.GetMalzeme((type == 1) ? a : (type == 2) ? b : c).Price;
        }

    }
}
