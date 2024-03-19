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

using System;
using System.Numerics;
internal partial class Program
{
    static List<Client> clienti = [];
    static List<Prestito> prestiti = [];






    private static void Main(string[] args)
    {


        Client cliente1 = new Client("mario", "rossi", "BASFWFG", 1000.00);
        Client cliente2 = new Client("gianni", "verdi", "BASFWFG", 1020.50);
        Client cliente3 = new Client("sara", "gialli", "BASFWFG", 1100.20);

        clienti.Add(cliente3);
        clienti.Add(cliente2);
        clienti.Add(cliente1);


        while (true)
        {
            Console.WriteLine("seleziona cosa vuoi fare\n1.aggiungi prestito\n2.rimuovi prestito \n3.modifica prestito \n4.ricerca un cliente \n5.vedi lista prestiti \n6.esci");
            string input = Console.ReadLine();


            bool exit = false;

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
                            if (clienti[clientSelector - 1] == null)
                            {
                                Console.WriteLine("numero non valido selezionare un numero nella lista");
                            }
                            else
                            {
                                string output = CreateLoan(clienti[clientSelector - 1]);
                                Console.WriteLine(output);
                                break;
                            }

                        }
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
                        exit = true;
                        break;
                    }


                default:
                    {
                        Console.WriteLine("input non valido");
                        break;
                    }
            }
            if (exit)
            {
                break;
            }





        }

    }




    public class Client
    {
        private string nome;
        private string cognome;
        private string codiceFiscale;
        private double stipendio;
        private List<Prestito> prestiti;



        //costruttore
        public Client(string nome, string cognome, string codiceFiscale, double stipendio)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.codiceFiscale = codiceFiscale;
            this.stipendio = stipendio;
            this.prestiti = [];
        }



        //setters
        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public void setCognome(string cognome)
        {
            this.cognome = cognome;
        }


        public void setCodiceFiscale(string codiceFiscale)
        {
            this.codiceFiscale = codiceFiscale;
        }


        public void setStipendio(double stipendio)
        {
            this.stipendio = stipendio;
        }


        //getters

        public string getNome()
        {
            return this.nome;
        }

        public string getCognome()
        {
            return this.cognome;
        }


        public string getCodiceFiscale()
        {
            return this.codiceFiscale;
        }


        public double getStipendio()
        {
            return this.stipendio;
        }

        public string getPrestiti()
        {
            return this.prestiti.ToString();
        }

        //tostring
        public string ToString()
        {
            return $"nome : {this.nome} cognome : {this.cognome} codice fiscale : {this.codiceFiscale} stipendio : {this.stipendio}";

        }

        public string presentazione()
        {
            return $"{this.nome} {this.cognome}";

        }


    }



    class Prestito
    {
        private DateTime dataDiInizio;
        private DateTime dataDiFine;
        private double ammontare;
        private string rata;
        private Client cliente;

        //costruttore
        public Prestito(DateTime dataDiInizio, DateTime dataDiFine, string rata, double ammontare, Client cliente)
        {
            this.dataDiInizio = dataDiInizio;
            this.dataDiFine = dataDiFine;
            this.rata = rata;
            this.ammontare = ammontare;
            this.cliente = cliente;

        }


        //setters
        public void setDataDiInizio(DateTime dataDiInizio)
        {
            this.dataDiInizio = dataDiInizio;
        }

        public void setDataDiFine(DateTime dataDiFine)
        {
            this.dataDiFine = dataDiFine;
        }


        public void setRata(string rata)
        {
            this.rata = rata;
        }


        public void setAmmontare(double ammontare)
        {
            this.ammontare = ammontare;
        }

        public void setCliente(Client cliente)
        {
            this.cliente = cliente;
        }

        //getters

        public DateTime getDataDiInizio()
        {
            return this.dataDiInizio;
        }

        public DateTime getDataDiFine()
        {
            return this.dataDiInizio;
        }


        public string getRata()
        {
            return this.rata;
        }


        public double getAmmontare()
        {
            return this.ammontare;
        }

        public Client getCliente()
        {
            return this.cliente;
        }




        //tostring
        public string ToString()
        {
            return $"Prestito iniziato : {dataDiInizio} , fine prestito {dataDiFine} rata ogni : {rata} totale da restituire : {ammontare} prestito di : {cliente.presentazione()}";
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