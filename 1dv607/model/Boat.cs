using System;

namespace _1dv607
{

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

            switch (_boatType)
            {
                case "Sailboat":
                    break;
                case "Motorsailer":
                    break;
                case "Kayak":
                    break;
                case "Canoe":
                    break;
                default:
                    _boatType = "Other";
                    break;
            }

            // if (_boatType != "Sailboat" || _boatType != "Motorsailer" || _boatType != "Kayak" || _boatType != "Canoe")
            // {
            //     _boatType = "Other";
            // }
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
