﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace из_файла
{
    struct Workers
    {
        private static readonly Program pro = new Program();

        #region свойства 
        public int WorkID { get; set; } // Табельный номер
        public string FisrtName { get; set; }// Имя
        public string LastName { get; set; } // Фамилия
        public int Age  { get; set; } // Возраст
        public string WorkDept { get; set; }// Отдел
        public int Solary { get; set; } // ЗряПлата
        public int CountProject { get; set; } // Количество проектов
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

        /// <summary>
        /// Метод создающий сотрудника
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
       public Workers CreateWorker(int count)
        {
            int workID = count + 1;
            Console.WriteLine("Введите следющую информацию о работнике: ");
            Console.WriteLine("Имя: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Фамилия: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Возраст: ");
            int age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Название Отдела: ");
            string dept = Console.ReadLine();
            Console.WriteLine("Зарплата: ");
            int solary = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Количество проектов: ");
            int projects = Int32.Parse(Console.ReadLine());
            
            Workers worker = new Workers(workID ,firstName, lastName, age,dept,solary,projects );

            return worker;
        }

    }
}
