using System.Net.Sockets;

namespace TicTacToe.Server;

public class ClientHandler
{

    private TcpClient _tcpClient;

    // write and read messages
    public NetworkStream networkStream;
    public StreamReader reader;
    public StreamWriter writer;
    private int clientId;

    public ClientHandler(TcpClient tcpClient, int clientId)
    {
        _tcpClient = tcpClient;
        this.clientId = clientId;
    }

    public void Init()
    {
        Thread t = new Thread(Start);
        t.Start();
    }

    public void Start()
    {
        Console.WriteLine(_tcpClient.Connected);
        networkStream = _tcpClient.GetStream();

        reader = new StreamReader(networkStream);
        writer = new StreamWriter(networkStream);


        while (true)
        {
            if (_tcpClient.Connected)
            {
                string? messageFromClient = reader.ReadLine();

                Console.WriteLine($"Client {clientId}: {messageFromClient}");

                Console.WriteLine($"Please type message for client {clientId}:");


                var result = messageFromClient.Split(' ');

                if (Server.Area[int.Parse(result[0]), int.Parse(result[1])].Equals('X'))
                {
                    Console.WriteLine("It's already taken. Choose another location =)");
                    continue;
                }

                Server.Area[int.Parse(result[0]), int.Parse(result[1])] = 'X';


                string messageToClient = "Waiting player choose...";
                



                writer.WriteLine("Your");
                writer.Flush();
            }
        }
    }
}
