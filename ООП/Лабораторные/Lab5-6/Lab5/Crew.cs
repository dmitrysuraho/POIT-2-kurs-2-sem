using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Crew : Form
    {
        public List<CrewMember> ListCrew;

        public Crew()
        {
            InitializeComponent();
            comboBox1.Items.Add("Пилот");
            comboBox1.Items.Add("Помощник пилота");
            comboBox1.Items.Add("Стюардесса");
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;
            label7.Text = Convert.ToString(trackBar1.Value);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (ListCrew.Count == 0 || ListCrew.Count < 3)
            {
                MessageBox.Show("Экипаж должен состоять из 3 человек");
            }
            else
            {
                this.Hide();
                SwitchForms.CreateObject.Show();
                SwitchForms.CreateObject.air.Crew = ListCrew;
                MessageBox.Show("Объект создан");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ListCrew.Count == 0 && Convert.ToString(comboBox1.SelectedItem) != "Пилот")
            {
                MessageBox.Show("Добавьте пилота");
            }
            else if (ListCrew.Count == 1 && Convert.ToString(comboBox1.SelectedItem) != "Помощник пилота")
            {
                MessageBox.Show("Добавьте помощника пилота");
            }
            else if (ListCrew.Count == 2 && Convert.ToString(comboBox1.SelectedItem) != "Стюардесса")
            {
                MessageBox.Show("Добавьте стюардессу");
            }
            else if (ListCrew.Count >= 3)
            {
                MessageBox.Show("Максимум 3 члена экипажа");
            }
            else
            {
                CrewMember crew = new CrewMember(textBox1.Text, textBox2.Text, trackBar1.Value, Convert.ToString(comboBox1.SelectedItem), (int)numericUpDown1.Value);
                var results = new List<ValidationResult>();
                var context = new ValidationContext(crew);
                if (!Validator.TryValidateObject(crew, context, results, true))
                {
                    string str = "";
                    foreach (var error in results)
                    {
                        str += (error.ErrorMessage + "\n");
                    }
                    MessageBox.Show(str);
                }
                else
                {
                    ListCrew.Add(crew);
                    MessageBox.Show("Член экипажа добавлен");
                }
            }
        }
        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;
            label7.Text = Convert.ToString(trackBar1.Value);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
