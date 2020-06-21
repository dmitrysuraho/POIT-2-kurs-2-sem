using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Result.Text = Result.Text + "sender: " + sender.ToString() + "\n";
            Result.Text = Result.Text + "source: " + e.Source.ToString() + "\n\n";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = $"Name: {TaskNameBox.NameOfTask}  Priority: {TaskPriorityBox.Priority.ToString()} \n\n\n";
        }
    }
}
