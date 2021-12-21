using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Domen.Korisno
{
    [Serializable]
    public class Odgovor
    {
        public bool Signal { get; set; }
        public object Podaci { get; set; }

        public Odgovor(bool signal, object podaci)
        {
            Signal = signal;
            Podaci = podaci;
        }
    }
}
