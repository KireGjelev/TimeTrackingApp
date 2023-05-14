using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApp.Domain.Models;

namespace TimeTrackingApp.Domain.DBInterface
{
    public interface IDatabase<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        User GetByUsername(string username);
        int Add(T entity);
        void RemoveById(int id);
        void Update(T entity);
    }
}