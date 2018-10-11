using System;

namespace WeightConvertServer
{
    class Program
    {
        private const int PORT = 10007;

        static void Main(string[] args)
        {

            Server server = new Server(PORT);
            server.Start();

        }
    }
}
