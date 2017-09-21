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

                MemberHandler memberHandler = new MemberHandler();
                BoatHandler boatHandler = new BoatHandler();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter name: ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter personal number: ");
                        int personalNumber = Convert.ToInt32(Console.ReadLine());

                        Member member = new Member(name, personalNumber);

                        memberHandler.addMember(member);

                        Console.WriteLine("Member registrered!");
                        break;
                    case "2":
                        Console.WriteLine("Compact list of members");
                        Console.WriteLine("-----------------------");

                        memberHandler.getMembers();
                        
                        break;
                    case "3":
                        Console.WriteLine("Verbose list of members");

                        
                        break;
                    case "4":
                        Console.WriteLine("4");
                        break;
                    case "5":
                        Console.WriteLine("5");
                        break;
                    case "6":
                        Console.WriteLine("Enter member name: ");
                        string memberName = Console.ReadLine();

                        Console.WriteLine("Enter boat type: ");
                        string boatType = Console.ReadLine();

                        Console.WriteLine("Enter boat length: ");
                        int boatLength = Convert.ToInt32(Console.ReadLine());

                        // leta upp member med memberName
                        // få fram memberId
                        // skapa båt
                        Boat boat = new Boat(memberId, boatType, boatLength);
                        BoatRegister.addBoat(boat);

                        break;
                    case "7":
                        Console.WriteLine("7");
                        break;
                    case "8":
                        Console.WriteLine("8");
                        break;
                    case "9":
                        Console.WriteLine("9");
                        break;
                    case "0":
                        programIsRunning = false;
                        Console.WriteLine("Good bye!");
                    break;
                }
            }
        }
    }
}
