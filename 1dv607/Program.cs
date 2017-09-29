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
            MemberHandler memberHandler = new MemberHandler();
            BoatHandler boatHandler = new BoatHandler();

            // Create controller
            MenuController menuController = new MenuController(view, memberHandler, boatHandler);
            menuController.run();

            
        }
    }
}
