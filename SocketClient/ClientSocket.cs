using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;


namespace LabBrabender.ClientSocket
{
    public enum ConnectionStatus { Connecting, Connected, Disconnect };
    public interface IClient
    {
        void Connect();
        void Disconnect();
        void Free();
        void Send(string Cmd);

    }
    public class Client : IClient
    {
        private Thread _Thread_Client;
        private TcpClient _TcpClient;
        private Boolean _Started;
        private Queue<string> _SendQueue;
        private ConnectionStatus _Status;

        public string Ip;
        public int Port;
        public int Tag;
        public int WriteBufferSize;
        public int ReadBufferSize;
        public int ReceiveTimeout;

        // Events:        
        //public delegate void Event(object sender);
        public delegate void Event_Receive(object sender, string Text);
        public delegate void Event_Status(object sender, ConnectionStatus connectionStatus);
        public delegate void Event_Error(object sender, string message);

        // Public Event:
        public event Event_Receive OnRead;
        public event Event_Status OnChangeConnection;
        public event Event_Error OnError;
        public Boolean Connected
        { // property:
            get
            {
                if (_TcpClient != null)
                    return _TcpClient.Connected;
                return false;
            }
        }

        public Client(int port = 65535, string ip = "127.0.0.1", int writeBufferSize = 1024, int readBufferSize = 1024, int receivetimeout = 100)
        { // Constructor:
            try
            {
                _ChangeConnection(ConnectionStatus.Disconnect);
                _SendQueue = new Queue<string>();

                _Started = false;

                _TcpClient = null;
                _Thread_Client = null;

                Port = port;
                Ip = ip;
                WriteBufferSize = writeBufferSize;
                ReadBufferSize = readBufferSize;
                ReceiveTimeout = receivetimeout;
            }
            catch (Exception e)
            {
                _OnError(e.Message);
            }
        }

        ~Client()
        {
            try
            {
                Free();
            }
            catch (Exception e)
            {
                _OnError(e.Message);
            }
        }

        public void Connect()
        {
            try
            {
                _Started = true;
                _Thread_Client = new Thread(CheckServer);
                _Thread_Client.Start();
            }
            catch (Exception e)
            {
                _OnError(e.Message);
            }
        }
        public void Disconnect()
        {// Stop:
            try
            {
                _Started = false;
                _DisposeConnection();
                _ChangeConnection(ConnectionStatus.Disconnect);
            }
            catch (Exception e)
            {
                _OnError(e.Message);
            }
        }
        public void Free()
        {
            try
            {
                Disconnect();
                _SendQueue = null;

                _Free_Client();

                if (_Thread_Client != null)
                    _Thread_Client.DisableComObjectEagerCleanup();

                //_Thread_Client?.Abort();
                _Thread_Client = null;
            }
            catch (Exception e)
            {
                _OnError(e.Message);
            }
        }
        public void Send(string Cmd)
        {
            if (_SendQueue == null)
                _SendQueue = new Queue<string>();

            if (!_SendQueue.Contains(Cmd))
                _SendQueue.Enqueue(Cmd);
        }

        public void ClearCommands()
        {
            _SendQueue.Clear();
        }

        private void _SendText()
        {
            if (_SendQueue == null)
                _SendQueue = new Queue<string>();

            if (_SendQueue.Count > 0)
                if (_Status == ConnectionStatus.Connected && _TcpClient != null)
                {
                    try
                    {
                        NetworkStream nstream = _TcpClient.GetStream();
                        byte[] buffer = Encoding.ASCII.GetBytes(_SendQueue.Dequeue());
                        nstream.Write(buffer, 0, buffer.Length);

                    }
                    catch (Exception e)
                    {
                        _OnError(e.Message);
                    }
                }
        }

        // Private:
        private void _Create_Client()
        {
            try
            {
                _TcpClient = null;
                _TcpClient = new TcpClient();              
                _TcpClient.ReceiveTimeout = ReceiveTimeout;
            }
            catch (Exception e)
            {
                _OnError(e.Message);
            }
        }

        private void _Connect_Client()
        {
            try
            {
                if (_TcpClient == null)
                    _Create_Client();

                if (_TcpClient != null)
                {
                    _ChangeConnection(ConnectionStatus.Connecting);
                    if (!string.IsNullOrEmpty(Ip))
                        _TcpClient?.Connect(Ip, Port);
                }
            }
            catch (Exception e)
            {
                _OnError(e.Message);
            }
        }
        private void _Free_Client()
        {
            try
            {
                _DisposeConnection();
                _TcpClient = null;
            }
            catch (Exception e)
            {
                _OnError(e.Message);
            }
        }
        private void _DisposeConnection()
        {
            try
            {
                if (_TcpClient != null)
                    if (_TcpClient.Connected)
                    {
                        _TcpClient?.GetStream().Close();
                        _TcpClient?.Client.Close();
                        _TcpClient?.Close();
                    }

            }
            catch
            {
                _TcpClient = null;
            }
            finally
            {
                _TcpClient = null;
            }
        }

        private void _ReadText()
        {
            try
            {
                if (_TcpClient == null)
                {
                    _Create_Client();
                    return;
                }

                NetworkStream nstream = _TcpClient.GetStream();
                byte[] Buffer = new byte[ReadBufferSize];
                if (nstream.DataAvailable)
                {
                    nstream.Read(Buffer, 0, Buffer.Length);
                    string ReciveText = Encoding.ASCII.GetString(Buffer);

                    OnRead?.Invoke(this, ReciveText);
                       
                }
            }
            catch (Exception e)
            {
                _OnError(e.Message);
            }
        }
        private void CheckServer()
        {
            while (_Started)
            {
                try
                {
                    if (_TcpClient != null)
                    {
                        if (_TcpClient.Connected)
                        {   // Connected to Server:
                            if (_Status != ConnectionStatus.Connected)// Connected:
                                _ChangeConnection(ConnectionStatus.Connected);

                            // Send:
                            _SendText();

                            // Read:
                            _ReadText();
                        }
                        else
                        { // DisConnect:
                            if (_Status == ConnectionStatus.Connected)
                                _ChangeConnection(ConnectionStatus.Disconnect);


                            //if(_Status != ConnectionStatus.Connecting)                                
                            _Connect_Client();
                        }
                    }
                    else
                    {// Not Create _TcpClient:
                        _Create_Client();
                    }
                }
                catch (Exception e)
                {
                    _OnError(e.Message);
                }
                Thread.Sleep(100);
            }
        }
        // Events:   
        protected virtual void _OnError(string message)
        {
            OnError?.Invoke(this, message);
            if (_Started)
            {
                _Free_Client();

                _ChangeConnection(ConnectionStatus.Disconnect);
            }
        }
        protected virtual void _ChangeConnection(ConnectionStatus connectionStatus)
        {
            try
            {
                if (_Status != connectionStatus)
                {
                    _Status = connectionStatus;
                    OnChangeConnection?.Invoke(this, _Status);
                }
            }
            catch (Exception e)
            {
                var s = e.Message;
            }
        }
    }
}

