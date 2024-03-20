using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bancarium
{
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
}
