using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApp.Domain.Enums;

namespace TimeTrackingApp.Domain.Models.Activities
{
    public class Activity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Time { get; set; }

        public Activity()
        {

        }

        protected Activity(string title, string description, double time)
        {
            Title = title;
            Description = description;
            Time = time;
        }
    }
}