using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1.Работа_с_листом
{
    internal class Program
    {
        static void Main()
        {
            #region Задание 1. Работа с листом
            /*
            Что нужно сделать
            Создайте лист целых чисел. 
            Заполните лист 100 случайными числами в диапазоне от 0 до 100. 
            Выведите коллекцию чисел на экран. 
            Удалите из листа числа, которые больше 25, но меньше 50. 
            Снова выведите числа на экран. 
            Рекомендация
            Сделайте отдельные методы для заполнения, удаления и вывода на экран.

            Что оценивается
            В программе используется три отдельных метода. 
            В качестве хранилища данных используется List.
             */
            #endregion

            List<int> nums = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < 100; i++) // Заполнение списка случайными числами
            {
                nums.Add(Num());
            }

            Print(nums); // Вывод полного списка на экран
            nums = DeleteNums(nums); // удаление из списка чисел
            Print(nums); // Вывод отредактированого списка на экран
            Console.ReadKey();



            #region Методы 
            // метод рандомного заполнения колекции
            int Num()
            {
                return rnd.Next(0, 100);
            }
            // метод удаления из списка чисел 25-50
            List<int> DeleteNums(List<int> list)
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] > 24 && nums[i] < 51) { nums.Remove(nums[i]); i--; }
                }
                return list;
            }
            // Метод вывода на экран списка
            void Print(List<int> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write($"{list[i].ToString()} ");
                }
                Console.WriteLine($"\n\nДлина коллекции: {nums.Count}");
            }
            #endregion
        }
    }
}
