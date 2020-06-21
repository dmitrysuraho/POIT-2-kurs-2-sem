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
    public partial class Plain : Form
    {
        public int TackBar1Plain()
        {
            return trackBar1.Value;
        }
        public string RadioPlain()
        {
            if(radioButton1.Checked) { return radioButton1.Text; }
            else if (radioButton2.Checked) { return radioButton2.Text; }
            else if(radioButton3.Checked) { return radioButton3.Text;}
            else { return ""; }
        }
        public string ComboBox1Plain()
        {
            return Convert.ToString(comboBox1.SelectedItem);
        }
        public int NumericUpDown1Plain()
        {
            return (int)numericUpDown1.Value;
        }
        public DateTime DateTimePicker1Plain()
        {
            return dateTimePicker1.Value;
        }
        public Plain()
        {
            InitializeComponent();
            comboBox1.Items.Add("ЛаГГ");
            comboBox1.Items.Add("Харрикейн");
            comboBox1.Items.Add("Юнкерс");
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label7.Text = Convert.ToString(trackBar1.Value);
        }
        private void Crew_Click(object sender, EventArgs e)
        {
            if (DateTimePicker1Plain().Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Выберите корректный год выпуска");
            }
            else
            {
                Airport air = new Airport(NumericUpDown1Plain(), RadioPlain(), ComboBox1Plain(), TackBar1Plain(), DateTimePicker1Plain());
                var results = new List<ValidationResult>();
                var context = new ValidationContext(air);
                if (!Validator.TryValidateObject(air, context, results, true))
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
                    this.Hide();
                    SwitchForms.Crew.Show();
                    SwitchForms.CreateObject.air = air;
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}