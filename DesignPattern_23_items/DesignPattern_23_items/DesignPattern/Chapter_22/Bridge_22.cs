using System;

namespace DesignPattern_23_items.DesignPattern.Chapter_22
{
    class Bridge_22
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

    abstract class HandsetSoft
    {
        public abstract void Run();
    }

    class HandsetGame : HandsetSoft
    {
        public override void Run()
        {
            Console.WriteLine("Run phone Game.");
        }
    }

    class HandsetAddressList : HandsetSoft
    {
        public override void Run()
        {
            Console.WriteLine("Phone Note.");
        }
    }

    abstract class HandsetBrand
    {
        protected HandsetSoft soft;

        public void SetHandsetSoft(HandsetSoft soft)
        {
            this.soft = soft;
        }

        public abstract void Run();
    }

    class HandsetBrandN : HandsetBrand
    {
        public override void Run()
        {
            soft.Run();
        }
    }

    class HandsetBrandM : HandsetBrand
    {
        public override void Run()
        {
            soft.Run();
        }
    }

}
