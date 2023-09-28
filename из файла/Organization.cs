using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace из_файла
{
    /// <summary>
    /// Класс описыающий организацию
    /// </summary>
    internal class Organization
    {
        /// <summary>
        /// Список отделов  
        /// </summary>
        public List<Department> Deps = new List<Department>();

        /// <summary>
        /// Основной список всех сотрудников  
        /// </summary>
        public List<Worker> Workers = new List<Worker>();

        #region Методы для работы с отделами  

        /// <summary>
        /// Метод создания нового отдела 
        /// </summary>
        public void NewDepartment()
        {
            Console.WriteLine("Введите название отдела:");
            string name = MyMetods.InputCheck(true, false); // Вводится имя нового отдела
            if (Deps.Count == 0)  // если список отделов пуст то создаем первый отдел
            {
                List<Worker> depList = new List<Worker>();      // Создается список сотрудников отдела
                Deps.Add(new Department(name, DateTime.Now, depList)); // Время создания сейчас }
            }
            else // если в списке есть хотя бы один отдел то проверяем название что бы не было повторений
            {
                bool flag = true;
                for (int i = 0; i < Deps.Count; i++) // сравнивается название присваемое и существующие у каждого одела в списке
                {
                    if (name == Deps[i].Name)
                    {
                        flag = false; break; // если есть совпадение то ставиться флажок ложь и цикл прерывается
                    }
                }
                if (flag == true) // если совадегий не найдено 
                {
                    List<Worker> depList = new List<Worker>();      // Создается список сотрудников отдела
                    Deps.Add(new Department(name, DateTime.Now, depList)); // Время создания сейчас }
                }
                else // если совпадение обнаружено то выводится сообщение
                {
                    Console.WriteLine($" Отдел с именем {name} уже существует.");
                }
            }
        }

        /// <summary>
        /// метод добавления сотрудника в отдел после добовления его в общий список сотрудников
        /// </summary>
        /// <param name="newWorker">новый сотрудник</param>
        /// <param name="deptName">имя отдела куда добавляется </param>
        public void ChangeDepsWorkerAdd(Worker newWorker, string deptName)
        {
            for (int i = 0; i < Deps.Count; i++)
            {
                if (Deps[i].Name == deptName)
                {
                    Deps[i].Workers.Add(newWorker);
                }
            }
        }

        /// <summary>
        /// Метод печати списка отделов
        /// </summary>
        public void PrintAllDeps()
        {
            Department.PrintTitle();
            for (int i = 0; i < Deps.Count; i++)
            {
                Console.WriteLine($"  {i}\t{Deps[i].Name}\t\t\t{Deps[i].RegDate:D}\t{Deps[i].Workers.Count} ");
            }
        }

        /// <summary>
        /// Метод редактирования отдела
        /// </summary>
        public void EditDept()
        {
            PrintAllDeps(); // выводим список всех отделов

            Console.Write("Введите индекс отдела: ");
            string name = MyMetods.InputCheck(true, true); // проверка ввода пользователя
            int itr = Int32.Parse(name);
            if (itr >= Deps.Count) // проверка что такой отдел существует ( не превышает индекс самого большого отдела)
            {
                Console.WriteLine($"Отдела с индексом: {itr}, не существует.");
            }
            else
            {
                Console.WriteLine("Введите новое название:");
                string newName = MyMetods.InputCheck(true, false);
                for (int i = 0; i < Workers.Count; i++)  //цикл для перевода сотрудников в отдел с новым названием
                {
                    if (Workers[i].WorkDept == Deps[itr].Name) { Workers[i].WorkDept = newName; }
                }
                Deps[itr].Name = newName; // присвоение отделу нового названия

            }
            PrintAllDeps();
        }

        /// <summary>
        /// Методу удаления отдела по индексу  
        /// </summary>
        public void DeleteDept()
        {
            PrintAllDeps(); //  выводится список отдела что бы пользователь увидел индекс удалаяемого отдела 
            Console.Write("Введите индекс отдела: ");
            string name = MyMetods.InputCheck(true, true); // проверка ввода пользователя
            int itr = Int32.Parse(name);
            if (itr >= Deps.Count) // проверка что такой отдел существует ( не превышает индекс самого большого отдела)
            {
                Console.WriteLine($"Отдела с индексом: {itr}, не существует.");
            }
            else
            {
                if (Deps[itr].Workers.Count == 0) // проверка что в отделе нет работников
                {
                    Deps.RemoveAt(itr);
                }
                else
                {
                    Console.WriteLine($"Невозможно удалить отдел пока в нем работают люди. {Deps[itr].Workers.Count} человек.\n");
                    PrintDeptWorkers(itr);     // отправляет индекс в метод
                }
            }
        }

        /// <summary>
        /// Метод выводящий на экран список сотрудников отдела по индексу
        /// </summary>
        /// <param name="itr"> индекс искомого отдела</param>
        public void PrintDeptWorkers(int itr)
        {
            string deptName = Deps[itr].Name; // получаем имя отдела по индексу
            Department.PrintTitle();
            for (int i = 0; i < Workers.Count; i++) // в цикле ищем работников с таким же названием отдела
            {
                if (Workers[i].WorkDept == deptName)
                {
                    Console.WriteLine($"{Workers[i].WorkID}\t\t" +  // выводим работника на экран
                                  $"{Workers[i].FisrtName}\t\t" +
                                  $"{Workers[i].LastName}\t\t" +
                                  $"{Workers[i].Age}\t " +
                                  $"{Workers[i].WorkDept}\t\t" +
                                  $"{Workers[i].Solary}\t\t" +
                                  $"{Workers[i].CountProject}");
                }
            }
        }

        /// <summary>
        /// Метод меняет в указаном отделе список работников 
        /// </summary>
        /// <param name="deptName">название отдела</param>
        public void ChangeDepsWorkerDel(string deptName)
        {
            for (int i = 0; i < Deps.Count; i++)
            {
                if (Deps[i].Name == deptName)
                {
                    Deps[i].Workers = DepsList(deptName); // просто заменяет старый список сотрудников новым без переведеного сотрудника
                }
            }
        }

        /// <summary>
        /// Метод находит всех работников отдела по названию
        /// </summary>
        /// <param name="depName">название отдела </param>
        /// <returns></returns>
        public List<Worker> DepsList(string depName)
        {
            List<Worker> tempWorkers = new List<Worker>(); // создается временный список работников
            for (int i = 0; i < Workers.Count; i++)  // цикл проходит по основному списку
            {
                if (Workers[i].WorkDept == depName) { tempWorkers.Add(Workers[i]); } //  выбирает тех у кого имя отдела совпадает с заданым
            }
            return tempWorkers; //складывает во временый лист и возвращает его 
        }

        #endregion

        #region Методы для работы с сотрудниками  

        /// <summary>
        /// Метод добавления сотрудника в списки 
        /// </summary>
        public void AddWorkers()
        {
            int workID = (Workers.Count == 0 ? 0 : Workers.Count); // проверка на пустой список сотрудников
            Console.Write("Имя сотрудника:  ");
            string firstName = MyMetods.InputCheck(true, false);
            Console.Write("Фамилия сотрудника:  ");
            string lastName = MyMetods.InputCheck(true, false);
            Console.Write("Возраст сотрудника:  ");
            int age = Convert.ToInt32(MyMetods.InputCheck(true, true));
            Console.Write("Отдел сотрудника:  ");
            string workDept = MyMetods.InputCheck(true, false);
            Console.Write("Зарплата сотрудника:  ");
            int solary = Convert.ToInt32(MyMetods.InputCheck(true, true));
            Console.Write("Количество проектов сотрудника:  ");
            int projects = Convert.ToInt32(MyMetods.InputCheck(true, true));

            Worker tempWorker = new Worker(workID + 1,
                                           firstName,
                                          lastName,
                                          age,
                                          workDept,
                                          solary,
                                          projects);
            Workers.Add(tempWorker); // добавление сотрудника в список сотрудников 
            ChangeDepsWorkerAdd(tempWorker, workDept);
        }

        /// <summary>
        /// Метод печати всех сотрудников
        /// </summary>
        public void PrintAllWorkers()
        {
            Worker.PrintTitle();
            for (int i = 0; i < Workers.Count; i++)
            {
                Console.WriteLine($"{Workers[i].WorkID}\t\t" +
                                  $"{Workers[i].FisrtName}\t\t" +
                                  $"{Workers[i].LastName}\t\t" +
                                  $"{Workers[i].Age}\t " +
                                  $"{Workers[i].WorkDept}\t\t" +
                                  $"{Workers[i].Solary}\t\t" +
                                  $"{Workers[i].CountProject}");
            }
        }

        /// <summary>
        /// Метод редактирования сотрудника 
        /// </summary>
        public void EditWorker()
        {
            PrintAllWorkers(); // Печать всех сотрудников для нахождения ID
            Console.WriteLine("Введите ID работника:");
            int id = Convert.ToInt32(MyMetods.InputCheck(true, true)); // Получаем ID Сотрудника
            int index = -1;
            for (int i = 0; i <= Workers.Count; i++)
            {
                if (Workers[i].WorkID == id) { index = i; break; }  //находим индекс сотрудника по id
            }

            if (index == -1) // порверка наличия такого сотрудника
            {
                Console.WriteLine($"Сотрудника с таким {id} не обнаружено.");
            }
            else
            {
                Console.WriteLine("Введите следющую информацию о работнике: ");

                Console.Write($"Существующее Имя: {Workers[index].FisrtName}.\t Новое имя: ");
                string firstName = MyMetods.InputCheck(false, false);                    // допускается пустая строка для сохранения старого имени
                if (firstName == "") { firstName = Workers[index].FisrtName; }
                Console.Write($"Существующая Фамилия: {Workers[index].LastName}.\t Новая Фамилия: ");
                string lastName = MyMetods.InputCheck(false, false);
                if (lastName == "") { lastName = Workers[index].LastName; }
                Console.Write($"Существующий возраст: {Workers[index].Age}.\t Новый возраст: ");
                string age = MyMetods.InputCheck(false, true);
                int tempAge;
                if (age == "") { tempAge = Workers[index].Age; } else { tempAge = Int32.Parse(age); }
                Console.Write($"Существующий отдел: {Workers[index].WorkDept}.\t Новый отдел: ");
                string dept = MyMetods.InputCheck(false, false);
                string oldDep = "";                                       //сохраняем старое название отдела для редактирования отделов
                if (dept == "") { dept = Workers[index].WorkDept; } else { oldDep = Workers[index].WorkDept; }
                Console.Write($"Существующая зарплата: {Workers[index].Solary}.\t Новая зарплата: ");
                int tempSolary;
                string solary = MyMetods.InputCheck(false, true);
                if (solary == "") { tempSolary = Workers[index].Solary; } else { tempSolary = Int32.Parse(solary); }
                Console.Write($"Существующие проекты: {Workers[index].CountProject}.\t Изменить кол-во проектов: ");
                int tempPrj;
                string projects = MyMetods.InputCheck(false, true);
                if (projects == "") { tempPrj = Workers[index].CountProject; } else { tempPrj = Int32.Parse(projects); }

                Worker tempWorker = new Worker(Workers[index].WorkID,
                                                  firstName,
                                                  lastName,
                                                  tempAge,
                                                  dept,
                                                  tempSolary,
                                                  tempPrj);
                Workers[index] = tempWorker;
                if (dept != "") // при изменении отдела сотрудника
                {
                    ChangeDepsWorkerAdd(tempWorker, dept); // добавляется в новый отдел
                    ChangeDepsWorkerDel(oldDep); // удаляется из старого
                }

                Console.WriteLine($"{Workers[index].WorkID}\t\t" +
                                  $"{Workers[index].FisrtName}\t\t" +
                                  $"{Workers[index].LastName}\t\t" +
                                  $"{Workers[index].Age}\t " +
                                  $"{Workers[index].WorkDept}\t\t" +
                                  $"{Workers[index].Solary}\t\t" +
                                  $"{Workers[index].CountProject}");

            }
        }

        /// <summary>
        /// Метод удаления сотрудника  
        /// </summary>
        public void DeleteWorker()
        {
            PrintAllWorkers();
            Console.WriteLine("Введите ID работника:");
            int id = Convert.ToInt32(MyMetods.InputCheck(true, true));
            int index = -1;
            for (int i = 0; i <= Workers.Count; i++)
            {
                if (Workers[i].WorkID == id) { index = i; break; }  //находим индекс сотрудника по id
            }

            if (index == -1)
            {
                Console.WriteLine($"Сотрудника с таким {id} не обнаружено.");
            }
            else
            {
                string depName = Workers[index].WorkDept;
                Workers.Remove(Workers[index]); // удаление сотрудника из общего списка
                ChangeDepsWorkerDel(depName); // удаление сотрудника из списка отдела
            }
        }
        #endregion

        #region  Методы сортировки сорудников  

        /// <summary>
        /// Метод сортирующий сотрудников по парамметрам  
        /// </summary>
        public void SortWorkers()
        {
            Console.WriteLine("Выберите способ сортировки сотрудников:\n" +
                              "1\tДля сортировки по одному параметру\n" +
                              "2\tДля сортировки по двам парамертрам\n" +
                              "3\tДля сортировки по трем парматерам");
            switch (MyMetods.InputCheck(true, false))
            {
                case "1": SortToOne(); break;
                case "2": SortToTwo(); break;
                case "3": SotrToDepsPlus(); break;
                default: Console.WriteLine("Выбор не понятен"); break;
            }

            // метод сортировки по одному параметру 
            void SortToOne()
            {
                Console.WriteLine("Выберите способ сортировки сотрудников:\n" +
                              "1\tДля сортировки по ID\n" +
                              "2\tДля сортировки по Имени\n" +
                              "3\tДля сортировки по Фамилии\n" +
                              "4\tДля сортировки по Возрасту\n" +
                              "5\tДля сортировки по Отделам\n" +
                              "6\tДля сортировки по Зарплате\n" +
                              "7\tДля сортировки по Количеству проектов");

                switch (MyMetods.InputCheck(true, false))
                {
                    case "1": var sortedWorkers = Workers.OrderBy(w => w.WorkID); PrintResultSort(sortedWorkers); break; // сортирует список сотрудников по ID
                    case "2": var sortedWorkersF = Workers.OrderBy(w => w.FisrtName); PrintResultSort(sortedWorkersF); break; // сортирует список сотрудников по имени
                    case "3": var sortedWorkersL = Workers.OrderBy(w => w.LastName); PrintResultSort(sortedWorkersL); break; // сортирует список сотрудников по фамилии
                    case "4": var sortedWorkersA = Workers.OrderBy(w => w.Age); PrintResultSort(sortedWorkersA); break; // сортирует список сотрудников по возрасту
                    case "5": var sortedWorkersD = Workers.OrderBy(w => w.WorkDept); PrintResultSort(sortedWorkersD); break; // сортирует список сотрудников по отделам
                    case "6": var sortedWorkersS = Workers.OrderBy(w => w.Solary); PrintResultSort(sortedWorkersS); break; // сортирует список сотрудников по зарплате
                    case "7": var sortedWorkersC = Workers.OrderBy(w => w.CountProject); PrintResultSort(sortedWorkersC); break; // сортирует список сотрудников по количеству проектов
                    default: Console.WriteLine("Выбор не понятен"); break;
                }
            }

            // метод сортировки по двум указанным параметрам  
            //Упорядочивание по полям возраст и оплате труда
            void SortToTwo()
            {
                var sortedWorkers = Workers.OrderBy(w => w.Age).ThenBy(w => w.Solary);
                PrintResultSort(sortedWorkers);
            }

            // метод сортировки по отделам и еще двум параметрам
            //Упорядочивание по полям возраст и оплате труда в рамках одного департамента
            void SotrToDepsPlus()
            {
                var sortedWorkers = Workers.OrderBy(w => w.WorkDept).ThenBy(w => w.Age).ThenBy(w => w.Solary);
                PrintResultSort(sortedWorkers);
            }
        }
        /// <summary>
        /// Метод вывода в консоль отсортированого списка сотрудников
        /// </summary>
        /// <param name="sortedWorkers"></param>
        void PrintResultSort(IOrderedEnumerable<Worker> sortedWorkers)
        {
            Worker.PrintTitle();
            foreach (var wor in sortedWorkers)
            {
                Console.WriteLine($"{wor.WorkID}\t\t" +
                                  $"{wor.FisrtName}\t\t" +
                                  $"{wor.LastName}\t\t" +
                                  $"{wor.Age}\t " +
                                  $"{wor.WorkDept}\t\t" +
                                  $"{wor.Solary}\t\t" +
                                  $"{wor.CountProject}");
            }
        }

        #endregion

        #region Методы для работы с файлами  

        /// <summary>
        /// Метод для записи БД в формате Xml
        /// </summary>
        /// <param name="file">расположение файла</param>
        public void SaveXml(string file, List<Department> d)
        {
            XmlSerializer srd = new XmlSerializer(typeof(List<Department>));
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                srd.Serialize(sw, d);
                //srw.Serialize(sw, w);
            }
        }

        /// <summary>
        /// Метод загружающий список отделов (Deps) , копирующий список сотрудников в список Workers и сортирующий последний по ID  
        /// </summary>
        /// <param name="file">Место харнения файла</param>
        public void LoadXml(string file)
        {
            XmlSerializer srd = new XmlSerializer(typeof(List<Department>));
            using (StreamReader sr = new StreamReader(file)) // создается поток считывания
            {
                Deps = srd.Deserialize(sr) as List<Department>; // считывается файл в список отделов
            }

            foreach (var item in Deps)
            {
                Workers.AddRange(item.Workers); // Добавляет список струдников отдела в общий список сотрудников  
            }

            Workers.Sort((x, y) => x.WorkID.CompareTo(y.WorkID)); // сортирует список сотрудников по ID
        }

        /// <summary>
        /// Метод сериализует (сохраняет в файл) в Json список Deps  
        /// </summary>
        /// <param name="file"></param>
        public void SaveJson(string file)
        {
            string json = JsonConvert.SerializeObject(Deps);
            using (StreamWriter sw = new StreamWriter(file, false))
            {
                sw.Write(json);
            }
        }


        /// <summary>
        /// Метод считывающий файл json и создающий два списка сначала Deps потом Workers   
        /// </summary>
        /// <param name="file"></param>
        public void LoadJson(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                Deps = JsonConvert.DeserializeObject<List<Department>>(sr.ReadToEnd());
            }
            foreach (var item in Deps)
            {
                Workers.AddRange(item.Workers); // Добавляет список струдников отдела в общий список сотрудников  
            }

            Workers.Sort((x, y) => x.WorkID.CompareTo(y.WorkID)); // сортирует список сотрудников по ID
        }

        #endregion

        #region Тестовые методы 

        /// <summary>
        /// Тестовый метод заполнения отдела, 
        /// где опрос пользователя заменен на автоВвод имени отдела   
        /// </summary>
        /// <param name="name"></param>
        public void NewDepartmentTest(string name)
        {
            if (Deps.Count == 0)
            {
                List<Worker> depList = new List<Worker>();      // Создается список сотрудников отдела
                Deps.Add(new Department(name, DateTime.Now, depList)); // Время создания сейчас }
            }
            else
            {
                bool flag = true;
                for (int i = 0; i < Deps.Count; i++)
                {
                    if (name == Deps[i].Name)
                    {
                        flag = false; break;
                    }
                }
                if (flag == true)
                {
                    List<Worker> depList = new List<Worker>();      // Создается список сотрудников отдела
                    Deps.Add(new Department(name, DateTime.Now, depList)); // Время создания сейчас }
                }
                else
                {
                    Console.WriteLine($" Отдел с именем {name} уже существует.");
                }
            }
        }
        /// <summary>
        /// Тестовый метод заполнения сотрудника, 
        /// где опрос пользователя заменен на автоВвод 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="workDept"></param>
        /// <param name="solary"></param>
        /// <param name="projects"></param>
        public void AddWorkersTest(string firstName, string lastName, int age, string workDept, int solary, int projects)
        {
            int workID = (Workers.Count == 0 ? 0 : Workers.Count); // проверка на пустой список сотрудников

            Worker tempWorker = new Worker(workID + 1,
                                           firstName,
                                          lastName,
                                          age,
                                          workDept,
                                          solary,
                                          projects);
            Workers.Add(tempWorker); // добавление сотрудника в список сотрудников 
            ChangeDepsWorkerAdd(tempWorker, workDept);
        }

        #endregion
    }
}
