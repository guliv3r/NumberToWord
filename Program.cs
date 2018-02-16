using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string aa = Console.ReadLine();
            int number = Convert.ToInt32(aa);

            string[] erteuli = { "nuli", "erit", "ori", "sami", "otxi", "xuti", "eqvsi", "shvidi", "rva", "cxra", "ati", "tertmeti", "tormeti", "cameti", "totxmeti", "txutmeti", "teqvsmeti", "chvidmeti", "tvrameti", "cxrameti", "oci" };
            string[] oceuli = { "ocda", "", "orm", "sam", "otxm", "oci" };
            string[] samaseuli = { "as", "", "or", "sam", "otx", "xut", "eqvs", "shvid", "rva", "cxra", "asi" };
            string[] ataseuli = { "atas", "atasi" };
            string[] milioni = { "milion", "milioni" };

            string nnn = numberToWord(number);

            string div10(int n)
            {
                return Convert.ToString(erteuli[n]);
            }

            string numberToWord(int n)
            {
                if (n > -1)
                    return div10000(Convert.ToInt32(n));
                return "0";
            }

            string div100(int n)
            {
                if (n <= 20)
                    return Convert.ToString(div10(n));
                if (n == 100)
                    return Convert.ToString(samaseuli[10]);
                if (n % 20 == 0)
                    return Convert.ToString(oceuli[(n / 20)] + oceuli[5]);
                return Convert.ToString(oceuli[(n / 20)] + oceuli[0] + div10(n - (n / 20) * 20));
            }

            string div1000(int n)
            {
                if (n <= symbols(2))
                    return div100(n);
                if (n % symbols(2) == 0 && n <= 9 * symbols(2))
                    return Convert.ToString(samaseuli[(n / symbols(2))] + " " + samaseuli[10]);
                if (n == symbols(3))
                    return Convert.ToString(ataseuli[1]);
                return Convert.ToString(samaseuli[(n / symbols(2))] + samaseuli[0] + " " + div100(n - (n / symbols(2)) * symbols(2)));
            }

            string div10000(int n)
            {
                if (n <= symbols(3))
                    return div1000(n);
                if (n % symbols(3) == 0 && n <= 9 * symbols(5))
                    return div1000((n / symbols(3))) + " " + ataseuli[1];
                if (n == symbols(6))
                    return Convert.ToString(milioni[1]);
                if ((n / symbols(3)) > 1)
                    return Convert.ToString(div1000((n / symbols(3))) + " " + ataseuli[0] + " " + div1000(n - (n / symbols(3)) * symbols(3)));
                else
                    return Convert.ToString(ataseuli[0] + " " + div1000(n - (n / symbols(3)) * symbols(3)));
            }

            int symbols(int s)
            {
                return Convert.ToInt32(Math.Pow(10, s));
            }

            Console.WriteLine(nnn);
            Console.ReadLine();
        }
    }
}
