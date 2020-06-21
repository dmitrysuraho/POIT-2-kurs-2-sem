using Lab7_8.Task;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab7_8.Json
{
    class Serialization
    {
        public static void Save(BindingList<Tasks> list)
        {
            using (StreamWriter stream = new StreamWriter(@"json.txt"))
            {
                string outStr = JsonConvert.SerializeObject(list);
                stream.WriteLine(outStr);
            }
        }
        public static void Load()
        {
            if (File.Exists(@"json.txt"))
            {
                using (StreamReader stream = new StreamReader(@"json.txt"))
                {
                    string outStr = stream.ReadToEnd();
                    TaskList.taskList = JsonConvert.DeserializeObject<BindingList<Tasks>>(outStr);
                }
            }
        }
    }
}
