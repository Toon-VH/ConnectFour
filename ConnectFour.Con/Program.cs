using System;
using ForOnARow.core;


namespace ForOnARow.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            ForOnARowEngine core = new ForOnARowEngine();
            Print(core);
            Console.WriteLine($"Player {core.Turn} may start");
            Console.Write("PLZ Enter the row number: ");
            int answer = int.Parse(Console.ReadLine());
            while(!core.Validate(answer))
            {
                Print(core);
                Console.WriteLine($"Player {core.Turn}");
                Console.Write("PLZ Enter the row number: ");
                answer = int.Parse(Console.ReadLine());
                
            }
            Print(core);
            Console.WriteLine("You won");
            

            
        }

        static void Print(ForOnARowEngine core)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int position = 35 - (i * 7) + j;
                    if (core.Board[position].HasValue)
                    {
                        Console.Write($"  {core.Board[position]}  ");
                    }
                    else Console.Write("  -  ");
                }

                Console.WriteLine();
            }
        }
    }
}