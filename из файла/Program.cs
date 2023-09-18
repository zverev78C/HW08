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
        #region
        /*
        Создать прототип информационной системы,
        в которой есть возможност работать со структурой организации
        В структуре присутствуют департаменты и сотрудники
        Каждый департамент может содержать не более 1_000_000 сотрудников.
        У каждого департамента есть поля:
        наименование,
        дата создания,
        количество сотрудников числящихся в нём 
        (можно добавить свои пожелания)
        
        У каждого сотрудника есть поля:
        Фамилия, 
        Имя
        , Возраст, 
        департамент в котором он числится, 
        уникальный номер,
        размер оплаты труда, 
        количество закрепленным за ним.
        
        В данной информаиционной системе должна быть возможность 
        - импорта и экспорта всей информации в xml и json
        Добавление, удаление, редактирование сотрудников и департаментов
        
        * Реализовать возможность упорядочивания сотрудников в рамках одно департамента 
        по нескольким полям, например возрасту и оплате труда
        
         №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
         1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
         2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
         3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
         4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
         5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
         6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
         7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
         8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
         9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
        10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
        
        
        Упорядочивание по одному полю возраст
        
         №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
         2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
        10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
         9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
         3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
         5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
         6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
         1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
         8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
         7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
         4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        
        
        Упорядочивание по полям возраст и оплате труда
        
         №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
        10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
         2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
         9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
         6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
         3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
         5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
         1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
         7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
         8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
         4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        
        
        Упорядочивание по полям возраст и оплате труда в рамках одного департамента
        
         №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
         9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
         6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
         3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
         1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
         7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
         8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
         4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
        10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 
         2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
         5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
        
        */
        #endregion

        static void Main()
        {
            Works Wrk = new Works();
            Department Dlt = new Department();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Информационная система!\n\n");
                Console.WriteLine("Для работы с системой выберите пункт меню:\n" +
                    "100\tДля тестового заполнения БД\n" +
                    "1\tДля просмотра всех сотрудников\n" +
                    "2\tДля просмотра всех отделов" +
                    "3\tДля сохранения базы данных" +
                    "4\tДля выхода из программы"
                    );
                switch (InputCheck(true, false))
                {
                    case "1": Workers(); break;
                    case "2": break;
                    case "3": break;
                    case "4": flag = false; break;
                }

                void Workers()
                {
                    Console.Clear();
                    Console.WriteLine("Информационная система!\n\n");
                    Console.WriteLine("Для работы с системой выберите пункт меню:\n" +
                        "100\tДля тестового заполнения БД\n" +
                        "1\tДля просмотра всех сотрудников\n" +
                        "2\tДля просмотра всех отделов" +
                        "3\tДля сохранения базы данных" +
                        "4\tДля выхода из программы"
                        );
                }
                /*
              Просмотр всех сотрудников      PrintAllWorkers()
              Создание сотрудника            AddWorkers()
              Редактирование сотрудника      EditWorker()
              Удаление сотрудника            DeleteWorker()
              * 
              * 
              Просмотр отделов               Print()
              Создание нового Отдела         NewDepartment()
              Редактирование отдела          EditDept()
              Удаление отдела                DeleteDept()
              *
              *
              Сохранение в 
               */


                void Test()
                {
                    Random rnd = new Random();
                    Console.WriteLine("\n\nТестовый режим, автоматическое заполнение БД.");

                    // Тестовое заполнение списка отделов случайным количеством.
                    int testDept = rnd.Next(1, 10);

                    // Тестовое заполнение списка сотрудников случайным количеством.
                    int testWokers = rnd.Next(10, 100);
                    int testWokerAge = rnd.Next(20, 63);
                    int testSolary = rnd.Next(30000, 100000);
                    int testCountProject = rnd.Next(0, 5);

                    for (int i = 0; i <= testWokers; i++)
                    {
                        Wrk.AddWorkersTest($"Вася_{i}", $"Пупкин_{i}", testWokerAge, $"Отдел {rnd.Next(1, testDept + 1)}", testSolary, testCountProject);
                    }

                    for (int i = 1; i <= testDept; i++)
                    {
                        Dlt.NewDepartmentTest($"Отдел {i}");
                    }

                    Console.WriteLine($"\nСоздано {testDept} Отделов");
                    Dlt.Print();
                    Console.WriteLine($"Создано {testWokers} сотрудников\n\n");
                    Wrk.PrintAllWorkers();
                }
            }
            /// <summary>
            /// Метод контроля ввода данных от пользователя
            /// </summary>
            /// <param name="noNull">возможно оставть пустую строку</param>
            /// <param name="num"> ожидается число Int </param>
            /// <returns> строку которую при необходимости надо конвертировать в int </returns>
            public string InputCheck(bool noNull, bool num)
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
        struct test
        {

        }
    }
