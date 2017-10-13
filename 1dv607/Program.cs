using System;
using System.Collections.Generic;
using System.IO;

namespace _1dv607
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create view
            MenuView view = new MenuView();

            // Create model
            DatabaseModel databaseModel = new DatabaseModel();
            MemberHandler memberHandler = new MemberHandler(databaseModel);
            BoatHandler boatHandler = new BoatHandler(databaseModel);

            // Create controller
            MenuController menuController = new MenuController(view, memberHandler, boatHandler);
            menuController.run();
        }
    }
}
