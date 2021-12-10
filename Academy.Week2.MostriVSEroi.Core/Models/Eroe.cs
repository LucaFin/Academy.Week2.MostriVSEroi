using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.MostriVSEroi.Core.Models
{
    public enum CategoriaEroe
    {
        Guerriero = 1,
        Mago= 2
    }
    public class Eroe
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Livello { get; set; }
        public int PuntiVita { get; set;}
        public int PuntiAccumulati { get; set;}
        public int IdArma { get; set; }
        public int IdUtente { get; set; }
        public CategoriaEroe Categoria { get; set; }
        

        public void AddExp(int puntiAccumulati)
        {
            PuntiAccumulati += puntiAccumulati;
            if(Livello < (PuntiAccumulati / 30) + 1 && Livello<5)
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            Livello = (PuntiAccumulati / 30) + 1;
            PuntiVita = Livello * 20;
        }

        public Eroe()
        {
        }

        public override string ToString()
        {
            return $"Id:{Id} Nome:{Nome} Livello:{Livello} PuntiVita:{PuntiVita} Exp:{PuntiAccumulati} Classe: {Categoria}";
        }

    }
}
