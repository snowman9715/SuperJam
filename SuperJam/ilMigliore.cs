using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperJam
{
    internal class ilMigliore
    {
        public int Id_Prodotto { get; set; }
        public string Nome_Prodotto { get; set; }
        public int Quantita { get; set; }
        public ilMigliore(int id_prodotto, string nome_prodotto, int quantita)
        {
            Id_Prodotto = id_prodotto;
            Nome_Prodotto= nome_prodotto;
            Quantita = quantita;
            
        }
    }
}
