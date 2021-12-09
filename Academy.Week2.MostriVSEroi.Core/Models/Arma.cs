using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.MostriVSEroi.Core.Models
{
    public enum TipoArma
    {
        ArmaGuerriero,
        ArmaMago,
        ArmaCultista,
        ArmaOrco,
        ArmaSignoreDelMale,
    }
    public class Arma
    {
        public int Id { get; set; }
        public string NomeArma { get; set; }
        public int Danno { get; set; }
        public TipoArma CategoriaArma { get; set; }
        private static int contId = 1;

        public Arma()
        {
            Id = contId++;
        }

        public override string ToString()
        {
            return $"Id:{Id} Arma:{NomeArma} Danno:{Danno} Utilizzatore:{CategoriaArma}";
        }
    }
}
