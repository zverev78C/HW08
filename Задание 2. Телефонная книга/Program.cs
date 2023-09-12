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
                    Search();
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
                                Console.WriteLine($"Номер: {num} добавлен для {name}");
                            }
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

            void Search()
            {
                Console.WriteLine("Поиск по номеру телефона.");
                Console.Write("Введите номер: ");
                string str = Console.ReadLine();
                if (str == "") {}
                else
                {
                    double num = Convert.ToDouble(str);
                    if (phoneBook.TryGetValue(num, out string name))// проверка наличия такого номера в словаре
                    {
                        Console.WriteLine($"Этот номер принадлежит: {name}"); // если номер существует выводится собщение
                        Console.ReadKey();
                    }
                    else // если такого номера нет 
                    {
                        Console.Write("Такого номера в списке нет.");
                        Console.ReadKey();
                        /*
                        name = Console.ReadLine();
                        phoneBook.Add(num, name); // добавляет новую пару в словарь
                        */
                    }
                    Search();
                }
            }

            #endregion
        }

    }
}
