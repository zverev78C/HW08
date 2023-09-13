using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace из_файла
{
    struct Workers
    {
        #region свойства 
        public int WorkID { get; set; }
        private string FisrtName { get; set; }
        private string LastName { get; set; }
        private int Age { get; set; }
        public string WorkDept { get; set; }
        private int Solary { get; set; }
        private int CountProject { get; set; }
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
    }
}
