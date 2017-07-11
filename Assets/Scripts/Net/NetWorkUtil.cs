using System;
using System.Net.Sockets;
public class NetWorkUtil  {
    private TcpClient clientSocket;
    public bool IsSocketOpen = false;
    public static NetWorkUtil Instance;
    public NetWorkUtil(string ip,int port)
    {
        try
        {
            clientSocket = new TcpClient();
            clientSocket.Connect(ip, port);
            IsSocketOpen = true;
        }
        catch (Exception e)
        {
            IsSocketOpen = false;
            throw new Exception(e.Message);
        }
    }
    public string sendCommand(string cmdString)
    {
        string result = "";
        if (cmdString.Trim().Length == 0)
        {
            result = "Error: No command found";
        }
        else
        {
            try
            {
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(cmdString + "\n");
                NetworkStream serverStream = clientSocket.GetStream();
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
                byte[] inStream = new byte[1024]; //1024 is long enough likely
                serverStream.Read(inStream, 0, 1024);
                result = System.Text.Encoding.ASCII.GetString(inStream);
            }
            catch
            {
                result = "";
                IsSocketOpen = false;
            }
        }
        return result;
    }
}
