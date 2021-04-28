using System;

namespace DesignPattern_23_items.DesignPattern.Chapter_10
{
    /// <summary>
    /// 【模板模式】Template Method 行為型模式
    /// <para>
    /// 定義一個操作中的算法骨架(基底)，而將一些步驟延遲到子類中實例。
    /// 模板方法可以不改變一個算法的結構即可重定義該算法的某些特定步驟。
    /// </para>
    /// </summary>
    internal class TemplateMethod_10
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

    internal abstract class AbstactClass
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

    internal class ConcreteClassA : AbstactClass
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

    internal class ConcreteClassB : AbstactClass
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