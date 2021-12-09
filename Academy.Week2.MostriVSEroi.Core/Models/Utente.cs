using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.MostriVSEroi.Core.Models
{
    public class Utente
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set;}
        public bool IsAdmin { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Nickname: {Nickname}";
        }
    }
}
