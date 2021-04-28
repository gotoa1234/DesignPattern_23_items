using System;

namespace DesignPattern_23_items.DesignPattern.Chapter_22
{
    /// <summary>
    /// 【橋接器模式】Bridge 結構型模式
    /// <para>
    /// 將抽象部分與它的實例部分分離，使他們都可以獨立地變化。
    /// </para>
    /// </summary>
    internal class Bridge_22
    {
        public void Excute()
        {
            HandsetBrand ab;
            ab = new HandsetBrandN();

            ab.SetHandsetSoft(new HandsetGame());
            ab.Run();

            ab.SetHandsetSoft(new HandsetAddressList());
            ab.Run();

            ab = new HandsetBrandM();

            ab.SetHandsetSoft(new HandsetGame());
            ab.Run();

            ab.SetHandsetSoft(new HandsetAddressList());
            ab.Run();
        }
    }

    internal abstract class HandsetSoft
    {
        public abstract void Run();
    }

    internal class HandsetGame : HandsetSoft
    {
        public override void Run()
        {
            Console.WriteLine("Run phone Game.");
        }
    }

    internal class HandsetAddressList : HandsetSoft
    {
        public override void Run()
        {
            Console.WriteLine("Phone Note.");
        }
    }

    internal abstract class HandsetBrand
    {
        protected HandsetSoft soft;

        public void SetHandsetSoft(HandsetSoft soft)
        {
            this.soft = soft;
        }

        public abstract void Run();
    }

    internal class HandsetBrandN : HandsetBrand
    {
        public override void Run()
        {
            soft.Run();
        }
    }

    internal class HandsetBrandM : HandsetBrand
    {
        public override void Run()
        {
            soft.Run();
        }
    }
}