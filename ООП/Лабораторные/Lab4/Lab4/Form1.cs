using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        Stack<double> memory = new Stack<double>(5);
        List<string> text = new List<string>(100);
        public Form1()
        {
            InitializeComponent();
        }

        private void pi_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += "pi";
                text.Add("pi");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += "pi/2";
                text.Add("pi/2");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += "pi/4";
                text.Add("pi/4");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += "pi/3";
                text.Add("pi/3");
            }
        }

        private void one_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += Convert.ToString(1);
                text.Add("1");
            }
        }

        private void two_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += Convert.ToString(2);
                text.Add("2");
            }
        }

        private void three_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += Convert.ToString(3);
                text.Add("3");
            }
        }

        private void four_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += Convert.ToString(4);
                text.Add("4");
            }
        }

        private void five_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += Convert.ToString(5);
                text.Add("5");
            }
        }

        private void six_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += Convert.ToString(6);
                text.Add("6");
            }
        }

        private void seven_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += Convert.ToString(7);
                text.Add("7");
            }
        }

        private void eight_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += Convert.ToString(8);
                text.Add("8");
            }
        }

        private void nine_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += Convert.ToString(9);
                text.Add("9");
            }
        }

        private void zero_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += Convert.ToString(0);
                text.Add("0");
            }
        }

        private void sin_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                if (EnterTextBox.Text == "pi") { ResultTextBox.Text = "0";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "sin(");
                    EnterTextBox.Text += ")";
                }
                else if (EnterTextBox.Text == "pi/2") { ResultTextBox.Text = "1";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "sin(");
                    EnterTextBox.Text += ")";
                }
                else if (EnterTextBox.Text == "pi/3") { ResultTextBox.Text = "0.866";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "sin(");
                    EnterTextBox.Text += ")";
                }
                else if (EnterTextBox.Text == "pi/4") { ResultTextBox.Text = "0.707";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "sin(");
                    EnterTextBox.Text += ")";
                }
                else
                {
                    double x;
                    if (!double.TryParse(EnterTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверное выражение синуса");
                    }
                    else
                    {
                        ResultTextBox.Text = Convert.ToString(Math.Round((Math.Sin((Convert.ToDouble(EnterTextBox.Text) * Math.PI) / 180)), 3));
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "sin(");
                        EnterTextBox.Text += ")";
                    }
                }
            }
            else
            {
                if (ResultTextBox.Text == "pi") { ResultTextBox.Text = "0";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "sin(");
                    EnterTextBox.Text += ")";
                }
                else if (ResultTextBox.Text == "pi/2") { ResultTextBox.Text = "1";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "sin(");
                    EnterTextBox.Text += ")";
                }
                else if (ResultTextBox.Text == "pi/3") { ResultTextBox.Text = "0.866";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "sin(");
                    EnterTextBox.Text += ")";
                }
                else if (ResultTextBox.Text == "pi/4") { ResultTextBox.Text = "0.707";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "sin(");
                    EnterTextBox.Text += ")";
                }
                else
                {
                    double x;
                    if (!double.TryParse(ResultTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверное выражение синуса");
                    }
                    else
                    {
                        ResultTextBox.Text = Convert.ToString(Math.Round((Math.Sin((Convert.ToDouble(ResultTextBox.Text) * Math.PI) / 180)), 3));
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "sin(");
                        EnterTextBox.Text += ")";
                    }
                }
            }
        }

        private void cos_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                if (EnterTextBox.Text == "pi")
                {
                    ResultTextBox.Text = "-1";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "cos(");
                    EnterTextBox.Text += ")";
                }
                else if (EnterTextBox.Text == "pi/2")
                {
                    ResultTextBox.Text = "0";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "cos(");
                    EnterTextBox.Text += ")";
                }
                else if (EnterTextBox.Text == "pi/3")
                {
                    ResultTextBox.Text = "0.5";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "cos(");
                    EnterTextBox.Text += ")";
                }
                else if (EnterTextBox.Text == "pi/4")
                {
                    ResultTextBox.Text = "0.707";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "cos(");
                    EnterTextBox.Text += ")";
                }
                else
                {
                    double x;
                    if (!double.TryParse(EnterTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверное выражение косинуса");
                    }
                    else
                    {
                        ResultTextBox.Text = Convert.ToString(Math.Round((Math.Cos((Convert.ToDouble(EnterTextBox.Text) * Math.PI) / 180)), 3));
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "cos(");
                        EnterTextBox.Text += ")";
                    }
                }
            }
            else
            {
                if (ResultTextBox.Text == "pi")
                {
                    ResultTextBox.Text = "-1";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "cos(");
                    EnterTextBox.Text += ")";
                }
                else if (ResultTextBox.Text == "pi/2")
                {
                    ResultTextBox.Text = "0";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "cos(");
                    EnterTextBox.Text += ")";
                }
                else if (ResultTextBox.Text == "pi/3")
                {
                    ResultTextBox.Text = "0.5";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "cos(");
                    EnterTextBox.Text += ")";
                }
                else if (ResultTextBox.Text == "pi/4")
                {
                    ResultTextBox.Text = "0.707";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "cos(");
                    EnterTextBox.Text += ")";
                }
                else
                {
                    double x;
                    if (!double.TryParse(ResultTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверное выражение косинуса");
                    }
                    else
                    {
                        ResultTextBox.Text = Convert.ToString(Math.Round((Math.Cos((Convert.ToDouble(ResultTextBox.Text) * Math.PI) / 180)), 3));
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "cos(");
                        EnterTextBox.Text += ")";
                    }
                }
            }
        }

        private void tg_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                if (EnterTextBox.Text == "pi")
                {
                    ResultTextBox.Text = "0";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "tg(");
                    EnterTextBox.Text += ")";
                }
                else if (EnterTextBox.Text == "pi/2")
                {
                    ResultTextBox.Text = "infinity";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "tg(");
                    EnterTextBox.Text += ")";
                }
                else if (EnterTextBox.Text == "pi/3")
                {
                    ResultTextBox.Text = "1.732";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "tg(");
                    EnterTextBox.Text += ")";
                }
                else if (EnterTextBox.Text == "pi/4")
                {
                    ResultTextBox.Text = "1";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "tg(");
                    EnterTextBox.Text += ")";
                }
                else
                {
                    double x;
                    if (!double.TryParse(EnterTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверное выражение тангенса");
                    }
                    else
                    {
                        ResultTextBox.Text = Convert.ToString(Math.Round((Math.Tan((Convert.ToDouble(EnterTextBox.Text) * Math.PI) / 180)), 3));
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "tg(");
                        EnterTextBox.Text += ")";
                    }
                }
            }
            else
            {
                if (ResultTextBox.Text == "pi")
                {
                    ResultTextBox.Text = "0";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "tg(");
                    EnterTextBox.Text += ")";
                }
                else if (ResultTextBox.Text == "pi/2")
                {
                    ResultTextBox.Text = "infinity";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "tg(");
                    EnterTextBox.Text += ")";
                }
                else if (ResultTextBox.Text == "pi/3")
                {
                    ResultTextBox.Text = "1.732";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "tg(");
                    EnterTextBox.Text += ")";
                }
                else if (ResultTextBox.Text == "pi/4")
                {
                    ResultTextBox.Text = "1";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "tg(");
                    EnterTextBox.Text += ")";
                }
                else
                {
                    double x;
                    if (!double.TryParse(ResultTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверное выражение тангенса");
                    }
                    else
                    {
                        ResultTextBox.Text = Convert.ToString(Math.Round((Math.Tan((Convert.ToDouble(ResultTextBox.Text) * Math.PI) / 180)), 3));
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "tg(");
                        EnterTextBox.Text += ")";
                    }
                }
            }
        }

        private void ctg_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                if (EnterTextBox.Text == "pi")
                {
                    ResultTextBox.Text = "infinity";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "ctg(");
                    EnterTextBox.Text += ")";
                }
                else if (EnterTextBox.Text == "pi/2")
                {
                    ResultTextBox.Text = "0";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "ctg(");
                    EnterTextBox.Text += ")";
                }
                else if (EnterTextBox.Text == "pi/3")
                {
                    ResultTextBox.Text = "0.577";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "ctg(");
                    EnterTextBox.Text += ")";
                }
                else if (EnterTextBox.Text == "pi/4")
                {
                    ResultTextBox.Text = "1";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "ctg(");
                    EnterTextBox.Text += ")";
                }
                else
                {
                    double x;
                    if (!double.TryParse(EnterTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверное выражение котангенса");
                    }
                    else
                    {
                        ResultTextBox.Text = Convert.ToString(Math.Round((1/Math.Tan((Convert.ToDouble(EnterTextBox.Text) * Math.PI) / 180)), 3));
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "ctg(");
                        EnterTextBox.Text += ")";
                    }
                }
            }
            else
            {
                if (ResultTextBox.Text == "pi")
                {
                    ResultTextBox.Text = "infinity";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "ctg(");
                    EnterTextBox.Text += ")";
                }
                else if (ResultTextBox.Text == "pi/2")
                {
                    ResultTextBox.Text = "0";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "ctg(");
                    EnterTextBox.Text += ")";
                }
                else if (ResultTextBox.Text == "pi/3")
                {
                    ResultTextBox.Text = "0.577";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "ctg(");
                    EnterTextBox.Text += ")";
                }
                else if (ResultTextBox.Text == "pi/4")
                {
                    ResultTextBox.Text = "1";
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "ctg(");
                    EnterTextBox.Text += ")";
                }
                else
                {
                    double x;
                    if (!double.TryParse(ResultTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверное выражение котангенса");
                    }
                    else
                    {
                        ResultTextBox.Text = Convert.ToString(Math.Round((1/Math.Tan((Convert.ToDouble(ResultTextBox.Text) * Math.PI) / 180)), 3));
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "ctg(");
                        EnterTextBox.Text += ")";
                    }
                }
            }
        }

        private void point_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                EnterTextBox.Text += ",";
                text.Add(",");
            }
        }

       

        private void clear_Click(object sender, EventArgs e)
        {
            EnterTextBox.Text = "";
            ResultTextBox.Text = "";
            text.Clear();
        }

        private void SaveResult_Click(object sender, EventArgs e)
        {
            double x;
            if (ResultTextBox.Text == "")
            {
                MessageBox.Show("Нельзя сохранить пустой результат");
            }
            else if (memory.Count == 5)
            {
                MessageBox.Show("Превышен максимальный размер памяти");
            }
            else if (!double.TryParse(ResultTextBox.Text, out x))
            {
                MessageBox.Show("Неверный результат для сохранения");
            }
            else
            {
                memory.Push(Convert.ToDouble(ResultTextBox.Text));
                MessageBox.Show("Результат сохранен");
            }        
        }

        private void TakeResult_Click(object sender, EventArgs e)
        {
            if (memory.Count == 0)
            {
                MessageBox.Show("Нет сохраненных результатов");
            }
            else
            {
                string last = Convert.ToString(memory.Pop());
                text.Add(last);
                EnterTextBox.Text += last;
            }
        }

        private void EnterTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SquareRoot_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                if (EnterTextBox.Text == "")
                {
                    MessageBox.Show("Пустое выражение");
                }
                else
                {
                    double x;
                    if (!double.TryParse(EnterTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверный формат для операции");
                    }
                    else
                    {
                        ResultTextBox.Text = Math.Round(Math.Sqrt(Convert.ToDouble(EnterTextBox.Text)), 3).ToString();
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "square(");
                        EnterTextBox.Text += ")";
                    }
                }
            }
            else
            {
                double x;
                if (!double.TryParse(ResultTextBox.Text, out x))
                {
                    MessageBox.Show("Неверный формат для операции");
                }
                else
                {
                    ResultTextBox.Text = Math.Round(Math.Sqrt(Convert.ToDouble(ResultTextBox.Text)), 3).ToString();
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "square(");
                    EnterTextBox.Text += ")";
                }
            }
        }

        private void CubicRoot_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                if (EnterTextBox.Text == "")
                {
                    MessageBox.Show("Пустое выражение");
                }
                else
                {
                    double x;
                    if (!double.TryParse(EnterTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверный формат для операции");
                    }
                    else
                    {   
                        ResultTextBox.Text = Math.Round(Math.Pow(Convert.ToDouble(EnterTextBox.Text), 1.0 / 3.0), 3).ToString();
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "cubic(");
                        EnterTextBox.Text += ")";
                    }
                }
            }
            else
            {
                double x;
                if (!double.TryParse(ResultTextBox.Text, out x))
                {
                    MessageBox.Show("Неверный формат для операции");
                }
                else
                {
                    ResultTextBox.Text = Math.Round(Math.Pow(Convert.ToDouble(ResultTextBox.Text), 1.0 / 3.0), 3).ToString();
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "cubic(");
                    EnterTextBox.Text += ")";
                }
            }
        }

        private void exponent2_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                if (EnterTextBox.Text == "")
                {
                    MessageBox.Show("Пустое выражение");
                }
                else
                {
                    double x;
                    if (!double.TryParse(EnterTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверный формат для операции");
                    }
                    else
                    {
                        ResultTextBox.Text = Math.Round(Math.Pow(Convert.ToDouble(EnterTextBox.Text), 2), 3).ToString();
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "(");
                        EnterTextBox.Text += ")^2";
                    }
                }
            }
            else
            {
                double x;
                if (!double.TryParse(ResultTextBox.Text, out x))
                {
                    MessageBox.Show("Неверный формат для операции");
                }
                else
                {
                    ResultTextBox.Text = Math.Round(Math.Pow(Convert.ToDouble(ResultTextBox.Text), 2), 3).ToString();
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "(");
                    EnterTextBox.Text += ")^2";
                }
            }
        }

        private void exponent3_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                if (EnterTextBox.Text == "")
                {
                    MessageBox.Show("Пустое выражение");
                }
                else
                {
                    double x;
                    if (!double.TryParse(EnterTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверный формат для операции");
                    }
                    else
                    {
                        ResultTextBox.Text = Math.Round(Math.Pow(Convert.ToDouble(EnterTextBox.Text), 3), 3).ToString();
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "(");
                        EnterTextBox.Text += ")^3";
                    }
                }
            }
            else
            {
                double x;
                if (!double.TryParse(ResultTextBox.Text, out x))
                {
                    MessageBox.Show("Неверный формат для операции");
                }
                else
                {
                    ResultTextBox.Text = Math.Round(Math.Pow(Convert.ToDouble(ResultTextBox.Text), 3), 3).ToString();
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "(");
                    EnterTextBox.Text += ")^3";
                }
            }
        }
        //^4
        private void button1_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text == "")
            {
                if (EnterTextBox.Text == "")
                {
                    MessageBox.Show("Пустое выражение");
                }
                else
                {
                    double x;
                    if (!double.TryParse(EnterTextBox.Text, out x))
                    {
                        MessageBox.Show("Неверный формат для операции");
                    }
                    else
                    {
                        ResultTextBox.Text = Math.Round(Math.Pow(Convert.ToDouble(EnterTextBox.Text), 4), 3).ToString();
                        EnterTextBox.Text = EnterTextBox.Text.Insert(0, "(");
                        EnterTextBox.Text += ")^4";
                    }
                }
            }
            else
            {
                double x;
                if (!double.TryParse(ResultTextBox.Text, out x))
                {
                    MessageBox.Show("Неверный формат для операции");
                }
                else
                {
                    ResultTextBox.Text = Math.Round(Math.Pow(Convert.ToDouble(ResultTextBox.Text), 4), 3).ToString();
                    EnterTextBox.Text = EnterTextBox.Text.Insert(0, "(");
                    EnterTextBox.Text += ")^4";
                }
            }
        }
    }
}