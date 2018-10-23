using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_23_items.DesignPattern.Chapter_23
{
    class Command_23
    {
        public void ExecuteOpenShop()
        {
            //開店前準備 廚師 + 服務生
            Barbecuer boy = new Barbecuer();//廚師
            Waiter girl = new Waiter();//服務生

            //客人點菜
            Command bakeMuttonCommand1 = new BakeMuttonCommand(boy);
            Command bakeMuttonCommand2 = new BakeMuttonCommand(boy);
            Command bakeChickenWingCommand1 = new BakeChickenWingCommand(boy);

            //服務生紀錄點菜
            girl.SetOrder(bakeMuttonCommand1);
            girl.SetOrder(bakeMuttonCommand2);
            girl.SetOrder(bakeChickenWingCommand1);

            //通知廚房
            girl.Notify();
        }
    }


    /// <summary>
    /// 烤肉
    /// </summary>
    public class Barbecuer
    {
        public void BakeMutton()
        {
            Console.WriteLine("烤羊肉串!");
        }

        public void BakeChickenWing()
        {
            Console.WriteLine("烤雞翅");
        }

    }

    public abstract class Command
    {
        protected Barbecuer receiver;

        public Command(Barbecuer receiver)
        {
            this.receiver = receiver;
        }

        /// <summary>
        /// 執行命令
        /// </summary>
        abstract public void ExcuteCommand();
    }

    /// <summary>
    /// 烤羊肉
    /// </summary>
    class BakeMuttonCommand : Command
    {
        public BakeMuttonCommand(Barbecuer receiver) : base(receiver)
        {
        }

        public override void ExcuteCommand()
        {
            receiver.BakeMutton();
        }
    }

    /// <summary>
    /// 烤雞翅
    /// </summary>
    class BakeChickenWingCommand : Command
    {
        public BakeChickenWingCommand(Barbecuer receiver) : base(receiver)
        {
        }

        public override void ExcuteCommand()
        {
            receiver.BakeChickenWing();
        }
    }

    /// <summary>
    /// 服務員
    /// </summary>
    public class Waiter
    {
        private IList<Command> orders = new List<Command>();

        /// <summary>
        /// 寫下訂單
        /// </summary>
        /// <param name="command"></param>
        public void SetOrder(Command command)
        {
            if (command.GetType().ToString() == "命令模式.BakeChickenWingCommand")
            {
                Console.WriteLine("服務員反映 : 沒有雞翅請點別的");

            }
            else
            {
                orders.Add(command);
                Console.WriteLine($"增加訂單: {command.ToString()} 時間: {DateTime.Now.ToString()}");

            }

        }

        public void CancelOrder(Command command)
        {
            orders.Remove(command);
            Console.WriteLine($"取消訂單 {command.ToString()} 時間：{DateTime.Now.ToString()}");
        }

        /// <summary>
        /// 通知
        /// </summary>
        public void Notify()
        {
            foreach (var item in orders)
            {
                item.ExcuteCommand();
            }
        }

    }
}
