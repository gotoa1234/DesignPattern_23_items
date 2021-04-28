using System;

namespace DesignPattern_23_items.DesignPattern.Chapter_08
{
    /// <summary>
    /// 【工廠方法模式】Factory 創建型模式
    /// <para>
    /// 定義一個用於創建對象的接口，讓子類決定實例化哪一個類。
    /// 工廠方法使一個類的實例化延遲到子類中實例
    /// </para>
    /// </summary>
    internal class FactoryMethod_08
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

    internal class LeiFeng
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

    internal class Undergraduate : LeiFeng
    {
    }

    internal class UndergraduateFactory : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Undergraduate();
        }
    }

    internal class Volunteer : LeiFeng
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Volunteer();
        }
    }

    internal class VolunteerFactory : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            throw new NotImplementedException();
        }
    }

    internal interface IFactory
    {
        LeiFeng CreateLeiFeng();
    }

    internal class SimpleFactory
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