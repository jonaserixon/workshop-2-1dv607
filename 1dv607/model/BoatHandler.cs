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

        public void deleteBoat(Boat boat)
        {
            List<Boat> boats = getBoats(boat.getMemberId());

            int index = -1;
            for (int i = 0; i < boats.Count; i++)
            {
                if (boats[i].getType() == boat.getType() && boats[i].getLength() == boat.getLength())
                {
                    index = i;
                }
            }

            boats.RemoveAt(index);

            if (File.Exists("./Boats.txt"))
            {
                File.Delete("./Boats.txt");
            }
            else
            {
                throw new Exception("Could not read the Boats file.");
            }

            for (int i = 0; i < boats.Count; i++)
            {
                addBoat(boats[i]);
            }
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

            if (File.Exists("./Boats.txt"))
            {
                File.Delete("./Boats.txt");
            }
            else
            {
                throw new Exception("Could not read the Boats file.");
            }

            for (int i = 0; i < boats.Count; i++)
            {
                addBoat(boats[i]);
            }
        }

        public List<Boat> getBoats()
        {
            List<Boat> boats = new List<Boat>();
            
            if (File.Exists("./Boats.txt") == false)
            {
                throw new Exception("Could not read the Boats file.");
            }

            string path = "./Boats.txt";

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
            string path = "./Boats.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(boat.getMemberId());
                sw.WriteLine(boat.getType());
                sw.WriteLine(boat.getLength());
            }	
        }
    }
}
