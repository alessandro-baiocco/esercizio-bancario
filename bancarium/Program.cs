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
using bancarium.entities;
using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
internal class Program
{
    static List<Client> clienti = [];
    static List<Prestito> prestiti = [];


    private static void Main(string[] args)
    {


        DateTime data1 = DateTime.Now;
        DateTime data2 = new DateTime(02 / 10 / 2021);
        DateTime data3 = new DateTime(08 / 05 / 2023);
        DateTime data4 = new DateTime(09 / 12 / 2022);
        DateTime data5 = new DateTime(09 / 10 / 2024);
        DateTime data6 = new DateTime(09 / 10 / 2025);

        Client cliente1 = new Client("mario", "rossi", "BASFWFG", 1000.00);
        Client cliente2 = new Client("gianni", "verdi", "AFGGXHWG", 1020.50);
        Client cliente3 = new Client("sara", "gialli", "VXGWTVSFG", 1100.20);
        Prestito prestito1 = new Prestito(data1, data6, "settimanale", 402.23, cliente1);
        Prestito prestito2 = new Prestito(data2, data5, "2 mesi", 4124124.42, cliente1);
        Prestito prestito3 = new Prestito(data4, data5, "mensile", 524.42, cliente3);
        Prestito prestito4 = new Prestito(data3, data5, "annuale", 48624.42, cliente2);

        clienti.Add(cliente3);
        clienti.Add(cliente2);
        clienti.Add(cliente1);
        prestiti.Add(prestito1);
        prestiti.Add(prestito2);
        prestiti.Add(prestito3);
        prestiti.Add(prestito4);


        bool exit = true;
        while (exit)
        {
            Console.WriteLine("seleziona cosa vuoi fare\n1.aggiungi prestito\n2.rimuovi prestito \n3.modifica prestito \n4.ricerca un cliente \n5.vedi lista prestiti \n6.esci");
            string input = Console.ReadLine();


            

            switch (input)
            {
                case "1":
                    {
                        Console.WriteLine("selezionare cliente");

                        for(int i = 0; i < clienti.Count; i++)
                        {
                            Console.WriteLine(i + 1 + ". " + clienti[i].ToString());
                        }
                        
                        while (true)
                        {
                            int clientSelector = CheckInt();
                            try
                            {
                                    Prestito output = CreateLoan(clienti[clientSelector - 1]);
                                    Console.WriteLine($"il prestito {output.ToString()} per {clienti[clientSelector - 1].presentazione()} è stato creato con successo");
                                    break;
                               
                            } catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine("numero non valido selezionare un numero nella lista");
                            }
                          

                        }
                        break;
                    }

                case "2":
                    {
                        for (int i = 0; i < prestiti.Count; i++)
                        {
                            Console.WriteLine(i + 1 + ". " + prestiti[i].ToString());
                        }


                        while (true)
                        {
                            int loanSelector = CheckInt();
                            try
                            {
          
                                    string output = DeleteLoan(loanSelector - 1);
                                    Console.WriteLine(output);
                                    break;
                            } catch(ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine("numero non valido selezionare un numero nella lista");
                            }
                          



                        }

                        break;
                    }

                case "3":
                    {

                        for (int i = 0; i < prestiti.Count; i++)
                        {
                            Console.WriteLine(i + 1 + ". " + prestiti[i].ToString());
                        }


                        while (true)
                        {
                            int loanSelector = CheckInt();
                            try
                            {

                                Prestito output = PutLoan(prestiti[loanSelector - 1]);
                                Console.WriteLine($"il prestito è stato midificato con successo ecco quello nuovo: {output.ToString()}");
                                break;
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine("numero non valido selezionare un numero nella lista");
                            }

                        }

                            break;
                        }
                case "4":
                    {

                        CLientSearch();
                        break;
                    }


                case "5":
                    {

                        for (int i = 0; i < prestiti.Count; i++)
                        {
                            Console.WriteLine(i + 1 + ". " + prestiti[i].ToString());
                        }


                        break;
                    }
                case "6":
                    {
                        Console.WriteLine("uscita...");
                        exit = false;
                        break;
                    }


                default:
                    {
                        Console.WriteLine("input non valido");
                        break;
                    }
            }


        }

    }




    


    public static int CheckInt()
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

    public static double CheckDouble()
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











    public static Prestito CreateLoan(Client cliente)
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


        Console.WriteLine("inserire tipo di rata \n 1.settimanale \n 2.mensile \n 3.annuale \n 4.personalizzata");
        string rateType = Console.ReadLine();
        string rata = "";
        while (rata == "" || rata == null)
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
                case "4":
                    {
                        Console.WriteLine("inserire rata");
                        rata = Console.ReadLine();
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

        return loan;


    }

    public static string DeleteLoan(int index)
    {
        prestiti.RemoveAt(index);


        return "il prestito è stato eliminato corettamente";


    }



    public static Prestito PutLoan(Prestito prestito)
    {

        bool exit = true;

        while (exit)
        {
            Console.WriteLine("cosa vuoi modificare ? \n1.data d'inizio  \n2.data di fine \n3.tipo di rata \n4.ammontare \n5.per uscire");
            string putSelector = Console.ReadLine();
            switch (putSelector)
            {
                case "1":
                    {

                        Console.WriteLine("inserire la data nel seguente formato \"gg/MM/AAAA\" \n0.per annullare");
                        string linea = Console.ReadLine();
                        DateTime newDate;
                        if (linea == "0")
                        {
                            linea = prestito.getDataDiInizio().ToString("dd/MM/yyyy");
                            Console.WriteLine(linea);
                        }

                        while (!DateTime.TryParseExact(linea, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out newDate))
                        {

                            Console.WriteLine("data invalida, per favore riprova");
                            linea = Console.ReadLine();
                            if (linea == "0")
                            {
                                linea = prestito.getDataDiInizio().ToString("dd/MM/yyyy");
                                Console.WriteLine(linea);
                            }


                        }

                        prestito.setDataDiInizio(newDate);

                        break;
                    }

                case "2":
                    {

                        Console.WriteLine("inserire la data nel seguente formato \"gg/MM/AAAA\"  \n0.per annullare");
                        string line = Console.ReadLine();
                        DateTime dt;

                        if (line == "0")
                        {
                            line = prestito.getDataDiFine().ToString("dd/MM/yyyy");
                            Console.WriteLine(line);
                        }

                        while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                        {
                            Console.WriteLine("data invalida, per favore riprova");
                            line = Console.ReadLine();
                            if (line == "0")
                            {
                                line = prestito.getDataDiFine().ToString();
                            }
                        }


                        prestito.setDataDiFine(dt);

                        break;
                    }

                case "3":
                    {
                        Console.WriteLine("inserire tipo di rata \n 1.settimanale \n 2.mensile \n 3.annuale \n 4.personalizzata \n5.annulla");
                        string rateType = Console.ReadLine();
                        string rata = "";
                        while (rata == "" || rata == null)
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
                                case "4":
                                    {
                                        Console.WriteLine("inserire rata");
                                        rata = Console.ReadLine();
                                        break;
                                    }
                                case "5":
                                    {
                                        rata = prestito.getRata();
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("input non valido");
                                        break;


                                    }
                            }
                        }

                        prestito.setRata(rata);

                        break;
                    }

                case "4":
                    {


                        Console.WriteLine("inserire totale da restituire \n0.per annullare ");

                        double ammontare = CheckDouble();

                        if (ammontare == 0.0)
                        {
                            ammontare = prestito.getAmmontare();
                        }

                        prestito.setAmmontare(ammontare);

                        break;
                    }
                case "5":
                    {
                        Console.WriteLine("uscita...");
                        exit = false;
                        break;
                    }



            }




        }

        return prestito;



    }


    static void CLientSearch()
    {
        bool exit = true;
        while (exit)
        {
            Console.WriteLine("cosa vuoi cercare ? \n1.nome \n2.cognome \n3.codice fiscale \n4.esci ");
            string searchString = Console.ReadLine();
            switch (searchString)
            {
                case "1":
                    {
                        Console.WriteLine("inserire nome da ricercare:");
                        string searchInput = Console.ReadLine().ToUpper();
                        int total = 0;

                        for (int i = 0; i < clienti.Count; i++)
                        {
                            if (clienti[i].getNome().ToUpper().Contains(searchInput))
                            {
                                Console.WriteLine(clienti[i].ToString() + "prestiti concessi : " + clienti[i].getPrestiti().Length);
                                total++;
                            }
                        }
                        if( total > 0)
                            {
                                Console.WriteLine("ricerca completata risultati trovati : " + total);
                            }
                        else
                            {
                                Console.WriteLine("ricerca completata non è stato trovato nessun risultato");
                            }
                         

                        
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("inserire cognome da ricercare:");
                        string searchInput = Console.ReadLine().ToUpper();
                        int total = 0;

                        for (int i = 0; i < clienti.Count; i++)
                        {
                            if (clienti[i].getCognome().ToUpper().Contains(searchInput))
                            {
                                Console.WriteLine(clienti[i].ToString() + "prestiti concessi : " + clienti[i].getPrestiti().Length);
                                total++;
                            }
                        }
                        if (total > 0)
                        {
                            Console.WriteLine("ricerca completata risultati trovati : " + total);
                        }
                        else
                        {
                            Console.WriteLine("ricerca completata non è stato trovato nessun risultato");
                        }
                        break;
                    }

                case "3":
                    {
                        Console.WriteLine("inserire Codice Fiscale da ricercare:");
                        string searchInput = Console.ReadLine().ToUpper();
                        int total = 0;

                        for (int i = 0; i < clienti.Count; i++)
                        {
                            if (clienti[i].getCodiceFiscale().ToUpper().Contains(searchInput))
                            {
                                Console.WriteLine(clienti[i].ToString() + "prestiti concessi : " + clienti[i].getPrestiti().Length );
                                total++;
                            }
                        }
                            if (total > 0)
                            {
                                Console.WriteLine("ricerca completata risultati trovati : " + total);
                            }
                            else
                            {
                                Console.WriteLine("ricerca completata non è stato trovato nessun risultato");
                            }
                        
                        break;
                    }
                case "4":
                    {
                        Console.WriteLine("uscita");
                        exit = false;
                        break;

                    }
                default:
                    {
                        Console.WriteLine("input non valido");
                        break;
                    }

            }

        }
       








    }








}
