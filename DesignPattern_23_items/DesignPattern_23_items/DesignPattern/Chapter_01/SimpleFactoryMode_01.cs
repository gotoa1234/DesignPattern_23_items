using System;

namespace DesignPattern_23_items.DesignPattern.Chapter_01
{
    class SimpleFactoryMode_01
    {
        /// <summary>
        /// 簡單工廠模式 - 計算
        /// </summary>
        public void SampleFactoryModeExecute()
        {
            //一般運算 Add 
            var add = new Add();
            add.NumberA = 10d;
            add.NumberB = 15d;
            add.GetResult();

            //一般運算 Sub 
            var sub = new Sub();
            sub.NumberA = 23d;
            sub.NumberB = 39d;
            sub.GetResult();

            //工廠呼叫 - 嘗試建立 "+"
            Operation operationsA;//建立一個Operation (父類)
            operationsA = EasyFactory.Runing("+");//依照傳進的"物件" 得到對應的子類別
            //此時可以設定值
            operationsA.NumberA = 993;
            operationsA.NumberB = 456;
            Console.WriteLine($"Class Type: {operationsA.GetType()}  運算結果: {operationsA.GetResult()}");

            //工廠呼叫 - 嘗試建立 "-"
            Operation operationsB;//建立一個Operation (父類)
            operationsB = EasyFactory.Runing("-");//依照傳進的"物件" 得到對應的子類別
            //此時可以設定值
            operationsB.NumberA = 993;
            operationsB.NumberB = 456;
            Console.WriteLine($"Class Type: {operationsB.GetType()}  運算結果: {operationsB.GetResult()}");




        }

        /// <summary>
        /// 父類 - 運算
        /// </summary>
        public class Operation
        {
            private double _numberA;
            private double _numberB;

            public double NumberA
            {
                get { return _numberA; }
                set { _numberA = value; }

            }

            public double NumberB
            {
                get { return _numberB; }
                set { _numberB = value; }
            }

            /// <summary>
            /// 回傳計算結果 
            /// </summary>
            /// <returns></returns>
            public virtual double GetResult()
            {
                double result = 0d;
                return result;
            }
        }

        /// <summary>
        /// 子類 - 加法 : 繼承運算
        /// </summary>
        public class Add : Operation
        {
            /// <summary>
            /// 覆寫【相加】取得計算結果
            /// </summary>
            /// <returns></returns>
            public override double GetResult()
            {
                double result = 0d;
                result = NumberA + NumberB;
                return result;
            }
        }

        /// <summary>
        /// 子類 - 減法 : 繼承運算
        /// </summary>
        public class Sub : Operation
        {
            /// <summary>
            /// 覆寫【相減】取得計算結果
            /// </summary>
            /// <returns></returns>
            public override double GetResult()
            {
                double result = 0d;
                result = NumberA - NumberB;
                return result;
            }
        }

        /// <summary>
        /// 簡單工廠模式 - 提供運算數值的結果
        /// </summary>
        public static class EasyFactory
        {
            public static Operation Runing(string operation)
            {
                switch (operation)
                {
                    case "+":
                        return new Add();

                    case "-":
                        return new Sub();
                }
                return new Operation();
            }

        }
    }
}
