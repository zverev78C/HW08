using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace из_файла
{
    /// <summary>
    /// Структура описывающий отдел 
    /// </summary>
    public class Department
    {
        #region свойства 

        /// <summary>
        /// Название отдела 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Время создания отдела  
        /// </summary>
        public DateTime RegDate { get; set; }
        /// <summary>
        /// Список сотрудников отдела   
        /// </summary>
        public List<Worker> Workers { get; set; }

        #endregion

        #region конструкторы  

        public Department(string name, DateTime date, List<Worker> list)
        {
            Name = name;
            RegDate = date;
            Workers = list;
        }

        public Department()
        {
        }


        #endregion

        #region Методы

        /// <summary>
        /// Метод выводящий заголовки отделов в консоль 
        /// </summary>
        public static void PrintTitle()
        {
            Console.WriteLine("Индекс\tНазвание\t\tдата создания отдела\tкол-во работников\n ");
        }


        #endregion

    }
}
