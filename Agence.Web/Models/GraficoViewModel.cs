using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agence.Web.Models
{
    public class GraficoViewModel
    {
        public string Periodo { get; set; }

        public IList<string> Consultores { get; set; }

        public IList<ColumnChartViewModel> ListColumn { get; set; }
    }
}