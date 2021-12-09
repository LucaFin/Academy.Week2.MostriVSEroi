using Academy.Week2.MostriVSEroi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.MostriVSEroi.Mock.Repository
{
    public class InMemoryStorage
    {
        public static List<Utente> Utenti = new List<Utente>()
        {
            new Utente(){Id = 1,Nickname="Amministratore",Password="qwerty",IsAdmin=true},
            new Utente(){Id = 1,Nickname="ComuneMortale",Password="pippo",IsAdmin=false}
        };
        public static List<Eroe> Eroe = new List<Eroe>()
        {
            new Eroe(){ Id = 1, Nome="Eroe1", PuntiAccumulati=120,IdArma=1,Categoria=CategoriaEroe.Guerriero,IdUtente=1},
            new Eroe(){ Id = 1, Nome="Eroe1", PuntiAccumulati=30,IdArma=5,Categoria=CategoriaEroe.Guerriero,IdUtente=2},
            new Eroe(){ Id = 1, Nome="Eroe1", PuntiAccumulati=160,IdArma=8,Categoria=CategoriaEroe.Guerriero,IdUtente=1},
            new Eroe(){ Id = 1, Nome="Eroe1", PuntiAccumulati=65,IdArma=9,Categoria=CategoriaEroe.Mago,IdUtente=2},
        };
        public static List<Mostro> Mostri = new List<Mostro>()
        {
            new Mostro(){Nome="Mostro1",Livello=1,IdArma=11,Categoria=CategoriaMostro.Cultista},
            new Mostro(){Nome="Mostro1",Livello=2,IdArma=12,Categoria=CategoriaMostro.Cultista},
            new Mostro(){Nome="Mostro1",Livello=3,IdArma=15,Categoria=CategoriaMostro.Orco},
            new Mostro(){Nome="Mostro1",Livello=4,IdArma=18,Categoria=CategoriaMostro.Orco},
            new Mostro(){Nome="Mostro1",Livello=5,IdArma=24,Categoria=CategoriaMostro.SignoreDelMale}
        };
        public static List<Arma> Armi = new List<Arma> {
            new Arma(){NomeArma="Alabarda", Danno=15,CategoriaArma=TipoArma.ArmaGuerriero},
            new Arma(){NomeArma="Ascia", Danno=8,CategoriaArma=TipoArma.ArmaGuerriero},
            new Arma(){NomeArma="Mazza", Danno=5,CategoriaArma=TipoArma.ArmaGuerriero},
            new Arma(){NomeArma="Spada", Danno=10,CategoriaArma=TipoArma.ArmaGuerriero},
            new Arma(){NomeArma="Spadone", Danno=15,CategoriaArma=TipoArma.ArmaGuerriero},
            new Arma(){NomeArma="Arco e Frecce", Danno=8,CategoriaArma=TipoArma.ArmaMago},
            new Arma(){NomeArma="Bacchetta", Danno=5,CategoriaArma=TipoArma.ArmaMago},
            new Arma(){NomeArma="Bastone magico", Danno=10,CategoriaArma=TipoArma.ArmaMago},
            new Arma(){NomeArma="Onda d'urto", Danno=15,CategoriaArma=TipoArma.ArmaMago},
            new Arma(){NomeArma="Pugnale", Danno=5,CategoriaArma=TipoArma.ArmaMago},
            new Arma(){NomeArma="Discorso noioso", Danno=4,CategoriaArma=TipoArma.ArmaCultista},
            new Arma(){NomeArma="Farneticazione", Danno=7,CategoriaArma=TipoArma.ArmaCultista},
            new Arma(){NomeArma="Imprecazione", Danno=5,CategoriaArma=TipoArma.ArmaCultista},
            new Arma(){NomeArma="Magie nera", Danno=3,CategoriaArma=TipoArma.ArmaCultista},
            new Arma(){NomeArma="Arco", Danno=7,CategoriaArma=TipoArma.ArmaOrco},
            new Arma(){NomeArma="Clava", Danno=5,CategoriaArma=TipoArma.ArmaOrco},
            new Arma(){NomeArma="Spada rotta", Danno=3,CategoriaArma=TipoArma.ArmaOrco},
            new Arma(){NomeArma="Mazza chiodata", Danno=10,CategoriaArma=TipoArma.ArmaOrco},
            new Arma(){NomeArma="Alabarda del drago", Danno=30,CategoriaArma=TipoArma.ArmaSignoreDelMale},
            new Arma(){NomeArma="Divinazione", Danno=15,CategoriaArma=TipoArma.ArmaSignoreDelMale},
            new Arma(){NomeArma="Fulmine", Danno=10,CategoriaArma=TipoArma.ArmaSignoreDelMale},
            new Arma(){NomeArma="Fulmine Celeste", Danno=15,CategoriaArma=TipoArma.ArmaSignoreDelMale},
            new Arma(){NomeArma="Tempesta", Danno=8,CategoriaArma=TipoArma.ArmaSignoreDelMale},
            new Arma(){NomeArma="Tempesta oscura", Danno=15,CategoriaArma=TipoArma.ArmaSignoreDelMale}
        };
    }
}
