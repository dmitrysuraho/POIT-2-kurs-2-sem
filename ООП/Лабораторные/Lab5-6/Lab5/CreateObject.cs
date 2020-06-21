using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab5
{
    public partial class CreateObject : Form
    {
        public Airport air;
        public List<Airport> ListObj = new List<Airport>();
        public CreateObject()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"json.txt"))
            {
                File.Delete(@"json.txt");
            }

            this.Hide();
            SwitchForms.Plain.Show();
            SwitchForms.Crew.ListCrew = new List<CrewMember>(3);
            SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: создание объекта";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (SwitchForms.CreateObject.air == null)
            {
                MessageBox.Show("Объект не создан");
            }
            else if (!File.Exists(@"json.txt"))
            {
                MessageBox.Show("Объект не сохранен");
            }
            else
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Airport));
                using (FileStream stream = new FileStream(@"json.txt", FileMode.Open))
                {
                    Airport newAir = (Airport)json.ReadObject(stream);
                    richTextBox1.Text = (newAir.PlaneInfo() + "\n\n");
                    richTextBox2.Text = (newAir.CrewInfo() + "\n\n");
                    SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: вывод объекта";
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (SwitchForms.CreateObject.air == null)
            {
                MessageBox.Show("Объект не создан");
            }
            else
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Airport));
                using (FileStream stream = new FileStream(@"json.txt", FileMode.OpenOrCreate))
                {
                    bool flag = false;
                    foreach (var x in ListObj)
                    {
                        if (x.Equals(SwitchForms.CreateObject.air))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        MessageBox.Show("Объект уже сохранен");
                    }
                    else
                    {
                        ListObj.Add(SwitchForms.CreateObject.air);
                        json.WriteObject(stream, SwitchForms.CreateObject.air);
                        MessageBox.Show("Объект сохранен в файл json.txt");
                        SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: сохранение объекта";
                    }
                }
            }
        }
        private void сортировкаПоToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void менюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListObj.Count == 0)
            {
                MessageBox.Show("Нет объектов");
            }
            else
            {
                this.Hide();
                SwitchForms.sort.Show();
                SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: сортировка";
            }
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void поТипуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListObj.Count == 0)
            {
                MessageBox.Show("Нет объектов");
            }
            else
            {
                SwitchForms.CreateObject.Hide();
                SwitchForms.search.Show();
                SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: поиск по типу";
            }
        }

        private void поКолвуМестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListObj.Count == 0)
            {
                MessageBox.Show("Нет объектов");
            }
            else
            {
                SwitchForms.CreateObject.Hide();
                SwitchForms.search2.Show();
                SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: поиск по кол-ву мест";
            }
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия: 2.0\n\nРазработал:\nСураго Дмитрий Александрович");
            SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: 'О программе'";
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListObj.Count == 0)
            {
                MessageBox.Show("Нет результатов");
            }
            else
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Airport));
                using (FileStream stream = new FileStream(@"results.txt", FileMode.OpenOrCreate))
                {
                    if (SwitchForms.sort.list == null && SwitchForms.search.list == null && SwitchForms.search2.list == null)
                    {
                        MessageBox.Show("Нет результатов");
                    }
                    else
                    {
                        if (SwitchForms.sort.list != null)
                        {
                            foreach (var x in SwitchForms.sort.list)
                            {
                                json.WriteObject(stream, x);
                            }
                        }
                        if (SwitchForms.search.list != null)
                        {
                            foreach (var x in SwitchForms.search.list)
                            {
                                json.WriteObject(stream, x);
                            }
                        }
                        if (SwitchForms.search2.list != null)
                        {
                            foreach (var x in SwitchForms.search2.list)
                            {
                                json.WriteObject(stream, x);
                            }
                        }
                        MessageBox.Show("Результат сохранен");
                        SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: сохранение результатов";
                    }
                }
            }
        }

        private void CreateObject_Load(object sender, EventArgs e)
        {
           SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: ожидание действий";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия: 2.0\n\nРазработал:\nСураго Дмитрий Александрович");
            SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: 'О программе'";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (ListObj.Count == 0)
            {
                MessageBox.Show("Нет результатов");
            }
            else
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Airport));
                using (FileStream stream = new FileStream(@"results.txt", FileMode.OpenOrCreate))
                {
                    if (SwitchForms.sort.list == null && SwitchForms.search.list == null && SwitchForms.search2.list == null)
                    {
                        MessageBox.Show("Нет результатов");
                    }
                    else
                    {
                        if (SwitchForms.sort.list != null)
                        {
                            foreach (var x in SwitchForms.sort.list)
                            {
                                json.WriteObject(stream, x);
                            }
                        }
                        if (SwitchForms.search.list != null)
                        {
                            foreach (var x in SwitchForms.search.list)
                            {
                                json.WriteObject(stream, x);
                            }
                        }
                        if (SwitchForms.search2.list != null)
                        {
                            foreach (var x in SwitchForms.search2.list)
                            {
                                json.WriteObject(stream, x);
                            }
                        }
                        MessageBox.Show("Результат сохранен");
                        SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: сохранение результатов";
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (ListObj.Count == 0)
            {
                MessageBox.Show("Нет объектов");
            }
            else
            {
                this.Hide();
                SwitchForms.sort.Show();
                SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: сортировка";
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ListObj.Count == 0)
            {
                MessageBox.Show("Нет объектов");
            }
            else
            {
                SwitchForms.CreateObject.Hide();
                SwitchForms.search.Show();
                SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: поиск по типу";
            }
        }

        private void скрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = оПрограммеToolStripMenuItem1.Checked =
                !оПрограммеToolStripMenuItem1.Checked;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (ListObj.Count == 0)
            {
                MessageBox.Show("Нет объектов");
            }
            else
            {
                SwitchForms.CreateObject.Hide();
                SwitchForms.search2.Show();
                SwitchForms.CreateObject.richTextBox3.Text = $"Дата: {DateTime.Now}\nКол-во объектов: {ListObj.Count}\nДействие: поиск по кол-ву мест";
            }
        }
    }
}
