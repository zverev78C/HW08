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
    }
}