using System;

namespace _1dv607
{
    class Member
    {
        private string _name;
        private int _personalNumber;
        private int _member_id;

        public Member(string name, int personalNumber)
        {
            _name = name;
            _personalNumber = personalNumber;
            _member_id =  new Random().Next(1, 250000000 + 1);
        }

        public Member(string name, int personalNumber, int member_id)
        {
            _name = name;
            _personalNumber = personalNumber;
            _member_id = member_id;
        }

        public string getName() 
        {
            return _name;
        }

        public int getPersonalNumber() 
        {
            return _personalNumber;
        }

        public int getMemberId() 
        {
            return _member_id;
        }
    }
}