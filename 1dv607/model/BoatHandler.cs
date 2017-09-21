using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class BoatHandler
    {
        public BoatHandler() 
        {
        }

        public List<Boat> getBoats()
        {
            List<Boat> boats = new List<Boat>();

            string path = "C:\\Users\\Jonne\\Documents\\workshop-2-1dv607\\1dv607\\Boats.txt";

            string[] readText = File.ReadAllLines(path);
            for (int i = 0; i < readText.Length; i += 3)
            {
                int memberId = Convert.ToInt32(readText[i]);
                string boatType = readText[i+1];
                int boatLength = Convert.ToInt32(readText[i+2]);

                Boat boat = new Boat(memberId, boatType, boatLength);

                boats.Add(boat);
            }

            return boats;
        }

        public List<Boat> getBoats(int memberId)
        {
            List<Boat> boats = getBoats();

            List<Boat> memberBoats = new List<Boat>();

            for (int i = 0; i < boats.Count; i++)
            {
                if (boats[i].getMemberId() == memberId)
                {
                    memberBoats.Add(boats[i]);
                }
            }

            return memberBoats;
        }

        public void addBoat(Boat boat)
        {
            string path = "C:\\Users\\Jonne\\Documents\\workshop-2-1dv607\\1dv607\\Boats.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(boat.getMemberId());
                sw.WriteLine(boat.getType());
                sw.WriteLine(boat.getLength());
            }	
        }
    }
}
