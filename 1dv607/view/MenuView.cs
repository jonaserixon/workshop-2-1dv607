using System;

namespace _1dv607
{
    class MenuView
    {
        public void RenderMenu()
        {
            Console.WriteLine("BOAT CLUB");
            Console.WriteLine("");
            Console.WriteLine("What do you want do?");
            Console.WriteLine("1. Register member");
            Console.WriteLine("2. Compact list of members");
            Console.WriteLine("3. Verbose list of members");
            Console.WriteLine("4. Delete member");
            Console.WriteLine("5. Edit member");
            Console.WriteLine("6. View member");
            Console.WriteLine("7. Register boat");
            Console.WriteLine("8. Delete boat");
            Console.WriteLine("9. Edit boat");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Press the desired number");
        }

        public void Output(string output)
        {
            Console.WriteLine(output);
        }

        public string Input()
        {
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
