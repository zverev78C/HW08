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
         Удаление сотрудника            DeleteWorker()
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
   

}
