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

namespace AppDesktop.Teacher.Pages.StudentsList
{
    class StudentsListViewModel : INotifyPropertyChanged
    {
        private string login;
        private TeacherWindow teacherWindow;
        public ObservableCollection<StudentsListModel> Students { get; set; } = new ObservableCollection<StudentsListModel>();
        private ObservableCollection<StudentsListModel> helper = new ObservableCollection<StudentsListModel>();


        private StudentsListModel model;
        public StudentsListModel Model
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

        private Command search;
        public Command Search
        {
            get
            {
                return search ??
                  (search = new Command(obj =>
                  {
                      Students.Clear();
                      foreach(var x in helper)
                          if (x.StudentName.ToUpper().Contains(model.Filter.ToUpper()) || x.StudentGroup.ToString().ToUpper().Contains(model.Filter.ToUpper()) ||
                              x.StudentCourse.ToString().ToUpper().Contains(model.Filter.ToUpper()) || x.StudentProfession.ToUpper().Contains(model.Filter.ToUpper()))
                              Students.Add(x);
                  }));
            }
        }

        private Command clear;
        public Command Clear
        {
            get
            {
                return clear ??
                  (clear = new Command(obj =>
                  {
                      Students.Clear();
                      foreach (var x in helper)
                      {
                          Students.Add(x);
                      }
                      model.Filter = "";
                  }));
            }
        }

        public StudentsListViewModel(TeacherWindow teacher, string login)
        {
            this.login = login;
            teacherWindow = teacher;
            PageOpacity = 1;
            Model = new StudentsListModel();

            string str = $"select STUDENT.NAME, STUDENT.IDGROUP, STUDENT.COURSE, GROUPS.PROFESSION, STUDENT.PICTURE, PROGRESS.NOTE " +
                $"from STUDENT inner join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP inner join SUBJECT on STUDENT.COURSE = SUBJECT.COURSE " +
                $"inner join TEACHER on SUBJECT.SUBJECT = TEACHER.SUBJECT left outer join PROGRESS on SUBJECT.SUBJECT = PROGRESS.SUBJECT" +
                $" where TEACHER.TEACHER = '{login}'";
            SqlCommand sqlCommand = new SqlCommand(str, Connection.SqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            foreach (var x in reader)
            {
                using (MemoryStream memStream = new MemoryStream(100))
                {
                    byte[] arr = (byte[])reader.GetValue(4);
                    memStream.Write(arr, 0, arr.Length);
                    Bitmap bm = new Bitmap(memStream);

                    int note = 0;
                    if(!reader.IsDBNull(reader.GetOrdinal("NOTE")))
                    {
                        note = reader.GetInt32(5);
                    }

                    Students.Add(new StudentsListModel
                    {
                        StudentName = reader.GetString(0).Trim(),
                        StudentGroup = reader.GetInt32(1),
                        StudentCourse = reader.GetInt32(2),
                        StudentProfession = reader.GetString(3),
                        Data = BitmapToImageSource(bm),
                        StudentNote = note
                    });
                }
            }
            reader.Close();
            foreach(var x in Students)
            {
                helper.Add(x);
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
            teacherWindow.GridAdminControl.Visibility = Visibility.Visible;
            teacherWindow.Frame.Visibility = Visibility.Collapsed;
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
