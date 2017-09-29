using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class BoatController
    {
        private MenuView _view;
        private MemberHandler _memberHandler;
        private BoatHandler _boatHandler;

        public BoatController(MenuView view, MemberHandler memberHandler, BoatHandler boatHandler)
        {
            _view = view;
            _memberHandler = memberHandler;
            _boatHandler = boatHandler;
        }

        public void RegisterBoat()
        {
            _view.Output("Register boat");
            _view.Output("-----------------------");

            _view.Output("Enter member name: ");
            string memberName = _view.Input();

            _view.Output("Enter boat type: ");
            string boatType = _view.Input();

            _view.Output("Enter boat length: ");
            int boatLength = Convert.ToInt32(_view.Input());

            Member member = _memberHandler.getMember(memberName);

            Boat boat = new Boat(member.getMemberId(), boatType, boatLength);
            _boatHandler.addBoat(boat);
        }

        public void DeleteBoat()
        {
            _view.Output("Delete boat");
            _view.Output("-----------------------");

            // enter username
            _view.Output("Enter member name: ");
            string memberName = _view.Input();

            // numbered list of boats belonging to that user
            Member member = _memberHandler.getMember(memberName);
            List<Boat> boatsDelete = _boatHandler.getBoats(member.getMemberId());
            _view.Output("Boats belonging to " + memberName + ":");
            for (int i = 0; i < boatsDelete.Count; i++)
            {
                _view.Output((i+1) + " Type: " + boatsDelete[i].getType() + ", Length: " + boatsDelete[i].getLength());
            }

            // enter number of boat the should be deleted
            _view.Output("Which boat do you want to delete?");
            int boatNumber = Convert.ToInt32(_view.Input());

            // delete boat
            _boatHandler.deleteBoat(boatsDelete[boatNumber-1]);
            _view.Output("");
        }

        public void EditBoat()
        {
            _view.Output("Edit boat");
            _view.Output("-----------------------");

            _view.Output("Enter name of boat owner: ");
            string boatOwner = _view.Input();

            // visa lista av båtar tillhörande båtägaren :D
            Member boatOwner123 = _memberHandler.getMember(boatOwner);
            List<Boat> boats123 = _boatHandler.getBoats(boatOwner123.getMemberId());
            _view.Output("Boats belonging to " + boatOwner + ":");
            for (int i = 0; i < boats123.Count; i++)
            {
                _view.Output((i+1) + " Type: " + boats123[i].getType() + ", Length: " + boats123[i].getLength());
            }

            // välj vilken av båtarna som ska editeras :D
            _view.Output("Which boat do you want to edit?");
            int boatNumber = Convert.ToInt32(_view.Input());
            Boat boat = boats123[boatNumber-1];

            // likadant som där uppe (:D)
            _view.Output("Enter new boat type (" + boat.getType() + "): ");
            string newType = _view.Input();
            _view.Output("Enter new boat length (" + boat.getLength() + "): ");
            int newLength = Convert.ToInt32(_view.Input());

            _boatHandler.deleteBoat(boat);

            boat.setType(newType);
            boat.setLength(newLength);
            _boatHandler.addBoat(boat);
        }
    }
}
