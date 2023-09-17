using System;
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
            Test test = new Test();
            Workers work = new Workers();
            Department dep = new Department();

            List<Workers> Wrk = new List<Workers>();
            List<Department> LDeps = new List<Department>();

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
                    case "100":
                        Console.Clear();
                        Test(); break;
                    case "1":// сделано
                        {
                            Console.WriteLine("Введите название нового отдела: ");
                            string name = InputCheck(true, false);
                            Department newDep = dep.CreateDept(name);
                            MainMenu();
                            break;
                        }
                    case "2": EditDept(); break;
                    case "3": DeleteDept(); break;// сделано
                    case "4":// сделано
                        {
                            Workers concretWorker = work.CreateWorker(Wrk.Count);
                            Wrk.Add(concretWorker);
                            MainMenu();
                            break;
                        }
                    case "5": EditWorker(); break;
                    case "6": DeleteWorker(); break; // сделано
                    case "7": SortWorkers(); break;
                    case "8": SaveAtXML(); break;
                    case "9": SaveAtJson(); break;
                }
            }

            //метод редактирования отдела
            void EditDept()
            {
                PrintDeps();
                Console.Write("Введите индекс отдела: ");
                string name = InputCheck(true, true); // проверка ввода пользователя
                int itr = Int32.Parse(name);
                if (itr >= LDeps.Count) // проверка что такой отдел существует ( не превышает индекс самого большого отдела)
                {
                    Console.WriteLine($"Отдела с индексом: {itr}, не существует.");
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Введите новое название:");
                    string newName = InputCheck(true, false);
                    LDeps[itr] = dep.changeName(LDeps[itr], newName);

                }
                PrintDeps();
                MainMenu();


            }

            void EditWorker()
            {
                Console.WriteLine("Введите ID работника:");
                int id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите следющую информацию о работнике: ");

                Console.WriteLine($"Существующее Имя: {Wrk[id].FisrtName}.\t Новое имя: ");
                string firstName = Console.ReadLine();
                if (firstName == "") { firstName = Wrk[id].FisrtName; }
                Console.WriteLine("Фамилия: ");
                string lastName = Console.ReadLine();
                if (lastName == "") { lastName = Wrk[id].LastName; }
                Console.WriteLine("Возраст: ");
                string age = Console.ReadLine();
                int tempAge;
                if (age == "") { tempAge = Wrk[id].Age; } else { tempAge = Int32.Parse(age); }
                Console.WriteLine("Название Отдела: ");
                string dept = Console.ReadLine();
                if (dept == "") { dept = Wrk[id].WorkDept; }
                Console.WriteLine("Зарплата: ");
                int tempSolary;
                string solary = Console.ReadLine();
                if (solary == "") { tempSolary = Wrk[id].Solary; } else { tempSolary = Int32.Parse(solary); }
                Console.WriteLine("Количество проектов: ");
                int tempPrj;
                string projects = Console.ReadLine();
                if (projects == "") { tempPrj = Wrk[id].CountProject; } else { tempPrj = Int32.Parse(projects); }

                Workers tempWorker = new Workers(Wrk[id].WorkID,
                                                  firstName,
                                                  lastName,
                                                  tempAge,
                                                  dept,
                                                  tempSolary,
                                                  tempPrj);
                Wrk[id] = tempWorker;
                MainMenu();
            }

            void SaveAtXML() { }

            void SaveAtJson() { }

            void SortWorkers() { }

            #endregion


            //Метод подсчета количества работников в отделе
            int CountWokers(string name)
            {
                var dictionary = new Dictionary<string, int>();
                for (int i = 0; i < Wrk.Count; i++)
                {
                    if (!dictionary.ContainsKey($"{Wrk[i].WorkDept}")) dictionary.Add($"{Wrk[i].WorkDept}", 0);
                    dictionary[$"{Wrk[i].WorkDept}"]++;
                }
                int count;
                try { count = dictionary[name]; }
                catch { count = 0; }

                return count;
            }

            // метод контроля ввода пользоваьеля
            string InputCheck(bool noNull, bool num)
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
                if (num == true)
                {
                    while (true)
                    {
                        bool result = int.TryParse(str, out int id);
                        if (result == false)
                        {
                            Console.WriteLine("В строке должно быть целое число");
                            Console.ReadLine();

                        }
                        break;
                    }
                }
                return str;
            }

            // метод удаления работника из списка
            void DeleteWorker()
            {
                Console.WriteLine("Введите ID работника:");
                string str = InputCheck(true, true);
                int id = Int32.Parse(str);
                Wrk.Remove(Wrk[id]);
                MainMenu();
            }

            // метод вывод на экран список всех отделов с индексом каждого
            void PrintDeps()
            {
                dep.Title();
                for (int i = 0; i < LDeps.Count; i++)
                {
                    Console.WriteLine($"  {i}\t\t {LDeps[i].Print()}");
                }
            }

            // метод удаления отдела
            /* Переделать на string аргумент и проверку наличия*/
            void DeleteDept()
            {
                PrintDeps();
                Console.Write("Введите индекс отдела: ");
                string name = InputCheck(true, true); // проверка ввода пользователя
                int itr = Int32.Parse(name);
                if (itr >= LDeps.Count) // проверка что такой отдел существует ( не превышает индекс самого большого отдела)
                {
                    Console.WriteLine($"Отдела с индексом: {itr}, не существует.");
                    MainMenu();
                }
                else
                {
                    if (LDeps[itr].WorkerCount == 0) // проверка что в отиделе нет работников
                    {
                        LDeps.RemoveAt(itr);
                    }
                    else
                    {
                        Console.WriteLine($"Невозможно удалить отдел пока в нем работают люди. {LDeps[itr].WorkerCount} человек.\n");
                        for (int i = 0; i < Wrk.Count; i++)
                        {
                            if (Wrk[i].WorkDept == LDeps[itr].DepName)
                            {
                                Console.Write($"{Wrk[i].WorkID}; ");  // выводит на экран список табельных номеров работников
                            }
                        }
                    }
                }
                MainMenu();
            }

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
                    LDeps.Add(new Department($"Отдел {i}", CountWokers($"Отдел {i}")));
                }

                Console.WriteLine($"\nСоздано {LDeps.Count} Отделов");
                Console.WriteLine($"Создано {Wrk.Count} сотрудников\n\n");
                MainMenu();
            }
        }
    }
}
