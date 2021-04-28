using System;

namespace DesignPattern_23_items.DesignPattern.Chapter_06
{
    /// <summary>
    /// 【修飾模式】Decorator 結構型模式
    /// <para>
    /// 動態的給一個對象添加一些額外的職責，
    /// 增加功能來說，裝飾模式生成子類更靈活
    /// </para>
    /// </summary>
    internal class Decorator_06
    {
        public void DecoratorExecute()
        {
            Person xc = new Person("Man");

            BTrouser kk = new BTrouser();

            TShirts dtx = new TShirts();

            TShirts dtx2 = new TShirts();

            dtx.Decorate(xc);

            kk.Decorate(dtx);

            dtx2.Decorate(kk);

            Console.WriteLine("--- 1 ---");
            dtx.Show();
            Console.WriteLine("--- 2 ---");
            kk.Show();
            Console.WriteLine("--- 3 ---");
            dtx2.Show();
        }
    }

    internal class Person
    {
        private string _name;

        public Person()
        {
        }

        public Person(string name)
        {
            this._name = name;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Decorete :{this._name}");
        }
    }

    internal class Finery : Person
    {
        protected Person _compoenet;

        public void Decorate(Person component)
        {
            this._compoenet = component;
        }

        public override void Show()
        {
            if (_compoenet != null)
                _compoenet.Show();
        }
    }

    internal class TShirts : Finery
    {
        public override void Show()
        {
            Console.WriteLine($" T Shirt");
            base.Show();
        }
    }

    internal class BTrouser : Finery
    {
        public override void Show()
        {
            Console.WriteLine($" B Trouser ");
            base.Show();
        }
    }
}