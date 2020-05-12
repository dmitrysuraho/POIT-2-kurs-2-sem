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
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace AppDesktop.Student.Pages.SubjectsPage
{
    class SubjectsViewModel : INotifyPropertyChanged
    {
        private Subjects page;
        private StudentWindow studentWindow;
        private string login;

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

        public ObservableCollection<SubjectsModel> Subjects { get; set; } = new ObservableCollection<SubjectsModel>();
        public ObservableCollection<SubjectsModel> Literature { get; set; } = new ObservableCollection<SubjectsModel>();

        private SubjectsModel selectedSubject;
        public SubjectsModel SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                Literature.Clear();
                page.ChooseSubject.Visibility = Visibility.Collapsed;
                page.Literature.Visibility = Visibility.Visible;
                page.ChooseLiterature.Visibility = Visibility.Visible;
                string litr = $"select TITLE, AUTHORS, PICTURE from LITERATURE where SUBJECT = '{value.Subject.Substring(9)}'";
                SqlCommand sqlCom = new SqlCommand(litr, Connection.SqlConnection);
                SqlDataReader reader = sqlCom.ExecuteReader();
                foreach (var x in reader)
                {
                    using (MemoryStream memStream = new MemoryStream())
                    {
                        byte[] arr = (byte[])reader.GetValue(2);
                        memStream.Write(arr, 0, arr.Length);
                        Bitmap bm = new Bitmap(memStream);
                        Literature.Add(new SubjectsModel
                        {
                            Title = "Название: " + reader.GetString(0).Trim(),
                            Authors = "Авторы: " + reader.GetString(1).Trim(),
                            Data = BitmapToImageSource(bm)
                        });
                    }
                }
                reader.Close();

                selectedSubject = value;
                OnPropertyChanged("SelectedSubject");
            }
        }

        private SubjectsModel selectedLiterature;
        public SubjectsModel SelectedLiterature
        {
            get { return selectedLiterature; }
            set
            {
                page.ChooseLiterature.Visibility = Visibility.Collapsed;
                selectedLiterature = value;
                OnPropertyChanged("SelectedLiterature");
            }
        }

        public SubjectsViewModel(StudentWindow student, string login, Subjects page)
        {
            studentWindow = student;
            this.login = login;
            this.page = page;
            PageOpacity = 1;

            string subj = $"select SUBJECT.SUBJECT from STUDENT inner join SUBJECT on STUDENT.COURSE = SUBJECT.COURSE where STUDENT.RECORD = {login}";
            SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            foreach(var x in reader)
            {
                Subjects.Add(new SubjectsModel
                {
                    Subject = "Предмет: " + reader.GetString(0).Trim()
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
