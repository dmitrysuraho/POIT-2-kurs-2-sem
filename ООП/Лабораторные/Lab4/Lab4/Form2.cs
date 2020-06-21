using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form2 : Form
    {
        int SizeCol = 0;
        Weather[] Collection;
        public Form2()
        {
            InitializeComponent();
        }        

        private void SizeCollection_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(SizeCollection.Text, out SizeCol))
            {
                Collection = null;
                SizeCol = 0;
            }
        }

        private void GenCollection_Click(object sender, EventArgs e)
        {
            ResultCollection.Text = "";
            if (SizeCol == 0)
            {
                MessageBox.Show("Невозможно сгенерировать пустую коллекцию");
            }
            else
            {
                Collection = new Weather[SizeCol];
                Random Rand = new Random();
                for (int i = 0; i < SizeCol; i++)
                {
                    Collection[i] = new Weather(Rand.Next(1, 50));
                    ResultCollection.Text += $"Температура: {Collection[i].Temperature}\n";
                }
            }
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void SortUp_Click(object sender, EventArgs e)
        {
            Results.Text = "";
            if (Collection == null)
            {
                MessageBox.Show("Пустая коллекция");
            }
            else
            {
                Weather temp;
                for (int i = 0; i < Collection.Length; i++)
                {
                    for (int j = i + 1; j < Collection.Length; j++)
                    {
                        if (Collection[i].Temperature > Collection[j].Temperature)
                        {
                            temp = Collection[i];
                            Collection[i] = Collection[j];
                            Collection[j] = temp;
                        }
                    }
                }
                foreach (var x in Collection)
                {
                    Results.Text += $"Температура: {x.Temperature}\n";
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void SortDown_Click(object sender, EventArgs e)
        {
            Results.Text = "";
            if (Collection == null)
            {
                MessageBox.Show("Пустая коллекция");
            }
            else
            {
                Weather temp;
                for (int i = 0; i < Collection.Length; i++)
                {
                    for (int j = i + 1; j < Collection.Length; j++)
                    {
                        if (Collection[i].Temperature < Collection[j].Temperature)
                        {
                            temp = Collection[i];
                            Collection[i] = Collection[j];
                            Collection[j] = temp;
                        }
                    }
                }
                foreach (var x in Collection)
                {
                    Results.Text += $"Температура: {x.Temperature}\n";
                }
            }
        }

        private void Request1_Click(object sender, EventArgs e)
        {
            Results.Text = "";
            if (Collection == null)
            {
                MessageBox.Show("Пустая коллекция");
            }
            else
            {
                //max = Collection.Max(t => t.Temperature);
                Weather max = Collection.OrderBy(x => x.Temperature).Last();
                Results.Text = $"Температура: {max.Temperature}\n";
            }
        }
        private void Request2_Click(object sender, EventArgs e)
        {
            Results.Text = "";
            if (Collection == null)
            {
                MessageBox.Show("Пустая коллекция");
            }
            else
            {
                IEnumerable<Weather> list = Collection.Where(t => t.Temperature > 10 && t.Temperature < 30);
                foreach(var x in list)
                {
                    Results.Text += $"Температура: {x.Temperature}\n";
                }
            }
        }

        private void Request3_Click(object sender, EventArgs e)
        {
            Results.Text = "";
            if (Collection == null)
            {
                MessageBox.Show("Пустая коллекция");
            }
            else
            {
                int maxThree = Collection.Take(3).Max(t => t.Temperature);
                Results.Text = $"Температура: {maxThree}\n";
            }
        }
    }

    class Weather
    {
        public int Temperature;
        public Weather(int temperature)
        {
            Temperature = temperature;
        }
    }
}