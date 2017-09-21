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
            string path = "C:\\Users\\Jonne\\Documents\\workshop-2-1dv607\\1dv607\\Members.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Name: " + member.getName());
                sw.WriteLine("PersonalNumber: " + member.getPersonalNumber());
                sw.WriteLine("Member_id: " + member.getMemberId());
            }	
        }

        public void getMember() 
        {
            //läsfrån txt fil
        }

        public List<Member> getMembers()
        {
            string path = "C:\\Users\\Jonne\\Documents\\workshop-2-1dv607\\1dv607\\Members.txt";

            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                Console.WriteLine(s);
            }
            return _members;
        }
    }
}
