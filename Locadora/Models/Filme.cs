﻿namespace Locadora.Models
{
    public class Filme
    {
        public long? FilmeID { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public decimal Preco { get; set; } 
        public int Quantidade { get; set; } 
        public string Sobre { get; set; }
    }
}
