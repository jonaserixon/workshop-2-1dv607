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

        public void deleteBoat(Member member, Boat boat)
        {
            databaseModel.deleteBoat(member, boat);
        }

        public void deleteBoats(Member member)
        {
            databaseModel.deleteBoats(member);
        }

        public List<Boat> getBoats(int memberId)
        {
            return databaseModel.findBoats(memberId);
        }

        public void addBoat(Member member, Boat boat)
        {
            databaseModel.addBoat(member, boat);
        }
    }
}
