using System;

namespace DesignPattern_23_items.DesignPattern.Chapter_25
{
    /// <summary>
    /// 【中介者模式】Mediator 行為型模式
    /// <para>
    /// 用一個中介對象來封裝一系列的對象交互。
    /// 中介者使各個對象不需要直接地相互引用，從而使其耦合松散，
    /// 而且可以獨立地改變它們之間的交互。
    /// </para>
    /// </summary>
    internal class Mediator_25
    {
        public void ExcuteOrigine()
        {
            //中介者
            ConcreteMediator m = new ConcreteMediator();

            //加入相同的中介者
            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;

            c1.Send("吃過飯了嗎");
            c2.Send("沒有呢! 你要請客嗎?");
        }

        /// <summary>
        /// 聯合國中介者
        /// </summary>
        public void ExcuteUnite()
        {
            UnitedNationsSecurityCouncil UNSC = new UnitedNationsSecurityCouncil();

            USA c1 = new USA(UNSC);
            China c2 = new China(UNSC);

            UNSC.Colleague1 = c1;
            UNSC.Colleague2 = c2;

            c1.Declare("開打");
            c2.Declare("來啊");
        }
    }

    #region 中介者模式原型

    /// <summary>
    /// 中介者
    /// </summary>
    internal abstract class Mediator
    {
        /// <summary>
        /// 發送消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="colleague"></param>
        public abstract void Send(string message, Colleague colleague);
    }

    /// <summary>
    /// 抽象同事類
    /// </summary>
    internal abstract class Colleague
    {
        /// <summary>
        /// 具有中介者協調
        /// </summary>
        protected Mediator mediator;

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="mediator"></param>
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }

    /// <summary>
    ///實體 同事2
    /// </summary>
    internal class ConcreteColleague1 : Colleague
    {
        /// <summary>
        /// 設定自己的中介者
        /// </summary>
        /// <param name="mediator"></param>
        public ConcreteColleague1(Mediator mediator) : base(mediator) { }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("同事1得到消息:" + message);
        }
    }

    /// <summary>
    /// 同事1
    /// </summary>
    internal class ConcreteColleague2 : Colleague
    {
        /// <summary>
        /// 設定自己的中介者
        /// </summary>
        /// <param name="mediator"></param>
        public ConcreteColleague2(Mediator mediator) : base(mediator) { }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("同事2得到消息:" + message);
        }
    }

    /// <summary>
    /// 中介者實作
    /// </summary>
    internal class ConcreteMediator : Mediator
    {
        #region 加入被協調的對象

        private ConcreteColleague1 _colleague1;
        private ConcreteColleague2 _colleague2;

        #endregion 加入被協調的對象

        public ConcreteColleague1 Colleague1
        {
            set => _colleague1 = value;
        }

        public ConcreteColleague2 Colleague2
        {
            set => _colleague2 = value;
        }

        /// <summary>
        /// 傳送對象
        /// </summary>
        /// <param name="message"></param>
        /// <param name="colleague"></param>
        public override void Send(string message, Colleague colleague)
        {
            if (colleague == _colleague1)
            {
                _colleague2.Notify(message);
            }
            else
            {
                _colleague1.Notify(message);
            }
        }
    }

    #endregion 中介者模式原型

    #region 聯合國中介模式

    /// <summary>
    /// 聯合國機構
    /// </summary>
    internal abstract class UnitedNations
    {
        /// <summary>
        /// 聲明
        /// </summary>
        /// <param name="message"></param>
        /// <param name="colleague"></param>
        public abstract void Declare(string message, Country colleague);
    }

    /// <summary>
    /// 國家
    /// </summary>
    internal abstract class Country
    {
        protected UnitedNations _mediator;

        public Country(UnitedNations mediator)
        {
            _mediator = mediator;
        }
    }

    internal class USA : Country
    {
        public USA(UnitedNations mediator) : base(mediator)
        {
        }

        /// <summary>
        ///  宣告
        /// </summary>
        /// <param name="message"></param>
        public void Declare(string message)
        {
            _mediator.Declare(message, this);
        }

        /// <summary>
        /// 接獲資訊
        /// </summary>
        /// <param name="message"></param>
        public void GetMessage(string message)
        {
            Console.WriteLine("美國獲得對方信息: " + message);
        }
    }

    internal class China : Country
    {
        public China(UnitedNations mediator) : base(mediator)
        {
        }

        /// <summary>
        /// 宣告
        /// </summary>
        /// <param name="message"></param>
        public void Declare(string message)
        {
            _mediator.Declare(message, this);
        }

        /// <summary>
        /// 接獲資訊
        /// </summary>
        /// <param name="message"></param>
        public void GetMessage(string message)
        {
            Console.WriteLine("中國獲得對方信息: " + message);
        }
    }

    internal class UnitedNationsSecurityCouncil : UnitedNations
    {
        private USA _colleague1;
        private China _colleague2;

        public USA Colleague1
        {
            set => _colleague1 = value;
        }

        public China Colleague2
        {
            set => _colleague2 = value;
        }

        public override void Declare(string message, Country colleague)
        {
            if (colleague == _colleague1)
            {
                _colleague2.GetMessage(message);
            }
            else
            {
                _colleague1.GetMessage(message);
            }
        }
    }

    #endregion 聯合國中介模式
}