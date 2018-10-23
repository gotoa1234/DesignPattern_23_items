using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_23_items.DesignPattern.Chapter_24
{
    class ChainOfResponsibility_24
    {
        /// <summary>
        /// 申請類別
        /// </summary>
        private string _requestType;
        public string RequestType
        {
            get => _requestType;
            set => _requestType = value;
        }

        /// <summary>
        /// 申請內容
        /// </summary>
        private string _requestContent;
        public string RequestContent
        {
            get => _requestContent;
            set => _requestContent = value;
        }

        private int _number;
        public int Number
        {
            get => _number;
            set => _number = value;
        }
    }

    /// <summary>
    /// 申請
    /// </summary>
    class Request
    {
        /// <summary>
        /// 申請類別
        /// </summary>
        private string _requestType;
        public string RequestType
        {
            get => _requestType;
            set => _requestType = value;
        }

        /// <summary>
        /// 申請內容
        /// </summary>
        private string _requestContent;
        public string RequestContent
        {
            get => _requestContent;
            set => _requestContent = value;
        }

        private int _number;
        public int Number
        {
            get => _number;
            set => _number = value;
        }
    }

    /// <summary>
    /// 管理者
    /// </summary>
    abstract class Manager
    {
        protected string _name;
        /// <summary>
        /// 管理者的上級
        /// </summary>
        protected Manager _superior;

        protected Manager(string name)
        {
            this._name = name;
        }

        /// <summary>
        /// 設置管理者的上級
        /// </summary>
        /// <param name="superior"></param>
        public void SetSuperior(Manager superior)
        {
            this._superior = superior;
        }

        /// <summary>
        /// 申請請求
        /// </summary>
        /// <param name="request"></param>
        abstract public void RequestApplications(Request request);
    }

    /// <summary>
    /// 一般主管
    /// </summary>
    class CommonManager : Manager
    {
        public CommonManager(string name) : base(name)
        { }

        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "請假" && request.Number < 2)
            {
                Console.WriteLine($"{_name} : {request.RequestContent} 數量{request.Number} 批准");
            }
            else if (_superior != null)
            {
                _superior.RequestApplications(request);
            }
        }
    }

    /// <summary>
    /// 總監
    /// </summary>
    class Majordomo : Manager
    {
        public Majordomo(string name) : base(name) { }

        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "請假" && request.Number <= 5)
            {
                Console.WriteLine($"{_name} : {request.RequestContent} 天數{request.Number} 批准");
            }
            else if (_superior != null)
            {
                _superior.RequestApplications(request);
            }
        }
    }

    /// <summary>
    /// 老闆
    /// </summary>
    class Boss : Manager
    {
        public Boss(string name) : base(name) { }

        public override void RequestApplications(Request request)
        {
            if (request.RequestType == "請假")
            {
                Console.WriteLine($"{_name} : {request.RequestContent} 天數:{request.Number} 批准");
            }
            else if (request.RequestType == "加薪" && request.Number <= 500)
            {
                Console.WriteLine($"{_name} : {request.RequestContent} 加薪幅度 :{request.Number} 批准");
            }
            else if (request.RequestType == "加薪" && request.Number >= 500)
            {
                Console.WriteLine($"{_name} : {request.RequestContent} 加薪幅度 :{request.Number} 考慮");
            }
        }
    }
}
