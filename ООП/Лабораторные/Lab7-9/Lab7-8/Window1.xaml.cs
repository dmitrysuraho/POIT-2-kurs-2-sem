using Lab7_8.Task;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab7_8
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        static int i = 1;
        public Window1()
        {
            InitializeComponent();
        }
        void Add_do(object sender, RoutedEventArgs e)
        {
            string text;
            if ((bool)home.IsChecked) text = "Дом";
            else if ((bool)work.IsChecked) text = "Работа";
            else if ((bool)study.IsChecked) text = "Учеба";
            else if ((bool)rest.IsChecked) text = "Отдых";
            else text = "";
            if (text == "") MessageBox.Show("Выберите тип задачи");
            else if (Date.SelectedDate == null || (DateTime)Date.SelectedDate <= DateTime.Now)
            {
                MessageBox.Show("Выберите корректную дату завершения");
            }
            else
            {
                TaskList.list.Add(new Tasks(text, TextMore.Text, (DateTime)Date.SelectedDate));
                TaskList.taskList.Add(new Tasks(text, TextMore.Text, (DateTime)Date.SelectedDate));
                i++;
                Close();
            }
        }
    }
}
