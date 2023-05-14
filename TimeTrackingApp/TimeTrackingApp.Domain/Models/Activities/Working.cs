using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApp.Domain.Enums;

namespace TimeTrackingApp.Domain.Models.Activities
{
    public class Working : Activity
    {
        public WorkingActivitiy WorkingActivityType { get; set; }

        public Working(WorkingActivitiy WorkingActivityType, string Title, string Description, double Time) : base(Title, Description, Time)
        {
            this.WorkingActivityType = WorkingActivityType;
        }

        public Working():base("", "", 0)
        {
        }

        public  void displayActivities()
        {
            int i = 1;
            foreach (string name in Enum.GetNames(typeof(WorkingActivitiy)))
            {
                Console.WriteLine(i + "). " + name);
                i++;
            }
        }
    }
}
