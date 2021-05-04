using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        int Number = 5;
        public Form1()
        {
            InitializeComponent();
        }

        public double[] data_check()
        {
            double[] probability = new double[Number];

            probability[0] = Convert.ToDouble(textBox1.Text);
            probability[1] = Convert.ToDouble(textBox2.Text);
            probability[2] = Convert.ToDouble(textBox3.Text);
            probability[3] = Convert.ToDouble(textBox4.Text);

            double sum_of_4 = probability.Sum();
            probability[4] = 1 - sum_of_4;
            textBox5.Text = probability[4].ToString("N3");

            if (probability[4] < 0) label6.Text = "Error in data input";
            
            return probability;
        }

        public double[] calculation(double[] probability, int number_experiment)
        {
            double[] Statistic = new double[Number];
            Random rnd = new Random();
            for (int i = 0; i < number_experiment; i++)
            {
                double K = rnd.NextDouble();
                int event_id = 0;
                K -= probability[0];
                while (K>0)
                {
                    event_id++;
                    K -= probability[event_id];
                };
                Statistic[event_id]++;
            }
            return Statistic;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            double[] probability = data_check();

            int number_of_tries;
            number_of_tries = Convert.ToInt32(textBox6.Text);

            double[] st = calculation(probability, number_of_tries);
            for (int i = 0; i < Number; i++) st[i] /= number_of_tries;

            label7.Text = Convert.ToString(st[0]);
            label8.Text = Convert.ToString(st[1]);
            label9.Text = Convert.ToString(st[2]);
            label10.Text = Convert.ToString(st[3]);
            label11.Text = Convert.ToString(st[4]);
        }
    }
}
