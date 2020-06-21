using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.Objects
{
    class Model : INotifyPropertyChanged
    {
        public int IdPlane { get; set; }
        private string planeType;
        public string PlaneType
        {
            get { return planeType; }
            set
            {
                planeType = value;
                OnPropertyChanged("PlaneType");
            }
        }

        private string planeModel;
        public string PlaneModel
        {
            get { return planeModel; }
            set
            {
                planeModel = value;
                OnPropertyChanged("PlaneModel");
            }
        }

        private int planePlaces;
        public int PlanePlaces
        {
            get { return planePlaces; }
            set
            {
                planePlaces = value;
                OnPropertyChanged("PlanePlaces");
            }
        }

        public string DataPath { get; set; }
        public string PathPicture { get; set; } 
        public byte[] Picture { get; set; }
        public string NamePicture { get; set; }

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

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        private string post;
        public string Post
        {
            get { return post; }
            set
            {
                post = value;
                OnPropertyChanged("Post");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
