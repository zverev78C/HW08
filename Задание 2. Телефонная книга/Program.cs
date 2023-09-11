using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2.Телефонная_книга
{
    internal class Program
    {
        #region Задание 2. Телефонная книга
        //Что нужно сделать
        //Пользователю итеративно предлагается вводить в программу номера телефонов и ФИО их владельцев.
        //В процессе ввода информация размещается в Dictionary, где ключом является номер телефона, а значением — ФИО владельца.
        //Таким образом, у одного владельца может быть несколько номеров телефонов.
        //Признаком того, что пользователь закончил вводить номера телефонов, является ввод пустой строки. 
        //Далее программа предлагает найти владельца по введенному номеру телефона.
        //Пользователь вводит номер телефона и ему выдаётся ФИО владельца.
        //Если владельца по такому номеру телефона не зарегистрировано, программа выводит на экран соответствующее сообщение.
        //Совет
        //Для того, чтобы находить значение в Dictionary, нужно использовать TryGetValue.

        //Что оценивается
        //Программа разделена на логические методы.
        //Для хранения элементов записной книжки используется Dictionary.
        #endregion
        static void Main()
        {
            Dictionary<double, string> phoneBook = new Dictionary<double, string>(); // сама книга 
            bool run = true;
            do
            {
                Console.WriteLine("\nТелефонная Книга\n\n");
                Console.WriteLine("Добавить запись:\t1\n" +
                    "Поиск по номеру:\t2\n" +
                    "Поиск по имени: \t3\n" +
                    "Выход: \t\t\tq");

                string str = Console.ReadLine();
                switch (str.ToLower())
                {
                    case "1": AddNote(); break;
                    case "2": SearchByNum(); break;
                    case "3": SearchByName(); break;
                    case "q": run = false; break;
                }
            } while (run);


            void AddNote()
            {
                Console.Clear();
                phoneBook.Add(79219842905, "Zverev78");
            }

            void SearchByNum()
            {
                Console.Clear();
            }

            void SearchByName()
            {
                Console.Clear();
            }
        }
    }
}
