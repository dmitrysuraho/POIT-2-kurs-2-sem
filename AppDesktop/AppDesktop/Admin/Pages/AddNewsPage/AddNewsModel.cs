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

namespace AppDesktop.Admin.Pages.AddNewsPage
{
    class AddNewsModel : INotifyPropertyChanged
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

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
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

        public bool Add()
        {
            if (name == "" || name == null)
            {
                MessageBox.Show("Введите заголовок");
                return false;
            }
            else if (description == "" || description == null)
            {
                MessageBox.Show("Введите описание");
                return false;
            }
            else if (file == "" || file == null)
            {
                MessageBox.Show("Выберите изображение");
                return false;
            }
            else
            {
                string str = $"insert into News(NAME, DESCRIPTION, PICTURE) select '{name}', '{description}', BulkColumn FROM Openrowset(Bulk '{file}', Single_Blob) as image";
                SqlCommand sqlCommand = new SqlCommand(str, Connection.SqlConnection);
                int number = sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Новость добавлена");
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
