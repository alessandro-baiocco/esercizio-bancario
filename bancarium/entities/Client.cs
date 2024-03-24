using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bancarium.entities
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
            prestiti = [];
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
            return nome;
        }

        public string getCognome()
        {
            return cognome;
        }


        public string getCodiceFiscale()
        {
            return codiceFiscale;
        }


        public double getStipendio()
        {
            return stipendio;
        }

        public string getPrestiti()
        {
            string allLoans = prestiti.ToString();
            if (allLoans == null)
            {
                return "non è presente nessun prestito";
            }
            return allLoans;
        }

        //tostring
        override
        public string ToString()
        {
            return $"nome : {nome} cognome : {cognome} codice fiscale : {codiceFiscale} stipendio : {stipendio}";

        }

        public string presentazione()
        {
            return $"{nome} {cognome}";

        }


    }
}
