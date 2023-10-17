using System;
public class Program {
    public bool LoggedIn { get; private set; } = false;
    //Never do this!
    private string Username = "admin";
    private string Password = "admin";

    public static void Main(string[] args) {
        Program program = new Program();
        program.MainMenu();
    }

    public void MainMenu() {
        if (!LoggedIn) {
            Console.WriteLine("You are not logged in!");
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            Login(username, password);
            MainMenu();
        } else {
            Console.WriteLine("Main menu:");
            Console.WriteLine("1. Do stuff");
            Console.WriteLine("2. Logout");
            string input = Console.ReadLine();
            switch (input) {
                case "1":
                    DoStuff();
                    break;
                case "2":
                    Logout();
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
            MainMenu();
        }
    }

    public bool Login(string _username, string _password) {
        if (_username == Username && _password == Password) {
            LoggedIn = true;
            return true;
        }
        else {
            Console.WriteLine("Wrong username or password!");
            return false;
        }
    }

    public void Logout() {
        LoggedIn = false;
    }

    public bool DoStuff() {
        if (!LoggedIn) {
            Console.WriteLine("You are not logged in!");
            return false;
        }
        else {
            Console.WriteLine("Doing very dangerous stuff!");
            return true;
        }
    }

}