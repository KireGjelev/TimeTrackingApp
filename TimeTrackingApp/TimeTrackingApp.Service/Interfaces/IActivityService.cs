using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApp.Domain.Models.Activities;

namespace TimeTrackingApp.Service.Interfaces
{
    public interface IActivityService<T> where T : Activity
    {
        public void addActivity(T activity);
        public void removeActivity(T activity);
        public void startActivityTimer(T activity);

        public void stopActivityTimer(T activity);
        public T getActivityById(int id);
    }
}
