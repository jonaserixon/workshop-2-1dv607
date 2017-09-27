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
                        // enter member name
                        Console.WriteLine("Enter member name: ");
                        string memberName3 = Console.ReadLine();

                        // show member information
                        Member member123 = memberHandler.getMember(memberName3);
                        Console.WriteLine("Name: " + member123.getName() + ", personal number: " + member123.getPersonalNumber());

                        // enter new member name
                        Console.WriteLine("Enter new name (" + member123.getName() + "): ");
                        string newName = Console.ReadLine();

                        // Enter new personal number
                        Console.WriteLine("Enter new personal number (" + member123.getPersonalNumber() + "): ");
                        int newPersonalNumber = Convert.ToInt32(Console.ReadLine());

                        memberHandler.deleteMember(member123.getName());

                        member123.setName(newName);
                        member123.setPersonalNumber(newPersonalNumber);
                        memberHandler.addMember(member123);
                        break;
                    case "6":
                        // VIEW MEMBER
                        Console.WriteLine("Enter member name: ");
                        string memberName2 = Console.ReadLine();

                        Member memberView = memberHandler.getMember(memberName2);
                        Console.WriteLine("Name: " + memberView.getName());
                        Console.WriteLine("Personal number: " + memberView.getPersonalNumber());
                        Console.WriteLine("Member id: " + memberView.getMemberId());
                        Console.WriteLine();
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
                        // enter username
                        Console.WriteLine("Enter member name: ");
                        string memberNameDeleteBoat = Console.ReadLine();

                        // numbered list of boats belonging to that user
                        Member memberDeleteBoat = memberHandler.getMember(memberNameDeleteBoat);
                        List<Boat> boatsDelete = boatHandler.getBoats(memberDeleteBoat.getMemberId());
                        Console.WriteLine("Boats belonging to " + memberNameDeleteBoat + ":");
                        for (int i = 0; i < boatsDelete.Count; i++)
                        {
                            Console.WriteLine((i+1) + " Type: " + boatsDelete[i].getType() + ", Length: " + boatsDelete[i].getLength());
                        }

                        // enter number of boat the should be deleted
                        Console.WriteLine("Which boat do you want to delete?");
                        int boatNumber = Convert.ToInt32(Console.ReadLine());

                        // delete boat
                        boatHandler.deleteBoat(boatsDelete[boatNumber-1]);
                        Console.WriteLine();
                        break;
                    case "9":
                        // EDIT BOAT
                        
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
