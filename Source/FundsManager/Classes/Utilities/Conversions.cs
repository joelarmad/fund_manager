using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundsManager.Classes.Utilities
{
    public static class Conversions
    {
        public static string toRomanNumeral(int aNumber)
        {
            if ((aNumber < 0) || (aNumber > 3999)) throw new ArgumentOutOfRangeException("Number value must be between 1 and 3999 in order to be converted to roman numeral.");

            if (aNumber < 1) return string.Empty;
            if (aNumber >= 1000) return "M" + toRomanNumeral(aNumber - 1000);
            if (aNumber >= 900) return "CM" + toRomanNumeral(aNumber - 900);
            if (aNumber >= 500) return "D" + toRomanNumeral(aNumber - 500);
            if (aNumber >= 400) return "CD" + toRomanNumeral(aNumber - 400);
            if (aNumber >= 100) return "C" + toRomanNumeral(aNumber - 100);
            if (aNumber >= 90) return "XC" + toRomanNumeral(aNumber - 90);
            if (aNumber >= 50) return "L" + toRomanNumeral(aNumber - 50);
            if (aNumber >= 40) return "XL" + toRomanNumeral(aNumber - 40);
            if (aNumber >= 10) return "X" + toRomanNumeral(aNumber - 10);
            if (aNumber >= 9) return "IX" + toRomanNumeral(aNumber - 9);
            if (aNumber >= 5) return "V" + toRomanNumeral(aNumber - 5);
            if (aNumber >= 4) return "IV" + toRomanNumeral(aNumber - 4);
            if (aNumber >= 1) return "I" + toRomanNumeral(aNumber - 1);

            throw new ArgumentOutOfRangeException("Out of range error converting number into roman numeral.");
        }
    }
}
