using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_23_items.DesignPattern.Chapter_02
{
    class Strategy_02
    {
        /// <summary>
        /// 策略模式
        /// </summary>
        public void ExecuteStrategyMode()
        {
            CashSuper strage1 = new CashNormal();//正常狀況
            Console.WriteLine($"Class Type => {strage1.GetType()} 金額 => {50} 策略運算 => {strage1.AcceptCashResult(50)}");
            Console.WriteLine($"Class Type => {strage1.GetType()} 金額 => {20} 策略運算 => {strage1.AcceptCashResult(20)}");

            strage1 = new CashRebate("0.8");//打8折 
            Console.WriteLine($"Class Type => {strage1.GetType()} 金額 => {50} 策略運算 => {strage1.AcceptCashResult(50)}");
            Console.WriteLine($"Class Type => {strage1.GetType()} 金額 => {20} 策略運算 => {strage1.AcceptCashResult(20)}");

            strage1 = new CashReturn("15", "5");//消費15 元 返金5元
            Console.WriteLine($"Class Type => {strage1.GetType()} 金額 => {50} 策略運算 => {strage1.AcceptCashResult(50)}");
            Console.WriteLine($"Class Type => {strage1.GetType()} 金額 => {20} 策略運算 => {strage1.AcceptCashResult(20)}");

        }

        /// <summary>
        /// 策略模式 - 原型
        /// </summary>
        public void ExecuteStrategyOrigine()
        {
            ///策略模式變數
            Context context;
            //進行策略A
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            //進行策略B
            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

        }
    }

    #region 策略模式 原型

    /// <summary>
    /// 抽象算法
    /// </summary>
    abstract class Strategy
    {
        /// <summary>
        /// 算法方法 Method
        /// </summary>
        public abstract void AlgorithmInterface();

    }

    /// <summary>
    /// 實體子類 - 策略A
    /// </summary>
    class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("策略執行A");
        }
    }

    /// <summary>
    /// 實體子類 - 策略B
    /// </summary>
    class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("策略執行B");
        }
    }

    class Context
    {
        Strategy _strategy;

        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }

    #endregion

    #region 策略模式 - 消費策略範例

    /// <summary>
    /// 父類 - 抽象類別
    /// </summary>
    abstract class CashSuper
    {
        public virtual double AcceptCashResult(double money)
        {
            return money;
        }
    }

    /// <summary>
    /// 一般策略
    /// </summary>
    class CashNormal : CashSuper
    {
    }

    /// <summary>
    /// 打折策略 
    /// </summary>
    class CashRebate : CashSuper
    {
        private double moneyRebate = 1d;

        /// <summary>
        /// 輸入打折比例
        /// </summary>
        /// <param name="moneyRebate"></param>
        public CashRebate(string moneyRebate)
        {
            this.moneyRebate = double.Parse(moneyRebate);
        }

        /// <summary>
        /// 回傳該策略運算結果
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public override double AcceptCashResult(double money)
        {
            return this.moneyRebate * money;
        }
    }

    /// <summary>
    /// 返利策略 
    /// </summary>
    class CashReturn : CashSuper
    {
        private readonly double _moneyCondition = 0.0d;
        private readonly double _moneyReturn = 0.0d;

        /// <summary>
        /// 輸入 返利條件 + 返利金額
        /// </summary>
        /// <param name="moneyCondition">返利條件</param>
        /// <param name="moneyReturn">返利金額</param>
        public CashReturn(string moneyCondition, string moneyReturn)
        {
            this._moneyCondition = double.Parse(moneyCondition);

            this._moneyReturn = double.Parse(moneyReturn);
        }

        /// <summary>
        /// 計算結果
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public override double AcceptCashResult(double money)
        {
            double result = money;

            if (money > _moneyCondition)
                result = money - Math.Floor(money / _moneyCondition) * _moneyReturn;

            return result;
        }
    }

    #endregion

}
