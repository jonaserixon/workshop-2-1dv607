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

            // Remove boats for the removed member
            Member member = _memberHandler.getMember(memberName);
            _boatHandler.deleteBoats(member.getMemberId());

            // Remove member
            _memberHandler.deleteMember(memberName);
        }

        public void EditMember()
        {
            _view.Output("Edit member");
            _view.Output("-----------------------");

            // enter member name
            _view.Output("Enter member name: ");
            string memberName = _view.Input();

            // show member information
            Member member = _memberHandler.getMember(memberName);
            _view.Output("Name: " + member.getName() + ", personal number: " + member.getPersonalNumber());

            // enter new member name
            _view.Output("Enter new name (" + member.getName() + "): ");
            string newName = _view.Input();

            // Enter new personal number
            _view.Output("Enter new personal number (" + member.getPersonalNumber() + "): ");
            int newPersonalNumber = Convert.ToInt32(_view.Input());

            _memberHandler.deleteMember(member.getName());

            member.setName(newName);
            member.setPersonalNumber(newPersonalNumber);
            _memberHandler.addMember(member);
        }

        public void ViewMember()
        {
            _view.Output("View member");
            _view.Output("-----------------------");

            _view.Output("Enter member name: ");
            string memberName = _view.Input();

            Member memberView = _memberHandler.getMember(memberName);
            _view.Output("Name: " + memberView.getName());
            _view.Output("Personal number: " + memberView.getPersonalNumber());
            _view.Output("Member id: " + memberView.getMemberId());
            _view.Output("");
        }
    }
}
