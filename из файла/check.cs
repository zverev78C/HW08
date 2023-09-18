using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace из_файла
{
    internal class Check
    {
        Department Dlt = new Department();

       public static string InputCheck(bool noNull, bool num)
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
                    bool result = int.TryParse(str, out _);
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
}
