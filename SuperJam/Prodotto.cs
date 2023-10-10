using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperJam
{
    public class Prodotto
    {
        public int Codice_tipologia { get; set; }
        public string Nome_prodotto { get; set; }
        public DateTime Data_Scadenza { get; set; }
        public Prodotto(int codice_tipologia, string nome_prodotto, DateTime data_scadenza)
        {
            Codice_tipologia = codice_tipologia;
            Nome_prodotto = nome_prodotto;
            Data_Scadenza= data_scadenza;
        }
    }
}
