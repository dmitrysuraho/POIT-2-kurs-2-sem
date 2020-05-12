using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppDesktop.Teacher.Pages.AddTestPage
{
    class AddTestModel : INotifyPropertyChanged
    {
        private string login;

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

        private string noanswer1;
        public string NoAnswer1
        {
            get { return noanswer1; }
            set
            {
                noanswer1 = value;
                OnPropertyChanged("NoAnswer1");
            }
        }

        private string noanswer2;
        public string NoAnswer2
        {
            get { return noanswer2; }
            set
            {
                noanswer2 = value;
                OnPropertyChanged("NoAnswer2");
            }
        }

        private string questionsCount;
        public string QuestionsCount
        {
            get { return questionsCount; }
            set
            {
                questionsCount = value;
                OnPropertyChanged("QuestionsCount");
            }
        }

        public AddTestModel(string login)
        {
            this.login = login;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
