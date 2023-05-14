using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApp.Domain.DataBase;
using TimeTrackingApp.Domain.DBInterface;
using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.Service.Interfaces;

namespace TimeTrackingApp.Service.Implementation
{
    public class UserService<T> : IUserService<T> where T : User
    {
        private IDatabase<T> _database;

        public UserService()
        {
            this._database = new FileDataBase<T>();
        }

        public User GetUserByUserName(string userName)
        {
            User user = this._database.GetByUsername(userName);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public void RegisterUser(T user)
        {
            _database.Add(user);
        }
    }
}
