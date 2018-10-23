using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_23_items.DesignPattern.Chapter_08
{
    class FactoryMethod_08
    {
        public FactoryMethod_08()
        {
            IFactory fac = new UndergraduateFactory();
            LeiFeng stu = fac.CreateLeiFeng();

            stu.BuyRice();
            stu.Wash();
            stu.Sweep();

        }
    }

    class LeiFeng
    {
        public void Sweep()
        {
            Console.WriteLine("Sweep");
        }

        public void Wash()
        {
            Console.WriteLine("Wash");
        }

        public void BuyRice()
        {
            Console.WriteLine("Buy Rice.");
        }
    }

    class Undergraduate : LeiFeng
    {
    }

    class UndergraduateFactory : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Undergraduate();
        }
    }

    class Volunteer : LeiFeng
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Volunteer();
        }
    }

    class VolunteerFactory : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            throw new NotImplementedException();
        }
    }

    interface IFactory
    {
        LeiFeng CreateLeiFeng();
    }

    class SimpleFactory
    {
        public static LeiFeng CreateLeiFang(string type)
        {
            LeiFeng result = null;
            switch (type)
            {
                case "a":
                    result = new Undergraduate();
                    break;
                case "b":
                    result = new Volunteer();
                    break;
            }

            return result;

        }

    }
}
