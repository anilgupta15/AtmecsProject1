using System;
using System.Collections.Generic;
using System.Text;

namespace SocketConnection
{
    public interface IUDPSocket
    {
        void ConnectToServer(ClientEntity clientEntity);
        byte[] RecieveBytes();
        string ReadMessage(byte[] content);
        byte[] ReadBytes(string message);
        int SendMessage(byte[] content);
    }
}
