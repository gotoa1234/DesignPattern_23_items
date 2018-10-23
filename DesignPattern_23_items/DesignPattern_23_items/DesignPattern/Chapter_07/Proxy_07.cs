using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_23_items.DesignPattern.Chapter_07
{
    class Proxy_07
    {
        public void ProxyModeExecute()
        {
            SchoolGirl mm = new SchoolGirl();
            mm.Name = "A";

            Proxy dd = new Proxy(mm);

            dd.GiveFlowers();
            dd.GiveChocalate();
            dd.GiveDolls();

        }
    }

    interface IGiveGift
    {
        void GiveDolls();

        void GiveChocalate();

        void GiveFlowers();
    }

    class Pursuit : IGiveGift
    {
        protected SchoolGirl _mm;

        public Pursuit(SchoolGirl mm)
        {
            _mm = mm;
        }


        public void GiveChocalate()
        {
            Console.WriteLine($"{_mm} Get Cho");
        }

        public void GiveDolls()
        {
            Console.WriteLine($"{_mm} Get Dolls");
        }

        public void GiveFlowers()
        {
            Console.WriteLine($"{_mm} Get Flowers");
        }
    }

    class SchoolGirl
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }

    class Proxy : IGiveGift
    {
        protected Pursuit Pursuit;

        public Proxy(SchoolGirl ps)
        {
            Pursuit = new Pursuit(ps);
        }

        public void GiveChocalate()
        {
            Pursuit.GiveChocalate();
        }

        public void GiveDolls()
        {
            Pursuit.GiveDolls();
        }

        public void GiveFlowers()
        {
            Pursuit.GiveFlowers();
        }
    }

}
