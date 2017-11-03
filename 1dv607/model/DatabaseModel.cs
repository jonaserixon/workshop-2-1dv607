using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class DatabaseModel
    {
        private static string MEMBER_FILE_PATH = "./Members.txt";

        private void doesFileExist(string filepath)
        {
            if (File.Exists(filepath) == false)
            {
                throw new Exception("Could not read the " + filepath + " file.");
            }
        }

        public void addMember(Member member) 
        {
            using (StreamWriter sw = File.AppendText(MEMBER_FILE_PATH))
            {
                sw.WriteLine(member.Name);
                sw.WriteLine(member.PersonalNumber);
                sw.WriteLine(member.MemberId);

                foreach(Boat boat in member.Boats)
                {
                    sw.WriteLine("-" + boat.getType());
                    sw.WriteLine(boat.getLength());
                    sw.WriteLine(boat.BoatId);                         
                }
            }
        }

        public List<Member> findMembers() 
        {
            doesFileExist(MEMBER_FILE_PATH);

            List<Member> members = new List<Member>();

            string[] readText = File.ReadAllLines(MEMBER_FILE_PATH);
            for (int i = 0; i < readText.Length; i += 3)
            {
                if (readText[i][0] == '-')
                {
                    continue;
                }

                string memberName = readText[i];
                int personalNumber = Convert.ToInt32(readText[i+1]);
                int memberId = Convert.ToInt32(readText[i+2]);

                Member member = new Member(memberName, personalNumber, memberId);

                int counter = 3;

                while (readText.Length >= i+counter+2 && readText[i+counter][0] == '-')
                {
                    string boatType = readText[i+counter].Substring(1);
                    int boatLength = Convert.ToInt32(readText[i+counter+1]);
                    int boatId = Convert.ToInt32(readText[i+counter+2]);

                    Boat boat = new Boat(boatType, boatLength, boatId);
                    member.AddBoat(boat);

                    counter = counter + 3;
                }

                members.Add(member);
            }

            return members;
        }

        public Member findMember(string memberName)
        {
            List<Member> members = findMembers();

            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Name == memberName)
                {
                    return members[i];
                }
            }

            return null;
        }

        public Member findMember(int memberId)
        {
            List<Member> members = findMembers();

            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].MemberId == memberId)
                {
                    return members[i];
                }
            }

            return null;
        }

        public void deleteMember(string memberName) 
        {
            doesFileExist(MEMBER_FILE_PATH);

            List<Member> members = findMembers();
            Member removeMember = findMember(memberName);

            //Find index of the member to remove
            int index = -1;
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Name == memberName)
                {
                    index = i;
                }
            }

            members.RemoveAt(index);

            File.Delete(MEMBER_FILE_PATH);

            for (int i = 0; i < members.Count; i++)
            {
                addMember(members[i]);
            }
        }

        public void deleteBoat(Member member, Boat boat)
        {
            doesFileExist(MEMBER_FILE_PATH);

            List<Member> members = findMembers();

            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].MemberId == member.MemberId)
                {
                    members[i].RemoveBoat(boat);
                    break;
                }
            }

            if (File.Exists(MEMBER_FILE_PATH))
            {
                File.Delete(MEMBER_FILE_PATH);
            }

            for (int i = 0; i < members.Count; i++)
            {
                addMember(members[i]);
            }
        }

        public void deleteBoats(Member member)
        {
            doesFileExist(MEMBER_FILE_PATH);

            List<Member> members = findMembers();

            foreach(Member member2 in members)
            {
                if (member.MemberId == member2.MemberId)
                {
                    member2.Boats = new List<Boat>();
                }
            }

            if (File.Exists(MEMBER_FILE_PATH))
            {
                File.Delete(MEMBER_FILE_PATH);
            }

            for (int i = 0; i < members.Count; i++)
            {
                addMember(members[i]);
            }
        }

        public List<Boat> findBoats(int memberId)
        {
            Member member = findMember(memberId);

            return member.Boats;
        }

        public void addBoat(Member member, Boat boat)
        {
            List<Member> members = findMembers();
            
            foreach(Member member2 in members)
            {
                if (member.MemberId == member2.MemberId)
                {
                    member2.AddBoat(boat);
                }
            }
            
            if (File.Exists(MEMBER_FILE_PATH))
            {
                File.Delete(MEMBER_FILE_PATH);
            }
            
            for (int i = 0; i < members.Count; i++)
            {
                addMember(members[i]);
            }
        }
    }
}
