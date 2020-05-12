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

namespace AppDesktop.Admin.Pages.AddTeacherPage
{
    class AddTeacherModel : INotifyPropertyChanged
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

        private string identificator;
        public string Identificator
        {
            get { return identificator; }
            set
            {
                identificator = value;
                OnPropertyChanged("Identificator");
            }
        }

        private string subject;
        public string Subject
        {
            get { return subject; }
            set
            {
                subject = value;
                OnPropertyChanged("Subject");
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
            string subj = "select SUBJECT from SUBJECT";
            SqlCommand sqlCom1 = new SqlCommand(subj, Connection.SqlConnection);
            SqlDataReader reader1 = sqlCom1.ExecuteReader();
            bool subjBool = false;
            foreach (var i in reader1)
            {
                if (subject == reader1.GetString(0).Replace(" ", ""))
                {
                    subjBool = true;
                    break;
                }
            }
            reader1.Close();
            string teach = "select TEACHER from TEACHER";
            SqlCommand sqlCom2 = new SqlCommand(teach, Connection.SqlConnection);
            SqlDataReader reader2 = sqlCom2.ExecuteReader();
            bool teachBool = false;
            foreach (var i in reader2)
            {
                if (identificator == reader2.GetString(0).Replace(" ", ""))
                {
                    teachBool = true;
                    break;
                }
            }
            reader2.Close();
            int index;
            if (teachBool)
            {
                MessageBox.Show("Такой учитель уже есть");
                return false;
            }
            else if (identificator == "" || identificator == null || int.TryParse(identificator, out index) || identificator == "admin")
            {
                MessageBox.Show("Неверный идентификатор");
                return false;
            }
            else if (name == "" || name == null)
            {
                MessageBox.Show("Неверные имя и фамилия");
                return false;
            }
            else if (!subjBool)
            {
                MessageBox.Show("Такого предмета нет");
                return false;
            }
            else
            {
                string str = $"insert into TEACHER(TEACHER, TPASS, SUBJECT, TEACHER_NAME) select '{identificator.Replace(" ", "")}', '{GetHash(identificator.Replace(" ", ""))}', '{subject}', '{name}'";  /* values('{identificator.Replace(" ", "")}', '{GetHash(identificator.Replace(" ", ""))}', '{subject}', '{name}', )";*/
                SqlCommand sqlCommand = new SqlCommand(str, Connection.SqlConnection);
                int number = sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Учитель добавлен");
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
