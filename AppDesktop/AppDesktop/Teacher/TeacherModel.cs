using Students.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppDesktop.Teacher
{
    class TeacherModel
    {
        private string enterTeacher;
        public string EnterTeacher
        {
            get { return enterTeacher; }
            set
            {
                enterTeacher = value;
                OnPropertyChanged("EnterTeacher");
            }
        }

        public TeacherModel(string login)
        {
            SqlCommand sqlCommand = new SqlCommand($"select TEACHER_NAME, SUBJECT from TEACHER where TEACHER = '{login}'", Connection.SqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            string name = "", subject = "";
            foreach (var i in reader)
            {
                name = reader.GetString(0).Trim();
                subject = reader.GetString(1).Trim();
            }
            reader.Close();
            EnterTeacher = $"Вы вошли под '{name}' ({subject})";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
