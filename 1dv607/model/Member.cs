using System;
using System.Collections.Generic;

namespace _1dv607
{
    class Member
    {
        public Member(string name, int personalNumber)
        {
            Name = name;
            PersonalNumber = personalNumber;
            MemberId =  new Random().Next(1, 250000000 + 1);
            Boats = new List<Boat>();
        }

        public Member(string name, int personalNumber, int member_id)
        {
            Name = name;
            PersonalNumber = personalNumber;
            MemberId = member_id;
            Boats = new List<Boat>();
        }

        public void AddBoat(Boat boat)
        {
            Boats.Add(boat);
        }

        public void RemoveBoat(Boat boat)
        {
            List<Boat> boatsTemp = new List<Boat>();

            for (int i = 0; i < Boats.Count; i++)
            {
                if (Boats[i].BoatId != boat.BoatId)
                {
                    boatsTemp.Add(boat);
                }
            }

            Boats = boatsTemp;
        }

        public string Name{get; set;}
        public int PersonalNumber{get; set;}
        public int MemberId {get; set;}
        public List<Boat> Boats {get; set;}
    }
}
