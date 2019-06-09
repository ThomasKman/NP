using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    class Werkzeuge
    {

        public static string Alphanumeric = "ABCDEFGTHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789öäüÖÄÜ";

        public static double notenSpiegelAusrechnen(double prozentDerPunkte)
        {
            if (prozentDerPunkte > 0.99)
            {
                return 1.0;
            }
            if (prozentDerPunkte > 0.97)
            {
                return 1.1;
            }
            if (prozentDerPunkte > 0.95)
            {
                return 1.2;
            }
            if (prozentDerPunkte > 0.93)
            {
                return 1.3;
            }
            if (prozentDerPunkte > 0.91)
            {
                return 1.4;
            }
            if (prozentDerPunkte > 0.90)
            {
                return 1.5;
            }
            if (prozentDerPunkte > 0.89)
            {
                return 1.6;
            }
            if (prozentDerPunkte > 0.88)
            {
                return 1.7;
            }
            if (prozentDerPunkte > 0.87)
            {
                return 1.8;
            }
            if (prozentDerPunkte > 0.86)
            {
                return 1.9;
            }
            if (prozentDerPunkte > 0.84)
            {
                return 2.0;
            }
            if (prozentDerPunkte > 0.83)
            {
                return 2.1;
            }
            if (prozentDerPunkte > 0.82)
            {
                return 2.2;
            }
            if (prozentDerPunkte > 0.81)
            {
                return 2.3;
            }
            if (prozentDerPunkte > 0.80)
            {
                return 2.4;
            }
            if (prozentDerPunkte > 0.79)
            {
                return 2.5;
            }
            if (prozentDerPunkte > 0.78)
            {
                return 2.6;
            }
            if (prozentDerPunkte > 0.76)
            {
                return 2.7;
            }
            if (prozentDerPunkte > 0.75)
            {
                return 2.8;
            }
            if (prozentDerPunkte > 0.73)
            {
                return 2.9;
            }
            if (prozentDerPunkte > 0.72)
            {
                return 3.0;
            }
            if (prozentDerPunkte > 0.70)
            {
                return 3.1;
            }
            if (prozentDerPunkte > 0.69)
            {
                return 3.2;
            }
            if (prozentDerPunkte > 0.67)
            {
                return 3.3;
            }
            if (prozentDerPunkte > 0.65)
            {
                return 3.4;
            }
            if (prozentDerPunkte > 0.64)
            {
                return 3.5;
            }
            if (prozentDerPunkte > 0.63)
            {
                return 3.6;
            }
            if (prozentDerPunkte > 0.61)
            {
                return 3.7;
            }
            if (prozentDerPunkte > 0.60)
            {
                return 3.8;
            }
            if (prozentDerPunkte > 0.58)
            {
                return 3.9;
            }
            if (prozentDerPunkte > 0.56)
            {
                return 4.0;
            }
            if (prozentDerPunkte > 0.54)
            {
                return 4.1;
            }
            if (prozentDerPunkte > 0.53)
            {
                return 4.2;
            }
            if (prozentDerPunkte > 0.51)
            {
                return 4.3;
            }
            if (prozentDerPunkte > 0.49)
            {
                return 4.4;
            }
            if (prozentDerPunkte > 0.48)
            {
                return 4.5;
            }
            if (prozentDerPunkte > 0.46)
            {
                return 4.6;
            }
            if (prozentDerPunkte > 0.44)
            {
                return 4.7;
            }
            if (prozentDerPunkte > 0.42)
            {
                return 4.8;
            }
            if (prozentDerPunkte > 0.40)
            {
                return 4.9;
            }
            if (prozentDerPunkte > 0.37)
            {
                return 5.0;
            }
            if (prozentDerPunkte > 0.35)
            {
                return 5.1;
            }
            if (prozentDerPunkte > 0.33)
            {
                return 5.2;
            }
            if (prozentDerPunkte > 0.31)
            {
                return 5.3;
            }
            if (prozentDerPunkte > 0.29)
            {
                return 5.4;
            }
            if (prozentDerPunkte > 0.28)
            {
                return 5.5;
            }
            if (prozentDerPunkte > 0.22)
            {
                return 5.6;
            }
            if (prozentDerPunkte > 0.16)
            {
                return 5.7;
            }
            if (prozentDerPunkte > 0.11)
            {
                return 5.8;
            }
            if (prozentDerPunkte > 0.05)
            {
                return 5.9;
            }
            if (prozentDerPunkte <= 0.05)
            {
                return 6.0;
            }
            else { return -1; }
        }



    }
}
