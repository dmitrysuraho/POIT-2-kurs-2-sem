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

namespace AppDesktop.Teacher.Pages.AddLiteraturePage
{
    /// <summary>
    /// Логика взаимодействия для AddLiterature.xaml
    /// </summary>
    public partial class AddLiterature : Page
    {
        public AddLiterature(TeacherWindow win, string login)
        {
            InitializeComponent();
            DataContext = new AddLiteratureViewModel(win, login);
        }
    }
}
