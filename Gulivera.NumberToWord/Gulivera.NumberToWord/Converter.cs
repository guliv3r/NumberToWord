using System;
using System.Globalization;

namespace Gulivera.NumberToWord
{
    public class Converter
    {
        readonly static string[] erteuli = { "ნული", "ერთი", "ორი", "სამი", "ოთხი", "ხუთი", "ექვსი", "შვიდი", "რვა", "ცხრა", "ათი", "თერთმეტი", "თორმეტი", "ცამეტი", "თოთხმეტი", "თხუთმეტი", "თექვსმეტი", "ჩვიდმეტი", "თვრამეტი", "ცხრამეტი", "ოცი" };
        readonly static string[] oceuli = { "ოცდა", "", "ორმ", "სამ", "ოთხმ", "ოცი" };
        readonly static string[] samaseuli = { "ას", "", "ორ", "სამ", "ოთხ", "ხუთ", "ექვს", "შვიდ", "რვა", "ცხრა", "ასი" };
        readonly static string[] ataseuli = { "ათას", "ათასი" };
        readonly static string[] milioni = { "მილიონ", "მილიონი" };
        readonly static string[] miliard = { "მილიარდ", "მილიარდი" };

        public static string Execute(decimal number, OptionType opt, bool printZero = true)
        {
            string res = string.Empty;

            if (number < 0)
            {
                res = "მინუს ";
                number *= -1;
            }

            if (number != (int)number || printZero)
            {
                var arr = number.ToString("G", CultureInfo.InvariantCulture).Split('.');
                res += $"{NumberToWord(Convert.ToInt32(arr[0]))} {GetCcy(opt, false)} და ";
                res += $"{NumberToWord(Convert.ToInt32(arr[1]))} {GetCcy(opt, true)}";
            }
            else  res += $"{NumberToWord(Convert.ToInt32(number))} {GetCcy(opt, false, opt == OptionType.Percent ? true : false)}";

            return res;
        }

        private static string NumberToWord(int n) => Div100000(n);

        #region Divs
        private static string Div10(Int64 n)
        {
            return Convert.ToString(erteuli[n]);
        }

        private static string Div100(Int64 n)
        {
            if (n <= 20)
                return Convert.ToString(Div10(n));
            if (n == 100)
                return Convert.ToString(samaseuli[10]);
            if (n % 20 == 0)
                return Convert.ToString(oceuli[(n / 20)] + oceuli[5]);
            return Convert.ToString(oceuli[(n / 20)] + oceuli[0] + Div10(n - (n / 20) * 20));
        }

        private static string Div1000(Int64 n)
        {
            if (n <= Symbols(2))
                return Div100(n);
            if (n % Symbols(2) == 0 && n <= 9 * Symbols(2))
                return Convert.ToString(samaseuli[(n / Symbols(2))] + " " + samaseuli[10]);
            if (n == Symbols(3))
                return Convert.ToString(ataseuli[1]);
            return Convert.ToString(samaseuli[(n / Symbols(2))] + samaseuli[0] + " " + Div100(n - (n / Symbols(2)) * Symbols(2)));
        }

        private static string Div10000(Int64 n)
        {
            if (n <= Symbols(3))
                return Div1000(n);
            if (n % Symbols(3) == 0 && n <= 9 * Symbols(5))
                return Div1000((n / Symbols(3))) + " " + ataseuli[1];
            if (n == Symbols(6))
                return Convert.ToString(milioni[1]);
            if ((n / Symbols(3)) > 1)
                return Convert.ToString(Div1000((n / Symbols(3))) + " " + ataseuli[0] + " " + Div1000(n - (n / Symbols(3)) * Symbols(3)));
            else
                return Convert.ToString(ataseuli[0] + " " + Div1000(n - (n / Symbols(3)) * Symbols(3)));
        }

        private static string Div100000(Int64 n)
        {
            if (n <= Symbols(6))
                return Div10000(n);
            if (n % Symbols(3) == 0 && n <= 9 * Symbols(5))
                return Div10000((n / Symbols(3))) + " " + ataseuli[1];
            if (n == Symbols(6))
                return Convert.ToString(milioni[1]);
            if ((n / Symbols(3)) > 1)
                return Convert.ToString(Div10000((n / Symbols(6))) + " " + milioni[0] + " " + Div10000(n - (n / Symbols(6)) * Symbols(6)));
            else
                return Convert.ToString(milioni[0] + " " + Div10000(n - (n / Symbols(3)) * Symbols(3)));
        }
        #endregion

        private static Int64 Symbols(Int64 s)
        {
            return Convert.ToInt64(Math.Pow(10, s));
        }

        private static string GetCcy(OptionType opt, bool isCoin, bool isInteger = false)
        {
            switch (opt)
            {
                case OptionType.GEL:
                    if (isCoin) return "თეთრი";
                    return "ლარი";
                case OptionType.USD:
                    if (isCoin) return "ცენტი";
                    return "დოლარი";
                case OptionType.EUR:
                    if (isCoin) return "ცენტი";
                    return "ევრო";
                case OptionType.GBP:
                    if (isCoin) return "ცენტი";
                    return "გირვანქა";
                case OptionType.Percent:
                    if(isInteger || isCoin)  return "პროცენტი";
                    return "მთელი";
                default:
                    return null;
            }
        }

        public enum OptionType
        {
            GEL,
            USD,
            EUR,
            GBP,
            Percent
        }
    }
}