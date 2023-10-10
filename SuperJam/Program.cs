using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

namespace SuperJam
{
    public class Program
    {
        static public SqlConnection GetDBConnection()
        {
            string connectionString = "Data Source = localhost; Initial Catalog = SuperJamDB ; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            
                return connection;
        }

        static private void ExecuteQuery(string query)
        {
            using (SqlConnection connection = GetDBConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }

        }
        static private DataTable GetDataFromDB(string tableName)
        {
            string queryString = $"Select * from {tableName}";
            using (SqlConnection connection = GetDBConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataTable resultTable = new DataTable();
                adapter.Fill(resultTable);

                return resultTable;
            }  
        }
                


        static string GetBestSeller()
        {
            DataTable dataTable = GetDataFromDB("ilMigliore");
            if (dataTable.Rows.Count > 0)
            {
                ilMigliore ilMigliore = new ilMigliore((int)dataTable.Rows[0]["id_prodotto"], (string)dataTable.Rows[0]["nome_prodotto"], (int)dataTable.Rows[0]["quantita"]);
                string bestSeller = $" Il prodotto più venduto negli ultimi 30 giorni è:\n {ilMigliore.Nome_Prodotto} || Quantittà venduta:{ilMigliore.Quantita}";
                return bestSeller;
            }
            else
            {
                ilMigliore ilMigliore = new ilMigliore(0, "Articolo fittizio", 0);

                return $" Il prodotto più venduto negli ultimi 30 giorni è:\n {ilMigliore.Nome_Prodotto} || Quantittà venduta:{ilMigliore.Quantita}";
            }
            
        }
        static List<string> GetExpirationProducts()
        {
            List<string> expirationProducts = new List<string> ();
            DataTable dataTable = GetDataFromDB("inScadenza");
            Console.WriteLine("\nI prodotti scaduti e quelli che scadrano nei prossimi 30 giorni sono:\n");
            foreach (DataRow row in dataTable.Rows)
            {
                expirationProducts.Add($"- {row["nome_prodotto"]} il: {row["data_scadenza"]}");
            }
            return expirationProducts;
        }

        static  List<string> getAllProducts()
        {
            DataTable dataTable = GetDataFromDB("Prodotti");
            List<string> prodotti = new List<string>();
            Console.WriteLine("Prodotti:\n");
            foreach (DataRow row in dataTable.Rows)
            {
                prodotti.Add($"- {row["nome_prodotto"]}");
            }
            return prodotti;
        }


        static void Main(string[] args)
        {
            try
            {
                string scelta = "";
                do
                {
                    scelta = MenuSuperJam.Menu();

                        if (scelta == "1")
                        {
                            List<string> products = getAllProducts();
                            products.ForEach(Console.WriteLine);
                        }
                        else if (scelta == "2")
                        {
                            Console.WriteLine(GetBestSeller());
                        }
                        else if (scelta == "3")
                        {
                            List<string> expirationProducts = GetExpirationProducts();
                            expirationProducts.ForEach(Console.WriteLine);
                        }
                        else if(scelta == "9")
                        {
                        Console.WriteLine("Arrivederci...");
                        }
                        else
                        {
                        Console.WriteLine("\nOpzione invalida\n");
                        }

                    Console.ReadLine();
                    Console.Clear();
                } while (scelta !="9");
            }
            catch (Exception e)
            {
                Console.WriteLine("Errore nella connesione al DB");
            }

        }



    }
}

//enviroment.exit(-1);
//instalare nuunit semplicemente per instalarlo come punto nel esame