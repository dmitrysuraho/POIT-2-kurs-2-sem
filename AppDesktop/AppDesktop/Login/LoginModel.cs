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
using System.Windows.Controls;

namespace AppDesktop.Login
{
    class LoginModel : INotifyPropertyChanged
    {
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        private string loginForChange;
        public string LoginForChange
        {
            get { return loginForChange; }
            set
            {
                loginForChange = value;
                OnPropertyChanged("LoginForChange");
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
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

        public string Check(object obj)
        {
            var passwordBox = obj as PasswordBox;
            string passwordEnter = GetHash(passwordBox.Password);
            string loginEnter = login;
            string flag = "";
            string str = $"select * from ADMIN";
            SqlCommand sqlCommand = new SqlCommand(str, Connection.SqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            foreach(var x in reader)
            {
                if(reader.GetString(0).Trim().Equals(loginEnter) &&
                    reader.GetString(1).Trim().Equals(passwordEnter))
                {
                    flag = "admin";
                    break;
                }

            }
            reader.Close();
            if(flag == "")
            {
                string str1 = $"select TEACHER, TPASS from TEACHER";
                SqlCommand sqlCommand1 = new SqlCommand(str1, Connection.SqlConnection);
                SqlDataReader reader1 = sqlCommand1.ExecuteReader();
                foreach (var x in reader1)
                {
                    if (reader1.GetString(0).Trim().Equals(loginEnter) &&
                        reader1.GetString(1).Trim().Equals(passwordEnter))
                    {
                        flag = "teacher";
                        break;
                    }
                }
                reader1.Close();
            }
            if (flag == "")
            {
                string str2 = $"select RECORD, SPASS from STUDENT";
                SqlCommand sqlCommand2 = new SqlCommand(str2, Connection.SqlConnection);
                SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                foreach (var x in reader2)
                {
                    if (reader2.GetInt32(0).ToString().Equals(loginEnter) &&
                        reader2.GetString(1).Trim().Equals(passwordEnter))
                    {
                        flag = "student";
                        break;
                    }
                }
                reader2.Close();
            }
            return flag;
        }
    }
}
