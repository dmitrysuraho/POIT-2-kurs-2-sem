using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab10.Dependencies
{
    public class TaskPriorityDep : DependencyObject
    {

        public static readonly DependencyProperty PriorityProperty;

        static TaskPriorityDep()
        {
            FrameworkPropertyMetadata metadataPriority = new FrameworkPropertyMetadata();
            metadataPriority.CoerceValueCallback = new CoerceValueCallback(CorrectPriority);

            PriorityProperty = DependencyProperty.Register("Priority", typeof(int), typeof(TaskPriorityDep), metadataPriority,
                new ValidateValueCallback(ValidatePriority));
        }

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
    }
}
