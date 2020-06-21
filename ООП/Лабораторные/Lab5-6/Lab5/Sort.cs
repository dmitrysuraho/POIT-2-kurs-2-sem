using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Sort : Form
    {
        public IEnumerable<Airport> list;
        public Sort()
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
            list = SwitchForms.CreateObject.ListObj.OrderBy(t => t.MadeDate);
            richTextBox1.Text = "";
            foreach(var x in list)
            {
                richTextBox1.Text += $"-------Самолет------\n{x.PlaneInfo()}\n\n-------Экипаж------\n{x.CrewInfo()}-----------------------------------------\n\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            list = SwitchForms.CreateObject.ListObj.OrderBy(t => t.Model);
            richTextBox1.Text = "";
            foreach (var x in list)
            {
                richTextBox1.Text += $"-------Самолет------\n{x.PlaneInfo()}\n\n-------Экипаж------\n{x.CrewInfo()}-----------------------------------------\n\n";
            }
        }
    }
}
