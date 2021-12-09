using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.MostriVSEroi.Core.Models
{
    public enum CategoriaMostro
    {
        Cultista = 1,
        Orco = 2 ,
        SignoreDelMale =3 
    }
    public class Mostro
    {
        public string Nome { get; set; }
        public int Livello { get; set; }
        public int PuntiVita { get; set; }
        public int  IdArma { get; set; }
        public CategoriaMostro Categoria { get; set; }

        public Mostro()
        {
            PuntiVita = Livello * 20;
        }

        public override string ToString()
        {
            return $"Nome:{Nome} Livello:{Livello} PuntiVita:{PuntiVita} Classe: {Categoria}";
        }
    }
}
