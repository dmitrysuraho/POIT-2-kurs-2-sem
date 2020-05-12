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

namespace AppDesktop.Teacher.Pages.StudentsList
{
    /// <summary>
    /// Логика взаимодействия для StudentsList.xaml
    /// </summary>
    public partial class StudentsList : Page
    {
        public StudentsList(TeacherWindow win, string login)
        {
            InitializeComponent();
            DataContext = new StudentsListViewModel(win, login);
        }
    }
}
