using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agence.Web.Models
{
    public class PerformanceComercialViewModel
    {
        public MultiSelectList AllConsultor { get; set; }
        public List<string> SelectedConsultorIds { get; set; }

        [DisplayName("Desde: ")]
        public int? MesDesde { get; set; }

        public int? AnoDesde { get; set; }

        [DisplayName("Hasta: ")]
        public int? MesHasta { get; set; }

        public int? AnoHasta { get; set; }

        public SelectList Anos { get; set; }

        public SelectList Meses { get; set; }
    }

    public class PerformanceComercialResultViewModel
    {
        public IList<RelatorioViewModel> ListRelatorio { get; set; }
    }
}