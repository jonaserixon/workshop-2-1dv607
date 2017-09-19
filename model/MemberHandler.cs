using System;

namespace _1dv607
{
    class MemberHandler
    {
        private List<Member> _members;

        public MemberHandler() 
        {
           _members = new List<Member>();
        }

        public List<Member> getMembers()
        {
            return _members;
        }
    }
}