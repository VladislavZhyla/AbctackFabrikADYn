using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbctackFabrikADYn
{
    public interface ILetter
    {
        void Send();
    }

    public interface IParcel
    {
        void Send();
    }
public class RegularLetter : ILetter
    {
        private readonly string _recipient;
        private readonly string _address;
        private readonly string _text;

        public RegularLetter(string recipient, string address, string text)
        {
            _recipient = recipient;
            _address = address;
            _text = text;
        }

        public void Send()
        {
            Console.WriteLine($"Лист доставлено до {_recipient} за адресою {_address}. Текст листа: {_text}");
        }
    }

    public class ExpressLetter : ILetter
    {
        private readonly string _recipient;
        private readonly string _address;
        private readonly string _text;

        public ExpressLetter(string recipient, string address, string text)
        {
            _recipient = recipient;
            _address = address;
            _text = text;
        }

        public void Send()
        {
            Console.WriteLine($"Лист доставлено швидко до {_recipient} за адресою {_address}. Текст листа: {_text}");
        }
    }

    public class RegularParcel : IParcel
    {
        private readonly string _recipient;
        private readonly string _address;
        private readonly string _text;

        public RegularParcel(string recipient, string address, string text)
        {
            _recipient = recipient;
            _address = address;
            _text = text;
        }

        public void Send()
        {
            Console.WriteLine($"Посилка доставлена до {_recipient} за адресою {_address}. Вміст посилки: {_text}");
        }
    }

    public class ExpressParcel : IParcel
    {
        private readonly string _recipient;
        private readonly string _address;
        private readonly string _text;

        public ExpressParcel(string recipient, string address, string text)
        {
            _recipient = recipient;
            _address = address;
            _text = text;
        }

        public void Send()
        {
            Console.WriteLine($"Посилка доставлена швидко до {_recipient} за адресою {_address}. Вміст посилки: {_text}");
        }
    }
public interface IDeliveryFactory
    {
        ILetter CreateLetter(string recipient, string address, string text);
        IParcel CreateParcel(string recipient, string address, string text);
    }

    public class RegularDeliveryFactory : IDeliveryFactory
    {
        public ILetter CreateLetter(string recipient, string address, string text)
        {
            return new RegularLetter(recipient, address, text);
        }

        public IParcel CreateParcel(string recipient, string address, string text)
        {
            return new RegularParcel(recipient, address, text);
        }
    }

    public class ExpressDeliveryFactory : IDeliveryFactory
    {
        public ILetter CreateLetter(string recipient, string address, string text)
        {
            return new ExpressLetter(recipient, address, text);
        }

        public IParcel CreateParcel(string recipient, string address, string text)
        {
            return new ExpressParcel(recipient, address, text);
        }
    }

class Program
    {
        static void Main(string[] args)
        {
            IDeliveryFactory regularFactory = new RegularDeliveryFactory();
            IDeliveryFactory expressFactory = new ExpressDeliveryFactory();

            ILetter regularLetter = regularFactory.CreateLetter("Монкі д Дуфі", "вул. Банкова, 1", "Привіт, Зоро!");
            IParcel regularParcel = regularFactory.CreateParcel("Монкі д Дуфі", "вул. Банкова, 1", "Золото");

            ILetter expressLetter = expressFactory.CreateLetter("Ророноа Зоро", "вул. Шевченка, 23", "Важлива інформація");
            IParcel expressParcel = expressFactory.CreateParcel("Ророноа Зоро", "вул. Щевченко, 23", "Подарунок");

            regularLetter.Send();
            regularParcel.Send();
            expressLetter.Send();
            expressParcel.Send();

            Console.ReadLine();
        }
    }

}
