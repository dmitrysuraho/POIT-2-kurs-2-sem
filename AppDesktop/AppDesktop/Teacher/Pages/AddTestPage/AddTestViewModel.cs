using Students.DataBaseConnection;
using Students.RelayCommand;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace AppDesktop.Teacher.Pages.AddTestPage
{
    class AddTestViewModel : INotifyPropertyChanged
    {
        private string login;
        private TeacherWindow teacherWindow;
        ObservableCollection<AddTestModel> Questions = new ObservableCollection<AddTestModel>(); 

        private AddTestModel model;
        public AddTestModel Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        private double pageOpacity;
        public double PageOpacity
        {
            get { return pageOpacity; }
            set
            {
                pageOpacity = value;
                OnPropertyChanged("PageOpacity");
            }
        }

        private Command cancel;
        public Command Cancel
        {
            get
            {
                return cancel ??
                  (cancel = new Command(obj =>
                  {
                      ShowPage();
                  }));
            }
        }

        private Command addQuestion;
        public Command AddQuestion
        {
            get
            {
                return addQuestion ??
                  (addQuestion = new Command(obj =>
                  {
                      if ((model.Question == null || model.Question == "") ||
                          (model.Answer == null || model.Answer == "") ||
                          (model.NoAnswer1 == null || model.NoAnswer1 == "") ||
                          (model.NoAnswer2 == null || model.NoAnswer2 == ""))
                          MessageBox.Show("Заполните все поля");
                      else if (Questions.Count == 5)
                          MessageBox.Show("Вы уже добавили максимальное количество вопросов, завершите создание теста");
                      else
                      {
                          Questions.Add(new AddTestModel("")
                          {
                              Question = model.Question,
                              Answer = model.Answer,
                              NoAnswer1 = model.NoAnswer1,
                              NoAnswer2 = model.NoAnswer2
                          });
                          model.QuestionsCount = $"Добавлено вопросов: {Questions.Count}, осталось добавить: {5 - Questions.Count}";
                          if (Questions.Count == 5)
                              MessageBox.Show("Все вопросы добавлены, заавершите создание теста");
                          model.Question = "";
                          model.Answer = "";
                          model.NoAnswer1 = "";
                          model.NoAnswer2 = "";
                      }
                  }));
            }
        }

        private Command addTest;
        public Command AddTest
        {
            get
            {
                return addTest ??
                  (addTest = new Command(obj =>
                  {
                      if (Questions.Count == 5)
                      {
                          string str1 = $"select SUBJECT from TEACHER where TEACHER = '{login}'";
                          SqlCommand sqlCommand1 = new SqlCommand(str1, Connection.SqlConnection);
                          SqlDataReader reader1 = sqlCommand1.ExecuteReader();
                          string subject = "";
                          foreach (var y in reader1)
                          {
                              subject = reader1.GetString(0).Trim();
                          }
                          reader1.Close();
                          string str = $"insert into TESTS(SUBJECT, QUESTION, ANSWER, NOANSWER1, NOANSWER2) values";
                          foreach (var x in Questions)
                          {
                               str += $"('{subject}', '{x.Question}', '{x.Answer}', '{x.NoAnswer1}', '{x.NoAnswer2}'),";
                          }
                          SqlCommand sqlCommand = new SqlCommand(str.Substring(0, str.Length - 1), Connection.SqlConnection);
                          int num = sqlCommand.ExecuteNonQuery();
                          MessageBox.Show("Тест добавлен");
                          ShowPage();
                      }    
                      else MessageBox.Show($"Добавьте еще {5 - Questions.Count} вопроса(ов)") ;
                  }));
            }
        }

        public AddTestViewModel(TeacherWindow teacher, string login)
        {
            this.login = login;
            teacherWindow = teacher;
            PageOpacity = 1;
            Model = new AddTestModel(login);
            model.QuestionsCount = $"Добавлено вопросов: 0, осталось добавить: 5";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private async void ShowPage()
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    PageOpacity = i;
                    Thread.Sleep(50);
                }
            });
            teacherWindow.GridAdminControl.Visibility = Visibility.Visible;
            teacherWindow.Frame.Visibility = Visibility.Collapsed;
        }
    }
}
