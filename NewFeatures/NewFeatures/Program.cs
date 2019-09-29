using System;

namespace NewFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IRoom livingRoom = new LivingRoom { length = 12, width = 10 };

            Console.WriteLine($"Square feet in living room {livingRoom.SquareFeet}");
            int x = 2;
            int y = 3;
            Console.WriteLine($"Total of {x} and {y} is {GetTotal(x, y)}");
            string size = livingRoom switch
            {
                { width: 12 } => size = "Perfect dozen width",
                { length: 12 } => size = "Perfect dozen length",
                _ => size = "Not a perfect dozen size"
            };
            Console.WriteLine(size);
        }

        public static int GetTotal(int x, int y)
        {
            return Add(x, y);
            static int Add(int x, int y) => x + y;
        }
    }
}
