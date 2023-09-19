using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace из_файла
{
    internal class MyMetods
    {
        /// <summary>
        /// Метод проверки ввода данных от пользователя  
        /// </summary>
        /// <param name="noNull"> Допускается ли пустая строка </param>
        /// <param name="num"> ожидается ли число </param>
        /// <returns></returns>
        public static string InputCheck(bool noNull, bool num) // требует статичный метод уточнить
        {
            string str = Console.ReadLine(); // Ввод проверяемого значения 
            if (noNull == true) // проверка на пустоту 
            {
                while (str == "") // цикл не позволяющий дальнеешее выполнение программы пока не будет удволетварено требование 
                {
                    Console.WriteLine("Строка не должна быть пустой.");
                    str = Console.ReadLine();
                }
            }
            if (num == true && noNull == true) // проверяем не ожидается ли число в итоге
            {
                while (true)  // цикл не позволяющий дальнеешее выполнение программы пока не будет удволетварено требование 
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
