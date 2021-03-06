﻿using System;

namespace DesignPattern_23_items.DesignPattern.Chapter_16
{
    /// <summary>
    /// 【狀態模式】State 行為型模式
    /// <para>
    /// 當一個對象的內在狀態改變時允許改變其行為，
    /// 這個對象看起來像是改變了其類。
    /// </para>
    /// </summary>
    internal class State_16
    {
        public void ExecuteWorkState()
        {
            Work project = new Work();
            for (int i = 9; i < 20; i++)
            {
                project.Hour = i;
                project.WriteProgram();
            }
        }

        public void ExecutePropertyStatePatten()
        {
            Context c = new Context(new ConcreteStateA());

            c.Request();
            c.Request();
            c.Request();
            c.Request();
        }
    }

    #region 1. Origine Class

    public class Work
    {
        private int _hour;
        private bool _finish = false;

        public int Hour
        {
            get => _hour;
            set => _hour = value;
        }

        public bool Finish
        {
            get => _finish;
            set => _finish = value;
        }

        public void WriteProgram()
        {
            if (_hour < 12)
            {
                Console.WriteLine("上午");
            }
            else if (_hour < 13)
            {
                Console.WriteLine("中午");
            }
            else if (_hour < 17)
            {
                Console.WriteLine("下午");
            }
            else
            {
                if (_finish)
                {
                    Console.WriteLine("下班");
                }
                else
                {
                    Console.WriteLine("加班");
                }
            }
        }
    }

    #endregion 1. Origine Class

    #region 2. Property State Patten

    internal class Context
    {
        private State _state;

        public Context(State state)
        {
            this._state = state;
        }

        public State State
        {
            get => _state;
            set => _state = value;
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }

    internal abstract class State
    {
        public abstract void Handle(Context context);
    }

    internal class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
            Console.WriteLine($"{context.State}");
        }
    }

    internal class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateC();
            Console.WriteLine($"{context.State}");
        }
    }

    internal class ConcreteStateC : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
            Console.WriteLine($"{context.State}");
        }
    }

    #endregion 2. Property State Patten

    #region 3. Finish Class

    internal class ContextWork
    {
        private State _state;

        public ContextWork(State state)
        {
            this._state = state;
        }

        public State State
        {
            get => _state;
            set => _state = value;
        }

        //public void Request()
        //{
        //    _state.Handle(this);
        //}
    }

    internal abstract class WorkState
    {
        public abstract void Working(ContextWork context);
    }

    internal class WorkingAM : WorkState
    {
        public override void Working(ContextWork context)
        {
            //context.State = new WorkingNoon();
        }
    }

    internal class WorkingNoon : WorkState
    {
        public override void Working(ContextWork context)
        {
            throw new NotImplementedException();
        }
    }

    internal class WorkingPM : WorkState
    {
        public override void Working(ContextWork context)
        {
            throw new NotImplementedException();
        }
    }

    internal class WorkingNight : WorkState
    {
        public override void Working(ContextWork context)
        {
            throw new NotImplementedException();
        }
    }

    #endregion 3. Finish Class
}