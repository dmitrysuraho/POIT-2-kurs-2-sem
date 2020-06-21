using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab5
{
    public partial class Search : Form
    {
        public IEnumerable<Airport> list;
        public Search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SwitchForms.CreateObject.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Text = textBox1.Text.ToUpper();
            richTextBox1.Text = "";
            list = SwitchForms.CreateObject.ListObj.Where(t => t.Type.ToUpper().Contains(Text));
            foreach (var x in list)
            {
                richTextBox1.Text += $"-------Самолет------\n{x.PlaneInfo()}\n\n-------Экипаж------\n{x.CrewInfo()}-----------------------------------------\n\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string symbol = textBox7.Text.ToUpper();
            richTextBox1.Text = "";
            Regex regex = new Regex($"^[{symbol}]");
            list = SwitchForms.CreateObject.ListObj.Where(t => regex.IsMatch(t.Type.ToUpper()));
            foreach (var x in list)
            {
                richTextBox1.Text += $"-------Самолет------\n{x.PlaneInfo()}\n\n-------Экипаж------\n{x.CrewInfo()}-----------------------------------------\n\n";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string text = textBox8.Text.ToUpper();
            richTextBox1.Text = "";
            Regex regex = new Regex($"[{text}]");
            list = SwitchForms.CreateObject.ListObj.Where(t => regex.IsMatch(t.Type.ToUpper()));
            foreach (var x in list)
            {
                richTextBox1.Text += $"-------Самолет------\n{x.PlaneInfo()}\n\n-------Экипаж------\n{x.CrewInfo()}-----------------------------------------\n\n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string symbol = textBox2.Text.ToUpper();
            int number = Convert.ToInt32(textBox3.Text);
            int number2 = Convert.ToInt32(textBox4.Text);
            richTextBox1.Text = "";
            Regex regex = new Regex($"[{symbol}]" + "{" + number + "," + number2 + "}");
            list = SwitchForms.CreateObject.ListObj.Where(t => regex.IsMatch(t.Type.ToUpper()));
            foreach (var x in list)
            {
                richTextBox1.Text += $"-------Самолет------\n{x.PlaneInfo()}\n\n-------Экипаж------\n{x.CrewInfo()}-----------------------------------------\n\n";
            }
        }
    }
}
