using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agence.Web.Models
{
    public class RelatorioViewModel
    {
        public string Consultor { get; set; }

        public IList<GananciaViewModel> ListGanancia { get; set; }
    }
}