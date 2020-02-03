using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace delivery
{
    public partial class GeneratorForm : Form
    {
        public GeneratorForm()
        {
            InitializeComponent();
        }

        double len(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int n = (int)numUDCount.Value;
            int mn = (int)numUDMinCoor.Value;
            int mx = (int)numUDMaxCoor.Value;
            double error = (double)numUDError.Value;

            List<int> x = new List<int>();
            List<int> y = new List<int>();

            for (int i = 0; i < n; i++)
            {
                x.Add(Tools.intRand(mn, mx + 1));
                while (i > 0 && x[i] == y[i - 1])
                    x[i] = Tools.intRand(mn, mx + 1);

                y.Add(Tools.intRand(mn, mx + 1));
                while (i > 0 && y[i] == x[i])
                    y[i] = Tools.intRand(mn, mx + 1);
            }

            StreamWriter writer;

            try
            {
                writer = new StreamWriter("gen.txt");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при открытии файла", "Ошибка");
                return;
            }

            writer.WriteLine(n);
            for (int i = 0; i < n; i++)
            {
                string line = "";
                for (int j = 0; j < n; j++)
                    line += ((int)(len(x[i], y[i], x[j], y[j]) * Tools.doubleRand(1 - error, 1 + error))).ToString() + ' ';
                writer.WriteLine(line);
            }

            for (int i = 0; i < n - 1; i++)
            {
                int t1 = Tools.intRand(0, 1440 - 60);
                int t2 = Tools.intRand(t1, 1440);
                writer.WriteLine(Tools.printTime(t1 / 60, t1 % 60) + ' ' + Tools.printTime(t2 / 60, t2 % 60));
            }

            writer.Close();

            MessageBox.Show("Тест сгенерирован");
            this.Close();
        }
    }
}
