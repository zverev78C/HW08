using System;
using System.Collections.Generic;

namespace из_файла
{
    /// <summary>
    /// Класс сотрудников 
    /// </summary>
    class Works
    {
        /// <summary>
        /// Основной список всех сотрудников  
        /// </summary>
       List<Works> workrs = new List<Works>(); // список всех сотрудников

        #region свойства 
        /// <summary>
        /// Табельный номер  
        /// </summary>
        int WorkID { get; set; } 
        /// <summary>
        /// Имя  
        /// </summary>
        string FisrtName { get; set; }
        /// <summary>
        /// Фамилия  
        /// </summary>
        string LastName { get; set; }
        /// <summary>
        /// Возраст   
        /// </summary>
        int Age { get; set; }
        /// <summary>
        /// Отдел   
        /// </summary>
        string WorkDept { get; set; }
        /// <summary>
        /// ЗряПлата   
        /// </summary>
        int Solary { get; set; }
        /// <summary>
        /// Количество проектов
        /// </summary>
        int CountProject { get; set; }
        #endregion

        #region Конструкторы 

        Works(int workID, string firstName, string lastName,
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

        public Works()
        {
        }

        #endregion

        #region Методы  


        /// <summary>
        /// Метод вывода на экран списка всех сотрудников 
        /// </summary>
        public void PrintAllWorkers()
        {
            PrintTitle();
            for (int i = 0; i < workrs.Count; i++)
            {
                Console.WriteLine(workrs[i].Print());
            }
        }
        /// <summary>
        /// Метод добавления сотрудника в список
        /// </summary>
        public void AddWorkers()
        {
            int workID = (workrs.Count == 0 ? 0 : workrs.Count); // проверка на пустой список сотрудников
            Console.Write("Имя сотрудника:  ");
            string firstName = Check.InputCheck(true, false);
            Console.Write("Фамилия сотрудника:  ");
            string lastName = Check.InputCheck(true, false);
            Console.Write("Возраст сотрудника:  ");
            int age = Convert.ToInt32(Check.InputCheck(true, true));
            Console.Write("Отдел сотрудника:  ");
            string workDept = Check.InputCheck(true, false);
            Console.Write("Зарплата сотрудника:  ");
            int solary = Convert.ToInt32(Check.InputCheck(true, true));
            Console.Write("Количество проектов сотрудника:  ");
            int projects = Convert.ToInt32(Check.InputCheck(true, true));

            Works tempWorker = new Works(WorkID = workID + 1, // Табельный номер нового сотрудника
                                          FisrtName = firstName, // Имя сотрудника
                                          LastName = lastName,
                                          Age = age,
                                          WorkDept = workDept,
                                          Solary = solary,
                                          CountProject = projects);
            workrs.Add(tempWorker);
            var Dlt = new Department(); // Создание экземпляра класса , здесь потому если в начале класса то вызывает переполнение памяти 
            Dlt.ChangeDepsWorkerAdd(tempWorker, workDept);
        }
        /// <summary>
        /// Метод редактирование сотрудника 
        /// </summary>
        public void EditWorker()
        {
            PrintAllWorkers();
            Console.WriteLine("Введите ID работника:");
            int id = Convert.ToInt32(Check.InputCheck(true, true))-1;

            Console.WriteLine("Введите следющую информацию о работнике: ");

            Console.Write($"Существующее Имя: {workrs[id].FisrtName}.\t Новое имя: ");
            string firstName = Check.InputCheck(false, false);                    // допускается пустая строка для сохранения старого имени
            if (firstName == "") { firstName = workrs[id].FisrtName; }
            Console.Write($"Существующая Фамилия: {workrs[id].LastName}.\t Новая Фамилия: ");
            string lastName = Check.InputCheck(false, false);
            if (lastName == "") { lastName = workrs[id].LastName; }
            Console.Write($"Существующий возраст: {workrs[id].Age}.\t Новый возраст: ");
            string age = Check.InputCheck(false, true);
            int tempAge;
            if (age == "") { tempAge = workrs[id].Age; } else { tempAge = Int32.Parse(age); }
            Console.Write($"Существующий отдел: {workrs[id].WorkDept}.\t Новый отдел: ");
            string dept = Check.InputCheck(false, false);
            string oldDep = "";                                       //сохраняем старое название отдела для редактирования отделов
            if (dept == "") { dept = workrs[id].WorkDept; } else { oldDep = workrs[id].WorkDept; }
            Console.Write($"Существующая зарплата: {workrs[id].Solary}.\t Новая зарплата: ");
            int tempSolary;
            string solary = Check.InputCheck(false, true);
            if (solary == "") { tempSolary = workrs[id].Solary; } else { tempSolary = Int32.Parse(solary); }
            Console.Write($"Существующие проекты: {workrs[id].CountProject}.\t Изменить кол-во проектов: ");
            int tempPrj;
            string projects = Check.InputCheck(false, true);
            if (projects == "") { tempPrj = workrs[id].CountProject; } else { tempPrj = Int32.Parse(projects); }

            Works tempWorker = new Works(workrs[id].WorkID,
                                              firstName,
                                              lastName,
                                              tempAge,
                                              dept,
                                              tempSolary,
                                              tempPrj);
            workrs[id] = tempWorker;
            if (dept != "") // при изменении отдела сотрудника
            {
                var Dlt = new Department();
                Dlt.ChangeDepsWorkerAdd(tempWorker, dept); // добавляется в новый отдел
                Dlt.ChangeDepsWorkerDel(oldDep); // удаляется из старого
            }

            Console.WriteLine(workrs[id].Print());
        }
        /// <summary>
        /// метод удаления сотрудника из списков
        /// </summary>
        public void DeleteWorker()
        {
            PrintAllWorkers();
            Console.WriteLine("Введите ID работника:");
            int id = Convert.ToInt32(Check.InputCheck(true, true));
            string depName = workrs[id].WorkDept;
            var Dlt = new Department();
            Dlt.ChangeDepsWorkerDel(depName); // удаление сотрудника из списка отдела
            workrs.Remove(workrs[id]);
        }

        /// <summary>
        ///  метод выводящий на экран сотрудников отдела
        /// </summary>
        /// <param name="deptName">имя отдела</param>
        public void PrintDeptWorkers(string deptName)
        {
            PrintTitle();
            for (int i = 0; i < workrs.Count; i++)
            {
                if (workrs[i].WorkDept == deptName) { Console.WriteLine(workrs[i].Print()); }
            }
        }
        /// <summary>
        /// Метод возвращающий список работников в отделе
        /// </summary>
        /// <param name="depName"> Имя отдела </param>
        /// <returns>список работников отдела depName </returns>
        public List<Works> DepsList(string depName)
        {
            List<Works> tempWorkers = new List<Works>(); // создается временный список работников
            for (int i = 0; i < workrs.Count; i++)  // цикл проходит по основному списку
            {
                if (workrs[i].WorkDept == depName) { tempWorkers.Add(workrs[i]); } //  выбирает тех у кого имя отдела совпадает с заданым
            }
            return tempWorkers; //складывает во временый лист и возвращает его в свойство отдела
        }
        /// <summary>
        /// метод печатующий заголовки 
        /// </summary>
        private void PrintTitle()
        {
            Console.WriteLine("Таб.номер\tИмя\t\tФамилия\t\tВозраст\t\t Название отдела\tЗарплата\tКоличество проектов\n ");
        }
        /// <summary>
        /// Метод возвращающий сотрудника для печати 
        /// </summary>
        /// <returns></returns>
        private string Print()
        {
            return $"   {this.WorkID}\t\t{this.FisrtName}\t\t{this.LastName}\t\t{this.Age}\t {this.WorkDept}\t\t{this.Solary}\t\t{this.CountProject}";
        }

        #endregion

        #region Методы для тестов
        public void AddWorkersTest(string firstName, string lastName, int age, string workDept, int solary, int projects)
        {
            int workID = (workrs.Count == 0 ? 0 : workrs.Count); // проверка на пустой список сотрудников



            Works tempWorker = new Works(WorkID = workID + 1, // Табельный номер нового сотрудника
                                          FisrtName = firstName, // Имя сотрудника
                                          LastName = lastName,
                                          Age = age,
                                          WorkDept = workDept,
                                          Solary = solary,
                                          CountProject = projects);
            workrs.Add(tempWorker);
            var Dlt = new Department();
            Dlt.ChangeDepsWorkerAdd(tempWorker, workDept);
        }

        #endregion
    }
}
