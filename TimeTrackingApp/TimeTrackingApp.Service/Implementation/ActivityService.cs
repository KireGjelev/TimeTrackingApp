using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApp.Domain.DataBase;
using TimeTrackingApp.Domain.DBInterface;
using TimeTrackingApp.Domain.Models.Activities;
using TimeTrackingApp.Service.Interfaces;

namespace TimeTrackingApp.Service.Implementation
{
    public class ActivityService<T> : IActivityService<T> where T : Activity
    {
        private IDatabase<T> _database;

        public ActivityService()
        {
            this._database = new FileDataBase<T>();
        }
        
        public void addActivity(T activity)
        {
            _database.Add(activity);
        }

        public T getActivityById(int id)
        {
           T activity = _database.GetById(id);
           return activity;
        }

        public void removeActivity(T activity)
        {
            _database.RemoveById(activity.Id);
        }

        public void startActivityTimer(T activity)
        {
            throw new NotImplementedException(); //here
        }

        public void stopActivityTimer(T activity)
        {
            throw new NotImplementedException();
        }
    }
}
