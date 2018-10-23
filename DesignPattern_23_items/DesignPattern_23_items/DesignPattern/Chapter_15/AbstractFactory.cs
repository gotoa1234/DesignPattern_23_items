using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_23_items.DesignPattern.Chapter_15
{
    class AbstractFactory
    {

    }


    interface IDepartment
    {
        void Insert(IDepartment department);

        IDepartment GetDepartment(int id);
    }

    class SqlserverDepartment : IDepartment
    {
        public IDepartment GetDepartment(int id)
        {
            Console.WriteLine("Get");
            return null;
        }

        public void Insert(IDepartment department)
        {
            Console.WriteLine("ADD");
        }
    }

    class AccessDepartment : IDepartment
    {
        public IDepartment GetDepartment(int id)
        {
            Console.WriteLine("Get");
            return null;
        }

        public void Insert(IDepartment department)
        {
            Console.WriteLine("ADD");
        }
    }

    class User
    {
        private int _id;
        public int ID
        {
            get => _id;
            set => _id = value;
        }

        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }



    }

    interface IUser
    {
        void Insert(User user);

        User GetUser(int id);
    }

}
