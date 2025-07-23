using App.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applicacion.Interfaces
{
    public interface IPersoService
    {
        Task<IEnumerable<Perso>> GetAllAsync();
        Task<string> GenerarTxtAsync();
    }
}
