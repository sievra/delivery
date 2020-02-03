using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delivery
{
    class Individual
    {
        public List<int> perm = new List<int>();
        List<int> phen = new List<int>();
        public int fulltime, cars;
        public double fitness;
        double mutationProbability;

        public Individual() { }

        public Individual(int n, double mutationProbability)
        {
            gen(n, mutationProbability);
            //this.mutationProbability = mutationProbability;
        }

        public void gen(int n, double mutationProbability) /// генерирация случайной перестановки
        {
            this.mutationProbability = mutationProbability;

            Tools.resize(ref perm, n);
            Tools.resize(ref phen, n);

            List<bool> used = new List<bool>();
            Tools.resize(ref used, n + 1);
            for (int i = 0; i < used.Count; i++)
                used[i] = false;

            for (int i = 0; i < n; i++)
            {
                perm[i] = Tools.intRand(1, n + 1);
                while (used[perm[i]])
                    perm[i] = Tools.intRand(1, n + 1);
                used[perm[i]] = true;
            }

            makephen();
        }

        void makephen() /// получение фенотипа
        {
            int n = perm.Count;

            List<bool> used = new List<bool>();
            Tools.resize(ref used, n + 1);
            for (int i = 0; i < used.Count; i++)
                used[i] = false;

            for (int i = 0; i < n; i++)
            {
                phen[i] = 1;
                for (int j = 1; j < perm[i]; j++)
                    if (!used[j])
                        phen[i]++;
                used[perm[i]] = true;
            }
        }

        void decode() /// декодирование фенотипа
        {
            int n = perm.Count;

            List<bool> used = new List<bool>();
            Tools.resize(ref used, n + 1);
            for (int i = 0; i < used.Count; i++)
                used[i] = false;

            for (int i = 0; i < n; i++)
            {
                int ph = phen[i];
                for (int j = 1; ph > 0; j++)
                    if (!used[j])
                    {
                        ph--;
                        perm[i] = j;
                    }
                used[perm[i]] = true;
            }
        }

        void swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public void cross(ref Individual b) /// кроссовер
        {
            int n = perm.Count;
            int pnt = Tools.intRand(0, n);
            for (int i = 0; i <= pnt; i++)
            {
                int temp = phen[i];
                phen[i] = b.phen[i];
                b.phen[i] = temp;
            }
            decode();
            b.decode();
        }

        public void mutation()
        {
            if (Tools.doubleRand(0, 1) > mutationProbability)
                return;
            int n = perm.Count;
            int ind1 = Tools.intRand(0, n);
            int ind2 = Tools.intRand(0, n);
            while (ind1 == ind2)
                ind2 = Tools.intRand(0, n);

            int temp = perm[ind1];
            perm[ind1] = perm[ind2];
            perm[ind2] = temp;
            
            makephen();
        }
    }
}
