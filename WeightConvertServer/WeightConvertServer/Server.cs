using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WeightConvertServer
{
    class Server
    {
        private int PORT;

        public Server(int port)
        {
            PORT = port;
        }

        public Server()
        {
        }

        public void Start()
        {
            TcpListener serverListener = new TcpListener(IPAddress.Loopback, PORT);
            serverListener.Start();
            while (true)
            {
                TcpClient socket = serverListener.AcceptTcpClient();


                IPEndPoint localAddr = (IPEndPoint)socket.Client.LocalEndPoint;
                IPEndPoint remoteAddr = (IPEndPoint)socket.Client.RemoteEndPoint;
                Console.WriteLine($"Incomming IP={remoteAddr.Address} PORT={remoteAddr.Port}");
                Console.WriteLine($"My own    IP={localAddr.Address} PORT={localAddr.Port}");

                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                });
            }
        }

        public void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                // incomming string
                string incommingString = sr.ReadLine();

                // process string
                string[] incommingPrompt = incommingString.Split(" ");
                string incommingCommand = incommingPrompt[0];
                double incommingNumber = 0;
                bool validNumber = true;
                bool validParameters = incommingPrompt.Length == 2;
                if (incommingPrompt.Length >= 2)
                {
                    try
                    {
                        incommingNumber = Convert.ToDouble(incommingPrompt[1]);
                    }
                    catch (Exception e)
                    {
                        validNumber = false;
                    }
                }

                // response
                double result;
                if (incommingCommand == "TOGRAMS" && validNumber && validParameters)
                {
                    result = MA01ClassLibrary.MyConvert.ToGrams(incommingNumber);
                    sw.WriteLine(result);
                    sw.Flush();
                }
                else if (incommingCommand == "TOOUNCES" && validNumber && validParameters)
                {
                    result = MA01ClassLibrary.MyConvert.ToOunces(incommingNumber);
                    sw.WriteLine(result);
                    sw.Flush();
                }
                else
                {
                    string fail = "Invalid command. ";
                    if (!validParameters)
                    {
                        fail = fail + "Wrong number of parameters. ";
                    }
                    if (!validNumber)
                    {
                        fail = fail + "Second Parameter must be a number. ";
                    }

                    sw.WriteLine(fail);
                    sw.Flush();
                }

            }







        }
    }
}
