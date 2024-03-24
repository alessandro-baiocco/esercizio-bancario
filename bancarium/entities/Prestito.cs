﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bancarium.entities
{
    public class Prestito
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
            return dataDiInizio;
        }

        public DateTime getDataDiFine()
        {
            return dataDiInizio;
        }


        public string getRata()
        {
            return rata;
        }


        public double getAmmontare()
        {
            return ammontare;
        }

        public Client getCliente()
        {
            return cliente;
        }




        //tostring
        public string ToString()
        {
            return $"Prestito iniziato : {dataDiInizio} , fine prestito {dataDiFine} rata ogni : {rata} totale da restituire : {ammontare} prestito di : {cliente.presentazione()}";
        }

    }
}