//
//	  UnityOSC - Open Sound Control interface for the Unity3d game engine
//
//	  Copyright (c) 2012 Jorge Garcia Martin
//
// 	  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// 	  documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// 	  the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
// 	  and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// 	  The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// 	  of the Software.
//
// 	  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// 	  TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// 	  THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// 	  CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// 	  IN THE SOFTWARE.
//

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

namespace UnityOSC
{
	/// <summary>
	/// Receives incoming OSC messages
	/// </summary>
    public class OSCServer
    {
        public OSCServer(int localPort)
        {
            _localPort = localPort;
            SocketStart(_localPort);
        }
        public static OSCServer Instance;
        public int LocalPort;
        Socket _socket;
        byte[] bufferlister;
        private int _localPort;

        private OSCPacket _lastReceivedPacket;
        public string moveInfoData = "";

        static int _lenth = 20;
        public List<OSCPacket> recvPacks = new List<OSCPacket>();
        private void SocketStart(int _localPort)
        {
            LocalPort = _localPort;
            Socket socket = new Socket(AddressFamily.InterNetwork,
              SocketType.Dgram,
              ProtocolType.Udp);
            EndPoint localEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), _localPort);
           // EndPoint localEP = new IPEndPoint(IPAddress.Any, _localPort);
            socket.Bind(localEP);
            SocketState state = new SocketState(socket);
            socket.BeginReceiveFrom(
                state.Buffer, 0, state.Buffer.Length,
                SocketFlags.None,
                ref state.RemoteEP,
                EndReceiveFromCallback,
                state);
        }
        void EndReceiveFromCallback(IAsyncResult iar)
        {
            SocketState state = iar.AsyncState as SocketState;
            Socket socket = state.Socket;
            try
            {
                int byteRead = socket.EndReceiveFrom(iar, ref state.RemoteEP);
                bufferlister = new byte[byteRead];
                Buffer.BlockCopy(state.Buffer, 0, bufferlister, 0, byteRead);
                if (bufferlister.Length < 1) return;
                _lastReceivedPacket = OSCPacket.Unpack(bufferlister);
                _lastReceivedPacket.TimeStamp = long.Parse(String.Concat(DateTime.Now.Ticks));
                if (_lastReceivedPacket.Data.Count == 2)
                {
                        lock (recvPacks)
                        {
                            recvPacks.Add(_lastReceivedPacket);

                            if (recvPacks.Count > _lenth - 1)
                            {
                                recvPacks.RemoveAt(0);
                            }
                        }
                   
                }


            }
            catch (Exception e)
            {
                _socket.Close();
                Console.WriteLine("发生异常！异常信息：");
                Console.WriteLine(e.Message);

            }
            finally
            {
                socket.BeginReceiveFrom(
                    state.Buffer, 0, state.Buffer.Length,
                    SocketFlags.None,
                    ref state.RemoteEP,
                    EndReceiveFromCallback,
                    state);
            }
        }
        /// <summary>
        /// Closes the server and terminates its listener thread.
        /// </summary>
        public void Close()
        {
            if (_socket != null)
            {
                _socket.Close();
                _socket = null;
            }
        }

    }
}


class SocketState
{
    public SocketState(Socket socket)
    {
        this.Buffer = new byte[1024];
        this.Socket = socket;
        this.RemoteEP = new IPEndPoint(IPAddress.Any, 0);

    }
    public Socket Socket { get; private set; }
    public byte[] Buffer { get; private set; }
    public EndPoint RemoteEP;

}