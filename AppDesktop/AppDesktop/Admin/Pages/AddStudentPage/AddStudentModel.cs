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
                OnPropertyChanged("Name");
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

        public bool Add()
        {
            string student = "select RECORD from STUDENT";
            SqlCommand sqlCom = new SqlCommand(student, Connection.SqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            bool studBool = false;
            foreach (var i in reader)
            {
                if (record == reader.GetInt32(0).ToString().Replace(" ", ""))
                {
                    studBool = true;
                    break;
                }
            }
            reader.Close();
            string idgroup = "select IDGROUP from GROUPS";
            SqlCommand sqlCom1 = new SqlCommand(idgroup, Connection.SqlConnection);
            SqlDataReader reader1 = sqlCom1.ExecuteReader();
            bool idgroupBool = false;
            foreach (var i in reader1)
            {
                if (group == reader1.GetInt32(0).ToString().Replace(" ", ""))
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
                if (course == reader2.GetInt32(0).ToString().Replace(" ", ""))
                {
                    courseBool = true;
                    break;
                }
            }
            reader2.Close();
            int index;
            if (studBool)
            {
                MessageBox.Show("Данный студент уже есть");
                return false;
            }
            else if (record == "" || record == null || !int.TryParse(record, out index))
            {
                MessageBox.Show("Неверный номер зачетки");
                return false;
            }
            else if (name == "" || name == null)
            {
                MessageBox.Show("Неверное имя");
                return false;
            }
            else if (!courseBool)
            {
                MessageBox.Show("Неверный курс");
                return false;
            }
            else if (!idgroupBool)
            {
                MessageBox.Show("Неверная группа");
                return false;
            }
            else
            {
                string str = $"insert into STUDENT(RECORD, SPASS, NAME, IDGROUP, COURSE, PICTURE) select {record.Replace(" ", "")}, '{GetHash(record.Replace(" ", ""))}', '{name}', {group}, {course}, BulkColumn FROM Openrowset(Bulk 'C:\\Users\\Dmitry\\Desktop\\Курсовой\\AppDesktop\\AppDesktop\\Pictures\\student.jpg', Single_Blob) as image";
                SqlCommand sqlCommand = new SqlCommand(str, Connection.SqlConnection);
                int number = sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Студент добавлен");
                return true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
