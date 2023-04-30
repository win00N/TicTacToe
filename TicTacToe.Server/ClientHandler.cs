using System.Net.Sockets;

namespace TicTacToe.ClientHandler;

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

                string messageToClient = Console.ReadLine();

                writer.WriteLine(messageToClient);
                writer.Flush();
            }
        }
    }
}
