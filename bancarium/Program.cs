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




internal class Program
{
    
    private static void Main(string[] args)
    {

        static Client[] clienti = [];
        static Prestito[] prestiti = [];
        while (true)
        {
            Console.WriteLine("seleziona cosa vuoi fare\n1.aggiungi prestito\n2.rimuovi prestito \n3.modifica prestito \n4.ricerca un cliente")
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("selezionare cliente");
                    for(int i = 0; i < clienti.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}.{clienti[i]}")
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
                            break;
                        }

                    }
                    
                    






            }





        }
       






        Console.WriteLine("Hello, World!");
    }
}



public class Client
{
    private string nome;
    private string cognome;
    private string codiceFiscale;
    private double stipendio;
    private Prestito[] prestiti;



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
    public string tostring()
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
    private DateOnly dataDiInizio;
    private DateOnly dataDiFine;
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
    public void setDataDiInizio(DateOnly dataDiInizio)
    {
        this.dataDiInizio = dataDiInizio;
    }

    public void setDataDiFine(DateOnly dataDiFine)
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

    public DateOnly getDataDiInizio()
    {
        return this.dataDiInizio;
    }

    public DateOnly getDataDiFine()
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
    public string toString()
    {
        return $"Prestito iniziato : {dataDiInizio} , fine prestito {dataDiFine} rata ogni : {rata} totale da restituire : {ammontare} prestito di : {cliente.presentazione()}";
    }





}


static int CheckInt()
{
    try
    {
        Console.WriteLine("inserisci un numero intero");
        int clientSelector = Convert.ToInt16(Console.ReadLine());
        return clientSelector;
    }
    catch
    {
        Console.WriteLine("input non valido");
        CheckInt();
         
    }
    




}



static string CreateLoan(Client cliente)
{
    DateTime today = DateTime.Today;

    Console.WriteLine("inserire la data nel seguente formato \"gg/MM/AAAA\"")
    string line = Console.ReadLine();
    DateTime dt;

    while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
    {
        Console.WriteLine("data invalida, per favore riprova");
        line = Console.ReadLine();
    }


    Console.WriteLine("inserire tipo di rata \n 1.settimanale \n 2.mensile \n 3.annuale")






}