using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketConnection
{
    public class ServerConnection : IUDPSocket
    {
        int port = 11000;
        UdpClient _udpClient;
        IPEndPoint _remoteIPEndPoint;
        public ServerConnection()
        {
            _udpClient = new UdpClient(port);
            _remoteIPEndPoint = new IPEndPoint(IPAddress.Any, port);
        }
        public byte[] RecieveBytes()
        {
            return _udpClient.Receive(ref _remoteIPEndPoint);
        }
        public string ReadMessage(byte[] content)
        {
            return Encoding.ASCII.GetString(content);
        }
        public byte[] ReadBytes(string message)
        {
            return Encoding.ASCII.GetBytes(message);
        }
        public int SendMessage(byte[] content)
        {
            return _udpClient.Send(content, content.Length, _remoteIPEndPoint);
        }

        public void ConnectToServer(ClientEntity clientEntity)
        {
            throw new NotImplementedException();
        }
    }
}
