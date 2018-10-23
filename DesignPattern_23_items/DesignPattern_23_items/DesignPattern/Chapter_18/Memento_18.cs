using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_23_items.DesignPattern.Chapter_18
{
    class Memento_18
    {
        public void HistoryExecte()
        {
            GameRole lixiaoyao = new GameRole();
            lixiaoyao.GetInitState();
            lixiaoyao.StateDisplay();

            //紀錄
            GameRole back = new GameRole();
            back.Vitality = lixiaoyao.Vitality;
            back.Attack = lixiaoyao.Attack;
            back.Defense = lixiaoyao.Defense;

            //大戰Boss時
            lixiaoyao.Fight();
            lixiaoyao.StateDisplay();

            //Loading
            lixiaoyao.Vitality = back.Vitality;
            lixiaoyao.Attack = back.Attack;
            lixiaoyao.Defense = back.Defense;

            lixiaoyao.StateDisplay();


        }

        public void ExecuteState()
        {
            Originator o = new Originator();
            o.State = "On";
            o.Show();

            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            o.State = "Off";
            o.Show();

            o.SetMemento(c.Memento);
            o.Show();



        }

        public void UltmateExcute()
        {
            Console.WriteLine(" BOSS Bettle Before.");
            GamePlayer lix = new GamePlayer();
            lix.GetInitState();//初始化
            lix.StateDisplay();//顯示資料

            Console.WriteLine(" Save.");//紀錄
            RoleStateCaretaker sataeAdmin = new RoleStateCaretaker();
            sataeAdmin.Memento = lix.SaveState();

            Console.WriteLine(" Boss Bettle After.");
            lix.Fight();
            lix.StateDisplay();

            Console.WriteLine(" Load.");
            lix.RecoveryState(sataeAdmin.Memento);
            lix.StateDisplay();
        }
    }

    class GameRole
    {

        /// <summary>
        /// 生命力
        /// </summary>
        private int _vit;
        /// <summary>
        /// 攻擊力
        /// </summary>
        private int _atk;
        /// <summary>
        /// 防禦力
        /// </summary>
        private int _def;


        public int Vitality
        {
            get => _vit;
            set => _vit = value;
        }

        public int Attack
        {
            get => _atk;
            set => _atk = value;
        }

        public int Defense
        {
            get => _def;
            set => _def = value;
        }

        public void StateDisplay()
        {
            Console.WriteLine("當前狀態");
            Console.WriteLine($"生命:{Vitality }");
            Console.WriteLine($"攻擊力:{Attack}");
            Console.WriteLine($"防禦力:{Defense}");
        }

        public void GetInitState()
        {
            this.Vitality = 100;
            this.Attack = 100;
            this.Defense = 100;
        }

        public void Fight()
        {
            this.Vitality = 0;
            this.Attack = 0;
            this.Defense = 0;
        }
    }

    class Originator
    {
        private string _state;
        public string State
        {
            get => _state;
            set => _state = value;
        }

        public Memento CreateMemento()
        {
            return new Memento(_state);
        }

        public void SetMemento(Memento memento)
        {
            _state = memento.State;
        }

        public void Show()
        {
            Console.WriteLine($"State = {_state}");
        }
    }

    class Memento
    {
        private string _state;
        public Memento(string state)
        {
            _state = state;
        }

        public string State
        {
            get => _state;
            set => _state = value;
        }
    }

    /// <summary>
    /// Manager
    /// </summary>
    class Caretaker
    {
        private Memento _memento;

        public Memento Memento
        {
            get => _memento;
            set => _memento = value;
        }
    }


    #region Ultmate Version

    class GamePlayer
    {
        private int _attack;

        private int _life;

        private int _defense;

        public int Attack
        {
            get => _attack;
            set => _attack = value;
        }
        public int Life
        {
            get => _life;
            set => _life = value;
        }
        public int Defense
        {
            get => _defense;
            set => _defense = value;
        }

        public RoleStateMemento SaveState()
        {
            return (new RoleStateMemento(_life, _attack, _defense));
        }

        public void RecoveryState(RoleStateMemento memento)
        {
            this.Life = memento.Life;
            this.Attack = memento.Attack;
            this.Defense = memento.Defense;
        }

        public void StateDisplay()
        {
            Console.WriteLine("當前狀態");
            Console.WriteLine($"生命:{_life }");
            Console.WriteLine($"攻擊力:{_attack}");
            Console.WriteLine($"防禦力:{_defense}");
        }

        public void GetInitState()
        {
            this._life = 100;
            this.Attack = 100;
            this.Defense = 100;
        }

        public void Fight()
        {
            this._life = 0;
            this.Attack = 0;
            this.Defense = 0;
        }
    }

    class RoleStateMemento
    {
        private int _life;
        private int _atk;
        private int _def;

        public RoleStateMemento(int life, int atk, int def)
        {
            this._atk = atk;
            this._life = life;
            this._def = def;
        }

        public int Life
        {
            get => _life;
            set => _life = value;
        }
        public int Attack
        {
            get => _atk;
            set => _atk = value;
        }
        public int Defense
        {
            get => _def;
            set => _def = value;
        }
    }

    class RoleStateCaretaker
    {
        private RoleStateMemento _memento;

        public RoleStateMemento Memento
        {
            get => _memento;
            set => _memento = value;
        }


    }
    #endregion
}
