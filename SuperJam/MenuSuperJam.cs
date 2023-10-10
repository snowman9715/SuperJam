using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperJam
{
    internal class MenuSuperJam
    {
        static public string Menu()
        {
            Console.WriteLine("Benvenuto a SuperJam Management");
            Console.WriteLine("1- Visualizza tutti prodotti");
            Console.WriteLine("2- Visualiza il prodotto piu venduto negli ultimi 30 giorni");
            Console.WriteLine("3- Visualizza i prodotti che scadrano i prossimi 30 giorni\n");
            Console.WriteLine("9- Esci");
            string scelta = Console.ReadLine();
            return scelta;


        }
    }

}
