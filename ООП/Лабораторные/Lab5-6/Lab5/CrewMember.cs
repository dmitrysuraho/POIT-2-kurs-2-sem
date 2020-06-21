using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab5
{
    [Serializable]
    public class CrewMember
    {
        [Required(ErrorMessage = "Отсутствует Имя", AllowEmptyStrings = false)]
        [RegularExpression("([A-Z]{1}[a-z]*)|([А-Я]{1}[а-я]*)", ErrorMessage = "Неверный формат имени")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Отсутствует Фамилия", AllowEmptyStrings = false)]
        [RegularExpression("([A-Z]{1}[a-z]*)|([А-Я]{1}[а-я]*)", ErrorMessage = "Неверный формат фамилии")]
        public string Surname { get; set; }
        [Required]
        [Range(18, 55, ErrorMessage = "Диапазон возраста от 18 до 55")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Отсутствует Должность", AllowEmptyStrings = false)]
        public string Function { get; set; }
        [Required(ErrorMessage = "Отсутствует Стаж")]
        [Range(0, 37, ErrorMessage = "Диапазон стажа от 0 до 37")]
        public int Experience { get; set; }

        public CrewMember(string name, string surname, int age, string function, int experience)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Function = function;
            Experience = experience;
        }

        public string CrewInfo()
        {
            return $"Имя: {Name}\nФамилия: {Surname}\nВозраст: {Age}\nДолжность: {Function}\nСтаж: {Experience}\n\n";
        }
    }
}
