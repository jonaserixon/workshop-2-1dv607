using System;

namespace _1dv607
{

    public enum BoatType 
    {
        Sailboat, Motorsailer, Kayak, Other
    }

    class Boat
    {
        private BoatType _boatType;
        private int _length;
        

        public Boat(BoatType boatType, int length) 
        {
            _boatType = boatType;
            _length = length;
        }

        public BoatType getType() 
        {
            return _boatType;
        }

        public int getLength() 
        {
            return _length;
        }
    }
}