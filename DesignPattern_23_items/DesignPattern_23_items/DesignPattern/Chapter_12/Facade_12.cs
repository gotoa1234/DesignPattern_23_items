using System;

namespace DesignPattern_23_items.DesignPattern.Chapter_12
{
    /// <summary>
    /// 【外觀模式】Facade 結構型模式
    /// <para>
    /// 為子系統中的一組接口提供一個一致的操作界面，
    /// 此模式定義了一個高階接口，這個接口使得這一子系統更加容易使用。
    /// </para>
    /// </summary>
    internal class Facade_12
    {
        public void FacadeExecute()
        {
            Facade fc = new Facade();

            fc.CombinateA();
            fc.CombinateB();
        }
    }

    internal class SubSystemOne
    {
        public void MethondOne()
        {
            Console.WriteLine("子系統方法一");
        }
    }

    internal class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine("子系統方法二");
        }
    }

    internal class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine("子系統方法三");
        }
    }

    internal class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine("子系統方法四");
        }
    }

    internal class Facade
    {
        private SubSystemOne _one;
        private SubSystemTwo _two;
        private SubSystemThree _three;
        private SubSystemFour _four;

        public Facade()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
            _four = new SubSystemFour();
        }

        public void CombinateA()
        {
            _one.MethondOne();
            _three.MethodThree();
        }

        public void CombinateB()
        {
            _two.MethodTwo();
            _four.MethodFour();
        }
    }
}