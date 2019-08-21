using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using SocketConnection;

namespace UDPClientCommunication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClientEntity _clientEntity;
        int port = 11000;
        byte[] contentToSend;
        byte[] contentToRecieve;
        string messageFromServer;
        IUDPSocket _iUDPSocket;      

        public MainWindow(IUDPSocket uDPSocket)
        {
             InitializeComponent();
            _clientEntity = new ClientEntity();
            _iUDPSocket = uDPSocket;
        }
        private void Connect(object sender, RoutedEventArgs e)
        {            
            _clientEntity.IpAddress = txtIpAddress.Text.Trim();
            _clientEntity.Port = port;
            _iUDPSocket.ConnectToServer(_clientEntity);
        }
        private void Send(object sender, RoutedEventArgs e)
        {
            contentToSend = _iUDPSocket.ReadBytes(txtMessageSend.Text);
            try
            {
                int count = _iUDPSocket.SendMessage(contentToSend);
                if (count>0)
                {
                    contentToRecieve = _iUDPSocket.RecieveBytes();
                    messageFromServer = _iUDPSocket.ReadMessage(contentToRecieve);
                    lblConnection.Content = messageFromServer;
                    lblConnection.Background = System.Windows.Media.Brushes.LightGray;
                    txtMessageSend.Text = string.Empty;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
