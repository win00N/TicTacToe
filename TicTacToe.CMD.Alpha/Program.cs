using System.Text.RegularExpressions;
using TicTacToe.CMD;

var area = InitData();
Regex regex = new Regex(@"^\d$");
char player1 = ' ';
char player2 = ' ';

PrintHelper.PrintBoard(area);


while (true)
{
    if (IsWin(player1))
    {
        Console.WriteLine("Game Over. Player1 win =)");

        area = InitData();
        Console.ReadLine();
        Console.Clear();
        PrintHelper.PrintArray(area);
    }
    if (IsWin(player2))
    {
        Console.WriteLine("Game Over. Player2 win =)");

        area = InitData();
        Console.ReadLine();
        Console.Clear();
        PrintHelper.PrintArray(area);

    }


    if (player1 == ' ' && player2 == ' ')
    {
        Console.WriteLine("(PLAYER 1)");
        Console.WriteLine("Please choose your side X or O >>> ");
        player1 = char.Parse(Console.ReadLine());

        Console.WriteLine("(PLAYER 2)");

        if (player1.Equals('X'))
        {
            player2 = 'O';
            Console.WriteLine($"Your opponent choose {player1} side. Your side is O >>> ");
        }
        else
        {
            player2 = 'X';
            Console.WriteLine($"Your opponent choose {player1} side. Your side is X >>> ");
        }
    }

    Console.WriteLine("PLAYER 1");
    Console.WriteLine("Enter value like: 0 0");

    var input = Console.ReadLine();

    if (input.Length > 0 && input.Equals("exit()"))
    {
        Console.WriteLine("Thanks for playing game. See you again :)");
        break;
    }

    if (string.IsNullOrWhiteSpace(input) ||
        !regex.IsMatch(input[0].ToString()) ||
        !regex.IsMatch(input[2].ToString()))
    {
        Console.WriteLine("Please enter correct data...");
        continue;
    }

    var result = input.Split(' ');


    if (!area[int.Parse(result[0]), int.Parse(result[1])].Equals(' '))
    {
        Console.WriteLine("It's already taken. Choose another location =)");
        continue;
    }

    area[int.Parse(result[0]), int.Parse(result[1])] = player1;


    PrintHelper.PrintBoard(area);

    Console.WriteLine("PLAYER 2");
    Console.WriteLine("Enter value like: 0 0");

    var input2 = Console.ReadLine();

    if (input.Length > 0 && input.Equals("exit()"))
    {
        Console.WriteLine("Thanks for playing game. See you again :)");
        break;
    }

    if (string.IsNullOrWhiteSpace(input) ||
        !regex.IsMatch(input[0].ToString()) ||
        !regex.IsMatch(input[2].ToString()))
    {
        Console.WriteLine("Please enter correct data...");
        continue;
    }

    var result2 = input2.Split(' ');


    if (!area[int.Parse(result2[0]), int.Parse(result2[1])].Equals(' '))
    {
        Console.WriteLine("It's already taken. Choose another location =)");
        continue;
    }

    area[int.Parse(result2[0]), int.Parse(result2[1])] = player2;

    PrintHelper.PrintBoard(area);

}

bool IsWin(char player)
{
    if (player == ' ')
        return false;

    #region Вертикальные случаи
    if (area[0, 0] == player && area[1, 0] == player && area[2, 0] == player)
    {
        return true;
    }

    else if (area[0, 1] == player && area[1, 1] == player && area[2, 1] == player)
    {
        return true;
    }

    else if (area[0, 2] == player && area[1, 2] == player && area[2, 2] == player)
    {
        return true;
    }
    #endregion

    #region Горизонтальные случаи
    if (area[0, 0] == player && area[0, 1] == player && area[0, 2] == player)
    {
        return true;
    }

    else if (area[1, 0] == player && area[1, 1] == player && area[1, 2] == player)
    {
        return true;
    }

    else if (area[2, 0] == player && area[2, 1] == player && area[2, 2] == player)
    {
        return true;
    }
    #endregion

    #region Все остальные случаи
    if (area[0, 0] == player && area[1, 1] == player && area[2, 2] == player)
    {
        return true;
    }
    if (area[0, 2] == player && area[1, 1] == player && area[2, 0] == player)
    {
        return true;
    }
    #endregion

    return false;
}

char[,] InitData()
{
    char symbol = ' ';
    char[,] area = new char[3, 3]
    {
        { symbol, symbol, symbol },
        { symbol, symbol, symbol },
        { symbol, symbol, symbol },
    };
    return area;
}