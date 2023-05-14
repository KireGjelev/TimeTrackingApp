using TimeTrackingApp.Domain.Enums;
using TimeTrackingApp.Domain.Models;
using TimeTrackingApp.Domain.Models.Activities;
using TimeTrackingApp.Service.Helpers;
using TimeTrackingApp.Service.Implementation;
using TimeTrackingApp.Service.Interfaces;

User currentUser = null;

UserValidationHelper<User> userValidationHelper = new UserValidationHelper<User>();
IUserService<User> userService = new UserService<User>();
IActivityService<Activity> activityService = new ActivityService<Activity>();
List<Activity> activities = new List<Activity>();


Init();

Main();

void Init()
{
    activityService.addActivity(new Exercising(ExercisingActivitiy.General, "General Activity", "General Activity Descirption", 0));
    activityService.addActivity(new Exercising(ExercisingActivitiy.Running, "Running Activity", "Running Activity Descirption", 0));
    activityService.addActivity(new Exercising(ExercisingActivitiy.Sport, "Sport Activity", "Sport Activity Descirption", 0));
    activityService.addActivity(new Exercising(ExercisingActivitiy.Gym, "Gym Activity", "Gym Activity Descirption", 0));

    activityService.addActivity(new Reading(ReadingActivitiy.BellesLettres, "BellesLettres ReadingActivitiy", "BellesLettres ReadingActivitiy Descirption", 0));
    activityService.addActivity(new Reading(ReadingActivitiy.Fiction, "Fiction ReadingActivitiy", "Fiction ReadingActivitiy Descirption", 0));
    activityService.addActivity(new Reading(ReadingActivitiy.ProfessionalLiterature, "ProfessionalLiterature ReadingActivitiy", "ProfessionalLiterature ReadingActivitiy Descirption", 0));
}

void Main()
{
    bool appRunning = true;

    while (appRunning)
    {
        // Display main menu options
        displayMainManuOptions();
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Login();
                break;
            case "2":
                Register();
                break;
            case "3":
                appRunning = false;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}

 void displayMainManuOptions()
 {
    Console.WriteLine("Main Menu");
    Console.WriteLine("1. Login");
    Console.WriteLine("2. Register");
    Console.WriteLine("3. Exit");
    Console.Write("Enter your choice: ");
 }

 void Login()
 {
    Console.WriteLine("Login");
    Console.Write("Username: ");
    string username = Console.ReadLine();
    Console.Write("Password: ");
    string password = Console.ReadLine();

    Console.WriteLine(userValidationHelper.tryLogin(username, password));
    Console.ResetColor();
    currentUser = userService.GetUserByUserName(username);

    MainMenu();

 }

 bool Register()
 {
    Console.WriteLine("Register");
    Console.Write("First Name: ");
    string firstName = Console.ReadLine();
    Console.Write("Last Name: ");
    string lastName = Console.ReadLine();
    Console.Write("Age: ");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.Write("Username: ");
    string username = Console.ReadLine();
    Console.Write("Password: ");
    string password = Console.ReadLine();


    // Validate the registration information
    if (userValidationHelper.isValidRegistration(firstName, lastName, age, username, password))
    {
        userService.RegisterUser(new User(firstName, lastName, age, username, password));
        Console.WriteLine("Registration successful!");
    }

    return true;
 }


 void MainMenu()
 {
    bool logoutRequested = false;

    while (!logoutRequested)
    {
        // Display main menu options for logged-in user
        if (currentUser == null)
        {
            return;
        }
        Console.WriteLine($"Welcome, {currentUser.Username}!");
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Track Activities");
        Console.WriteLine("2. User Statistics");
        Console.WriteLine("3. Account Management");
        Console.WriteLine("4. Logout");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();


        string activityChoice = "";
        switch (choice)
        {
            case "1":
                Console.WriteLine("1. Reading Activities");
                Console.WriteLine("2. Exercising Activities");
                Console.WriteLine("3. Working Activities");
                Console.WriteLine("4. Other Hobbies Activities");
                activityChoice = Console.ReadLine();

                break;
            case "2":
                //TODO: Display User statistics
                break;
            case "3":
                //TODO: Display Account management
                break;
            case "4":
                logoutRequested = true;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }


        switch(activityChoice)
        {
            case "1":
                 new Reading().displayActivities();
                break;
                case "2":
                  new Exercising().DisplayActivities();
                break;
                case "3":
                    new OtherHobbies().displayActivities();
                break;
                case  "4":
                    new Working().displayActivities();
                break;

            default:
                break;
        }
        return;

        Console.WriteLine();
    }
 }