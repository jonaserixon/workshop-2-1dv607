using System;

namespace _1dv607
{
    class Member
    {
        // private string _name;
        // private int _personalNumber;
        // private int _member_id;

        public Member(string name, int personalNumber)
        {
            Name = name;
            PersonalNumber = personalNumber;
            MemberId =  new Random().Next(1, 250000000 + 1);
        }

        public Member(string name, int personalNumber, int member_id)
        {
            Name = name;
            PersonalNumber = personalNumber;
            MemberId = member_id;
        }

        public string Name{get; set;}
        public int PersonalNumber{get; set;}
        public int MemberId {get; set;}

        // public string getName() 
        // {
        //     return _name;
        // }

        // public void setName(string name)
        // {
        //     _name = name;
        // }

        // public int getPersonalNumber() 
        // {
        //     return _personalNumber;
        // }

        // public void setPersonalNumber(int personalNumber)
        // {
        //     _personalNumber = personalNumber;
        // }

        // public int getMemberId() 
        // {
        //     return _member_id;
        // }
    }
}