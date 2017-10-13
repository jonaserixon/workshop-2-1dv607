using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class MemberHandler
    {
        private DatabaseModel databaseModel;

        public MemberHandler(DatabaseModel databaseModel) 
        {
            this.databaseModel = databaseModel;
        }

        public void deleteMember(string memberName)
        {
            databaseModel.deleteMember(memberName);
        }

        public void addMember(Member member)
        {
            databaseModel.addMember(member);
        }

        public Member getMember(string memberName) 
        {
            return databaseModel.findMember(memberName);
        }

        public List<Member> getMembers()
        {
            return databaseModel.findMembers();
        }
    }
}
