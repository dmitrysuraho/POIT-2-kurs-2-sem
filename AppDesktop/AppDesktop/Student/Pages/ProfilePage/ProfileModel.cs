using Students.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppDesktop.Student.Pages.ProfilePage
{
    class ProfileModel : INotifyPropertyChanged
    {
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

        private byte[] data;
        private string dataName;
        public string DataName
        {
            get { return dataName; }
            set
            {
                dataName = value;
                OnPropertyChanged("DataName");
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
                studentName = reader.GetString(2);
                studentRecord = reader.GetInt32(0);
                studentGroup = reader.GetInt32(4);
                studentCourse = reader.GetInt32(5);
                studentProfession = reader.GetString(8);
                data = (byte[])reader.GetValue(3);

                dataName = @"C:\Users\Dmitry\Desktop\Курсовой\AppDesktop\AppDesktop\bin\Debug\" + reader.GetString(6).Replace(" ", "");
            }
            reader.Close();
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
        }
    }
}
