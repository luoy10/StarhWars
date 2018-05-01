using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UPDServer {
    class Player {
        public int sector;
        public int col;
        public int row;
    }

    public struct Received {
        public IPEndPoint Sender;
        public string Message;
    }

    abstract class UdpBase {
        protected UdpClient Client;

        protected UdpBase() {
            Client = new UdpClient();
        }

        public async Task<Received> Receive() {
            var result = await Client.ReceiveAsync();
            return new Received() {
                Message = Encoding.ASCII.GetString(result.Buffer, 0, result.Buffer.Length),
                Sender = result.RemoteEndPoint
            };
        }
    }

    class UdpListener : UdpBase {
        private IPEndPoint _listenOn;

        public UdpListener() : this(new IPEndPoint(IPAddress.Any, 32123)) { }

        public UdpListener(IPEndPoint endpoint) {
            _listenOn = endpoint;
            Client = new UdpClient(_listenOn);
        }

        public void Reply(string message, IPEndPoint endpoint) {
            var datagram = Encoding.ASCII.GetBytes(message);
            Client.Send(datagram, datagram.Length, endpoint);
        }

    }


    class Program {
        static Player p1 = new Player();

        static void Main(string[] args) {
            //create a new server
            var server = new UdpListener();
			Random rnd = new Random();
            Dictionary<string, IPEndPoint> connections = new Dictionary<string, IPEndPoint>();
            Dictionary<string, Player> players = new Dictionary<string, Player>();


            Console.WriteLine("============================================= Server");

            string[] parts;

            //start listening for messages and copy the messages back to the client
            Task.Factory.StartNew(async () => {
                while (true) {
                    var received = await server.Receive();
                    string msg = received.Message.ToString();
                    parts = msg.Split(':');
                    fixParts(parts);
                    Console.WriteLine(msg + " -- " + received.Sender.Address.MapToIPv4().ToString());

                    // Only add new connections to the list of clients
                    if (!connections.ContainsKey(received.Sender.Address.MapToIPv4().ToString())) {
                        connections.Add(received.Sender.Address.MapToIPv4().ToString(), received.Sender);
                        p1 = new Player();
                        p1.sector = rnd.Next(0, 63);
                        p1.col = rnd.Next(0, 9);
                        p1.row = rnd.Next(0, 9);
                        players.Add(received.Sender.Address.MapToIPv4().ToString(), p1);
                        server.Reply(String.Format("connected:true:{0}:{1}:{2}", p1.sector, p1.col, p1.row ), received.Sender);
                    }


                    string ret = "[Connected Users]";
                    if (received.Message.Equals("list")) {
                        foreach (string s in connections.Keys)
                            ret += "\n>> " + s;
                        server.Reply(ret + "\n*****************", received.Sender);
                    } else {
                        // Okay, send message to everyone
                        //foreach (IPEndPoint ep in connections.Values)
                        //    server.Reply("[" + received.Sender.Address.ToString() + "] says: " + received.Message, ep);
                    }

                    if (received.Message == "quit") {
                        connections.Remove(received.Sender.Address.ToString());     // Remove the IP Address from the list of connections
                    } else if(parts[0].Equals("mov")) {

                        Player p;
                        players.TryGetValue(received.Sender.Address.MapToIPv4().ToString(), out p);

                        if (parts[1].Equals("n")) p.row--;
                        else if (parts[1].Equals("s")) p.row++;
                        else if (parts[1].Equals("e")) p.col++;
                        else if (parts[1].Equals("w")) p.col--;

                        server.Reply(String.Format("loc:{0}:{1}:{2}:{3}", p.sector, p.col, p.row, parts[1]), received.Sender);
                    }
                }
            });


            // Endless loop for user's to send messages to Client
            string read;
            do {
                read = Console.ReadLine();
                foreach (IPEndPoint ep in connections.Values)
                    server.Reply(read, ep);
            } while (read != "quit");
        }

        private static void fixParts(string[] parts) {
            for (int i = 0; i < parts.Length; i++)
                parts[i] = parts[i].Trim().ToLower();
        }
    }
}
