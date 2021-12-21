using IgricePS.Domen.Korisno;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgricePS.Klijent.Transfer
{
    public class Komunikacija
    {
        public Socket klijentskiSoket;
        NetworkStream tok;
        BinaryFormatter formatter = new BinaryFormatter();

        private static Komunikacija instance;
        private Komunikacija()
        {
            PoveziSe();
        }

        public static Komunikacija Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Komunikacija();
                    
                }
                return instance;
            }
        }

        public bool PoveziSe()
        {
            try
            {
                klijentskiSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                klijentskiSoket.Connect("localhost", 9090);
                tok = new NetworkStream(klijentskiSoket);
                return true;
            }
            catch (SocketException)
            {
                return false;

            }

        }
       
        public Odgovor GenerickiZahtevOdgovor(Operacija operacija, object objekat)
        {
            try
            {
                Zahtev zahtev = new Zahtev(operacija, objekat);
                formatter.Serialize(tok, zahtev);

                Odgovor odgovor = (Odgovor)formatter.Deserialize(tok);
                return odgovor;
            }
            catch (SocketException)
            {
                klijentskiSoket.Close();
                MessageBox.Show("Doslo je do greske na serveru!");
                Environment.Exit(0);
                return new Odgovor(false, "");
            }
            catch (IOException)
            {
                klijentskiSoket.Close();
                MessageBox.Show("Doslo je do greske na serveru!");
                Environment.Exit(0);
                return new Odgovor(false, "");
            }
        }
    }
}
