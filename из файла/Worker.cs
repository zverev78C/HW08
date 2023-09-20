using System;
using System.Collections.Generic;

namespace из_файла
{
    /// <summary>
    /// Структура описывающий сотрудника
    /// </summary>
    class Worker
    {
        #region свойства 

        /// <summary>
        /// Табельный номер  
        /// </summary>
        public int WorkID { get; set; }
        /// <summary>
        /// Имя  
        /// </summary>
        public string FisrtName { get; set; }
        /// <summary>
        /// Фамилия  
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Возраст   
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Отдел   
        /// </summary>
        public string WorkDept { get; set; }
        /// <summary>
        /// ЗряПлата   
        /// </summary>
        public int Solary { get; set; }
        /// <summary>
        /// Количество проектов
        /// </summary>
        public int CountProject { get; set; }
        #endregion

        #region Конструкторы 

        public Worker(int workID, string firstName, string lastName,
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


        /// <summary>
        /// Метод печати заголовков для сотрудников  
        /// </summary>
        public static void PrintTitle()
        {
            Console.WriteLine("Таб.номер\tИмя\t\tФамилия\t\tВозраст\t\t Название отдела\tЗарплата\tКоличество проектов\n ");
        }


    }
}
