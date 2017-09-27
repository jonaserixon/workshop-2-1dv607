using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class MemberHandler
    {

        public MemberHandler() 
        {
           // _members = new List<Member>();
        }

        public void deleteMember(string memberName)
        {
            List<Member> members = getMembers();
            Member removeMember = getMember(memberName);

            // hitta index på remove member i members
            int index = -1;
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].getName() == memberName)
                {
                    index = i;
                }
            }

            members.RemoveAt(index);

            File.Delete("C:\\Users\\Jonne\\Documents\\workshop-2-1dv607\\1dv607\\Members.txt");

            for (int i = 0; i < members.Count; i++)
            {
                addMember(members[i]);
            }
        }

        public void addMember(Member member)
        {
            string path = "C:\\Users\\Jonne\\Documents\\workshop-2-1dv607\\1dv607\\Members.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(member.getName());
                sw.WriteLine(member.getPersonalNumber());
                sw.WriteLine(member.getMemberId());
            }	
        }

        public Member getMember(string memberName) 
        {
            List<Member> members = getMembers();

            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].getName() == memberName)
                {
                    return members[i];
                }
            }

            return null;
        }

        public List<Member> getMembers()
        {
            List<Member> members = new List<Member>();

            string path = "C:\\Users\\Jonne\\Documents\\workshop-2-1dv607\\1dv607\\Members.txt";

            string[] readText = File.ReadAllLines(path);
            for (int i = 0; i < readText.Length; i += 3)
            {
                string memberName = readText[i];
                int personalNumber = Convert.ToInt32(readText[i+1]);
                int memberId = Convert.ToInt32(readText[i+2]);

                Member member = new Member(memberName, personalNumber, memberId);

                members.Add(member);
            }

            return members;
        }
    }
}
