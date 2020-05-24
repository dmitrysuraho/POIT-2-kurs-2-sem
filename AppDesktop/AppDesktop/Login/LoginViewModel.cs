using Students.RelayCommand;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Data.SqlClient;
using Students.DataBaseConnection;
using AppDesktop.Login;
using System.Windows.Controls;
using AppDesktop;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using System.Text.RegularExpressions;

namespace Students.MainWindow
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private AppDesktop.MainWindow mainWindow;

        private LoginModel model;
        public LoginModel Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        private Command forgotPassword;
        public Command ForgotPassword
        {
            get
            {
                return forgotPassword ??
                  (forgotPassword = new Command(obj =>
                  {
                      mainWindow.Log.Visibility = Visibility.Collapsed;
                      mainWindow.ForgotPass.Visibility = Visibility.Visible;
                  }));
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
                      mainWindow.Log.Visibility = Visibility.Visible;
                      mainWindow.ForgotPass.Visibility = Visibility.Collapsed;
                  }));
            }
        }

        private Command getNewPass;
        public Command GetNewPass
        {
            get
            {
                return getNewPass ??
                  (getNewPass = new Command(obj =>
                  {
                      string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
                      int index;
                      if (model.LoginForChange == "" || model.LoginForChange == null || !int.TryParse(model.LoginForChange, out index) ||
                            model.Email == "" || model.Email == null || !Regex.IsMatch(model.Email, pattern, RegexOptions.IgnoreCase))
                      {
                          MessageBox.Show("Некорректные данные");
                      }
                      else
                      {

                          Random rnd = new Random();
                          int value = rnd.Next(1000, 9999);
                          string str = $"update STUDENT set SPASS = '{GetHash(value.ToString())}' where RECORD = {model.LoginForChange}";
                          SqlCommand sqlCommand = new SqlCommand(str, Connection.SqlConnection);
                          int num = sqlCommand.ExecuteNonQuery();
                          if (num == 0)
                              MessageBox.Show("Неверный логин");
                          else 
                          {
                              SendMail(model.Email, value);
                              mainWindow.Log.Visibility = Visibility.Visible;
                              mainWindow.ForgotPass.Visibility = Visibility.Collapsed;
                          }
                              
                      }
                      model.LoginForChange = "";
                      model.Email = "";
                  }));
            }
        }

        private Command logIn;
        public Command LogIn
        {
            get
            {
                return logIn ??
                  (logIn = new Command(obj =>
                  {
                      if (model.Check(obj) == "admin")
                      {
                          mainWindow.Hide();
                          AdminWindow admin = new AdminWindow(mainWindow);
                          admin.Show();
                      }
                      else if (model.Check(obj) == "teacher")
                      {
                          mainWindow.Hide();
                          TeacherWindow teacher = new TeacherWindow(mainWindow, model.Login);
                          teacher.Show();
                      }
                      else if (model.Check(obj) == "student")
                      {
                          mainWindow.Hide();
                          StudentWindow student = new StudentWindow(mainWindow, model.Login);
                          student.Show();
                      }
                      else MessageBox.Show("Неверный логин или пароль");
                  }));
            }
        }

        public LoginViewModel(AppDesktop.MainWindow win)
        {
            Model = new LoginModel();
            mainWindow = win;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
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

        private void SendMail(string address, int pass)
        {
            MailAddress fromMailAddress = new MailAddress("dmitriysurago@gmail.com", "Dmitry Suraho - Administrator");
            MailAddress toAddress = new MailAddress(address, "Student");

            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                mailMessage.Subject = "Восстановление пароля";
                mailMessage.Body = $"Вы запросили восстановление пароля.\n" +
                                   $"Ваш новый пароль: {pass}.\n" +
                                   $"Никому не сообщайте его, чтобы уберечь свою учетную запись.\n\n" +
                                   $"----------------------------\n" +
                                   $"С уважением, Dmitry Suraho";

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, "F.d2001l5");
                try
                {
                    smtpClient.Send(mailMessage);
                    MessageBox.Show("Письмо отправлено, проверьте почту");
                }
                catch
                {
                    MessageBox.Show("Не удалось отправить письмо");
                }
            }
        }
    }
}
