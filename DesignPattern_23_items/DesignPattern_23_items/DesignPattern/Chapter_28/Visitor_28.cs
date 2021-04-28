using System;
using System.Collections.Generic;

namespace DesignPattern_23_items.DesignPattern.Chapter_28
{
    /// <summary>
    /// 【訪問者模式】Visitor 行為型模式
    /// <para>
    /// 表示一個作用於某對象結構中的各元素的操作者。
    /// 它使你可以在不改變元素的類的前提下定義作用於這些元素的新操作。
    /// </para>
    /// </summary>
    internal class Visitor_28
    {
        /// <summary>
        /// 拜訪者
        /// </summary>
        public void ExcuteVisitor()
        {
            IList<Person> persons = new List<Person>();

            Person man1 = new Man();
            man1.Action = "成功";
            persons.Add(man1);

            Person woman1 = new Woman();
            woman1.Action = "成功";
            persons.Add(woman1);

            Person man2 = new Man();
            man2.Action = "失敗";
            persons.Add(man2);

            Person woman2 = new Woman();
            woman2.Action = "失敗";
            persons.Add(woman2);

            Person man3 = new Man();
            man3.Action = "戀愛";
            persons.Add(man3);

            Person woman3 = new Woman();
            woman3.Action = "戀愛";
            persons.Add(woman3);

            foreach (Person item in persons)
            {
                item.GetConclusion();
            }
        }

        /// <summary>
        /// 抽象人類
        /// </summary>
        private abstract class Person
        {
            protected string _action;

            public string Action
            {
                get => _action;
                set => _action = value;
            }

            /// <summary>
            /// 得到結論或反應
            /// </summary>
            public abstract void GetConclusion();
        }

        private class Man : Person
        {
            public override void GetConclusion()
            {
                if (_action == "成功")
                {
                    Console.WriteLine($"{this.GetType().Name} {_action}，背後多半有一個偉大的女人");
                }
                else if (_action == "失敗")
                {
                    Console.WriteLine($"{this.GetType().Name} {_action}，悶頭喝酒，誰也不用勸");
                }
                else if (_action == "戀愛")
                {
                    Console.WriteLine($"{this.GetType().Name} {_action}，凡事不懂也要裝懂");
                }
            }
        }

        private class Woman : Person
        {
            public override void GetConclusion()
            {
                if (_action == "成功")
                {
                    Console.WriteLine($"{this.GetType().Name} {_action}，背後多半有一個不成功的男人");
                }
                else if (_action == "失敗")
                {
                    Console.WriteLine($"{this.GetType().Name} {_action}，眼淚汪汪，誰也勸不了");
                }
                else if (_action == "戀愛")
                {
                    Console.WriteLine($"{this.GetType().Name} {_action}，遇事懂也裝不懂");
                }
            }
        }
    }
}