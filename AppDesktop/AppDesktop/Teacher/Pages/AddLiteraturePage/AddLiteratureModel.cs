using Students.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppDesktop.Teacher.Pages.AddLiteraturePage
{
    class AddLiteratureModel : INotifyPropertyChanged
    {
        private string login;

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private string authors;
        public string Authors
        {
            get { return authors; }
            set
            {
                authors = value;
                OnPropertyChanged("Authors");
            }
        }

        private string file;
        public string File
        {
            get { return file; }
            set
            {
                file = value;
                OnPropertyChanged("File");
            }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        public AddLiteratureModel(string login)
        {
            this.login = login;
        }

        public bool Add()
        {
            if (title == "" || title == null)
            {
                MessageBox.Show("Введите название");
                return false;
            }
            else if (authors == "" || authors == null)
            {
                MessageBox.Show("Введите авторов");
                return false;
            }
            else if (file == "" || file == null)
            {
                MessageBox.Show("Выберите изображение");
                return false;
            }
            else
            {
                string str1 = $"select SUBJECT from TEACHER where TEACHER = '{login}'";
                SqlCommand sqlCommand1 = new SqlCommand(str1, Connection.SqlConnection);
                SqlDataReader reader = sqlCommand1.ExecuteReader();
                string subj = "";
                foreach(var x in reader)
                {
                    subj = reader.GetString(0).Trim();
                }
                reader.Close();

                string str = $"insert into LITERATURE(TITLE, AUTHORS, SUBJECT, PICTURE) select '{title}', '{authors}', '{subj}', BulkColumn FROM Openrowset(Bulk '{file}', Single_Blob) as image";
                SqlCommand sqlCommand = new SqlCommand(str, Connection.SqlConnection);
                int number = sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Литература добавлена");
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
