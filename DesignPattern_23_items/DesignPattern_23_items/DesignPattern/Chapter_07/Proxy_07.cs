using System;

namespace DesignPattern_23_items.DesignPattern.Chapter_07
{
    /// <summary>
    /// 【代理模式】Proxy 結構型模式
    /// <para>
    /// 為其它對象提供一種代理，以控制自己對這個其他對象的訪問
    /// </para>
    /// </summary>
    internal class Proxy_07
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

    internal interface IGiveGift
    {
        void GiveDolls();

        void GiveChocalate();

        void GiveFlowers();
    }

    internal class Pursuit : IGiveGift
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

    internal class SchoolGirl
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }

    internal class Proxy : IGiveGift
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