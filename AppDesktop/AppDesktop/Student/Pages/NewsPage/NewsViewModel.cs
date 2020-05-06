using Students.DataBaseConnection;
using Students.RelayCommand;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AppDesktop.Student.Pages.NewsPage
{
    class NewsViewModel : INotifyPropertyChanged
    {

        private StudentWindow studentWindow;
        private News news;

        public ObservableCollection<NewsModel> News { get; set; } = new ObservableCollection<NewsModel>();

        private NewsModel selectedNews;
        public NewsModel SelectedNews
        {
            get { return selectedNews; }
            set
            {
                selectedNews = value;
                OnPropertyChanged("SelectedNews");
            }
        }

        private double pageOpacity;
        public double PageOpacity
        {
            get { return pageOpacity; }
            set
            {
                pageOpacity = value;
                OnPropertyChanged("PageOpacity");
            }
        }

        private Command cancel;
        public Command Cancel
        {
            get
            {
                return cancel ??
                  (cancel = new Command(obj =>
                  {
                      ShowPage();
                  }));
            }
        }

        public NewsViewModel(News news, StudentWindow student)
        {
            studentWindow = student;
            this.news = news;
            PageOpacity = 1;


            string subj = $"select * from NEWS";
            SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            string title, description, dataName;
            byte[] data;
            foreach (var x in reader)
            {
                title = reader.GetString(0).Trim();
                description = reader.GetString(1).Trim();
                data = (byte[])reader.GetValue(2);
                dataName = @"C:\Users\Dmitry\Desktop\Курсовой\AppDesktop\AppDesktop\bin\Debug\" + reader.GetString(3).Trim();
                try
                {
                    using (FileStream fs = new FileStream(dataName, FileMode.OpenOrCreate))
                    {
                        fs.Write(data, 0, data.Length);
                    }
                }
                catch
                {
                }
                News.Add(new NewsModel
                {
                    Title = title,
                    Description = description,
                    DataName = dataName,
                    Date = Convert.ToString(reader.GetDateTime(4).Date).Substring(0,10)
                });
            }
            reader.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private async void ShowPage()
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    PageOpacity = i;
                    Thread.Sleep(50);
                }
            });
            studentWindow.GridAdminControl.Visibility = Visibility.Visible;
            studentWindow.Frame.Visibility = Visibility.Collapsed;
        }
    }
}
