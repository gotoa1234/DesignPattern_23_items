using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_23_items.DesignPattern.Chapter_10
{
    class TemplateMethod_10
    {
        public void TemplateMethodExecute()
        {
            AbstactClass c;

            c = new ConcreteClassA();
            c.TemplateMethod();

            c = new ConcreteClassB();
            c.TemplateMethod();

        }
    }

    abstract class AbstactClass
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("");
        }

    }

    class ConcreteClassA : AbstactClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("A");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("A");
        }
    }

    class ConcreteClassB : AbstactClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("B");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("B");
        }
    }
}
