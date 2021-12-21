using IgricePS.Domen.Korisno;
using IgricePS.Server.KontrolerAplikacioneLogike;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Server.Niti
{
    public class KlijentNit
    {
        BinaryFormatter formatter = new BinaryFormatter();
        NetworkStream network;
        Socket soket;
        public KlijentNit(Socket soket)
        {
            this.soket = soket;
            this.network = new NetworkStream(soket);
        }
        public void ObradiZahtev()
        {
            bool signal = false;
            while (!signal)
            {
                try
                {
                    Zahtev zahtev = (Zahtev)formatter.Deserialize(network);
                    Odgovor o = Kontroler.Instance.GetResponse(zahtev);
                    formatter.Serialize(network, o);
                }
                catch (SocketException)
                {
                    soket.Close();
                    signal = true;
                }
                catch (IOException)
                {
                    soket.Close();
                    signal = true;
                }
                catch (SerializationException)
                {
                    soket.Close();
                    signal = true;
                }
            }

        }

        
    }
}
