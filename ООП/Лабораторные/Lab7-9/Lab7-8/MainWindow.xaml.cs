using Lab7_8.Json;
using Lab7_8.Task;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
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

namespace Lab7_8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BindingList<Tasks> UndoRedo = new BindingList<Tasks>();
        Stack<BindingList<Tasks>> DeletedTasks = new Stack<BindingList<Tasks>>();
        BindingList<BindingList<Tasks>> Redo = new BindingList<BindingList<Tasks>>();
        public MainWindow()
        {
            InitializeComponent();

            addTask.SetResourceReference(Button.StyleProperty, "rightButtons");
            saveTask.SetResourceReference(Button.StyleProperty, "rightButtons");
            About.SetResourceReference(Button.StyleProperty, "rightButtons");

            List<string> styles = new List<string> { "styles", "styles2" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "styles";

            App.LanguageChanged += LanguageChanged;

            CultureInfo currLang = App.Language;

            //Заполняем меню смены языка:
            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Serialization.Load();
            foreach(var x in TaskList.taskList)
            {
                if(x.EndDate == DateTime.Now)
                {
                    x.Status = "Неактивна";
                }
            }
            dataGrid.ItemsSource = TaskList.taskList;
            foreach (var x in TaskList.taskList)
            {
                TaskList.list.Add(x);
                UndoRedo.Add(x);
            }
            Date.SelectedDate = DateTime.Now;
        }
        private void About_click(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Версия: 2.0\nВладелец: Дмитрий");
        }
        private void Make_click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.ShowDialog();
        }
        private void Save_click(object sender, RoutedEventArgs e)
        {
            Serialization.Save(TaskList.taskList);
        }
        private void SType_click(object sender, RoutedEventArgs e)
        {
            string FilterText = Type.Text.ToLower();
            TaskList.taskList.Clear();
            foreach (var x in TaskList.list)
            {
                if (x.Type.ToLower().Contains(FilterText))
                {
                    TaskList.taskList.Add(x);
                }
            }
        }
        private void SDescription_click(object sender, RoutedEventArgs e)
        {
            string FilterText = Description.Text.ToLower();
            TaskList.taskList.Clear();
            foreach (var x in TaskList.list)
            {
                if (x.Information.ToLower().Contains(FilterText))
                {
                    TaskList.taskList.Add(x);
                }
            }
        }
        private void SCal_click(object sender, RoutedEventArgs e)
        {
            DateTime FilterDate = (DateTime)Date.SelectedDate;
            TaskList.taskList.Clear();
            foreach (var x in TaskList.list)
            {
                if (FilterDate == x.EndDate)
                {
                    TaskList.taskList.Add(x);
                }
            }
        }
        private void SClear_click(object sender, RoutedEventArgs e)
        {
            TaskList.taskList.Clear();
            foreach(var x in TaskList.list)
            {
                TaskList.taskList.Add(x);
            }
            Type.Text = "";
            Description.Text = "";
            home.IsChecked = false;
            work.IsChecked = false; 
            study.IsChecked = false;
            rest.IsChecked = false;
            active.IsChecked = false;
            notactive.IsChecked = false;
            thismonth.IsChecked = false;
            nextmonth.IsChecked = false;

        }
        private void Local_click(object sender, EventArgs e)
        {
            
        }
        private void Close_click(object sender, EventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (((bool)active.IsChecked && (bool)notactive.IsChecked) || ((bool)thismonth.IsChecked && (bool)nextmonth.IsChecked))
            {
                MessageBox.Show("Нельзя выбрать сразу два фильтра в 'Статус' и 'Дата'(выберите либо один,либо ничего)");
            }
            else if (!(bool)home.IsChecked && !(bool)work.IsChecked && !(bool)study.IsChecked &&
                !(bool)rest.IsChecked && !(bool)active.IsChecked && !(bool)notactive.IsChecked &&
                !(bool)thismonth.IsChecked && !(bool)nextmonth.IsChecked)
            {
                MessageBox.Show("Выберите фильтры");
            }
            else
            {
                BindingList<Tasks> helpList = new BindingList<Tasks>();
                foreach (var x in TaskList.list) helpList.Add(x);
                TaskList.taskList.Clear();
                if ((bool)home.IsChecked)
                {
                    foreach (var x in helpList)
                    {
                        if (x.Type == "Дом") TaskList.taskList.Add(x);
                    }
                }
                if ((bool)work.IsChecked)
                {
                    foreach (var x in helpList)
                    {
                        if (x.Type == "Работа") TaskList.taskList.Add(x);
                    }
                }
                if ((bool)study.IsChecked)
                {
                    foreach (var x in helpList)
                    {
                        if (x.Type == "Учеба") TaskList.taskList.Add(x);
                    }
                }
                if ((bool)rest.IsChecked)
                {
                    foreach (var x in helpList)
                    {
                        if (x.Type == "Отдых") TaskList.taskList.Add(x);
                    }
                }
                if ((bool)home.IsChecked || (bool)work.IsChecked || (bool)study.IsChecked || (bool)rest.IsChecked)
                {
                    helpList.Clear();
                    foreach (var x in TaskList.taskList) helpList.Add(x);
                }
                if ((bool)active.IsChecked)
                {
                    TaskList.taskList.Clear();
                    foreach (var x in helpList)
                    {
                        if (x.Status == "Активна") TaskList.taskList.Add(x);
                    }
                    helpList.Clear();
                    foreach (var x in TaskList.taskList) helpList.Add(x);
                }
                if ((bool)notactive.IsChecked)
                {
                    TaskList.taskList.Clear();
                    foreach (var x in helpList)
                    {
                        if (x.Status == "Неактивна") TaskList.taskList.Add(x);
                    }
                    helpList.Clear();
                    foreach (var x in TaskList.taskList) helpList.Add(x);
                }
                if ((bool)thismonth.IsChecked)
                {
                    TaskList.taskList.Clear();
                    foreach (var x in helpList)
                    {
                        if (x.EndDate.Month == DateTime.Now.Month) TaskList.taskList.Add(x);
                    }
                }
                if ((bool)nextmonth.IsChecked)
                {
                    TaskList.taskList.Clear();
                    foreach (var x in helpList)
                    {
                        if (x.EndDate.Month == (DateTime.Now.Month + 1)) TaskList.taskList.Add(x);
                    }
                }
            }
        }

        private void customControl_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, i'm Custom Control");
        }

        private void Undo_click(object sender, RoutedEventArgs e)
        {
            if (DeletedTasks.Count != 0)
            {
                BindingList<Tasks> t = new BindingList<Tasks>();
                foreach(var y in DeletedTasks.Pop())
                {
                    t.Add(y);
                }
                TaskList.taskList.Clear();
                foreach (var x in t)
                {
                    TaskList.taskList.Add(x);
                }
            }
            else
            {
                MessageBox.Show("Назад больше нельзя");
            }
        }

        private void Redo_click(object sender, RoutedEventArgs e)
        {
            if (Redo.Count != 0)
            {
                BindingList<Tasks> t = new BindingList<Tasks>();
                foreach (var y in Redo.ElementAt(0))
                {
                    t.Add(y);
                }
                Redo.RemoveAt(0);
                TaskList.taskList.Clear();
                foreach (var x in t)
                {
                    TaskList.taskList.Add(x);
                }
            }
            else
            {
                MessageBox.Show("Вперед больше нельзя");
            }
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex != -1)
            {
                BindingList<Tasks> t = new BindingList<Tasks>();
                foreach (var x in TaskList.taskList)
                {
                    t.Add(x);
                }
                DeletedTasks.Push(t);
                int i = dataGrid.SelectedIndex;
                TaskList.taskList.RemoveAt(i);
                BindingList<Tasks> t1 = new BindingList<Tasks>();
                foreach (var x in TaskList.taskList)
                {
                    t1.Add(x);
                }
                Redo.Add(t1);
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления");
            }
        }
    }
}
