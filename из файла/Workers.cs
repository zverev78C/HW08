using System;
using System.Collections.Generic;

namespace из_файла
{
    /// <summary>
    /// Класс сотрудников 
    /// </summary>
    class Works
    {
        readonly Program Fdt = new Program();
        readonly Department Dlt = new Department();
        private readonly List<Works> workrs = new List<Works>(); // список всех сотрудников

        #region свойства 
        private int WorkID { get; set; } // Табельный номер
        private string FisrtName { get; set; }// Имя
        private string LastName { get; set; } // Фамилия
        private int Age { get; set; } // Возраст
        private string WorkDept { get; set; }// Отдел
        private int Solary { get; set; } // ЗряПлата
        private int CountProject { get; set; } // Количество проектов
        #endregion

        #region Конструкторы 

        private Works(int workID, string firstName, string lastName,
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
            string firstName = Fdt.InputCheck(true, false);
            Console.Write("Фамилия сотрудника:  ");
            string lastName = Fdt.InputCheck(true, false);
            Console.Write("Возраст сотрудника:  ");
            int age = Convert.ToInt32(Fdt.InputCheck(true, true));
            Console.Write("Отдел сотрудника:  ");
            string workDept = Fdt.InputCheck(true, false);
            Console.Write("Зарплата сотрудника:  ");
            int solary = Convert.ToInt32(Fdt.InputCheck(true, true));
            Console.Write("Количество проектов сотрудника:  ");
            int projects = Convert.ToInt32(Fdt.InputCheck(true, true));

            Works tempWorker = new Works(WorkID = workID + 1, // Табельный номер нового сотрудника
                                          FisrtName = firstName, // Имя сотрудника
                                          LastName = lastName,
                                          Age = age,
                                          WorkDept = workDept,
                                          Solary = solary,
                                          CountProject = projects);
            workrs.Add(tempWorker);
            Dlt.ChangeDepsWorkerAdd(tempWorker, workDept);
        }
        /// <summary>
        /// Метод редактирование сотрудника 
        /// </summary>
        public void EditWorker()
        {
            PrintAllWorkers();
            Console.WriteLine("Введите ID работника:");
            int id = Convert.ToInt32(Fdt.InputCheck(true, true));

            Console.WriteLine("Введите следющую информацию о работнике: ");

            Console.WriteLine($"Существующее Имя: {workrs[id].FisrtName}.\t Новое имя: ");
            string firstName = Fdt.InputCheck(false, false);                    // допускается пустая строка для сохранения старого имени
            if (firstName == "") { firstName = workrs[id].FisrtName; }
            Console.WriteLine($"Существующая Фамилия: {workrs[id].LastName}.\t Новая Фамилия: ");
            string lastName = Fdt.InputCheck(false, false);
            if (lastName == "") { lastName = workrs[id].LastName; }
            Console.WriteLine($"Существующий возраст: {workrs[id].Age}.\\t Новый возраст: ");
            string age = Fdt.InputCheck(false, true);
            int tempAge;
            if (age == "") { tempAge = workrs[id].Age; } else { tempAge = Int32.Parse(age); }
            Console.WriteLine($"Существующий отдел: {workrs[id].WorkDept}.\\t Новый отдел: ");
            string dept = Fdt.InputCheck(false, false);
            string oldDep = "";                                       //сохраняем старое название отдела для редактирования отделов
            if (dept == "") { dept = workrs[id].WorkDept; } else { oldDep = workrs[id].WorkDept; }
            Console.WriteLine($"Существующая зарплата: {workrs[id].Solary}.\\t Новая зарплата: ");
            int tempSolary;
            string solary = Fdt.InputCheck(false, true);
            if (solary == "") { tempSolary = workrs[id].Solary; } else { tempSolary = Int32.Parse(solary); }
            Console.WriteLine($"Существующие проекты: {workrs[id].CountProject}.\\t Изменить кол-во проектов: ");
            int tempPrj;
            string projects = Fdt.InputCheck(false, true);
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
            int id = Convert.ToInt32(Fdt.InputCheck(true, true));
            string depName = workrs[id].WorkDept;
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
            List<Works> tempWorkers = new List<Works>();
            for (int i = 0; i < workrs.Count; i++)
            {
                if (workrs[i].WorkDept == depName) { tempWorkers.Add(workrs[i]); }
            }
            return tempWorkers;
        }
        /// <summary>
        /// метод печатующий заголовки 
        /// </summary>
        private void PrintTitle()
        {
            Console.WriteLine("Таб.№\t   Имя\t  Фамилия\t Возраст\t Yfpdfybt отдела\t Зарплата\t Количество проектов\n ");
        }
        /// <summary>
        /// Метод возвращающий сотрудника для печати 
        /// </summary>
        /// <returns></returns>
        private string Print()
        {
            return $"{this.WorkID}  {this.FisrtName} {this.LastName} {this.Age} {this.WorkDept} {this.Solary} {this.CountProject}";
        }

        #endregion

        #region Методы для тестов
        public void AddWorkersTest(string firstName, string lastName,int age,string workDept,int solary,int projects)
        {
            int workID = (workrs.Count == 0 ? 0 : workrs.Count); // проверка на пустой список сотрудников
            /*Console.Write("Имя сотрудника:  ");
            string firstName = Fdt.InputCheck(true, false);
            Console.Write("Фамилия сотрудника:  ");
            string lastName = Fdt.InputCheck(true, false);
            Console.Write("Возраст сотрудника:  ");
            int age = Convert.ToInt32(Fdt.InputCheck(true, true));
            Console.Write("Отдел сотрудника:  ");
            string workDept = Fdt.InputCheck(true, false);
            Console.Write("Зарплата сотрудника:  ");
            int solary = Convert.ToInt32(Fdt.InputCheck(true, true));
            Console.Write("Количество проектов сотрудника:  ");
            int projects = Convert.ToInt32(Fdt.InputCheck(true, true));
            */

            Works tempWorker = new Works(  WorkID = workID + 1, // Табельный номер нового сотрудника
                                          FisrtName = firstName, // Имя сотрудника
                                          LastName = lastName,
                                          Age = age,
                                          WorkDept = workDept,
                                          Solary = solary,
                                          CountProject = projects );
            workrs.Add(tempWorker);
            Dlt.ChangeDepsWorkerAdd(tempWorker, workDept);
        }

        #endregion
    }
}
