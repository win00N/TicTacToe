using System.Net;
using System.Net.Sockets;
using TicTacToe.ClientHandler;
using TicTacToe.Server;

Console.WriteLine("(TicTacToe Server)");
Console.Title = "TicTacToe.Server";


Server server = new Server(IPAddress.Parse("127.0.0.1"), 5000);


Console.WriteLine("INIT Listener");
server.InitListener();

int clientNumber = 1;

while (true)
{
    Console.WriteLine("Wating clients");
    TcpClient client = server.tcpListener.AcceptTcpClient();

    ClientHandler ch = new ClientHandler(client, clientNumber);
    ch.Init(); // new stream

    Console.WriteLine($"Client {clientNumber} connected");
    clientNumber++;
}