using Students.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppDesktop.Admin.Pages.AddStudentPage
{
    class AddStudentModel : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("PageOpacity");
            }
        }
        private string record;
        public string Record
        {
            get { return record; }
            set
            {
                record = value;
                OnPropertyChanged("Record");
            }
        }
        private string group;
        public string Group
        {
            get { return group; }
            set
            {
                group = value;
                OnPropertyChanged("Group");
            }
        }
        private string course;
        public string Course
        {
            get { return course; }
            set
            {
                course = value;
                OnPropertyChanged("Course");
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

        public void Add()
        {
            //if ()
            //{
                
            //}
            //else
            //{
                string str = $"insert into STUDENT(RECORD, SPASS, NAME, IDGROUP, COURSE) values({record}, '{GetHash(record)}', '{name}', {group}, {course})";
                SqlCommand sqlCommand = new SqlCommand(str, Connection.SqlConnection);
                int number = sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Кол-во затронутых строк: " + number);
            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
