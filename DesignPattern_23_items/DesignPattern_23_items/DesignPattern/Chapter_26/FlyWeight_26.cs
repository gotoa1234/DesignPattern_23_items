using System;
using System.Collections;
using System.Linq;

namespace DesignPattern_23_items.DesignPattern.Chapter_26
{
    /// <summary>
    /// 【享元模式】Fly Weight 結構型模式
    /// <para>
    /// 運用共享技術有效地支持大量細粒度的對象。
    /// </para>
    /// </summary>
    class FlyWeight_26
    {
        public void ExcuteOriFlyWeight()
        {
            int extrinsicstate = 22;

            FlyweightFactory f = new FlyweightFactory();

            Flyweight fx = f.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight fy = f.GetFlyweight("Y");
            fx.Operation(--extrinsicstate);

            Flyweight fz = f.GetFlyweight("Z");
            fx.Operation(--extrinsicstate);

            UnsharedConcreteFlyweight uf = new UnsharedConcreteFlyweight();
            uf.Operation(--extrinsicstate);


        }

        /// <summary>
        /// 享元模式個人網站
        /// </summary>
        public void ExcuteWebsiteFlyWeight()
        {
            WebSiteFactory f = new WebSiteFactory();
            WebSite fx = f.GetWebSiteCategory("產品展示");
            fx.Use();

            WebSite fy = f.GetWebSiteCategory("產品展示");
            fy.Use();

            WebSite fz = f.GetWebSiteCategory("產品展示");
            fz.Use();

            WebSite fl = f.GetWebSiteCategory("柏克萊");
            fl.Use();

            WebSite fm = f.GetWebSiteCategory("柏克萊");
            fm.Use();

            WebSite fn = f.GetWebSiteCategory("柏克萊");
            fn.Use();

            Console.WriteLine($"網站分類總數{f.GetWebSiteCount()}");


        }

        /// <summary>
        /// 享元模式帳號身分網站
        /// </summary>
        public void ExcuteWebsiteAccountFlyWeight()
        {
            WebSiteAccountFactory f = new WebSiteAccountFactory();
            WebSiteAccount fx = f.WebSiteAccountCategory("產品展示");
            fx.Use(new User("A"));

            WebSiteAccount fy = f.WebSiteAccountCategory("產品展示");
            fy.Use(new User("B"));

            WebSiteAccount fz = f.WebSiteAccountCategory("產品展示");
            fz.Use(new User("C"));

            WebSiteAccount fl = f.WebSiteAccountCategory("柏克萊");
            fl.Use(new User("D"));

            WebSiteAccount fm = f.WebSiteAccountCategory("柏克萊");
            fm.Use(new User("E"));

            WebSiteAccount fn = f.WebSiteAccountCategory("柏克萊");
            fn.Use(new User("F"));

            Console.WriteLine($"網站分類總數{f.GetWebSiteCount()}");


        }
    }

    #region 享元模式原型
    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);

    }

    class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("具體 Fleweight : " + extrinsicstate);
        }
    }

    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("不共享的具體 Flyweight:" + extrinsicstate);
        }
    }

    /// <summary>
    /// 享元工廠
    /// </summary>
    class FlyweightFactory
    {
        private Hashtable flyweights = new Hashtable();

        public FlyweightFactory()
        {
            //生成三個實例
            flyweights.Add("X", new ConcreteFlyweight());
            flyweights.Add("Y", new ConcreteFlyweight());
            flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return (Flyweight)flyweights[key];
        }
    }
    #endregion

    abstract class WebSite
    {
        public abstract void Use();
    }

    /// <summary>
    /// 具體網站類
    /// </summary>
    class ConcreteWebSite : WebSite
    {
        private string _name = "";

        public ConcreteWebSite(string name)
        {
            this._name = name;

        }

        public override void Use()
        {
            Console.WriteLine($"網站分類:{_name}");
        }
    }

    class WebSiteFactory
    {
        private Hashtable flyweight = new Hashtable();

        /// <summary>
        /// 取得網站實例
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public WebSite GetWebSiteCategory(string key)
        {
            if (!flyweight.ContainsKey(key))
            {
                flyweight.Add(key, new ConcreteWebSite(key));
            }

            return (WebSite)flyweight[key];
        }

        /// <summary>
        /// 取得網站種類數
        /// </summary>
        /// <returns></returns>
        public int GetWebSiteCount()
        {
            return flyweight.Count;
        }
    }
    #region 含有帳號

    class User
    {
        private string _name;

        public User(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }

    abstract class WebSiteAccount
    {
        public abstract void Use(User user);
    }

    /// <summary>
    /// 具體網站類
    /// </summary>
    class ConcreteWebSiteAccount : WebSiteAccount
    {
        private string _name = "";

        public ConcreteWebSiteAccount(string name)
        {
            this._name = name;

        }

        public override void Use(User user)
        {
            Console.WriteLine($"網站分類:{_name} 用戶: {user.Name}");
        }
    }

    class WebSiteAccountFactory
    {
        private Hashtable flyweight = new Hashtable();

        /// <summary>
        /// 取得網站帳戶實例
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public WebSiteAccount WebSiteAccountCategory(string key)
        {
            if (!flyweight.ContainsKey(key))
            {
                flyweight.Add(key, new ConcreteWebSiteAccount(key));
            }

            return (WebSiteAccount)flyweight[key];
        }

        /// <summary>
        /// 取得網站種類數
        /// </summary>
        /// <returns></returns>
        public int GetWebSiteCount()
        {
            return flyweight.Count;
        }
    }
    #endregion



}
