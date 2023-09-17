using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace из_файла
{
    class Department
    {
        Workers work = new Workers();
        static List<Workers> Wrk = new List<Workers>();

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



        #region Методы 

        /// <summary>
        /// Метод добавления нового отдела 
        /// </summary>
        /// <returns></returns>
        public static Department CreateDept()
        {
            Console.Write("Введите название нового отдела: ");
            string name = Console.ReadLine();
            int count = CountWokers(name);
            Department newdep = new Department(name, count);
            return newdep;
        }

        /// <summary>
        /// Метод подсчета количества работников в отделе 
        /// </summary>
        /// <param name="name">Имя отдела</param>
        /// <returns></returns>
        private static int CountWokers(string name)
        {
            var dictionary = new Dictionary<string, int>();
            for (int i = 0; i < Wrk.Count; i++)
            {
                if (!dictionary.ContainsKey($"{Wrk[i].WorkDept}")) dictionary.Add($"{Wrk[i].WorkDept}", 0);
                dictionary[$"{Wrk[i].WorkDept}"]++;
            }
            int count;
            try { count = dictionary[name]; }
            catch { count = 0; }

            return count;
        }

        #endregion
    }
}