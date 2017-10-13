using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class BoatHandler
    {
        private DatabaseModel databaseModel;
        public BoatHandler(DatabaseModel databaseModel) 
        {
            this.databaseModel = databaseModel;
        }

        public void deleteBoat(Boat boat)
        {
            databaseModel.deleteBoat(boat);
        }

        public void deleteBoats(int memberId)
        {
            databaseModel.deleteBoats(memberId);
        }

        public List<Boat> getBoats()
        {
            return databaseModel.findBoats();
        }

        public List<Boat> getBoats(int memberId)
        {
            return databaseModel.findBoats(memberId);
        }

        public void addBoat(Boat boat)
        {
            databaseModel.addBoat(boat);
        }
    }
}
