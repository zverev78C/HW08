using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace из_файла
{
    struct Department
    {
        #region свойства 

        public string DepName { get; set; }

        public DateTime RegDate { get; set; }

        public int WorkerCount { get; set; }

        #endregion

        #region  Конструктор

        public Department(string depName, int count)
        {
            DepName = depName;
            RegDate = DateTime.Now;
            WorkerCount = count;
        }

        #endregion

        /// <summary>
        /// метод создания нового отдела
        /// </summary>
        /// <param name="name">Название отдела</param>
        /// <returns></returns>
        public Department CreateDept(string name)
        {
            int count = 0; // поскольку это новый отдел то и количество работников в нем 0
            Department newdep = new Department(name, count);
            return newdep;
        }

        public string Print ()
        {
           return $"  {this.DepName}\t\t{this.RegDate:D}\t\t{this.WorkerCount} ";
        }

        public void Title ()
        {
            // Console.Clear();
            Console.WriteLine("Индекс\t   Название\t\tдата создания отдела\t\tкол-во работников\n ");
        }
    
        public Department ChangeName( Department name, string newName) 
        {
        name.DepName = newName;
            return name;
        }
    }
}
