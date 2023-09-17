using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace из_файла
{
    class Test
    {
        Workers wrk = new Workers();
        Program pro = new Program();

        void T123est()
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
    }
}
