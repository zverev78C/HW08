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
        /*
        Что нужно сделать
        Пользователю итеративно предлагается вводить в программу номера телефонов и ФИО их владельцев.
        В процессе ввода информация размещается в Dictionary, где ключом является номер телефона, а значением — ФИО владельца.
        Таким образом, у одного владельца может быть несколько номеров телефонов.
        Признаком того, что пользователь закончил вводить номера телефонов, является ввод пустой строки. 
        Далее программа предлагает найти владельца по введенному номеру телефона.
        Пользователь вводит номер телефона и ему выдаётся ФИО владельца.
        Если владельца по такому номеру телефона не зарегистрировано, программа выводит на экран соответствующее сообщение.
        Совет
        Для того, чтобы находить значение в Dictionary, нужно использовать TryGetValue.

        Что оценивается
        Программа разделена на логические методы.
        Для хранения элементов записной книжки используется Dictionary.
        */
        #endregion
        static void Main()
        {
            var /* Dictionary<double, string> */phoneBook = new Dictionary<double, string>(); // сама книга 

            AddNote();

            #region Методы 

            void AddNote()
            {
                Console.Write("Введите номер телефона:  ");
                string str = Console.ReadLine();
                if (str == "")
                {
                    MainMenu();
                }
                else
                {
                    try //проверка коректности ввода номера 
                    {
                        double num = Convert.ToDouble(str); // ввод номера телефон 79219842905
                        if (num < 10000000000 || num > 99999999999)
                        {
                            Console.WriteLine("Номер слишком короткий");
                            Console.ReadKey();
                            AddNote();
                        }
                        else
                        {
                            if (phoneBook.TryGetValue(num, out string name))// проверка наличия такогог номера в словаре
                            {
                                Console.WriteLine($"Такой номер существует для {name}"); // если номер существует выводится собщение
                            }
                            else // если такого номера нет то просит ввести имя 
                            {
                                Console.Write("Введите имя:   ");
                                name = Console.ReadLine();
                                phoneBook.Add(num, name); // добавляет новую пару в словарь
                            }
                            Console.WriteLine($"{num}");
                            Console.ReadKey();
                            AddNote();
                        }
                    }
                    catch (FormatException) // если номер введен не коректно то выводится сообщение
                    {
                        Console.WriteLine("Не верный формат телефона");
                        Console.ReadKey();
                        AddNote();
                    }

                }
            }

            void MainMenu()
            {
                Console.WriteLine("\nТелефонная Книга\n\n");
                Console.WriteLine("Добавить запись:\t1\n" +
                    "Поиск:\t\t\t2\n" +
                    "Поиск по имени:\t\t3\n" +
                    "Удаление записи:\t4\n" +
                    "Выход:\t\t\tQ");

                string str = Console.ReadLine();
                switch (str.ToLower())
                {
                    case "1": AddNote(); break;
                    case "2": Search(); break;
                    //case "3": SearchByName(); break;

                    default: Console.WriteLine("Не верный выбор! Нажмите любую кнопку. (кроме reset и power)"); Console.ReadKey(); Console.Clear(); break;
                }

                Console.WriteLine($"\nВсего телефонов в книге: {phoneBook.Count}");
                Console.ReadKey();
            }

            void Search()
            {

            }

            #endregion
        }

    }
}
