using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class MemberHandler
    {
        private List<Member> _members;

        public MemberHandler() 
        {
           _members = new List<Member>();
        }

        

        public void addMember(Member member) 
        {
            // string[] memberInfo = {member.getName(), "" + member.getPersonalNumber(), "" + member.getMemberId()};
            // File.WriteAllLines(@"C:\Users\Jonne\Documents\workshop-2-1dv607\1dv607\Members.txt", memberInfo);

            string path = "C:\\Users\\Jonne\\Documents\\workshop-2-1dv607\\1dv607\\Members.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(member.getName());
                sw.WriteLine(member.getPersonalNumber());
                sw.WriteLine(member.getMemberId());
            }	
        }

        public void getMember() 
        {
            //läsfrån txt fil
        }

        public List<Member> getMembers()
        {
            return _members;
        }
    }
}