Client

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DummyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // DNS (Domain Name System)
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

            // 휴대폰 설정
            Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);            
            try
            {
                // 문지기한테 입장 문의
                socket.Connect(endPoint);
                Console.WriteLine($"Connected To {socket.RemoteEndPoint.ToString()}");

                // 보낸다
                byte[] sendBuff = Encoding.UTF8.GetBytes("Hello World!");
                int sentBytes = socket.Send(sendBuff);

                // 받는다
                byte[] recvBuff = new byte[1024];
                int recvBytes = socket.Receive(recvBuff);
                string recvData = Encoding.UTF8.GetString(recvBuff, 0, recvBytes);
                Console.WriteLine($"[From Server] {recvData}");

                // 나간다.
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}

Server

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        static void Main(string[] args)
        {            
            // DNS (Domain Name System)
            string host = Dns.GetHostName(); 
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

            // www.rookiss.com -> 127.1.2.3

            // 문지기
            Socket listenSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            /*서버 */
            try
            {
                // 문지기 교육
                listenSocket.Bind(endPoint);
                
                // 영업 시작
                // backlog : 최대 대기수
                listenSocket.Listen(10);
                while (true)
                {
                    Console.WriteLine("Listening...");

                    // 손님을 입장시킨다.
                    Socket clientSocket = listenSocket.Accept();

                    // 받는다
                    byte[] recvBuff = new byte[1024];
                    int recvBytes = clientSocket.Receive(recvBuff);
                    string recvData = Encoding.UTF8.GetString(recvBuff, 0, recvBytes);
                    Console.WriteLine($"[From Client] {recvData}");

                    // 보낸다
                    byte[] sendBuff = Encoding.UTF8.GetBytes("Welcome to MMORPG Server !");
                    clientSocket.Send(sendBuff);

                    // 쫒아낸다
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();           
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}