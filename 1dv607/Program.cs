using System;

namespace _1dv607
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuView view = new MenuView();

            Boolean programIsRunning = true;

            while(programIsRunning)
            {    
                view.renderMenu();
           
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter name: ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter personal number: ");
                        int personalNumber = Convert.ToInt32(Console.ReadLine());

                        Member member = new Member(name, personalNumber);

                        MemberHandler memberHandler = new MemberHandler();
                        memberHandler.addMember(member);

                        Console.WriteLine("Member registrered!");
                        break;
                    case "2":
                        Console.WriteLine("2");
                        break;
                    case "3":
                        Console.WriteLine("3");
                        break;
                    case "4":
                        Console.WriteLine("4");
                        break;
                    case "5":
                        Console.WriteLine("5");
                        break;
                    case "6":
                        Console.WriteLine("6");
                        break;
                    case "7":
                        Console.WriteLine("7");
                        break;
                    case "8":
                        Console.WriteLine("8");
                        break;
                    case "9":
                        programIsRunning = false;
                        Console.WriteLine("Good bye!");
                    break;
                }
            }
        }
    }
}
