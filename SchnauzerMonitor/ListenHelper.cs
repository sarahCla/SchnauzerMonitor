using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SchnauzerMonitor
{
    public delegate void DealDataHander(byte[] data);
   

    public class ListenHelper
    {
        public IPEndPoint EndPort { get; set; }
        static readonly object padlock = new object();
        public ListenHelper()
        {

        }
        public ListenHelper(IPEndPoint endport) : this() { this.EndPort = endport; }
        public event DealDataHander dealDataHander;


        public void Open()
        {
            try
            {
                Socket socketServer = new Socket(EndPort.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socketServer.Bind(EndPort);
                socketServer.Listen(10);
                
                Socket socketClient;

                try
                {
                    Thread t = new Thread(new ThreadStart(delegate()
                    {
                        while (true)
                        {
                            socketClient = socketServer.Accept();
                            Thread thread = new Thread(new ThreadStart(delegate()
                            {
                               
                                if (socketClient != null)
                                {
                                    lock (padlock)
                                    {
                                        if (socketClient != null)
                                        {
                                            byte[] buff = new byte[500];
                                            Socket tempSocket = socketClient;
                                            try
                                            {  
                                                tempSocket.Receive(buff);
                                                BeginReceiveAfterDeal(buff);
                                                tempSocket.Close();
                                            }
                                            catch (Exception)
                                            {
                                                tempSocket.Close();
                                            }
                                            finally
                                            {
                                                tempSocket.Close();
                                                Thread.CurrentThread.Abort();
                                            }
                                        }
                                        
                                    }
                                    
                                }

                            }));
                            thread.Start();
                        }
                    }));
                    t.IsBackground = true;
                    t.Start();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 线程接收完成后的处理
        /// </summary>
        private void BeginReceiveAfterDeal(byte[] socketData)
        {
            dealDataHander(socketData);
        }
    }
}
