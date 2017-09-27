using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _1dv607
{
    class BoatHandler
    {
        public BoatHandler() 
        {
        }

        public void deleteBoats(int memberId)
        {
            // List<Boat> boats = getBoats().Except(getBoats(memberId)).ToList();

            List<Boat> boats = getBoats();
            List<Boat> removeBoats = getBoats(memberId);

            for (int i = 0; i < boats.Count; i++)
            {
                for (int j = 0; j < removeBoats.Count; j++)
                {
                    if (boats[i].getMemberId() == removeBoats[j].getMemberId())
                    {
                        boats.RemoveAt(i);
                        i--;
                    }
                }
            }

            // Console.WriteLine(boats.Count);

            File.Delete("C:\\Users\\Jonne\\Documents\\workshop-2-1dv607\\1dv607\\Boats.txt");

            for (int i = 0; i < boats.Count; i++)
            {
                addBoat(boats[i]);
            }
            // List<Boat> removeBoats = getBoats(memberId);

            // ta bort alla removeBoats i boats

            // delete boats.txt
            // skriv boats till boats.txt
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
