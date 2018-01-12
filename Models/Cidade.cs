using System;
using System.Collections.Generic;

namespace Proj.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int Habitantes { get; set; }
        public Cidade()
        {
            
        }
        public Cidade(int Id, string Nome, string Estado, int Habitantes )
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Estado = Estado;
            this.Habitantes = Habitantes;
        }
        public List<Cidade> ListarCidades()
        {
            List<Cidade> cid = new List<Cidade>(){
                new Cidade(12, "São Paulo", "SP", 35),
                new Cidade(13, "Leme", "SP", 5),
                new Cidade(14, "Campinas", "SP", 32),
                new Cidade(15, "São João da Barra", "RJ", 14),
                new Cidade(16, "Salvador", "Ba", 55)
            };
            return cid;
        }
    }
}