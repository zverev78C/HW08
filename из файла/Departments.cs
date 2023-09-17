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

        public void Print (int index)
        {
            Console.WriteLine($"{index}\t{DepName}\t{RegDate:D}\t{WorkerCount} ");
        }

        public void Title ()
        {
            // Console.Clear();
            Console.WriteLine("Индекс\tНазвание\tдата создания отдела\tкол-во работников\n ");
        }
    

    }
}
