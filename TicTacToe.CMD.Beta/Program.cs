namespace TicTacToe.CMDD;

class Program
{
    static void Main(string[] args)
    {
        int gameStatus = 0;
        int currentPlayer = -1;
        char[] gameMarkers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        
        Console.Write("Введите имя первый игрок >>> ");
        var firstPlayer = Console.ReadLine();

        Console.Write("Введите имя второй игрок >>> ");
        var secondPlayer = Console.ReadLine();


        var players = new Dictionary<int, string>
        {
            {  1, firstPlayer},
            {  2, secondPlayer},
        };


        Console.WriteLine("Добро пожаловать в Крестики-Нолики!");
        PrintHelper.DisplayIntro();
        Console.WriteLine("Чтобы продолжить игру нажмите на любую кнопку...");
        Console.ReadLine();

        do
        {
            Console.Clear();

            currentPlayer = GetNextPlayer(currentPlayer);

            if (currentPlayer == 1)
                Console.WriteLine($"Ваш ход {firstPlayer}");
            if (currentPlayer == 2)
                Console.WriteLine($"Ваш ход {secondPlayer}");

            PrintHelper.DisplayUI(players[currentPlayer]);
            PrintHelper.DisplayGameboard(gameMarkers);

            Game(gameMarkers, currentPlayer);

            gameStatus = CheckWinner(gameMarkers);

        } while (gameStatus.Equals(0));

        Console.Clear();
        PrintHelper.DisplayUI(players[currentPlayer]);
        PrintHelper.DisplayGameboard(gameMarkers);

        if (gameStatus.Equals(1))
        {
            Console.WriteLine($"Игрок {currentPlayer} выиграл!");
        }

        if (gameStatus.Equals(2))
        {
            Console.WriteLine($"Ничья!");
        }
    }

    private static int CheckWinner(char[] gameMarkers)
    {

        if (IsGameWinner(gameMarkers))
        {
            return 1;
        }

        if (IsGameDraw(gameMarkers))
        {
            return 2;
        }

        return 0;
    }

    private static bool IsGameDraw(char[] gameMarkers)
    {
        return gameMarkers[0] != '1' &&
               gameMarkers[1] != '2' &&
               gameMarkers[2] != '3' &&
               gameMarkers[3] != '4' &&
               gameMarkers[4] != '5' &&
               gameMarkers[5] != '6' &&
               gameMarkers[6] != '7' &&
               gameMarkers[7] != '8' &&
               gameMarkers[8] != '9';
    }


    /// <summary>
    /// Метод проверяет выграл ли игрок.
    /// Все возможные комбинации
    /// </summary>
    /// <param name="gameMarkers"></param>
    /// <returns></returns>
    private static bool IsGameWinner(char[] gameMarkers)
    {
        if (IsGameMarkersTheSame(gameMarkers, 0, 1, 2))
        {
            return true;
        }

        if (IsGameMarkersTheSame(gameMarkers, 3, 4, 5))
        {
            return true;
        }

        if (IsGameMarkersTheSame(gameMarkers, 6, 7, 8))
        {
            return true;
        }

        if (IsGameMarkersTheSame(gameMarkers, 0, 3, 6))
        {
            return true;
        }

        if (IsGameMarkersTheSame(gameMarkers, 1, 4, 7))
        {
            return true;
        }

        if (IsGameMarkersTheSame(gameMarkers, 2, 5, 8))
        {
            return true;
        }

        if (IsGameMarkersTheSame(gameMarkers, 0, 4, 8))
        {
            return true;
        }

        if (IsGameMarkersTheSame(gameMarkers, 2, 4, 6))
        {
            return true;
        }

        return false;
    }

    private static bool IsGameMarkersTheSame(char[] testGameMarkers, int pos1, int pos2, int pos3)
    {
        return testGameMarkers[pos1].Equals(testGameMarkers[pos2])
            && testGameMarkers[pos2].Equals(testGameMarkers[pos3]);
    }

    private static void Game(char[] gameMarkers, int currentPlayer)
    {
        bool notValidMove = true;

        do
        {
            string userInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(userInput) &&
                (userInput.Equals("1") ||
                userInput.Equals("2") ||
                userInput.Equals("3") ||
                userInput.Equals("4") ||
                userInput.Equals("5") ||
                userInput.Equals("6") ||
                userInput.Equals("7") ||
                userInput.Equals("8") ||
                userInput.Equals("9")))
            {

                int.TryParse(userInput, out var gamePlacementMarker);

                char currentMarker = gameMarkers[gamePlacementMarker - 1];

                if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                {
                    Console.WriteLine("Это место уже занято. Выберите другое место =)");
                }
                else
                {
                    gameMarkers[gamePlacementMarker - 1] = GetPlayerMarker(currentPlayer);

                    notValidMove = false;
                }
            }
            else
            {
                Console.WriteLine("Выберите правильное значение.");
            }
        } while (notValidMove);
    }

    private static char GetPlayerMarker(int player)
    {
        return player % 2 == 0 ? 'O' : 'X';
    }

    private static int GetNextPlayer(int player)
    {
        return player.Equals(1) ? 2 : 1;
    }
}