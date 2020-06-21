using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_8.Task
{
    class Tasks
    {
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } 
        public string Type { get; set; }
        public string Information { get; set; }
        public string Status { get; set; }
        public Tasks(string type, string information, DateTime date)
        {
            EndDate = date;
            Type = type;
            Information = information;
            Status = "Активна";
        }
    }
    class TaskList
    {
        public static BindingList<Tasks> taskList = new BindingList<Tasks>();
        public static BindingList<Tasks> list = new BindingList<Tasks>();
    }
}
