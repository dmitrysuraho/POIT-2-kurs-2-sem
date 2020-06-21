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
    /// Логика взаимодействия для TaskPriority.xaml
    /// </summary>
    public partial class TaskPriority : UserControl
    {
        public static readonly DependencyProperty PriorityProperty;


        private static bool ValidatePriority(object value)
        {
            int curValue = (int)value;
            if (curValue >= 0)
                return true;
            return false;
        }

        private static object CorrectPriority(DependencyObject d, object baseValue)
        {
            int curValue = (int)baseValue;
            if (curValue > 3)
            {
                return 3;
            }
            return curValue;
        }


        public int Priority
        {
            get { return (int)GetValue(PriorityProperty); }
            set { SetValue(PriorityProperty, value); }
        }


        static TaskPriority()
        {
            FrameworkPropertyMetadata metadataPriority = new FrameworkPropertyMetadata();

            metadataPriority.CoerceValueCallback = new CoerceValueCallback(CorrectPriority);
            PriorityProperty = DependencyProperty.Register("Priority", typeof(int), typeof(TaskPriority), metadataPriority,
                    new ValidateValueCallback(ValidatePriority));
        }

        public TaskPriority()
        {
            InitializeComponent();
        }
    }
}
