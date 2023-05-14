using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackingApp.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string FirstName, string LastName, int age, string Username, string Password)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = age;
            this.Username = Username;
            this.Password = Password;
        }
    }
}
