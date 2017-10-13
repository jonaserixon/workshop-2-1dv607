using System;

namespace _1dv607
{
    class Member
    {
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
    }
}