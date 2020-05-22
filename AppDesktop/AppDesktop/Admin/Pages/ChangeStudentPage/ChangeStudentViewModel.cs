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
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using MessageBox = System.Windows.MessageBox;

namespace AppDesktop.Admin.Pages.ChangeStudentPage
{
    class ChangeStudentViewModel : INotifyPropertyChanged
    {
        AdminWindow adminWindow;
        ChangeStudent page;
        public ObservableCollection<ChangeStudentModel> Students { get; set; } = new ObservableCollection<ChangeStudentModel>();

        private ChangeStudentModel selectedStudent;
        public ChangeStudentModel SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                page.ChangeInfo.Visibility = Visibility.Visible;
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

        private Command change;
        public Command Change
        {
            get
            {
                return change ??
                  (change = new Command(obj =>
                  {
                      if (selectedStudent == null)
                          MessageBox.Show("Выберите студента");
                      else
                      {
                          string idgroup = "select IDGROUP from GROUPS";
                          SqlCommand sqlCom11 = new SqlCommand(idgroup, Connection.SqlConnection);
                          SqlDataReader reader1 = sqlCom11.ExecuteReader();
                          bool idgroupBool = false;
                          foreach (var i in reader1)
                          {
                              if (selectedStudent.Group == reader1.GetInt32(0))
                              {
                                  idgroupBool = true;
                                  break;
                              }
                          }
                          reader1.Close();
                          string cour = "select COURSE from COURSE";
                          SqlCommand sqlCom2 = new SqlCommand(cour, Connection.SqlConnection);
                          SqlDataReader reader2 = sqlCom2.ExecuteReader();
                          bool courseBool = false;
                          foreach (var i in reader2)
                          {
                              if (selectedStudent.Course == reader2.GetInt32(0))
                              {
                                  courseBool = true;
                                  break;
                              }
                          }
                          reader2.Close();

                          int index;
                          if (!idgroupBool || !int.TryParse(selectedStudent.Group.ToString(), out index))
                              MessageBox.Show("Невернаая группа");
                          else if (!courseBool || !int.TryParse(selectedStudent.Course.ToString(), out index))
                              MessageBox.Show("Неверный курс");
                          else
                          {
                              string student = $"update STUDENT set NAME = '{selectedStudent.Name}', IDGROUP = {selectedStudent.Group}, COURSE = {selectedStudent.Course}" +
                              $"where RECORD = {selectedStudent.Login}";
                              SqlCommand sqlCom = new SqlCommand(student, Connection.SqlConnection);
                              int num = sqlCom.ExecuteNonQuery();

                              Students.Clear();
                              string student1 = "select NAME, IDGROUP, COURSE, PICTURE, RECORD from STUDENT";
                              SqlCommand sqlCom1 = new SqlCommand(student1, Connection.SqlConnection);
                              SqlDataReader reader = sqlCom1.ExecuteReader();
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
                                          Data = BitmapToImageSource(bm),
                                          Login = reader.GetInt32(4)
                                      });
                                  }
                              }
                              reader.Close();
                              page.DataGtidStudents.SelectedIndex = 0;
                              MessageBox.Show("Изменения сохранены");
                          }
                      }
                  }));
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

        public ChangeStudentViewModel(AdminWindow admin, ChangeStudent page)
        {
            adminWindow = admin;
            this.page = page;
            PageOpacity = 1;
            Model = new ChangeStudentModel();

            string student = "select NAME, IDGROUP, COURSE, PICTURE, RECORD from STUDENT";
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
                        Data = BitmapToImageSource(bm),
                        Login = reader.GetInt32(4)
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
