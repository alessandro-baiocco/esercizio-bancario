/*
 Esercizio 1: Prestiti bancari

Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.
La banca è caratterizzata da un nome e da un insieme di clienti. I clienti sono caratterizzati da nome, cognome, codice fiscale stipendio. 
Il prestito concesso al cliente, considerato intestatario del prestito, è caratterizzato da un ammontare, una rata, una data inizio, una data fine. 
Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.
Per la banca deve essere possibile aggiungere, modificare, eliminare e ricercare un cliente. Inoltre, la banca deve poter aggiungere un prestito.
La banca deve poter eseguire delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale. La banca vuole anche sapere, dato il codice fiscale di un cliente, 
l’ammontare totale dei prestiti concessi.
 */

using bancarium;
using System;
using System.Numerics;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}




    


    static int CheckInt()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("inserisci un numero intero");
                int clientSelector = Convert.ToInt32(Console.ReadLine());
                return clientSelector;
            }
            catch (Exception ex)
            {
                Console.WriteLine("input non valido");

            }
        }
    }

    static double CheckDouble()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("inserisci un numero con il \".\"");
                double ammount = Convert.ToDouble(Console.ReadLine());
                return ammount;
            }
            catch (Exception ex)
            {
                Console.WriteLine("input non valido");

            }
        }
    }







    public static string CreateLoan(Client cliente)
    {
        DateTime today = DateTime.Today;

        Console.WriteLine("inserire la data nel seguente formato \"gg/MM/AAAA\"");
        string line = Console.ReadLine();
        DateTime dt;

        while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
        {
            Console.WriteLine("data invalida, per favore riprova");
            line = Console.ReadLine();
        }


        Console.WriteLine("inserire tipo di rata \n 1.settimanale \n 2.mensile \n 3.annuale");
        string rateType = Console.ReadLine();
        string rata = "";
        while (rata == "")
        {
            switch (rateType)
            {
                case "1":
                    {
                        rata = "settimanale";
                        break;
                    }
                case "2":
                    {
                        rata = "mensile";
                        break;
                    }
                case "3":
                    {
                        rata = "annuale";
                        break;
                    }
                default:
                    {
                        Console.WriteLine("input non valido");
                        break;


                    }
            }
        }

        Console.WriteLine("inserire totale da restituire");

        double ammontare = CheckDouble();


        Prestito loan = new Prestito(today, dt, rata, ammontare, cliente);

        prestiti.Add(loan);

        return "il prestito è stato aggiunto con successo";










    }
}
