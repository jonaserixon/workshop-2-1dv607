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
            Member member = _memberHandler.getMember(memberName);
            if (member == null)
            {
                _view.Error("No member with that name found.");
                RegisterBoat();
            }

            _view.Output("Enter boat type (Sailboat, Motorsailer, Kayak, Canoe, Other): ");
            string boatType = _view.Input();
            if (boatType == "Sailboat" || boatType == "Motorsailer" || boatType == "Kayak" || boatType == "Canoe" || boatType == "Other")
            {
                _view.Output("Enter boat length: ");
                int boatLength = Convert.ToInt32(_view.Input());

                Boat boat = new Boat(member.getMemberId(), boatType, boatLength);
                _boatHandler.addBoat(boat);

                _view.Output("Boat added!");
            }
            else
            {
                _view.Error("Wrong boat type.");
                RegisterBoat();
            }
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
            if (member == null)
            {
                _view.Error("No member with that name found.");
                DeleteBoat();
            }

            List<Boat> boatsDelete;
            try
            {
                boatsDelete = _boatHandler.getBoats(member.getMemberId());

                if (boatsDelete.Count == 0)
                {
                    _view.Error("No boats registered to that member.");
                    DeleteBoat();
                }

                _view.Output("Boats belonging to " + memberName + ":");
                for (int i = 0; i < boatsDelete.Count; i++)
                {
                    _view.Output((i+1) + " Type: " + boatsDelete[i].getType() + ", Length: " + boatsDelete[i].getLength());
                }

                // enter number of boat the should be deleted
                _view.Output("Which boat do you want to delete?");
                int boatNumber = Convert.ToInt32(_view.Input());
                if (boatNumber < 1 || boatNumber > boatsDelete.Count)
                {
                    _view.Error("No boat with that index.");
                    DeleteBoat();
                }

                // delete boat
                try
                {
                    _boatHandler.deleteBoat(boatsDelete[boatNumber-1]);
                }
                catch (Exception e)
                {
                    _view.Error(e.Message);
                    DeleteBoat();
                }

                _view.Output("Boat deleted!");
            }
            catch (Exception e)
            {
                _view.Error(e.Message);
                DeleteBoat();
            }
        }

        public void EditBoat()
        {
            _view.Output("Edit boat");
            _view.Output("-----------------------");

            _view.Output("Enter name of boat owner: ");
            string boatOwnerName = _view.Input();

            // visa lista av båtar tillhörande båtägaren :D
            Member boatOwner = _memberHandler.getMember(boatOwnerName);
            List<Boat> boats = _boatHandler.getBoats(boatOwner.getMemberId());
            _view.Output("Boats belonging to " + boatOwner + ":");
            for (int i = 0; i < boats.Count; i++)
            {
                _view.Output((i+1) + " Type: " + boats[i].getType() + ", Length: " + boats[i].getLength());
            }

            // välj vilken av båtarna som ska editeras :D
            _view.Output("Which boat do you want to edit?");
            int boatNumber = Convert.ToInt32(_view.Input());
            Boat boat = boats[boatNumber-1];

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
