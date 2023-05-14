using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApp.Domain.Enums;

namespace TimeTrackingApp.Domain.Models.Activities
{
    public class Reading : Activity
    {
        public ReadingActivitiy ReadingActivityType { get; set; }


        public Reading(ReadingActivitiy ReadingActivityType, string Title, string Description, double Time) : base(Title, Description, Time)
        {
            this.ReadingActivityType = ReadingActivityType;
        }

        public Reading():base("","",0)
        {
        }

        public  void displayActivities()
        {
            int i = 1;
            foreach (string name in Enum.GetNames(typeof(ReadingActivitiy)))
            {
                Console.WriteLine(i + "). " + name);
                i++;
            }
        }
    }
}