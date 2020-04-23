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

namespace AppDesktop.Admin.Pages.AddNewsPage
{
    /// <summary>
    /// Логика взаимодействия для AddNews.xaml
    /// </summary>
    public partial class AddNews : Page
    {
        public AddNews(AdminWindow win)
        {
            InitializeComponent();
            DataContext = new AddNewsViewModel(win);
        }
    }
}
