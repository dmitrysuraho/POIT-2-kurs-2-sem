using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppDesktop.Admin.Pages.ChangeStudentPage
{
    /// <summary>
    /// Логика взаимодействия для ChangeStudent.xaml
    /// </summary>
    public partial class ChangeStudent : Page
    {
        public ChangeStudent(AdminWindow win)
        {
            InitializeComponent();
            DataContext = new ChangeStudentViewModel(win, this);
        }
    }
}
