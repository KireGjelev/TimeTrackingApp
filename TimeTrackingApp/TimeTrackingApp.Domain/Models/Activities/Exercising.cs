using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApp.Domain.Enums;

namespace TimeTrackingApp.Domain.Models.Activities
{
    public class Exercising : Activity
    {
        public ExercisingActivitiy ExercisingActivitiyType { get; set; }

        public Exercising(ExercisingActivitiy ExercisingActivitiyType, string Title, string Description, double Time) : base(Title, Description, Time)
        {
            this.ExercisingActivitiyType = ExercisingActivitiyType;
        }

        public Exercising():base("","",0)
        {
        }

        public  void DisplayActivities()
        {
            int i = 1;
            foreach (string name in Enum.GetNames(typeof(ExercisingActivitiy)))
            {
                Console.WriteLine(i + "). " + name);
                i++;
            }
        }
    }
}
