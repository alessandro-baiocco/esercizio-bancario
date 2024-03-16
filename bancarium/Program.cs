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






internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}



public class Client
{
    string nome;
    string cognome;
    string codiceFiscale;
    double stipendio;
    //Prestito[] prestiti;




    public Client(string nome, string cognome, string codiceFiscale, double stipendio)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.codiceFiscale = codiceFiscale;
        this.stipendio = stipendio;
        //this.prestiti = [];

    }


    public string tostring()
    {
        return $"nome : {this.nome} cognome : {this.cognome} codice fiscale : {this.codiceFiscale} stipendio : {this.stipendio}";

    }

    public string presentazione()
    {
        return $"{this.nome} {this.cognome}";

    }


}



