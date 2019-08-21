using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketConnection
{
    public class ClientConnection : IUDPSocket
    {

        UdpClient _udpClient;
        IPAddress _ipAddress;
        IPEndPoint _ipEndPoint;
        
        public ClientConnection()
        {
            _udpClient = new UdpClient();           
        }

        public void ConnectToServer(ClientEntity clientEntity)
        {
            _ipAddress = IPAddress.Parse(clientEntity.IpAddress.Trim());
            _ipEndPoint = new IPEndPoint(_ipAddress, clientEntity.Port);
        }

        public byte[] RecieveBytes()
        {
            return _udpClient.Receive(ref _ipEndPoint);
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
            return _udpClient.Send(content, content.Length, _ipEndPoint);
        }
    }
}
