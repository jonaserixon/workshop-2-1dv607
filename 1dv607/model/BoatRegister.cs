using System;

namespace _1dv607
{
    class BoatRegister
    {
        private List<Boat> _boats;

        public BoatRegister() 
        {
           _boats = new List<Boat>();
        }

        public List<Boat> getBoats()
        {
            return _boats;
        }
    }
}