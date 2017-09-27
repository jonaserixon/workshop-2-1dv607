using System;

namespace _1dv607
{

    public enum BoatType 
    {
        Sailboat, Motorsailer, Kayak, Other
    }

    class Boat
    {
        private int _memberId;
        private string _boatType;
        private int _length;

        public Boat(int memberId, string boatType, int length) 
        {
            _memberId = memberId;
            _boatType = boatType;
            _length = length;

            if (_boatType != "Sailboat" || _boatType != "Motorsailer" || _boatType != "Kayak" || _boatType != "Canoe")
            {
                _boatType = "Other";
            }
        }

        public int getMemberId()
        {
            return _memberId;
        }

        public string getType() 
        {
            return _boatType;
        }

        public void setType(string type)
        {
            _boatType = type;

            if (_boatType != "Sailboat" || _boatType != "Motorsailer" || _boatType != "Kayak" || _boatType != "Canoe")
            {
                _boatType = "Other";
            }
        }

        public int getLength() 
        {
            return _length;
        }

        public void setLength(int length)
        {
            _length = length;
        }
    }
}
