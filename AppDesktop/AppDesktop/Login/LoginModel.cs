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

        public bool Check(object obj, string str)
        {
            var passwordBox = obj as PasswordBox;
            string passwordEnter = GetHash(passwordBox.Password);
            SqlCommand sqlCommand = new SqlCommand(str, Connection.SqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            string passwordData = "";
            bool flag = false;
            string objRead;
            foreach (var i in reader)
            {
                if (str.Contains("STUDENT")) objRead = reader.GetInt32(0).ToString().Replace(" ", "");
                else objRead = reader.GetString(0).Replace(" ", "");
                if (objRead == login)
                {
                    passwordData = reader.GetString(1).Replace(" ", "");
                    flag = true;
                    break;
                }
            }
            reader.Close();
            if (flag)
            {
                if (passwordData == passwordEnter) return true;
                else return false;
            }
            else return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
