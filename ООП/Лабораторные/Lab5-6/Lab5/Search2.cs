using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Search2 : Form
    {
        public IEnumerable<Airport> list;
        public Search2()
        {
            InitializeComponent();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            int Text = Convert.ToInt32(textBox1.Text);
            richTextBox1.Text = "";
            list = SwitchForms.CreateObject.ListObj.Where(t => t.Places == Text);
            foreach (var x in list)
            {
                richTextBox1.Text += $"-------Самолет------\n{x.PlaneInfo()}\n\n-------Экипаж------\n{x.CrewInfo()}-----------------------------------------\n\n";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string symbol = textBox7.Text;
            richTextBox1.Text = "";
            Regex regex = new Regex($"^[{symbol}]");
            list = SwitchForms.CreateObject.ListObj.Where(t => regex.IsMatch(t.Places.ToString()));
            foreach (var x in list)
            {
                richTextBox1.Text += $"-------Самолет------\n{x.PlaneInfo()}\n\n-------Экипаж------\n{x.CrewInfo()}-----------------------------------------\n\n";
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string text = textBox8.Text;
            richTextBox1.Text = "";
            Regex regex = new Regex($"[{text}]");
            list = SwitchForms.CreateObject.ListObj.Where(t => regex.IsMatch(t.Places.ToString()));
            foreach (var x in list)
            {
                richTextBox1.Text += $"-------Самолет------\n{x.PlaneInfo()}\n\n-------Экипаж------\n{x.CrewInfo()}-----------------------------------------\n\n";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string symbol = textBox2.Text;
            int number = Convert.ToInt32(textBox3.Text);
            int number2 = Convert.ToInt32(textBox4.Text);
            richTextBox1.Text = "";
            Regex regex = new Regex($"[{symbol}]" + "{" + number + "," + number2 + "}");
            list = SwitchForms.CreateObject.ListObj.Where(t => regex.IsMatch(t.Places.ToString()));
            foreach (var x in list)
            {
                richTextBox1.Text += $"-------Самолет------\n{x.PlaneInfo()}\n\n-------Экипаж------\n{x.CrewInfo()}-----------------------------------------\n\n";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SwitchForms.CreateObject.Show();
        }
    }
}
