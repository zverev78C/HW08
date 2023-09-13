using System;
using System.Xml.Linq;

namespace Задание_4.Записная_книжка
{
    internal class Program
    {
        #region  Что нужно сделать 
        /*
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
        Заполняйте XElement в ходе заполнения данных.
        Изучите возможности XElement в документации Microsoft.

        Что оценивается
        Программа создаёт Xml файл, содержащий все данные о контакте.
        */
        #endregion
        static void Main()
        {
            Console.WriteLine("Ведите следующие данные о человеке:");
            XElement myPerson = new XElement("Person");
            XElement myAdress = new XElement("Address");
            XElement myPhone = new XElement("Phones");

            Console.Write("ФИО:\t");
            XAttribute name = new XAttribute("name", Console.ReadLine());

            Console.Write("Название улицы:\t");
            XElement street = new XElement("Street", Console.ReadLine());
            Console.Write("Номер дома:\t");
            XElement house = new XElement("HouseNumber", Console.ReadLine());
            Console.Write("Номер квартиры:\t");
            XElement flat = new XElement("FlatNumber", Console.ReadLine());

            Console.Write("Мобильный телефон:\t");
            XElement mPhone = new XElement("MobilePhone", Console.ReadLine());
            Console.Write("Домашний телефон:\t");
            XElement fPhone = new XElement("FlatPhone", Console.ReadLine());

            myPerson.Add(name);
            myAdress.Add(street, house, flat);
            myPhone.Add(mPhone, fPhone);
            myPerson.Add(myAdress, myPhone);

            myPerson.Save("file");
        }
    }
} 
