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

namespace Lab10.UserControls
{


    /// <summary>
    /// Логика взаимодействия для TaskName.xaml
    /// </summary>
    public partial class TaskName : UserControl
    {

        public static readonly DependencyProperty NameOfTaskProperty = DependencyProperty.Register("NameOfTask", typeof(string), typeof(TaskName), new PropertyMetadata(),
                new ValidateValueCallback(ValidateTaskName));

        private static bool ValidateTaskName(object value)
        {
            string curValue = (string)value;
            if (curValue != null)
            {
                if (curValue.Length > 20)
                    return false;
            }
            return true;
        }

        public string NameOfTask
        {
            get { return (string)GetValue(NameOfTaskProperty); }
            set { SetValue(NameOfTaskProperty, value); }
        }


        public TaskName()
        {
            InitializeComponent();
        }
    }
}
