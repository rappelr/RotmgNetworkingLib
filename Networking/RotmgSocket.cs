using QR9ProxyLib.Socks;
using RotmgNetworkingLib.Binary;
using RotmgNetworkingLib.Extensions;
using RotmgNetworkingLib.Messaging;
using RotmgNetworkingLib.Reference;
using RotmgNetworkingLib.Utilities;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace RotmgNetworkingLib.Networking
{
    public class RotmgSocket
    {
        public string IncomingRC4, OutgoingRC4;
        public int Port;
        public SocksProxy Proxy;

        public long LastRecievedTimestamp { get; private set; }
        public IPAddress CurrentAddress { get; private set; }

        private readonly ISocketListener _listener;

        private RC4 _incomingCrypto, _outgoingCrypto;
        private Socket _socket;

        public bool Connected => _socket != null && _socket.Connected;

        public RotmgSocket(ISocketListener listener)
        {
            Port = Constants.NET_PORT;
            IncomingRC4 = Constants.NET_RC4_IN;
            OutgoingRC4 = Constants.NET_RC4_OUT;

            _listener = listener;

            LastRecievedTimestamp = -1;
        }

        public void Connect(string dns) => Connect(IPAddress.Parse(dns));

        public void Connect(IPAddress address)
        {
            if (Connected)
                throw new InvalidOperationException("Socket already connected");

            CurrentAddress = address;

            _incomingCrypto = new RC4(Conversion.HexToByteArray(IncomingRC4));
            _outgoingCrypto = new RC4(Conversion.HexToByteArray(OutgoingRC4));

            OpenSocket();

            _listener.OnSocketConnect();

            Task.Run(() => Listen());
        }

        public bool WritePacket(OutgoingPacket packet)
        {
            if (!Connected)
                throw new InvalidOperationException("Socket not connected");

            using (RotmgBinaryWriter writer = new RotmgBinaryWriter(new MemoryStream()))
            {
                writer.Write(0);
                writer.Write(packet.ByteType);
                packet.Write(writer);

                byte[] array = writer.ToByteArray();
                int length = array.Length;

                lock (_outgoingCrypto)
                    _outgoingCrypto.Cipher(array, 5);

                array[0] = (byte)(length >> 24);
                array[1] = (byte)(length >> 16);
                array[2] = (byte)(length >> 8);
                array[3] = (byte)length;

                lock (_socket)
                    _socket.Send(array);
            }

            return true;
        }

        public bool Close()
        {
            if (!Connected)
                return false;

            _socket.Close();
            _socket.Dispose();

            return true;
        }

        private void OpenSocket()
        {
            if (Proxy is null)
            {
                _socket = new Socket(SocketType.Stream, ProtocolType.Tcp)
                {
                    NoDelay = true
                };

                _socket.Connect(new IPEndPoint(CurrentAddress, Port));
            }
            else
            {
                _socket = Proxy.OpenSocket(CurrentAddress, (ushort)Port);
            }
        }

        private void Listen()
        {
            while (_socket.Connected)
            {
                try
                {
                    byte[] packetHeader = new byte[5];
                    _socket.ReceiveAll(packetHeader);

                    byte[] packetContent = new byte[packetHeader.ToInt32() - 5];
                    _socket.ReceiveAll(packetContent);

                    Read(packetHeader[4], packetContent);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Socket recieve failure:\n" + e.ToString());
                    // TODO recieve failure
                    break;
                }
            }

            if (Connected)
                Close();

            _listener.OnSocketDisconnect();
        }

        private bool Read(byte type, byte[] buffer)
        {
            _incomingCrypto.Cipher(buffer, 0);

            Type packetType = null;

            try
            {
                packetType = Packet.Convert(type);
            }
            catch
            {
                return false;
            }

            IncomingPacket packet = Activator.CreateInstance(packetType) as IncomingPacket;

            using RotmgBinaryReader reader = new RotmgBinaryReader(new MemoryStream(buffer));

            try
            {
                packet.Read(reader);
            }
            catch (Exception e)
            {
                Console.WriteLine("Packet read failure:\n" + e.ToString());
                return false;
            }

            LastRecievedTimestamp = TimeUtil.UnixMillis();

            _listener.OnSocketReadPacket(packet);
            return true;
        }
    }

    public interface ISocketListener
    {
        public void OnSocketConnect();
        public void OnSocketDisconnect();
        public void OnSocketReadPacket(IncomingPacket packet);
    }
}
