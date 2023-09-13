using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4.Записная_книжка
{
    internal class Program
    {
        #region
        /*
        Что нужно сделать
        Программа спрашивает у пользователя данные о контакте:

        ФИО
        Улица
        Номер дома
        Номер квартиры
        Мобильный телефон
        Домашний телефон
        С помощью XElement создайте xml файл, в котором есть введенная информация.XML файл должен содержать следующую структуру:

        <Person name =”ФИО человека” >
            <Address>
                <Street>Название улицы</Street>
                <HouseNumber>Номер дома</HouseNumber>
                <FlatNumber>Номер квартиры</FlatNumber>
            </Address>
            <Phones>
                <MobilePhone>89999999999999</MobilePhone>
                <FlatPhone>123-45-67<FlatPhone>
            </Phones>
        </Person>
        Советы и рекомендации
        Заполняйте XElement в ходе заполнения данных.Изучите возможности XElement в документации Microsoft.

        Что оценивается
        Программа создаёт Xml файл, содержащий все данные о контакте.
        */
        #endregion
        static void Main()
        {
            List<string> Persons = new List<string>(6);
            AddPerson();

            void AddPerson()
            {
                Console.Clear();
                Console.Write("Введите ФИО: ");
                Persons.Add(Console.ReadLine());
                Console.Write("Введите улицу: ");
                Persons.Add(Console.ReadLine());
                Console.Write("Введите номер дома: ");
                Persons.Add(Console.ReadLine());
                Console.Write("Введите номер квартиры: ");
                Persons.Add(Console.ReadLine());
                Console.Write("Введите номер мобильного телефона: ");
                Persons.Add(Console.ReadLine());
                Console.Write("Введите номер домашнего телефона: ");
                Persons.Add(Console.ReadLine());

                SavePerson(Persons);
            }

            //метод записи колекции в файл
            void SavePerson(List<string> people)
            {
                Console.WriteLine (Persons.Count);
                foreach(string person in people) { Console.Write (person); }
                Console.ReadKey();
                AddPerson();
            }

        }
    }
}
