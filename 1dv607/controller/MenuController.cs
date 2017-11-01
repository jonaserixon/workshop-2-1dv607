using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class MenuController
    {
        private MenuView _view;
        private MemberHandler _memberHandler;
        private BoatHandler _boatHandler;

        public MenuController(MenuView view, MemberHandler memberHandler, BoatHandler boatHandler)
        {
            _view = view;
            _memberHandler = memberHandler;
            _boatHandler = boatHandler;
        }

        public void run()
        {
            _view.Clear();

            MemberController memberController = new MemberController(_view, _memberHandler, _boatHandler);
            BoatController boatController = new BoatController(_view, _memberHandler, _boatHandler);

            Boolean programIsRunning = true;

            while(programIsRunning)
            {
                _view.RenderMenu();
           
                string choice = _view.Input();
                _view.Clear();

                switch (choice)
                {
                    case "1":
                        memberController.RegisterMember();
                        break;
                    case "2":
                        CompactList();
                        break;
                    case "3":
                        VerboseList();
                        break;
                    case "4":
                        memberController.DeleteMember();
                        break;
                    case "5":
                        memberController.EditMember();
                        break;
                    case "6":
                        memberController.ViewMember();
                        break;
                    case "7":
                        boatController.RegisterBoat();
                        break;
                    case "8":
                        boatController.DeleteBoat();
                        break;
                    case "9":
                        boatController.EditBoat();
                        break;
                    case "0":
                        programIsRunning = false;
                        _view.Output("Good bye!");
                    break;
                }

                _view.Output("Press any button to continue.");
                _view.Input();
                _view.Clear();
            }
        }

        private void CompactList()
        {
            _view.Output("Compact list of members");
            _view.Output("-----------------------");

            List<Member> members = _memberHandler.getMembers();

            foreach(Member profile in members)
            {
                _view.Output("Name: " + profile.Name);
                _view.Output("Member id: " + profile.MemberId);
                _view.Output("Number of boats: " + profile.Boats.Count);
                _view.Output("");
            }
        }

        private void VerboseList()
        {
            _view.Output("Verbose list of members");
            _view.Output("-----------------------");

            List<Member> members = _memberHandler.getMembers();

            foreach(Member profile in members)
            {
                _view.Output("Name: " + profile.Name);
                _view.Output("Member id: " + profile.MemberId);
                _view.Output("Personal number: " + profile.PersonalNumber);

                List<Boat> boats = _boatHandler.getBoats(profile.MemberId);
                foreach(Boat profileBoat in boats)
                {
                    _view.Output("Boat type: " + profileBoat.getType());
                    _view.Output("Boat length: " + profileBoat.getLength());
                }
                _view.Output("");
            }
        }
    }
}
