using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using SocketConnection;


namespace UDPServerComunication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUDPSocket _iUDPSocket;
        public delegate void ShowMessage(string message);
        public ShowMessage myDelegate;
        Thread thread;
        public MainWindow(IUDPSocket iUDPSocket)
        {
            _iUDPSocket = iUDPSocket;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myDelegate = new ShowMessage(ShowMessageMethod);
            thread = new Thread(new ThreadStart(ReceiveMessage));
            thread.IsBackground = true;
            thread.Start();
        }
        private void ReceiveMessage()
        {
            while (true)
            {
                byte[] content = _iUDPSocket.RecieveBytes();
                if (content.Length > 0)
                {
                    byte[] contentToSend = _iUDPSocket.ReadBytes("Server Successfully recieve packates");
                    _iUDPSocket.SendMessage(contentToSend);
                    string message = _iUDPSocket.ReadMessage(content);
                    this.Dispatcher.Invoke(myDelegate, new object[] { message });
                }
            }
        }

        private void ShowMessageMethod(string message)
        {
            txtMessageFromClient.Text +="Client : " + message + " \n";
        }

   
    }
}
