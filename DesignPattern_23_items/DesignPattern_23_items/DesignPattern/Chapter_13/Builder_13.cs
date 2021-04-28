using System;
using System.Collections.Generic;
using System.Drawing;

namespace DesignPattern_23_items.DesignPattern.Chapter_13
{
    /// <summary>
    /// 【建造者模式】Builder 創建型模式
    /// <para>
    /// 將一個複雜對象的構建與它的表示分離，
    /// 使得同樣的構建過程可以創建不同的表示。
    /// </para>
    /// </summary>
    internal class Builder_13
    {
        public Builder_13()
        {
            //Graphics g = new PictureBox().CreateGraphics();
            //Pen p = new Pen(Color.Yellow);
            //PersonThinBuilder ptb = new PersonThinBuilder(g, p);
            //Director Manager = new Director(ptb);
            //Manager.CreateBuilder();
            DirectorFactory df = new DirectorFactory();
            Builder x1 = new ConcreteBuilder1();
            Builder x2 = new ConcreteBuilder2();

            df.Construct(x1);
            Product p1 = x1.GetResult();
            p1.show();

            df.Construct(x2);
            Product p2 = x2.GetResult();
            p2.show();
        }
    }

    #region Basic Builder

    internal abstract class PersonBuilder
    {
        protected Graphics g;
        protected Pen p;

        public PersonBuilder(Graphics g, Pen p)
        {
            this.g = g;
            this.p = p;
        }

        public abstract void BuildeHead();

        public abstract void BuildeBody();

        public abstract void BuildeFoot();
    }

    /// <summary>
    /// Thin Man
    /// </summary>
    internal class PersonThinBuilder : PersonBuilder
    {
        public PersonThinBuilder(Graphics g, Pen p) : base(g, p)
        {
        }

        public override void BuildeBody()
        {
            Console.WriteLine("Thin Builder Body");
        }

        public override void BuildeFoot()
        {
            Console.WriteLine("Thin Builder Foot");
        }

        public override void BuildeHead()
        {
            Console.WriteLine("Thin Builder Head");
        }
    }

    internal class Director
    {
        private PersonBuilder _pb;

        public Director(PersonBuilder pb)
        {
            this._pb = pb;
        }

        public void CreateBuilder()
        {
            _pb.BuildeBody();
            _pb.BuildeFoot();
            _pb.BuildeHead();
        }
    }

    #endregion Basic Builder

    #region Extension Builder

    internal class Product
    {
        private IList<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void show()
        {
            Console.WriteLine("Product Builder == :");

            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }
        }
    }

    internal abstract class Builder
    {
        public abstract void BuilderPartA();

        public abstract void BuilderPartB();

        public abstract Product GetResult();
    }

    internal class ConcreteBuilder1 : Builder
    {
        private Product _product = new Product();

        public override void BuilderPartA()
        {
            _product.Add("Componet A");
        }

        public override void BuilderPartB()
        {
            _product.Add("Componet B");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    internal class ConcreteBuilder2 : Builder
    {
        private Product _product = new Product();

        public override void BuilderPartA()
        {
            _product.Add("Componet X");
        }

        public override void BuilderPartB()
        {
            _product.Add("Componet Z");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    internal class DirectorFactory
    {
        public void Construct(Builder builder)
        {
            builder.BuilderPartA();
            builder.BuilderPartB();
        }
    }

    #endregion Extension Builder
}