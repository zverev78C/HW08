using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace из_файла
{
    class Department
    {
        readonly Works Wrks = new Works();
        readonly Program Fdt = new Program();
        readonly List<Department> Deps = new List<Department>();

        #region свойства 
        private string Name { get; set; }
        private DateTime RegDate { get; set; }
        private List<Works> Works { get; set; }
        #endregion

        #region конструкторы  

        private Department(string name, DateTime date, List<Works> list)
        {
            Name = name;
            RegDate = date;
            Works = list;
        }
        public Department()
        {
        }
        #endregion

        #region методы 

        /// <summary>
        /// Метод создания нового отдела
        /// </summary>
        public void NewDepartment()
        {
            string name = Fdt.InputCheck(true, false);
            _ = new List<Works>();
            List<Works> depList = Wrks.DepsList(name);

            Deps.Add(new Department(Name = name, RegDate = DateTime.Now, Works = depList));
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
                    Deps[i].Works.Add(newWorker);
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
                    Deps[i].Works = Wrks.DepsList(deptName); // просто заменяет старый список сотрудников новым без переведеного сотрудника
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
                Console.WriteLine($"{i}  {Deps[i].Name}\t\t{Deps[i].RegDate:D}\t\t{Deps[i].Works.Count} ");
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
                if (Deps[itr].Works.Count == 0) // проверка что в отделе нет работников
                {
                    Deps.RemoveAt(itr);
                }
                else
                {
                    Console.WriteLine($"Невозможно удалить отдел пока в нем работают люди. {Deps[itr].Works.Count} человек.\n");
                    Wrks.PrintDeptWorkers(Deps[itr].Name);     // выводит на экран список работников
                }
            }
        }
        #endregion
    }
}
