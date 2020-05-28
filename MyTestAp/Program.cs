using System;

namespace MyTestAp
{
  public class Program
    {
        static int Counter;
        static Random rand = new Random();
        static int Interval = 50; 
        static int FullFlow = Interval + 15; 
        static int Blacking = FullFlow + 25; 
        static ConsoleColor NormalColor = ConsoleColor.DarkGreen;
        static ConsoleColor GlowColor = ConsoleColor.Green;
        static ConsoleColor FancyColor = ConsoleColor.White;
        static String TextInput = "Matrix";
        //heres a change
      public static void Main(string[] args)
        {
            Console.ForegroundColor = NormalColor;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;

            int width, height;
            int[] y;
            Initialize(out width, out height, out y);

            while (true)
            {
                Counter = Counter + 1;
                UpdateAllColumns(width, height, y);
                if (Counter > (3 * Interval))
                    Counter = 0;

            }
        }

        private static void UpdateAllColumns(int width, int height, int[] y)
        {
            int x;
            if (Counter < Interval)
            {
                for (x = 0; x < width; ++x)
                {
                    Console.ForegroundColor = x % 10 == 1 ? FancyColor : GlowColor;
                    Console.SetCursorPosition(x, y[x]);
                    Console.Write(AsciiCharacter);

                    Console.ForegroundColor = x % 10 == 9 ? FancyColor : NormalColor;
                    int temp = y[x] - 2;
                    Console.SetCursorPosition(x, InScreenYPosition(temp, height));
                    Console.Write(AsciiCharacter);

                    int temp1 = y[x] - 20;
                    Console.SetCursorPosition(x, InScreenYPosition(temp1, height));
                    Console.Write(' ');
                    y[x] = InScreenYPosition(y[x] + 1, height);

                }
            }
            else if (Counter > Interval && Counter < FullFlow)
            {
                for (x = 0; x < width; ++x)
                {

                    Console.SetCursorPosition(x, y[x]);
                    Console.ForegroundColor = x % 10 == 9 ? FancyColor : NormalColor;

                    Console.Write(AsciiCharacter);

                    y[x] = InScreenYPosition(y[x] + 1, height);
                }
            }
            else if (Counter > FullFlow)
            {
                for (x = 0; x < width; ++x)
                {
                    Console.SetCursorPosition(x, y[x]);
                    Console.Write(' ');
                    int temp1 = y[x] - 20;
                    Console.SetCursorPosition(x, InScreenYPosition(temp1, height));
                    Console.Write(' ');
                    if (Counter > FullFlow && Counter < Blacking)
                    {
                        Console.ForegroundColor = x % 10 == 9 ? FancyColor : NormalColor;
                        int temp = y[x] - 2;
                        Console.SetCursorPosition(x, InScreenYPosition(temp, height));
                        Console.Write(AsciiCharacter);

                    }
                    Console.SetCursorPosition(width / 2, height / 2);
                    Console.Write(TextInput);
                    y[x] = InScreenYPosition(y[x] + 1, height);
                }

            }
        }
        public static int InScreenYPosition(int yPosition, int height)
        {
            if (yPosition < 0)
                return yPosition + height;
            if (yPosition < height)
                return yPosition;
            return 0;
        }

        private static void Initialize(out int width, out int height, out int[] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;
            y = new int[width];
            Console.Clear();

            for (int x = 0; x < width; ++x) 
            {
                y[x] = rand.Next(height);
            }
        }


        static char AsciiCharacter
        {
            get
            {
                int t = rand.Next(10);
                if (t <= 2)
                    return (char)('0' + rand.Next(10));
                if (t <= 4)
                    return (char)('a' + rand.Next(27));
                if (t <= 6)
                    return (char)('A' + rand.Next(27));
                return (char)(rand.Next(32, 255));
            }
        }
    }
}
