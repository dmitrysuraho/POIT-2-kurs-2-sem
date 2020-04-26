using Students.RelayCommand;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppDesktop.Student.Pages.TestPage
{
    class TestModel : INotifyPropertyChanged
    {
        public static int progress { get; set; } = 0;

        private string timer;
        public string Timer
        {
            get { return timer; }
            set
            {
                timer = value;
                OnPropertyChanged("Timer");
            }
        }

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

        private string nameQuestion;
        public string NameQuestion
        {
            get { return nameQuestion; }
            set
            {
                nameQuestion = value;
                OnPropertyChanged("NameQuestion");
            }
        }

        private Command answerCommand;
        public Command AnswerCommand
        {
            get
            {
                return answerCommand ??
                    (answerCommand = new Command(obj =>
                    {
                        progress += 2;
                    }));
            }
        }

        private Command noanswerCommand;
        public Command NoAnswerCommand
        {
            get
            {
                return noanswerCommand ??
                    (noanswerCommand = new Command(obj =>
                    {
                        progress -= 2;
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
