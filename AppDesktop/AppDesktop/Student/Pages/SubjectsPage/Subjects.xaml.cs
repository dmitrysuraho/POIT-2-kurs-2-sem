﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppDesktop.Student.Pages.SubjectsPage
{
    /// <summary>
    /// Логика взаимодействия для Subjects.xaml
    /// </summary>
    public partial class Subjects : Page
    {
        public Subjects(StudentWindow win, string login)
        {
            InitializeComponent();
            DataContext = new SubjectsViewModel(win, login, this);
        }
    }
}
