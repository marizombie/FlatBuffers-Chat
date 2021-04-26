using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using FlatBuffers;

namespace FlatBufChat.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string address = "127.0.0.1";
        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        private string localPort = "8000";
        public string LocalPort
        {
            get => localPort;
            set => SetProperty(ref localPort, value);
        }

        private string port = "8001";
        public string Port
        {
            get => port;
            set => SetProperty(ref port, value);
        }

        private string name = "mari";
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        private string messageBoxContent;
        public string MessageBoxContent
        {
            get => messageBoxContent;
            set => SetProperty(ref messageBoxContent, value);
        }

        private RelayCommand sendMessageCommand;
        public RelayCommand SendMessageCommand
        {
            get => new RelayCommand(SendMessage);
            set => sendMessageCommand = value;
        }

        private void SendMessage()
        {
            var sender = new UdpClient();
            try
            {
                var newMessage = Name + ": " + Message;
                var data = Encoding.Unicode.GetBytes(newMessage);
                sender.Send(data, data.Length, Address, Convert.ToInt32(Port));

                MessageBoxContent += newMessage + "\n";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sender.Close();
            }
        }

        private void ReceiveMessage()
        {
            var receiver = new UdpClient(Convert.ToInt32(localPort));
            IPEndPoint remoteIp = null;
            try
            {
                while (true)
                {
                    var data = receiver.Receive(ref remoteIp);
                    var opponentMessage = Encoding.Unicode.GetString(data);

                    MessageBoxContent += opponentMessage + "\n";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                receiver.Close();
            }
        }

        public MainViewModel()
        {
            var receiveThread = new Thread(ReceiveMessage);
            receiveThread.Start();
        }
    }
}
