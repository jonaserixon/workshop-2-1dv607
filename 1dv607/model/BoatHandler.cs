using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class BoatHandler
    {
        private List<Boat> _boats;

        public BoatHandler() 
        {
           _boats = new List<Boat>();
        }

        public List<Boat> getBoats()
        {
            return _boats;
        }

        public void addBoat(Boat boat)
        {
            string path = "C:\\Users\\Jonne\\Documents\\workshop-2-1dv607\\1dv607\\Boats.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Type: " + boat.getType());
                sw.WriteLine("Length: " + boat.getLength());
            }	
        }
    }
}