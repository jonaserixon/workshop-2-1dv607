using System;
using System.Collections.Generic;
using System.IO;

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
                List<Member> members;

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

                        members = memberHandler.getMembers();

                        foreach(Member profile in members)
                        {
                            Console.WriteLine("Name: " + profile.getName());
                            Console.WriteLine("Member id: " + profile.getMemberId());
                            Console.WriteLine("Number of boats: " + boatHandler.getBoats(profile.getMemberId()).Count);
                            Console.WriteLine();
                        }
                        Console.WriteLine("-----------------------");

                        break;
                    case "3":
                        Console.WriteLine("Verbose list of members");
                        Console.WriteLine("-----------------------");

                        members = memberHandler.getMembers();

                        foreach(Member profile in members)
                        {
                            Console.WriteLine("Name: " + profile.getName());
                            Console.WriteLine("Member id: " + profile.getMemberId());
                            Console.WriteLine("Personal number: " + profile.getPersonalNumber());

                            List<Boat> boats = boatHandler.getBoats(profile.getMemberId());
                            foreach(Boat profileBoat in boats)
                            {
                                Console.WriteLine("Boat type: " + profileBoat.getType());
                                Console.WriteLine("Boat length: " + profileBoat.getLength());
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("-----------------------");
                        
                        break;
                    case "4":
                        // DELETE MEMBER
                        Console.WriteLine("Enter name of member: ");
                        string memberNameDelete = Console.ReadLine();

                        // Remove boats for the removed member
                        Member memberDelete = memberHandler.getMember(memberNameDelete);
                        boatHandler.deleteBoats(memberDelete.getMemberId());

                        // Remove member
                        memberHandler.deleteMember(memberNameDelete);
                        break;
                    case "5":
                        // EDIT MEMBER
                        Console.WriteLine("5");
                        break;
                    case "6":
                        // VIEW MEMBER
                        Console.WriteLine("7");
                        break;
                    case "7":
                        Console.WriteLine("Enter member name: ");
                        string memberName = Console.ReadLine();

                        Console.WriteLine("Enter boat type: ");
                        string boatType = Console.ReadLine();

                        Console.WriteLine("Enter boat length: ");
                        int boatLength = Convert.ToInt32(Console.ReadLine());

                        member = memberHandler.getMember(memberName);

                        Boat boat = new Boat(member.getMemberId(), boatType, boatLength);
                        boatHandler.addBoat(boat);

                        break;
                    case "8":
                        // DELETE BOAT
                        Console.WriteLine("8");
                        break;
                    case "9":
                        // EDIT BOAT
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
