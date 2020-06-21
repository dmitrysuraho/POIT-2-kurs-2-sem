using Lab11.ConnectionDB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab11.Objects
{
    class ViewModel : INotifyPropertyChanged
    {
        private MainWindow mainWindow;
        public ObservableCollection<Model> Planes { get; set; } = new ObservableCollection<Model>();
        public ObservableCollection<Model> Crew { get; set; } = new ObservableCollection<Model>();

        private Model mdl;
        public Model Mdl
        {
            get { return mdl; }
            set
            {
                mdl = value;
                OnPropertyChanged("Mdl");
            }
        }

        private Model selectedCrew;
        public Model SelectedCrew
        {
            get { return selectedCrew; }
            set
            {
                selectedCrew = value;
                OnPropertyChanged("SelectedCrew");
            }
        }

        private Model selectedPlane;
        public Model SelectedPlane
        {
            get { return selectedPlane; }
            set
            {
                if (value != null)
                {
                    Crew.Clear();
                    string subj = $"select name, age, post from Crew inner join Plane on Crew.idPlane = Plane.idPlane where Plane.idPlane = {value.IdPlane}";
                    SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
                    SqlDataReader reader = sqlCom.ExecuteReader();
                    foreach (var x in reader)
                    {
                        Crew.Add(new Model
                        {
                            Name = reader.GetString(0).Trim(),
                            Age = reader.GetInt32(1),
                            Post = reader.GetString(2).Trim()
                        });
                    }
                    reader.Close();
                    mainWindow.dataGrid.Visibility = Visibility.Visible;
                }
                selectedPlane = value;
                OnPropertyChanged("SelectedPlane");
            }
        }

        private Command.Command delete;
        public Command.Command Delete
        {
            get
            {
                return delete ??
                  (delete = new Command.Command(obj =>
                  {
                      if (selectedPlane != null)
                      {
                          SqlTransaction transaction = Connection.SqlConnection.BeginTransaction();
                          string str = $"delete from Crew where idPlane = @id";
                          string subj = $"delete from Plane where idPlane = @id";
                          SqlCommand sqlCom = new SqlCommand();
                          sqlCom.Connection = Connection.SqlConnection;
                          SqlParameter param = new SqlParameter("@id", selectedPlane.IdPlane);
                          sqlCom.Parameters.Add(param);
                          sqlCom.Transaction = transaction;
                          sqlCom.CommandText = str;
                          int reader = sqlCom.ExecuteNonQuery();
                          sqlCom.CommandText = subj;
                          int reader2 = sqlCom.ExecuteNonQuery();
                          transaction.Commit();
                          MessageBox.Show($"Удалено {reader2} строк");
                          Planes.Remove(selectedPlane);
                          mainWindow.dataGrid.Visibility = Visibility.Hidden;
                      }
                  }));
            }
        }

        private Command.Command update;
        public Command.Command Update
        {
            get
            {
                return update ??
                  (update = new Command.Command(obj =>
                  {
                      Planes.Clear();
                      string subj = $"select idPlane, type, model, places, picture, namePicture from Plane";
                      SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
                      SqlDataReader reader = sqlCom.ExecuteReader();
                      foreach (var x in reader)
                      {
                          Planes.Add(new Model
                          {
                              IdPlane = reader.GetInt32(0),
                              PlaneType = reader.GetString(1).Trim(),
                              PlaneModel = reader.GetString(2).Trim(),
                              PlanePlaces = reader.GetInt32(3),
                              Picture = (byte[])reader.GetValue(4),
                              NamePicture = reader.GetString(5).Trim(),
                              DataPath = @"C:\Users\Dmitry\Desktop\labs\ООП\Лабораторные\Lab11\Lab11\bin\Debug\" + reader.GetString(5).Trim()
                          });
                      }
                      reader.Close();
                      mainWindow.dataGrid.Visibility = Visibility.Collapsed;
                  }));
            }
        }

        private Command.Command addPlane;
        public Command.Command AddPlane
        {
            get
            {
                return addPlane ??
                  (addPlane = new Command.Command(obj =>
                  {
                      string subj = $"insert into Plane(type, model, places, namePicture, picture) select @type, @model, @places, @namePicture, BulkColumn FROM Openrowset(Bulk '{mdl.PathPicture}', Single_Blob) as image";
                      SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
                      SqlParameter param = new SqlParameter("@type", mdl.PlaneType);
                      SqlParameter param2 = new SqlParameter("@model", mdl.PlaneModel);
                      SqlParameter param3 = new SqlParameter("@places", mdl.PlanePlaces);
                      SqlParameter param4 = new SqlParameter("@namePicture", mdl.NamePicture);
                      sqlCom.Parameters.Add(param);
                      sqlCom.Parameters.Add(param2);
                      sqlCom.Parameters.Add(param3);
                      sqlCom.Parameters.Add(param4);
                      int reader = sqlCom.ExecuteNonQuery();
                      MessageBox.Show($"Добавлено {reader} строк");
                  }));
            }
        }

        private Command.Command addPicture;
        public Command.Command AddPicture
        {
            get
            {
                return addPicture ??
                  (addPicture = new Command.Command(obj =>
                  {
                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.Filter = "Image files (*.jpg)|*.jpg|(*.png)|*.png";
                      if (openFileDialog.ShowDialog() == true)
                      {
                          mdl.PathPicture = openFileDialog.FileName;
                          mdl.NamePicture = openFileDialog.SafeFileName;
                      }
                  }));
            }
        }

        private Command.Command addCrew;
        public Command.Command AddCrew
        {
            get
            {
                return addCrew ??
                  (addCrew = new Command.Command(obj =>
                  {
                      string subj = $"insert into Crew(idPlane, name, age, post) values(@idPlane, @name, @age, @post)";
                      SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
                      SqlParameter param = new SqlParameter("@idPlane", mdl.IdPlane);
                      SqlParameter param2 = new SqlParameter("@name", mdl.Name);
                      SqlParameter param3 = new SqlParameter("@age", mdl.Age);
                      SqlParameter param4 = new SqlParameter("@post", mdl.Post);
                      sqlCom.Parameters.Add(param);
                      sqlCom.Parameters.Add(param2);
                      sqlCom.Parameters.Add(param3);
                      sqlCom.Parameters.Add(param4);
                      int reader = sqlCom.ExecuteNonQuery();
                      MessageBox.Show($"Добавлено {reader} строк");
                      Crew.Add(mdl);
                  }));
            }
        }

        private Command.Command sort;
        public Command.Command Sort
        {
            get
            {
                return sort ??
                  (sort = new Command.Command(obj =>
                  {
                      //IEnumerable<Model> result = Planes.OrderBy(u => u.PlaneModel);
                      //Planes.Clear();
                      //foreach (Model x in result)
                      //{
                      //    MessageBox.Show(x.PlaneModel);
                      //}
                      Model temp;
                      for (int i = 0; i < Planes.Count; i++)
                      {
                          for (int j = i + 1; j < Planes.Count; j++)
                          {
                              if (Planes[i].PlaneModel.CompareTo(Planes[j].PlaneModel) >  0)
                              {
                                  temp = Planes[i];
                                  Planes[i] = Planes[j];
                                  Planes[j] = temp;
                              }
                          }
                      }
                      mainWindow.dataGrid.Visibility = Visibility.Collapsed;
                  }));
            }
        }

        private Command.Command up;
        public Command.Command Up
        {
            get
            {
                return up ??
                  (up = new Command.Command(obj =>
                  {
                      if(selectedPlane != null && Planes.IndexOf(selectedPlane) != 0)
                      {
                          mainWindow.List.SelectedIndex = (Planes.IndexOf(selectedPlane) - 1);
                      }
                  }));
            }
        }

        private Command.Command down;
        public Command.Command Down
        {
            get
            {
                return down ??
                  (down = new Command.Command(obj =>
                  {
                      if (selectedPlane != null && Planes.IndexOf(selectedPlane) != (Planes.Count - 1))
                      {
                          mainWindow.List.SelectedIndex = (Planes.IndexOf(selectedPlane) + 1);
                      }
                  }));
            }
        }

        public ViewModel(MainWindow win)
        {
            Mdl = new Model();
            mainWindow = win;
            string subj = $"select idPlane, type, model, places, picture, namePicture from Plane";
            SqlCommand sqlCom = new SqlCommand(subj, Connection.SqlConnection);
            SqlDataReader reader = sqlCom.ExecuteReader();
            foreach (var x in reader)
            {
                Planes.Add(new Model
                {
                    IdPlane = reader.GetInt32(0),
                    PlaneType = reader.GetString(1).Trim(),
                    PlaneModel = reader.GetString(2).Trim(),
                    PlanePlaces = reader.GetInt32(3),
                    Picture = (byte[])reader.GetValue(4),
                    NamePicture = reader.GetString(5).Trim(),
                    DataPath = @"C:\Users\Dmitry\Desktop\labs\ООП\Лабораторные\Lab11\Lab11\bin\Debug\" + reader.GetString(5).Trim()
                });
                try
                {
                    using (FileStream fs = new FileStream(@"C:\Users\Dmitry\Desktop\labs\ООП\Лабораторные\Lab11\Lab11\bin\Debug\" + reader.GetString(5).Trim(), FileMode.OpenOrCreate))
                    {
                        fs.Write((byte[])reader.GetValue(4), 0, ((byte[])reader.GetValue(4)).Length);
                    }
                }
                catch
                {
                }
            }
            reader.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
