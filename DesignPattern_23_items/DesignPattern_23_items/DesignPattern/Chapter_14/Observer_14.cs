using System;
using System.Collections.Generic;

namespace DesignPattern_23_items.DesignPattern.Chapter_14
{
    /// <summary>
    /// 【觀察者模式】Observer 行為型模式
    /// <para>
    /// 定義了一種一對多的依賴關係，讓多個觀察者對象同時監聽某一個主題對象。
    /// 這個主題對象在狀態發生變化時，會通知所有觀察者對象，
    /// 使它們能夠自動更新自己
    /// </para>
    /// </summary>
    internal class Observer_14
    {
        public void ExecuteObserverStandard()
        {
            ConcreteSubject s = new ConcreteSubject();

            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            s.SubjectState = "ABC";
            s.Notify();
        }
    }

    #region Observer Origine

    /// <summary>
    /// Register
    /// </summary>
    internal class StockObserver
    {
        private string _name;
        private Secretary _sub;

        public StockObserver(string name, Secretary sub)
        {
            this._name = name;
            this._sub = sub;
        }

        public void Update()
        {
            Console.WriteLine($"{this._name} : {this._sub} Notify!!!");
        }
    }

    /// <summary>
    /// Publisher
    /// </summary>
    internal class Secretary
    {
        private IList<StockObserver> observers = new List<StockObserver>();
        private string _action;

        /// <summary>
        /// 增加註冊者
        /// </summary>
        /// <param name="observer"></param>
        public void Attach(StockObserver observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// 通知的動作
        /// </summary>
        public void Notify()
        {
            foreach (StockObserver o in observers)
                o.Update();
        }

        public string SecretaryAction
        {
            get => _action;
            set => _action = value;
        }
    }

    #endregion Observer Origine

    #region Observer Standard

    internal abstract class Observer
    {
        public abstract void Update();
    }

    internal abstract class Subject
    {
        private IList<Observer> observers = new List<Observer>();

        /// <summary>
        /// 增加觀察者
        /// </summary>
        /// <param name="register"></param>
        public void Attach(Observer register)
        {
            observers.Add(register);
        }

        /// <summary>
        /// 移除觀察者
        /// </summary>
        /// <param name="register"></param>
        public void Detach(Observer register)
        {
            observers.Remove(register);
        }

        /// <summary>
        /// 推播
        /// </summary>
        public void Notify()
        {
            foreach (var item in observers)
            {
                item.Update();
            }
        }
    }

    internal class ConcreteSubject : Subject
    {
        private string _subjectState;

        public string SubjectState
        {
            get => _subjectState;
            set => _subjectState = value;
        }
    }

    internal class ConcreteObserver : Observer
    {
        private string _name;
        private string _observerState;
        private ConcreteSubject _subject;

        private string Name
        {
            get => _name;
            set => _name = value;
        }

        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this._name = name;
            this._subject = subject;
        }

        public override void Update()
        {
            _observerState = _subject.SubjectState;
            Console.WriteLine($"觀察者{_name}的新狀態是{_observerState}");
        }
    }

    #endregion Observer Standard
}