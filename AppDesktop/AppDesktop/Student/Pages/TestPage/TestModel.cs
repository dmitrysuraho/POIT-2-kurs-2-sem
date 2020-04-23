using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppDesktop.Student.Pages.TestPage
{
    class TestModel : INotifyPropertyChanged
    {
        private string subjectName;
        public string SubjectName
        {
            get { return subjectName; }
            set
            {
                subjectName = value;
                OnPropertyChanged("SubjectName");
            }
        }

        private string question;
        public string Question
        {
            get { return question; }
            set
            {
                question = value;
                OnPropertyChanged("Question");
            }
        }

        private string answer;
        public string Answer
        {
            get { return answer; }
            set
            {
                answer = value;
                OnPropertyChanged("Answer");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
