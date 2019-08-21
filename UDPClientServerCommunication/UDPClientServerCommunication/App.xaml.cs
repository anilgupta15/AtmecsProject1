using SocketConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UDPClientCommunication;
using Unity;

namespace UDPClientServerCommunication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUDPSocket, ClientConnection>();
            MainWindow mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
