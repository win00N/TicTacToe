namespace TicTacToe.Server;

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
}
