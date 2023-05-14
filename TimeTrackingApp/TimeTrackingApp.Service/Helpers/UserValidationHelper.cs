using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingApp.Domain.DataBase;
using TimeTrackingApp.Domain.DBInterface;
using TimeTrackingApp.Domain.Models;

namespace TimeTrackingApp.Service.Helpers
{
    public class UserValidationHelper<T> where T : User
    {
        private IDatabase<T> _database;

        public UserValidationHelper()
        {
            this._database = new FileDataBase<T>();
        }
        
        public static bool AreFirstAndLastNameValid(string firstName, string lastName)
        {
            bool namesContainNumbers = firstName.Any(char.IsDigit) || lastName.Any(char.IsDigit);
            if (namesContainNumbers)
            {
                return false;
            }
            return firstName.Length > 2 && lastName.Length > 2;
        }

        public static bool IsUsernameValid(string userName)
        {
            return userName.Length > 5;
        }
        public static bool IsAgeValid(int age)
        {
            return age > 18 && age < 100;
        }

        public static bool IsPasswordValid(string password)
        {
            return password.Any(char.IsUpper) && password.Any(char.IsDigit);
        }

        public string tryLogin(string? username, string? password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return String.Format("Username and password are required.");
            }
            if (username.Length < 5 || password.Length < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return String.Format("Username should not be shorter than 5 characters. Password should not be shorter than 6 characters.");
            }
            User user = _database.GetByUsername(username);
            if (user == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return String.Format("User is still not registered! Please register");
            }
            if (user.Password != password)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return String.Format("Wrong password, please try again!");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            return String.Format("Login successfull!");

        }

        public bool isValidRegistration(string? firstName, string? lastName, int age, string? username, string? password)
        {
            return IsUsernameValid(username) && IsPasswordValid(password) && AreFirstAndLastNameValid(firstName, lastName) && IsAgeValid(age);
        }
    }
}