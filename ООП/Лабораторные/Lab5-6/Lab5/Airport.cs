using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class IDValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                int passport = Convert.ToInt32(value);
                if (passport > 0 && passport <= 50)
                    return true;
                else
                    this.ErrorMessage = "Диапазон ID от 1 до 50";
            }
            return false;
        }
    }
    [Serializable]
    public class Airport
    {
        [IDValidator]
        public int ID { get; set; }
        [Required(ErrorMessage = "Отсутствует Тип", AllowEmptyStrings = false)]
        public string Type { get; set; }
        [Required(ErrorMessage = "Отсутствует Модель", AllowEmptyStrings = false)]
        public string Model { get; set; }
        [Required(ErrorMessage = "Отсутствует кол-во мест")]
        [Range(10, 50, ErrorMessage = "Диапазон Мест от 10 до 50")]
        public int Places { get; set; }
        [Required(ErrorMessage = "Отсутствует дата")]
        public DateTime MadeDate { get; set; }
        public List<CrewMember> Crew { get; set; }

        public Airport(int id, string type, string model, int places, DateTime madeDate)
        {
            ID = id;
            Type = type;
            Model = model;
            Places = places;
            MadeDate = madeDate;
        }

        public string PlaneInfo()
        {
            return $"ID:{ID}\nТип: {Type}\nМодель: {Model}\nКол-во мест: {Places}\nДата выпуска: {MadeDate.Year}";
        }
        public string CrewInfo()
        {
            string str = "";
            foreach(var x in Crew)
            {
                str += x.CrewInfo();
            }
            return str;
        }
    }
}
