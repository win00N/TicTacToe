using System.Text.RegularExpressions;
using TicTacToe.CMD;

var area = InitData();
Regex regex = new Regex(@"^\d$");


PrintHelper.PrintArray(area);


while (true)
{
    if (IsWin())
    {
        Console.WriteLine("Game Over. You win =)");

        area = InitData();
        Console.ReadLine();
        Console.Clear();
        PrintHelper.PrintArray(area);
    }

    

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


    if (area[int.Parse(result[0]), int.Parse(result[1])].Equals('X'))
    {
        Console.WriteLine("It's already taken. Choose another location =)");
        continue;
    }

    area[int.Parse(result[0]), int.Parse(result[1])] = 'X';


    PrintHelper.PrintArray(area);

}

bool IsWin()
{

    #region Вертикальные случаи
    if (area[0, 0] == 'X' && area[1, 0] == 'X' && area[2, 0] == 'X')
    {
        return true;
    }

    else if (area[0, 1] == 'X' && area[1, 1] == 'X' && area[2, 1] == 'X')
    {
        return true;
    }

    else if (area[0, 2] == 'X' && area[1, 2] == 'X' && area[2, 2] == 'X')
    {
        return true;
    }
    #endregion

    #region Горизонтальные случаи
    if (area[0, 0] == 'X' && area[0, 1] == 'X' && area[0, 2] == 'X')
    {
        return true;
    }

    else if (area[1, 0] == 'X' && area[1, 1] == 'X' && area[1, 2] == 'X')
    {
        return true;
    }

    else if (area[2, 0] == 'X' && area[2, 1] == 'X' && area[2, 2] == 'X')
    {
        return true;
    }
    #endregion

    #region Все остальные случаи
    if (area[0, 0] == 'X' && area[1, 1] == 'X' && area[2, 2] == 'X')
    {
        return true;
    }
    if (area[0, 2] == 'X' && area[1, 1] == 'X' && area[2, 0] == 'X')
    {
        return true;
    }


    #endregion

    return false;
}





char[,] InitData()
{
    char symbol = '_';
    char[,] area = new char[3, 3]
    {
        { symbol, symbol, symbol },
        { symbol, symbol, symbol },
        { symbol, symbol, symbol },
    };
    return area;
}