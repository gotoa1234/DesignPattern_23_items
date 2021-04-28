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
    class FactoryMethod_08
    {
        public FactoryMethod_08()
        {
            IFactory factory = new UndergraduateFactory();
            LeiFeng stu = factory.CreateLeiFeng();
            stu.BuyRice();
            stu.Wash();
            stu.Sweep();

            factory = new VolumnteerFactory();
            stu = factory.CreateLeiFeng();
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

    interface IFactory
    {
        LeiFeng CreateLeiFeng();
    }

    #region 第一個物件

    //主體
    class Undergrated : LeiFeng
    {
    }

    //產生主體的工廠
    class UndergraduateFactory : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Undergrated();
        }
    }
    #endregion

    #region 第二個物件

    //主體
    class Volunteer : LeiFeng
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Volunteer();
        }
    }

    //產生主體的工廠
    class VolumnteerFactory : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Volunteer();
        }
    }
    #endregion

    //工廠方法模式就不會用簡單工廠 -- 以下是對照用
    class SimpleFactory
    {
        public static LeiFeng CreateLeiFang(string type)
        {
            LeiFeng result = null;
            switch (type)
            {
                case "a":
                    result = new Undergrated();
                    break;
                case "b":
                    result = new Volunteer();
                    break;
            }

            return result;

        }

    }
}

