using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AppDesktop.Teacher.Pages.StudentsList
{
    class StudentsListModel : INotifyPropertyChanged
    {
        private string filter;
        public string Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                OnPropertyChanged("Filter");
            }
        }

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

        private BitmapImage data;
        public BitmapImage Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged("Data");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
