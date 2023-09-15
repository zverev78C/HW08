using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace из_файла
{
    struct Workers
    {
        #region свойства 
        public int WorkID { get; set; } // Табельный номер
        public string FisrtName { get; set; }// Имя
        public string LastName { get; set; } // Фамилия
        public int Age { get; set; } // Возраст
        public string WorkDept { get; set; }// Отдел
        private int Solary { get; set; } // ЗряПлата
        private int CountProject { get; set; } // Количество проектов
        #endregion

        #region Конструктор 
        public Workers(int workID, string firstName, string lastName,
            int age, string workDept, int solary, int countProject)
        {
            WorkID = workID;
            FisrtName = firstName;
            LastName = lastName;
            Age = age;
            WorkDept = workDept;
            Solary = solary;
            CountProject = countProject;
        }
        #endregion

        public void Print () 
        { Console.WriteLine($"{WorkID} {FisrtName}  {LastName}  {Age}   {WorkDept}  {Solary}    {CountProject}"); }

        public void Heading()
        {
            Console.WriteLine($"Таб.№   Имя     Фамилия    Возраст     Отдел   Зарплата    Проекты ");
        }
    }
}
