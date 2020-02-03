using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delivery
{
    abstract class Tools
    {
        public static Random rnd;

        static Tools()
        {
            rnd = new Random((int)(DateTime.Now.Ticks));
        }

        public static int intRand(int mn, int mx) // [mn, mx - 1)
        {
            return rnd.Next(mn, mx);
        }

        public static double doubleRand(double mn, double mx)
        {
            return mn + (mx - mn) * rnd.NextDouble();
        }

        public static void resize(ref List<int> a, int n)
        {
            while (a.Count < n)
                a.Add(0);
        }

        public static void resize(ref List<bool> a, int n)
        {
            while (a.Count < n)
                a.Add(false);
        }

        public static void resize(ref List<Individual> a, int n)
        {
            while (a.Count < n)
                a.Add(new Individual());
        }

        public static string printTime(int h, int m)
        {
            string hh, mm;

            hh = h.ToString();
            if (hh.Length == 1)
                hh = '0' + hh;

            mm = m.ToString();
            if (mm.Length == 1)
                mm = '0' + mm;

            return hh + ':' + mm;
        }
    }
}
