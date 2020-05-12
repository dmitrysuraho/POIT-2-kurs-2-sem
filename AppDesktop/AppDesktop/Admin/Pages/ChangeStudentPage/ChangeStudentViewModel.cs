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

namespace AppDesktop.Admin.Pages.ChangeStudentPage
{
    class ChangeStudentViewModel : INotifyPropertyChanged
    {
        AdminWindow adminWindow;
        public ObservableCollection<ChangeStudentModel> Students { get; set; } = new ObservableCollection<ChangeStudentModel>();

        private ChangeStudentModel selectedStudent;
        public ChangeStudentModel SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }

        private ChangeStudentModel model;
        public ChangeStudentModel Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
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

        public ChangeStudentViewModel(AdminWindow admin)
        {
            adminWindow = admin;
            PageOpacity = 1;
            Model = new ChangeStudentModel();

            string student = "select NAME, IDGROUP, COURSE, PICTURE from STUDENT";
            SqlCommand sqlCom = new SqlCommand(student, Connection.SqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            foreach (var x in reader)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    byte[] arr = (byte[])reader.GetValue(3);
                    memStream.Write(arr, 0, arr.Length);
                    Bitmap bm = new Bitmap(memStream);

                    Students.Add(new ChangeStudentModel
                    {
                        Name = reader.GetString(0).Trim(),
                        Group = reader.GetInt32(1),
                        Course = reader.GetInt32(2),
                        Data = BitmapToImageSource(bm)
                    });
                }
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
            adminWindow.GridAdminControl.Visibility = Visibility.Visible;
            adminWindow.Frame.Visibility = Visibility.Collapsed;
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
