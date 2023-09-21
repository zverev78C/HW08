﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace из_файла
{
    class Program
    {
        #region что нужно сделать 

        //Создать прототип информационной системы,
        //в которой есть возможност работать со структурой организации
        //В структуре присутствуют департаменты и сотрудники
        //Каждый департамент может содержать не более 1_000_000 сотрудников.
        //У каждого департамента есть поля:
        //наименование,
        //дата создания,
        //количество сотрудников числящихся в нём 
        //(можно добавить свои пожелания)

        //У каждого сотрудника есть поля:
        //Фамилия, 
        //Имя
        //, Возраст, 
        //департамент в котором он числится, 
        //уникальный номер,
        //размер оплаты труда, 
        //количество закрепленным за ним.

        //В данной информаиционной системе должна быть возможность 
        //- импорта и экспорта всей информации в xml и json
        //Добавление, удаление, редактирование сотрудников и департаментов

        //* Реализовать возможность упорядочивания сотрудников в рамках одно департамента 
        //по нескольким полям, например возрасту и оплате труда

        // №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        // 1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
        // 2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        // 3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
        // 4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        // 5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
        // 6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
        // 7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
        // 8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
        // 9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        //10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 


        //Упорядочивание по одному полю возраст

        // №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        // 2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        //10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
        // 9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        // 3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
        // 5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
        // 6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
        // 1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
        // 8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
        // 7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
        // 4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 


        //Упорядочивание по полям возраст и оплате труда

        // №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        //10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
        // 2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        // 9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        // 6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
        // 3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
        // 5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
        // 1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
        // 7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
        // 8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
        // 4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 


        //Упорядочивание по полям возраст и оплате труда в рамках одного департамента

        // №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        // 9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        // 6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
        // 3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
        // 1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
        // 7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
        // 8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
        // 4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        //10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
        // 2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        // 5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 


        #endregion

        static void Main()
        {
            bool flag = true;
            var Org = new Organization();
            string filePath = "list.xml";

            while (flag)
            {
                Console.WriteLine("\nИнформационная система!\n\n");
                Console.WriteLine("Для работы с системой выберите пункт меню:\n" +
                    "100\tДля тестового заполнения БД\n" +
                    "1\tДля просмотра всех сотрудников\n" +
                    "2\tДля просмотра всех отделов\n" +
                    "3\tДля сохранения базы данных\n" +
                    "4\tДля выхода из программы"
                    );

                switch (MyMetods.InputCheck(true, false))
                {
                    case "100": Test(); break;  // Тестовый запуск
                    case "1": // Работа с сотрудниками
                        {
                            Console.WriteLine("Для работы с системой выберите пункт меню:\n" +
                                              "1\tДля просмотра всех сотрудников\n" +
                                              "2\tДля Создания нового сотрудника\n" +
                                              "3\tДля Редактирования сотрудника\n" +
                                              "4\tДля Удаления сотрудника\n" +
                                              "5\tДля сортировки сотрудников\n" +
                                              "6\tДля выхода из меню"
                                              );

                            switch (MyMetods.InputCheck(true, false))
                            {
                                case "1": // Просмотр всех сотрудников 
                                    {
                                        Org.PrintAllWorkers();
                                        break;
                                    }  // Просмотр всех сотрудников 
                                case "2": //Создания нового сотрудника
                                    {
                                        Org.AddWorkers();
                                        break;
                                    } //Создания нового сотрудника
                                case "3": //Редактирования сотрудника
                                    {
                                        Org.EditWorker();
                                        break;
                                    } //Редактирования сотрудника
                                case "4": //Удаления сотрудника
                                    {
                                        Org.DeleteWorker();
                                        break;
                                    } //Удаления сотрудника
                                case "6": { break; }
                                default: Console.WriteLine("Выбор не понятен попробуйте еще разю"); continue;
                            }
                            break;
                        }// Работа с сотрудниками

                    case "2":// работа с отделами
                        {
                            Console.WriteLine("Для работы с системой выберите пункт меню:\n" +
                                              "1\tДля просмотра всех отделов\n" +
                                              "2\tДля Создания нового отдела\n" +
                                              "3\tДля Редактирования отдела\n" +
                                              "4\tДля Удаления отдела\n" +
                                              "5\tДля выхода из меню"
                                              );

                            switch (MyMetods.InputCheck(true, false))
                            {
                                case "1": //печать списка отделов
                                    {
                                        Org.PrintAllDeps();
                                        break;
                                    } //печать списка отделов
                                case "2": //Создания нового отдела
                                    {
                                        Org.NewDepartment();
                                        break;
                                    } //Создания нового отдела
                                case "3":  //редактирование отдела
                                    {
                                        Org.EditDept();
                                        break;
                                    } //редактирование отдела
                                case "4":  //удаление отдела
                                    {
                                        Org.DeleteDept();
                                        break;
                                    } //удаление отдела
                                case "5": { break; }
                                default: Console.WriteLine("Выбор не понятен попробуйте еще разю"); break;
                            }
                            break;
                        }// работа с отделами

                    case "3":
                        {
                            Console.WriteLine("Для работы с системой выберите пункт меню:\n" +
                                              "1\tДля сохранения Xml\n" +
                                              "2\tДля Чтения Xml\n" +
                                              "3\tДля Редактирования отдела\n" +
                                              "4\tДля Удаления отдела\n" +
                                              "5\tДля выхода из меню"
                                              );
                            switch (MyMetods.InputCheck(true, true))
                            {
                                case "1": //печать списка отделов
                                    {
                                        Org.SaveXml(filePath, Org.Deps, Org.Workers);
                                        break;
                                    } //печать списка отделов
                                case "2": //Создания нового отдела
                                    {
                                        Org.Deps = Org.LoadXml(filePath);
                                        break;
                                    } //Создания нового отдела
                                case "3":  //редактирование отдела
                                    {
                                        Org.EditDept();
                                        break;
                                    } //редактирование отдела
                                case "4":  //удаление отдела
                                    {
                                        Org.DeleteDept();
                                        break;
                                    } //удаление отдела
                                case "5": { break; }
                                default: Console.WriteLine("Выбор не понятен попробуйте еще разю"); break;
                            }
                            break;
                        }   // работа с Файлами

                    case "4": flag = false; break; // выход из программы 

                    default: Console.WriteLine("Выбор не понятен попробуйте еще разю"); break;
                }
            }

            /// <summary>
            /// Метод заполняющий списки рандомом
            /// </summary>
            void Test()
            {
                Random rnd = new Random();
                Console.WriteLine("\n\nТестовый режим, автоматическое заполнение БД.");

                // Тестовое заполнение списка отделов случайным количеством.
                int testDept = rnd.Next(1, 10);

                // Тестовое заполнение списка сотрудников случайным количеством.
                int testWokers = rnd.Next(10, 20);

                for (int i = 1; i <= testDept; i++)
                {
                    Org.NewDepartmentTest($"Отдел {i}");
                }

                for (int i = 1; i <= testWokers; i++)
                {
                    Org.AddWorkersTest($"Вася_{i}", $"Пупкин_{i}", rnd.Next(20, 63), $"Отдел {rnd.Next(1, testDept + 1)}", rnd.Next(30000, 100000), rnd.Next(0, 5));
                }

                Console.WriteLine($"\nСоздано {testDept} Отделов\n");
                Org.PrintAllDeps();

                Console.WriteLine($"\nСоздано {testWokers} сотрудников\n");
                Org.PrintAllWorkers();
            }
        }

    }
}
