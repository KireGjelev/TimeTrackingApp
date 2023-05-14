using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApp.Domain.Models;

namespace TimeTrackingApp.Service.Interfaces
{
    public interface IUserService<T> where T : User
    {
        public void RegisterUser(T user);

        public User GetUserByUserName(string userName);
    }   
}