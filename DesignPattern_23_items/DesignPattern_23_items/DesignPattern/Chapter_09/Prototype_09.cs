using System;

namespace DesignPattern_23_items.DesignPattern.Chapter_09
{
    /// <summary>
    /// 【原型模式】Prototype 創建型模式
    /// <para>
    /// 用原型實例指定創建對象的種類，並且通過複製
    /// 這些原型來創建新的對象
    /// </para>
    /// </summary>
    internal class Prototype_09
    {
        public void ExecuteSwallowClone()
        {
            //Shallow Clone
            ConcretePrototype1 p1 = new ConcretePrototype1("I");
            ConcretePrototype1 p2 = (ConcretePrototype1)p1.Clone();
            Console.WriteLine($"Cloned:{p2.ID}");
        }

        public void ExecuteDeepClone()
        {
            //Deep Clone
            WorkExperience s = new WorkExperience();
            s.Company = "IT";
            s.WorkDate = "2018-01-01";

            Resume x1 = new Resume(s);
            x1.SetPersonalInfo("女", "18");
            x1.SetWorkExperience("2018-0202", "HTC");
            var x2 = x1.Clone();
        }
    }

    #region Shallow Clone 淺層Clone

    internal abstract class Prototype
    {
        private string _id;

        public Prototype(string id)
        {
            _id = id;
        }

        public string ID
        {
            get => _id;
            set => _id = value;
        }

        public abstract Prototype Clone();
    }

    internal class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(string id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    #endregion Shallow Clone 淺層Clone

    #region Deep Clone 深層 Clone

    internal class WorkExperience : ICloneable
    {
        private string _workDate;
        private string _company;

        public string WorkDate
        {
            get => _workDate;
            set => _workDate = value;
        }

        public string Company
        {
            get => _company;
            set => _company = value;
        }

        public object Clone()
        {
            return (object)this.MemberwiseClone();
        }
    }

    internal class Resume : ICloneable
    {
        private string _name;
        private string _sex;
        private string _age;
        private WorkExperience _work;

        public Resume(WorkExperience wk)
        {
            this._work = (WorkExperience)wk.Clone();
        }

        public void SetPersonalInfo(string sex, string age)
        {
            this._sex = sex;
            this._age = age;
        }

        public void SetWorkExperience(string workDate, string company)
        {
            _work.WorkDate = workDate;
            _work.Company = company;
        }

        public void Display()
        {
        }

        public object Clone()
        {
            Resume obj = new Resume(this._work);
            obj._name = this._name;
            obj._sex = this._sex;
            obj._age = this._age;
            return obj;
        }
    }

    #endregion Deep Clone 深層 Clone
}