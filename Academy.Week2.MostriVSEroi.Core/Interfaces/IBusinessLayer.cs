using Academy.Week2.MostriVSEroi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.MostriVSEroi.Core.Interfaces
{
    public interface IBusinessLayer
    {
        Utente Accedi(string? nickname, string? password);
        bool CheckNickname(string? nickname);
    }
}
