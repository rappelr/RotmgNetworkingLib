using System;
using System.Net;
using System.Net.Sockets;

namespace RotmgNetworkingLib.Extensions
{
    public static class SocketExtensions
    {
        public static void ReceiveAll(this Socket socket, byte[] data)
        {
            int num;

            for (int offset = 0; offset < data.Length; offset += num)
            {
                num = socket.Receive(data, offset, data.Length - offset, SocketFlags.None);
                if (num == 0)
                    throw new Exception("End of stream reached");
            }
        }

        public static void Connect(this Socket socket, EndPoint endpoint, TimeSpan timeout)
        {
            IAsyncResult asyncResult = socket.BeginConnect(endpoint, (AsyncCallback)null, (object)null);
            asyncResult.AsyncWaitHandle.WaitOne(timeout, true);

            if (socket.Connected)
                socket.EndConnect(asyncResult);

            else
            {
                socket.Close();
                throw new SocketException(10060);
            }
        }

        public static int ToInt32(this byte[] buffer, int startIndex = 0) => buffer[startIndex + 3] | buffer[startIndex + 2] << 8 | buffer[startIndex + 1] << 16 | buffer[startIndex] << 24;
    }
}
