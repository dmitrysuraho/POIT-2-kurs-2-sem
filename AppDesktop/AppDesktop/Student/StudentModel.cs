using Students.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AppDesktop.Student
{
    class StudentModel : INotifyPropertyChanged
    {
        private string enterStudent;
        public string EnterStudent
        {
            get { return enterStudent; }
            set
            {
                enterStudent = value;
                OnPropertyChanged("EnterStudent");
            }
        }

        public StudentModel(string login)
        {
            SqlCommand sqlCommand = new SqlCommand($"select NAME from STUDENT where RECORD = '{login}'", Connection.SqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            string name = "";
            foreach (var i in reader)
            {
                name = reader.GetString(0);
            }
            reader.Close();
            EnterStudent = "Вы вошли под '" + name + "'";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
