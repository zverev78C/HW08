using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace из_файла
{

    class Foundat
    {
        /*
         Просмотр всех сотрудников      PrintAllWorkers()
         Создание сотрудника            AddWorkers()
         Редактирование сотрудника      EditWorker()
         * 
         * 
         Просмотр отделов               Print()
         Создание нового Отдела         NewDepartment()
         Редактирование отдела          EditDept()
         Удаление отдела                DeleteDept()
         *
         *
         Сохранение в 
          */

        /// <summary>
        /// Метод контроля ввода данных от пользователя
        /// </summary>
        /// <param name="noNull">возможно оставть пустую строку</param>
        /// <param name="num"> ожидается число Int </param>
        /// <returns> строку которую при необходимости надо конвертировать в int </returns>
        public string InputCheck(bool noNull, bool num)
        {
            string str = Console.ReadLine();
            if (noNull == true)
            {
                while (str == "")
                {
                    Console.WriteLine("Строка не должна быть пустой.");
                    str = Console.ReadLine();
                }
            }
            if (num == true && noNull == true)
            {
                while (true)
                {
                    bool result = int.TryParse(str, out int id);
                    if (result == false)
                    {
                        Console.WriteLine("В строке должно быть целое число");
                        Console.ReadLine();

                    }
                    else { break; }
                }
            }
            return str;
        }

    }



    /// <summary>
    /// Класс Отделов 
    /// </summary>
    class Delete
    {
        Works Wrks = new Works();
        Foundat Fdt = new Foundat();
        List<Delete> Deps = new List<Delete>();

        #region свойства 
        private string Name { get; set; }
        private DateTime RegDate { get; set; }
        private List<Works> wrks { get; set; }
        #endregion

        #region конструкторы  

        private Delete(string name, DateTime date, List<Works> list)
        {
            Name = name;
            RegDate = date;
            wrks = list;
        }
        public Delete()
        {
        }
        #endregion

        #region методы 

        /// <summary>
        /// Метод создания нового отдела
        /// </summary>
        public void NewDepartment()
        {
            string name = "";
            name = Fdt.InputCheck(true, false);
            List<Works> depList = new List<Works>();
            depList = Wrks.DepsList(name);

            Deps.Add(new Delete(Name = name, RegDate = DateTime.Now, wrks = depList));
        }
        /// <summary>
        /// Метод добовляющий нового сотрудника при создании в соответствующий список отдела 
        /// </summary>
        /// <param name="newWorker"></param>
        /// <param name="deptName"></param>
        public void ChangeDepsWorkerAdd(Works newWorker, string deptName)
        {
            for (int i = 0; i < Deps.Count; i++)
            {
                if (Deps[i].Name == deptName)
                {
                    Deps[i].wrks.Add(newWorker);
                }
            }
        }
        /// <summary>
        /// Метод удаления сотрудника из списка отдела 
        /// </summary>
        /// <param name="deptName"></param>
        public void ChangeDepsWorkerDel(string deptName)
        {
            for (int i = 0; i < Deps.Count; i++)
            {
                if (Deps[i].Name == deptName)
                {
                    Deps[i].wrks = Wrks.DepsList(deptName); // просто заменяет старый список сотрудников новым без переведеного сотрудника
                }
            }
        }
        /// <summary>
        /// Метод редактирующий название отдела 
        /// </summary>
        public void EditDept()
        {
            Print();

            Console.Write("Введите индекс отдела: ");
            string name = Fdt.InputCheck(true, true); // проверка ввода пользователя
            int itr = Int32.Parse(name);
            if (itr >= Deps.Count) // проверка что такой отдел существует ( не превышает индекс самого большого отдела)
            {
                Console.WriteLine($"Отдела с индексом: {itr}, не существует.");
            }
            else
            {
                Console.WriteLine("Введите новое название:");
                string newName = Fdt.InputCheck(true, false);
                Deps[itr].Name = newName;

            }
            Print();
        }
        /// <summary>
        /// Метод выводящий на экран все отделы с индексом
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Индекс\t   Название\t\tдата создания отдела\t\tкол-во работников\n ");
            for (int i = 0; i < Deps.Count; i++)
            {
                Console.WriteLine($"{i}  {Deps[i].Name}\t\t{Deps[i].RegDate:D}\t\t{Deps[i].wrks.Count} ");
            }
        }
        /// <summary>
        /// Метод условного удаления отдела 
        /// </summary>
        public void DeleteDept()
        {
            Print();

            Console.Write("Введите индекс отдела: ");
            string name = Fdt.InputCheck(true, true); // проверка ввода пользователя
            int itr = Int32.Parse(name);
            if (itr >= Deps.Count) // проверка что такой отдел существует ( не превышает индекс самого большого отдела)
            {
                Console.WriteLine($"Отдела с индексом: {itr}, не существует.");
            }
            else
            {
                if (Deps[itr].wrks.Count == 0) // проверка что в отделе нет работников
                {
                    Deps.RemoveAt(itr);
                }
                else
                {
                    Console.WriteLine($"Невозможно удалить отдел пока в нем работают люди. {Deps[itr].wrks.Count} человек.\n");
                    Wrks.PrintDeptWorkers(Deps[itr].Name);     // выводит на экран список работников
                }
            }
        }
        #endregion
    }



    /// <summary>
    /// Класс сотрудников 
    /// </summary>
    class Works
    {
        Foundat Fdt = new Foundat();
        Delete Dlt = new Delete();
        private List<Works> workrs = new List<Works>(); // список всех сотрудников

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
            int id = Convert.ToInt32( Fdt.InputCheck(true,true));

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
                Dlt.ChangeDepsWorkerDel( oldDep); // удаляется из старого
            }

           Console.WriteLine(workrs[id].Print());
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

    }

}
