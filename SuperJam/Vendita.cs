using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperJam
{
    internal class Vendita
    {
        public int Id_Prodotto{get;set;}
        public int Quantita { get;set;}
        public DateTime Data_vendita { get;set;}
        public Vendita(int id_prodotto, int quantita, DateTime data_vendita)
        {
            Id_Prodotto = id_prodotto;
            Quantita = quantita;
            Data_vendita = data_vendita;
        }
    }
}
