using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Workers> Wrk = new List<Workers>();
            List<Department> Deps = new List<Department>();

            MainMenu();

            #region методы 
            void MainMenu()
            {
                Console.WriteLine("\n100\t Для тестового заполнения.\n\n" +
                    "1\t Для создания Депортаментов.\n" +
                    "2\t Для редактирования Депортаментов.\n" +
                    "3\t Для удаления Депортаментов.\n\n" +

                    "4\t Для создания нового Сотрудников.\n" +
                    "5\t Для редактирования Сотрудников.\n" +
                    "6\t Для удаления Сотрудников.\n" +

                    "7\t Для Сортировки сотрудников\n\n" +

                    "8\t Для Сохранения в XML\n" +
                    "9\t Для Сохранения в JSON\n");

                switch (Console.ReadLine())
                {
                    case "100": Test(); break;
                    case "1": CreateDept(); break;
                    case "2": EditDept(); break;
                    case "3": DeleteDept(); break;
                    case "4": CreateWorker(); break;
                    case "5": EditWorker(); break;
                    case "6": DeleteWorker(); break;
                    case "7": SortWorkers(); break;
                    case "8": SaveAtXML(); break;
                    case "9": SaveAtJson(); break;
                }
            }

            // метод создания отдела
            /* проверка наличия такого отдела*/
            void CreateDept()
            {
                Console.Write("Введите название нового отдела: ");
                string name = Console.ReadLine();
                Deps.Add(new Department(name, CountWokers(name)));
                MainMenu();
            }

            // метод удаления отдела
            /* Переделать на string аргумент и проверку наличия*/
            void DeleteDept()
            {
                Console.Write("Введите индекс отдела: ");
                int itr = Int32.Parse(Console.ReadLine());
                if (itr >= Deps.Count)
                {
                    Console.WriteLine($"Отдела с индексом: {itr}, не существует.");
                }
                else
                {
                    if (Deps[itr].WorkerCount == 0)
                    {
                        Deps.RemoveAt(itr);
                    }
                    else
                    {
                        Console.WriteLine($"Невозможно удалить отдел пока в нем работают люди. {Deps[itr].WorkerCount} человек.\n");
                        for (int i = 0; i < Wrk.Count; i++)
                        {
                            if (Wrk[i].WorkDept == Deps[itr].DepName)
                            {
                                Console.Write($"{Wrk[i].WorkID}; ");
                            }
                        }
                    }
                }
                MainMenu();
            }

            //метод редактирования отдела
            void EditDept()
            {

            }

            // метод счетчика количества работников в отделе
            int CountWokers(string itr)
            {
                var dictionary = new Dictionary<string, int>();
                for (int i = 0; i < Wrk.Count; i++)
                {
                    if (!dictionary.ContainsKey($"{Wrk[i].WorkDept}")) dictionary.Add($"{Wrk[i].WorkDept}", 0);
                    dictionary[$"{Wrk[i].WorkDept}"]++;
                }
                int count;
                try { count = dictionary[itr]; }
                catch { count = 0; }

                return count;
            }


            // Метод создания работника
            void CreateWorker()
            {
                Console.WriteLine("Введите следющую информацию о работнике: ");
                Console.WriteLine("Имя: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Фамилия: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Возраст: ");
                int age = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Название Отдела: ");
                string dept = Console.ReadLine();
                Console.WriteLine("Зарплата: ");
                int solary = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Количество проектов: ");
                int projects = Int32.Parse(Console.ReadLine());

                Wrk.Add(new Workers(Wrk.Count,
                                    firstName,
                                    lastName,
                                    age,
                                    dept,
                                    solary,
                                    projects));
                MainMenu();
            }

            void EditWorker(int id)
            {
                Console.WriteLine("Введите следющую информацию о работнике: ");
                string nowName = Wrk[id].FisrtName;
                Console.WriteLine($"Существующее Имя: {nowName}.\t Новое имя: ");
                string firstName = Console.ReadLine();
                if (firstName != null) { Wrk.Find( ind => ind.FisrtName == firstName).FisrtName= firstName; }
                Console.WriteLine("Фамилия: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Возраст: ");
                int age = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Название Отдела: ");
                string dept = Console.ReadLine();
                Console.WriteLine("Зарплата: ");
                int solary = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Количество проектов: ");
                int projects = Int32.Parse(Console.ReadLine()); 
            }

            void DeleteWorker(int id) 
            {
                Wrk.Remove(Wrk[id]);
                MainMenu();
            }



            void SaveAtXML() { }

            void SaveAtJson() { }



            void SortWorkers() { }

            // метод для тестового заполнения БД
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
                    Wrk.Add(new Workers(i + 1, $"Вася_{i}", $"Пупкин_{i}", testWokerAge, $"Отдел {rnd.Next(1, testDept + 1)}", testSolary, testCountProject));
                }


                for (int i = 1; i <= testDept; i++)
                {
                    Deps.Add(new Department($"Отдел {i}", CountWokers($"Отдел {i}")));
                }


                Console.WriteLine($"\nСоздано {Deps.Count} Отделов");
                for (int i = 0; i <= Deps.Count - 1; i++)
                { Console.WriteLine($"{Deps[i].DepName} {Deps[i].RegDate:D} {Deps[i].WorkerCount} "); }
                Console.WriteLine($"Создано {Wrk.Count} сотрудников\n\n");
                MainMenu();
            }
            #endregion
        }
    }
}
