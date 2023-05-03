using System.Net;
using TicTacToe.Client;

var rnd = new Random(Guid.NewGuid().GetHashCode());

Console.Title = "TicTacToe.Client";

var side = rnd.Next(0, 1) == 0 ? "X" : "O";
Console.WriteLine($"Player {side}");

Console.WriteLine("Welcome player =)\n" +
    $"Your side is {side}. Its randomly choosing by randomizer");
Console.WriteLine("To start play enter value like: 0 0");


Client client = new Client(IPAddress.Parse("127.0.0.1"), 5000);

client.InitConnection();

client.InitData();


while (true)
{
    string message = Console.ReadLine();

    client.writer.WriteLine(message);
    client.writer.Flush();

    string messageFromServer = client.reader.ReadLine();

    Console.WriteLine("Another player: " + messageFromServer);
}