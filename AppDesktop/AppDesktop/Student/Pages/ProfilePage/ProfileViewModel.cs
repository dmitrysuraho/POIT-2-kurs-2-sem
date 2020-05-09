using Microsoft.Win32;
using Students.DataBaseConnection;
using Students.RelayCommand;
using System;
using System.Collections.Generic;
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

namespace AppDesktop.Student.Pages.ProfilePage
{
    class ProfileViewModel : INotifyPropertyChanged
    {
        private StudentWindow studentWindow;
        private Profile profile;
        private string login;

        private ProfileModel model;
        public ProfileModel Model
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
                      studentWindow.Profile.IsEnabled = true;
                  }));
            }
        }

        private Command changePass;
        public Command ChangePass
        {
            get
            {
                return changePass ??
                  (changePass = new Command(obj =>
                  {
                      profile.ProfileInfo.Visibility = Visibility.Collapsed;
                      profile.ChangePassword.Visibility = Visibility.Visible;
                  }));
            }
        }

        private Command change;
        public Command Change
        {
            get
            {
                return change ??
                  (change = new Command(obj =>
                  {
                      profile.ProfileInfo.Visibility = Visibility.Visible;
                      profile.ChangePassword.Visibility = Visibility.Collapsed;
                  }));
            }
        }

        private Command changeImage;
        public Command ChangeImage
        {
            get
            {
                return changeImage ??
                  (changeImage = new Command(obj =>
                  {
                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.Filter = "Image files (*.jpg)|*.jpg|(*.png)|*.png";
                      if (openFileDialog.ShowDialog() == true)
                      {
                          string str = $"UPDATE STUDENT SET PICTURE = (SELECT * FROM OPENROWSET(BULK '{openFileDialog.FileName}', SINGLE_BLOB) AS image), NAMEPICTURE = '{openFileDialog.SafeFileName}' where RECORD = {login}";
                          SqlCommand sqlCommand = new SqlCommand(str, Connection.SqlConnection);
                          int number = sqlCommand.ExecuteNonQuery();
                          model.Data = BitmapToImageSource(new Bitmap(openFileDialog.FileName));
                      }
                  }));
            }
        }

        public ProfileViewModel(Profile profile, StudentWindow student, string login)
        {
            this.login = login;
            studentWindow = student;
            this.profile = profile;
            PageOpacity = 1;
            Model = new ProfileModel(login);
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
