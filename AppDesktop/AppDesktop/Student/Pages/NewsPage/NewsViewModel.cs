using Students.DataBaseConnection;
using Students.RelayCommand;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

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
                news.ChooseNews.Visibility = Visibility.Collapsed;
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
            foreach (var x in reader)
            {
                using (MemoryStream memStream = new MemoryStream(100))
                {
                    byte[] arr = (byte[])reader.GetValue(2);
                    memStream.Write(arr, 0, arr.Length);
                    Bitmap bm = new Bitmap(memStream);
                    News.Add(new NewsModel
                    {
                        Title = reader.GetString(0).Trim(),
                        Description = reader.GetString(1).Trim(),
                        Data = BitmapToImageSource(bm),
                        Date = Convert.ToString(reader.GetDateTime(4).Date).Substring(0, 10)
                    });
                }
            }
            reader.Close();

            NewsModel temp;
            for (int i = 0; i < News.Count - 1; i++)
            {
                for (int j = i + 1; j < News.Count; j++)
                {
                    if (string.Compare(News[i].Date, News[j].Date) > 0)
                    {
                        temp = News[i];
                        News[i] = News[j];
                        News[j] = temp;
                    }
                }
            }
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

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
    }
}
