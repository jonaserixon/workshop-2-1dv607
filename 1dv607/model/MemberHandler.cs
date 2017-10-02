using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class MemberHandler
    {

        public MemberHandler() 
        {
        }

        public void deleteMember(string memberName)
        {
            if (File.Exists("./Members.txt") == false)
            {
                throw new Exception("Could not read the Boats file.");
            }

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

            File.Delete("./Members.txt");

            for (int i = 0; i < members.Count; i++)
            {
                addMember(members[i]);
            }
        }

        public void addMember(Member member)
        {
            if (File.Exists("./Members.txt") == false)
            {
                throw new Exception("Could not read the Boats file.");
            }

            string path = "./Members.txt";
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

            string path = "./Members.txt";
            
            if (File.Exists("./Members.txt") == false)
            {
                throw new Exception("Could not read the Boats file.");
            }

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
