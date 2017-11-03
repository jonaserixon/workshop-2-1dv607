using System;

namespace _1dv607
{

    class Boat
    {
        private string _boatType;
        private int _length;

        public Boat(string boatType, int length) 
        {
            setType(boatType);
            _length = length;
            BoatId =  new Random().Next(1, 250000000 + 1);
        }

        public Boat(string boatType, int length, int boatId)
        {
            setType(boatType);
            _length = length;
            BoatId =  boatId;
        }
        
        public int BoatId {get; set;}

        public string getType() 
        {
            return _boatType;
        }

        public void setType(string type)
        {
            _boatType = type;

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
