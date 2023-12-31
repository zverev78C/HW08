﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3.Проверка_повторов
{
    internal class Program
    {
        #region Задание 3. Проверка повторов
        //Что нужно сделать
        //Пользователь вводит число. Число сохраняется в HashSet коллекцию.
        //Если такое число уже присутствует в коллекции, то пользователю на экран выводится сообщение, что число уже вводилось ранее.
        //Если числа нет, то появляется сообщение о том, что число успешно сохранено. 

        //Советы и рекомендации
        //Для добавление числа в HashSet используйте метод Add.

        //Стоит ли пользоваться поиском в Сети во время обучения?

        //Однозначно стоит.Одна и та же информация, представленная в разных источниках, усваивается намного лучше, чем если бы вы пользовались только материалами курса.
        //В будущем, когда вы станете самостоятельным разработчиком, поиск в интернете будет занимать большую часть вашей работы.
        //Поэтому важно учиться этому уже сейчас. Обратите внимание на статью Google-oriented programming.

        //Что оценивается
        //В программе в качестве коллекции используется HashSet.
        #endregion
        static void Main()
        {
            HashSet<int> list = new HashSet<int>(); //коллекция для вводимых чисел
            while (true) // цикл обеспечивает повторение ввода
            {
                Console.WriteLine("Введите целое число:");
                string str = Console.ReadLine();
                int num;
                if (str.ToLower() == "q") { break; } // если введено Q то программа прерывается
                else
                {
                    try // проверка на коректность ввода
                    {
                        num = Convert.ToInt32(str);
                        if (list.Contains(num)) // проверка на наличие числа в коллекции
                        {
                            Console.WriteLine("Такое число уже есть в коллекции.");
                        }
                        else
                        {
                            list.Add(num); // добавление числа в коллекцию
                            Console.WriteLine("Число добавлено в коллекцию.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Не верный ввод числа. Для выхода нажмите:  q"); // сообщение при не правильном вводе
                    }
                }
            }
        }
    }
}
