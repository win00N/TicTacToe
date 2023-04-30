using System.Net;
using TicTacToe.Client;

Console.WriteLine("Player");
Console.Title = "TicTacToe.Client";

Console.WriteLine("Enter name: ");

Client client = new Client(IPAddress.Parse("127.0.0.1"), 5000);

client.InitConnection();

client.InitData();


while (true)
{
    string message = Console.ReadLine();

    client.writer.WriteLine(message);
    client.writer.Flush();

    string messageFromServer = client.reader.ReadLine();

    Console.WriteLine("Server: " + messageFromServer);
}