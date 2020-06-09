using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agence.Web.Models
{
    public class GananciaViewModel
    {
        public string Periodo { get; set; }

        public double ReceitaLiquida { get; set; }

        public double CustoFixo { get; set; }

        public double Comissao { get; set; }

        public double Lucro { get; set; }
    }
}