using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_23_items.DesignPattern.Chapter_21
{
    class Singleton_21
    {
    }

    public sealed class Singleton
    {
        private Singleton()
        {
        }
        public static Singleton GetInstance { get; } = new Singleton();
    }

}
