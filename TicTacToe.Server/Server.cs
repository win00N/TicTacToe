using System.Net;
using System.Net.Sockets;

namespace TicTacToe.Server;

public class Server
{
    public IPAddress ipAddress;
    public int port;
    public static char[,] Area = InitData();

    // network layer
    public TcpListener tcpListener;

    public Server(IPAddress ipAddress, int port)
    {
        this.ipAddress = ipAddress;
        this.port = port;
    }

    public void InitListener()
    {
        tcpListener = new TcpListener(ipAddress, port);
        tcpListener.Start();
    }
    private static char[,] InitData()
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
}
