using Students.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace AppDesktop.Student.Pages.ProfilePage
{
    class ProfileModel : INotifyPropertyChanged
    {
        private string newPass;
        public string NewPass
        {
            get { return newPass; }
            set
            {
                newPass = value;
                OnPropertyChanged("NewPass");
            }
        }

        private string oldPass;
        public string OldPass
        {
            get { return oldPass; }
            set
            {
                oldPass = value;
                OnPropertyChanged("OldPass");
            }
        }

        private string studentName;
        public string StudentName
        {
            get { return studentName; }
            set
            {
                studentName = value;
                OnPropertyChanged("StudentName");
            }
        }

        private int studentRecord;
        public int StudentRecord
        {
            get { return studentRecord; }
            set
            {
                studentRecord = value;
                OnPropertyChanged("StudentRecord");
            }
        }

        private int studentCourse;
        public int StudentCourse
        {
            get { return studentCourse; }
            set
            {
                studentCourse = value;
                OnPropertyChanged("StudentCourse");
            }
        }

        private int studentGroup;
        public int StudentGroup
        {
            get { return studentGroup; }
            set
            {
                studentGroup = value;
                OnPropertyChanged("StudentGroup");
            }
        }

        private string studentProfession;
        public string StudentProfession
        {
            get { return studentProfession; }
            set
            {
                studentProfession = value;
                OnPropertyChanged("StudentProfession");
            }
        }

        private BitmapImage data;
        public BitmapImage Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged("Data");
            }
        }

        public ProfileModel(string login)
        {
            ProfileInfo(login);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void ProfileInfo(string login)
        {
            string subj = $"select * from STUDENT inner join GROUPS on STUDENT.IDGROUP = GROUPS.IDGROUP where RECORD = {login}";
            SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            foreach (var x in reader)
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    studentName = reader.GetString(2);
                    studentRecord = reader.GetInt32(0);
                    studentGroup = reader.GetInt32(4);
                    studentCourse = reader.GetInt32(5);
                    studentProfession = reader.GetString(8);

                    byte[] arr = (byte[])reader.GetValue(3);
                    memStream.Write(arr, 0, arr.Length);
                    Bitmap bm = new Bitmap(memStream);
                    data = BitmapToImageSource(bm);

                }
            }
            reader.Close();
        }

        public bool CheckChange(string login)
        {
            if (oldPass == "" || oldPass == null)
                return false;
            else if (oldPass == newPass)
            {
                return false;
            }
            else
            {
                string subj = $"select SPASS from STUDENT where RECORD = {login}";
                SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
                SqlDataReader reader = sqlCom.ExecuteReader();
                bool flag = false;
                foreach (var x in reader)
                {
                    if (GetHash(oldPass).Equals(reader.GetString(0).Trim()))
                    {
                        flag = true;
                        break;
                    }
                }
                reader.Close();
                if (flag)
                {
                    if (newPass == "" || newPass == null)
                        return false;
                    else
                    {
                        string str = $"update STUDENT set SPASS = '{GetHash(newPass)}' where RECORD = {login}";
                        SqlCommand sqlCom2 = new SqlCommand(str, Connection.SqlConnection);
                        int num = sqlCom2.ExecuteNonQuery();
                        return true;
                    }
                }
                else return false;
            }
        }

        private string GetHash(string str)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(str);
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = string.Empty;
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);
            return hash;
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
