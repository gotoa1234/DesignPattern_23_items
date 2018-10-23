using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_23_items.DesignPattern.Chapter_12
{
    class Facade_12
    {
        public void FacadeExecute()
        {
            Facade fc = new Facade();

            fc.CombinateA();
            fc.CombinateB();

        }
    }
    class SubSystemOne
    {
        public void MethondOne()
        {
            Console.WriteLine("子系統方法一");
        }

    }

    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine("子系統方法二");
        }
    }

    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine("子系統方法三");
        }
    }

    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine("子系統方法四");
        }
    }

    class Facade
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
