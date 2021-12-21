using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IgricePS.Server.Niti
{
    public class ServerNit
    {
        Socket osluskujuciSoket;
        List<Socket> lista = new List<Socket>();

        private static ServerNit instance;
        private ServerNit()
        {

        }
        public static ServerNit Instance
        {
            get
            {
                if (instance is null) instance = new ServerNit();
                return instance;
            }
        }

        public bool StartujServer()
        {
            try
            {
                osluskujuciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint parametri = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9090);
                osluskujuciSoket.Bind(parametri);
                osluskujuciSoket.Listen(5);
                lista.Add(osluskujuciSoket);
                Thread osluskuj = new Thread(OsluskujKorisnike);
                osluskuj.Start();
                return true;
            }
            catch (SocketException)
            {
                osluskujuciSoket.Close();
                return false;
            }
            catch (IOException)
            {
                osluskujuciSoket.Close();
                return false;
            }
        }

        public bool StopirajServer()
        {
            try
            {
                foreach (Socket soketJedan in lista)
                {
                    soketJedan.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void OsluskujKorisnike()
        {
            bool kraj = false;
            while (!kraj)
            {
                try
                {

                    Socket soketKlijent = osluskujuciSoket.Accept();
                    lista.Add(soketKlijent);
                    KlijentNit klijentNit = new KlijentNit(soketKlijent);
                    new Thread(klijentNit.ObradiZahtev).Start();
                }
                catch (SocketException)
                {
                    kraj = true;
                }
                catch (IOException)
                {
                    kraj = true;
                }
            }
        }
    }
}
