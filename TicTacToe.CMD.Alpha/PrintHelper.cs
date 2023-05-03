namespace TicTacToe.CMD;

public static class PrintHelper
{
    public static void PrintArray(char[,] area)
    {
        Console.WriteLine("   0|1|2|");
        for (int i = 0; i < area.GetLength(0); i++)
        {
            Console.Write($"{i}| ");
            for (int j = 0; j < area.GetLength(1); j++)
            {
                Console.Write(area[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void PrintBoard(char[,] area)
    {
        Console.WriteLine(" {0} | {1} | {2} ", area[0, 0], area[0, 1], area[0, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", area[1, 0], area[1, 1], area[1, 2]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" {0} | {1} | {2} ", area[2, 0], area[2, 1], area[2, 2]);
        Console.WriteLine();
    }
}
