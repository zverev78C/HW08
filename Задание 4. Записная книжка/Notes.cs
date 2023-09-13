using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4.Записная_книжка
{
    class Notes
    {
        /*
        ФИО
        Улица
        Номер дома
        Номер квартиры
        Мобильный телефон
        Домашний телефон
        */
        string FIO { get; set; }
        string Street { get; set; }
        string House { get; set; }
        string Flate { get; set; }
        double Mobile { get; set; }
        double Phone { get; set; }

        public Notes(string fIO, string street, string house, string flate, double mobile, double phone)
        {
            FIO = fIO;
            Street = street;
            House = house;
            Flate = flate;
            Mobile = mobile;
            Phone = phone;
        }
    }
}
