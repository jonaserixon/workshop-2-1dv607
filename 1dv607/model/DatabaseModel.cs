using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class DatabaseModel
    {
        private static string MEMBER_FILE_PATH = "./Members.txt";
        private static string BOAT_FILE_PATH = "./Boats.txt";

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
            }
        }

        public List<Member> findMembers() 
        {
            doesFileExist(MEMBER_FILE_PATH);

            List<Member> members = new List<Member>();

            string[] readText = File.ReadAllLines(MEMBER_FILE_PATH);
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

        public void deleteBoat(Boat boat)
        {
            doesFileExist(BOAT_FILE_PATH);
            
            List<Boat> boats = findBoats(boat.getMemberId());

            int index = -1;
            for (int i = 0; i < boats.Count; i++)
            {
                if (boats[i].getType() == boat.getType() && boats[i].getLength() == boat.getLength())
                {
                    index = i;
                }
            }

            boats.RemoveAt(index);

            if (File.Exists(BOAT_FILE_PATH))
            {
                File.Delete(BOAT_FILE_PATH);
            }

            for (int i = 0; i < boats.Count; i++)
            {
                addBoat(boats[i]);
            }
        }

        public void deleteBoats(int memberId)
        {
            doesFileExist(BOAT_FILE_PATH);

            List<Boat> boats = findBoats();
            List<Boat> removeBoats = findBoats(memberId);

            for (int i = 0; i < boats.Count; i++)
            {
                for (int j = 0; j < removeBoats.Count; j++)
                {
                    if (boats[i].getMemberId() == removeBoats[j].getMemberId())
                    {
                        boats.RemoveAt(i);
                        i--;
                    }
                }
            }

            if (File.Exists(BOAT_FILE_PATH))
            {
                File.Delete(BOAT_FILE_PATH);
            }

            for (int i = 0; i < boats.Count; i++)
            {
                addBoat(boats[i]);
            }
        }

        public List<Boat> findBoats() 
        {
            doesFileExist(BOAT_FILE_PATH);

            List<Boat> boats = new List<Boat>();

            string[] readText = File.ReadAllLines(BOAT_FILE_PATH);
            for (int i = 0; i < readText.Length; i += 3)
            {
                int memberId = Convert.ToInt32(readText[i]);
                string boatType = readText[i+1];
                int boatLength = Convert.ToInt32(readText[i+2]);

                Boat boat = new Boat(memberId, boatType, boatLength);

                boats.Add(boat);
            }

            return boats;
        }

        public List<Boat> findBoats(int memberId)
        {
            List<Boat> boats = findBoats();

            List<Boat> memberBoats = new List<Boat>();

            for (int i = 0; i < boats.Count; i++)
            {
                if (boats[i].getMemberId() == memberId)
                {
                    memberBoats.Add(boats[i]);
                }
            }

            return memberBoats;
        }

        public void addBoat(Boat boat)
        {
            using (StreamWriter sw = File.AppendText(BOAT_FILE_PATH))
            {
                sw.WriteLine(boat.getMemberId());
                sw.WriteLine(boat.getType());
                sw.WriteLine(boat.getLength());
            }	
        }
    }
}