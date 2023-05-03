namespace TicTacToe.CMDD;

public static class PrintHelper
{
    public static void DisplayUI(string name)
    {
        Console.WriteLine();

        Console.WriteLine($"Чтобы сделать ход {name} выберите число от 1 от 9 ");
        Console.WriteLine();
    }

    public static void DisplayGameboard(char[] gameMarkers)
    {
        Console.WriteLine($" {gameMarkers[0]} | {gameMarkers[1]} | {gameMarkers[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {gameMarkers[3]} | {gameMarkers[4]} | {gameMarkers[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {gameMarkers[6]} | {gameMarkers[7]} | {gameMarkers[8]} ");
    }

    public static void DisplayIntro()
    {
        Console.WriteLine(" X | X | X ");
        Console.WriteLine("---+---+---");
        Console.WriteLine(" O | O | O ");
        Console.WriteLine("---+---+---");
        Console.WriteLine(" X | X | X ");
    }
}
