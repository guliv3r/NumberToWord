using System;

namespace Gulivera.NumberToWord
{
    public class Converter
    {
        readonly static string[] erteuli = { "ნული", "ერთი", "ორი", "სამი", "ოთხი", "ხუთი", "ექვსი", "შვიდი", "რვა", "ცხრა", "ათი", "თერთმეტი", "თორმეტი", "ცამეტი", "თოთხმეტი", "თხუთმეტი", "თექვსმეტი", "ჩვიდმეტი", "თვრამეტი", "ცხრამეტი", "ოცი" };
        readonly static string[] oceuli = { "ოცდა", "", "ორმ", "სამ", "ოთხმ", "ოცი" };
        readonly static string[] samaseuli = { "ას", "", "ორ", "სამ", "ოთხ", "ხუთ", "ექვს", "შვიდ", "რვა", "ცხრა", "ასი" };
        readonly static string[] ataseuli = { "ათას", "ათასი" };
        readonly static string[] milioni = { "მილიონ", "მილიონი" };

        public static string Execute(decimal number)
        {
            return NumberToWord(number);
        }

        private static string NumberToWord(decimal n)
        {
            if (n > -1)
                return Div10000(Convert.ToInt32(n));
            return "0";
        }

        private static string Div10(int n)
        {
            return Convert.ToString(erteuli[n]);
        }

        private static string Div100(int n)
        {
            if (n <= 20)
                return Convert.ToString(Div10(n));
            if (n == 100)
                return Convert.ToString(samaseuli[10]);
            if (n % 20 == 0)
                return Convert.ToString(oceuli[(n / 20)] + oceuli[5]);
            return Convert.ToString(oceuli[(n / 20)] + oceuli[0] + Div10(n - (n / 20) * 20));
        }

        private static string Div1000(int n)
        {
            if (n <= Symbols(2))
                return Div100(n);
            if (n % Symbols(2) == 0 && n <= 9 * Symbols(2))
                return Convert.ToString(samaseuli[(n / Symbols(2))] + " " + samaseuli[10]);
            if (n == Symbols(3))
                return Convert.ToString(ataseuli[1]);
            return Convert.ToString(samaseuli[(n / Symbols(2))] + samaseuli[0] + " " + Div100(n - (n / Symbols(2)) * Symbols(2)));
        }

        private static string Div10000(int n)
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

        private static int Symbols(int s)
        {
            return Convert.ToInt32(Math.Pow(10, s));
        }
    }
}