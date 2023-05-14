using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApp.Domain.Enums;

namespace TimeTrackingApp.Domain.Models.Activities
{
    public class OtherHobbies : Activity
    {
        public OtherHobbiesActivitiy OtherHobbiesActivitiyType { get; set; }

        public OtherHobbies(OtherHobbiesActivitiy OtherHobbiesActivitiyType, string Title, string Description, double Time) : base(Title, Description, Time)
        {
            this.OtherHobbiesActivitiyType = OtherHobbiesActivitiyType;
        }

        public OtherHobbies():base("","",0)
        {
        }

        public  void displayActivities()
        {
            int i = 1;
            foreach (string name in Enum.GetNames(typeof(OtherHobbiesActivitiy)))
            {
                Console.WriteLine(i + "). " + name);
                i++;
            }
        }
    }
}