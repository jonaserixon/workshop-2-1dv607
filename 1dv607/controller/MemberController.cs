using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class MemberController
    {
        private MenuView _view;
        private MemberHandler _memberHandler;
        private BoatHandler _boatHandler;

        public MemberController(MenuView view, MemberHandler memberHandler, BoatHandler boatHandler)
        {
            _view = view;
            _memberHandler = memberHandler;
            _boatHandler = boatHandler;
        }

        public void RegisterMember()
        {
            _view.Output("Register member");
            _view.Output("-----------------------");

            _view.Output("Enter name: ");
            string name = _view.Input();

            _view.Output("Enter personal number: ");
            int personalNumber = Convert.ToInt32(_view.Input());

            Member member = new Member(name, personalNumber);

            _memberHandler.addMember(member);

            _view.Output("Member registrered!");
        }

        public void DeleteMember()
        {
            _view.Output("Delete member");
            _view.Output("-----------------------");

            _view.Output("Enter name of member: ");
            string memberName = _view.Input();

            // Remove boats along the removed member
            Member member = _memberHandler.getMember(memberName);
            _boatHandler.deleteBoats(member.MemberId);

            // Remove member
            _memberHandler.deleteMember(memberName);

            _view.Output("Member deleted.");
        }

        public void EditMember()
        {
            _view.Output("Edit member");
            _view.Output("-----------------------");

            _view.Output("Enter member name: ");
            string memberName = _view.Input();

            //COntains member information
            Member member = _memberHandler.getMember(memberName);
            if (member == null)
            {
                _view.Error("No member with that name found.");
                EditMember();
            }

            _view.Output("Name: " + member.Name + ", personal number: " + member.PersonalNumber);

            _view.Output("Enter new name (" + member.Name + "): ");
            string newName = _view.Input();

            _view.Output("Enter new personal number (" + member.PersonalNumber + "): ");
            int newPersonalNumber = Convert.ToInt32(_view.Input());

            _memberHandler.deleteMember(member.Name);

            member.Name = newName;
            member.PersonalNumber = newPersonalNumber;

            _memberHandler.addMember(member);

            _view.Output("Member edited!");
        }

        public void ViewMember()
        {
            _view.Output("View member");
            _view.Output("-----------------------");

            _view.Output("Enter member name: ");
            string memberName = _view.Input();

            Member member = _memberHandler.getMember(memberName);
            if (member == null)
            {
                _view.Error("No member with that name found.");
                ViewMember();
            }

            _view.Output("Name: " + member.Name);
            _view.Output("Personal number: " + member.PersonalNumber);
            _view.Output("Member id: " + member.MemberId);
            _view.Output("");
        }
    }
}
