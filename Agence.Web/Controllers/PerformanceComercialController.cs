using Agence.LogicaNegocio.Contratos;
using Agence.Web.Helpers;
using Agence.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agence.Web.Controllers
{
    public class PerformanceComercialController : Controller
    {
        private readonly IGananciaLogica _gananciaLogica;

        public PerformanceComercialController(IGananciaLogica gananciaLogica)
        {
            _gananciaLogica = gananciaLogica;
        }

        public ActionResult Index()
        {
            var viewModel = new PerformanceComercialViewModel();
            viewModel.AllConsultor = new MultiSelectList(_gananciaLogica.ObtenerConsultores(), "co_usuario", "no_usuario", new List<string>());
            viewModel.SelectedConsultorIds = new List<string>();
            viewModel.Meses = Common.GetMonthsSelectList();
            viewModel.Anos = Common.GetYearsSelectList();
            return View(viewModel);
        }

        public ActionResult SearchData(PerformanceComercialViewModel fr)
        {
            DateTime fechaInicial = Convert.ToDateTime(fr.MesDesde.ToString() + "-" + "01-" +  fr.AnoDesde.ToString(), CultureInfo.InvariantCulture);
            DateTime fechaFinal = Convert.ToDateTime(fr.MesHasta.ToString() + "-" + "01-" + fr.AnoHasta.ToString(), CultureInfo.InvariantCulture);
            PerformanceComercialResultViewModel resultViewModel = new PerformanceComercialResultViewModel();
            if (fr.SelectedConsultorIds != null && fechaInicial <= fechaFinal)
            {              
                resultViewModel.ListRelatorio = new List<RelatorioViewModel>();
                int diferenciaMeses = Common.MonthDifference(fechaFinal, fechaInicial);
                foreach (string consultor in fr.SelectedConsultorIds)
                {              
                    RelatorioViewModel relatorioViewModel = new RelatorioViewModel();
                    relatorioViewModel.ListGanancia = new List<GananciaViewModel>();
                    relatorioViewModel.Consultor = _gananciaLogica.ObtenerNombreConsulto(consultor);
                    var i = 0;
                    while (i <= diferenciaMeses)
                    {
                        DateTimeFormatInfo mfi = new DateTimeFormatInfo();
                        string strMonthName = mfi.GetMonthName(fechaInicial.AddMonths(i).Month).ToString();
                        GananciaViewModel gananciaViewModel = new GananciaViewModel();
                        gananciaViewModel.Periodo = strMonthName + " del " + fechaInicial.AddMonths(i).Year.ToString();
                        gananciaViewModel.ReceitaLiquida = _gananciaLogica.CalcularReceitaLiquidaPorMes(fechaInicial.AddMonths(i), consultor);
                        gananciaViewModel.CustoFixo = _gananciaLogica.CalcularCustoFixo(consultor);
                        gananciaViewModel.Comissao = _gananciaLogica.CalcularComissaoPorMes(fechaInicial.AddMonths(i), consultor);
                        gananciaViewModel.Lucro = gananciaViewModel.ReceitaLiquida - (gananciaViewModel.CustoFixo + gananciaViewModel.Comissao);
                        if (gananciaViewModel.ReceitaLiquida != 0)
                            relatorioViewModel.ListGanancia.Add(gananciaViewModel);

                        i++;
                    }
                    if (relatorioViewModel.ListGanancia.Count() > 0)
                        resultViewModel.ListRelatorio.Add(relatorioViewModel);
                }  
            }
            return PartialView("_Result", resultViewModel);
        }

        [HttpPost]
        public JsonResult PizzaGrafico(PerformanceComercialViewModel fr)
        {
            List<PizzaViewModel> resultViewModel = new List<PizzaViewModel>();

            DateTime fechaInicial = Convert.ToDateTime(fr.MesDesde.ToString() + "-" + "01-" + fr.AnoDesde.ToString(), CultureInfo.InvariantCulture);
            DateTime fechaFinal = Convert.ToDateTime(fr.MesHasta.ToString() + "-" + "01-" + fr.AnoHasta.ToString(), CultureInfo.InvariantCulture);
            if (fr.SelectedConsultorIds != null && fechaInicial <= fechaFinal)
            {
                int diferenciaMeses = Common.MonthDifference(fechaFinal, fechaInicial);
                foreach (string consultor in fr.SelectedConsultorIds)
                {
                    PizzaViewModel pizzaViewModel = new PizzaViewModel();
                    RelatorioViewModel relatorioViewModel = new RelatorioViewModel();
                    relatorioViewModel.ListGanancia = new List<GananciaViewModel>();
                    pizzaViewModel.Consultor = _gananciaLogica.ObtenerNombreConsulto(consultor);
                    var i = 0;
                    while (i <= diferenciaMeses)
                    {
                        DateTimeFormatInfo mfi = new DateTimeFormatInfo();
                        string strMonthName = mfi.GetMonthName(fechaInicial.AddMonths(i).Month).ToString();
                        GananciaViewModel gananciaViewModel = new GananciaViewModel();
                        gananciaViewModel.Periodo = strMonthName + " del " + fechaInicial.AddMonths(i).Year.ToString();
                        gananciaViewModel.ReceitaLiquida = _gananciaLogica.CalcularReceitaLiquidaPorMes(fechaInicial.AddMonths(i), consultor);
                        if (gananciaViewModel.ReceitaLiquida != 0)
                            relatorioViewModel.ListGanancia.Add(gananciaViewModel);

                        i++;
                    }

                    pizzaViewModel.Percentagem = int.Parse(Math.Round(relatorioViewModel.ListGanancia.Sum(g => g.ReceitaLiquida)).ToString());
                    resultViewModel.Add(pizzaViewModel);
                }
            }

            return Json(resultViewModel, JsonRequestBehavior.AllowGet);            
        }

        [HttpPost]
        public JsonResult ColumnGrafico(PerformanceComercialViewModel fr)
        {
            List<GraficoViewModel> resultViewModel = new List<GraficoViewModel>();
            DateTime fechaInicial = Convert.ToDateTime(fr.MesDesde.ToString() + "-" + "01-" + fr.AnoDesde.ToString(), CultureInfo.InvariantCulture);
            DateTime fechaFinal = Convert.ToDateTime(fr.MesHasta.ToString() + "-" + "01-" + fr.AnoHasta.ToString(), CultureInfo.InvariantCulture);
            int diferenciaMeses = Common.MonthDifference(fechaFinal, fechaInicial);
            if (fr.SelectedConsultorIds != null && fechaInicial <= fechaFinal)
            {
                var i = 0;
                while (i <= diferenciaMeses)
                {
                    GraficoViewModel graficoViewModel = new GraficoViewModel();
                    DateTimeFormatInfo mfi = new DateTimeFormatInfo();
                    string strMonthName = mfi.GetMonthName(fechaInicial.AddMonths(i).Month).ToString();
                    string periodo = strMonthName + " del " + fechaInicial.AddMonths(i).Year.ToString();
                    graficoViewModel.ListColumn = new List<ColumnChartViewModel>();
                    graficoViewModel.Consultores = new List<string>();
                    graficoViewModel.Periodo = periodo;
                    double totalReceitaLiquita = 0;
                    foreach (string consultor in fr.SelectedConsultorIds)
                    {
                        var consultorName = _gananciaLogica.ObtenerNombreConsulto(consultor);                      
                        ColumnChartViewModel gananciaViewModel = new ColumnChartViewModel();                       
                        gananciaViewModel.Consultor = consultorName;
                        graficoViewModel.Consultores.Add(consultorName);
                        gananciaViewModel.ReceitaLiquida = _gananciaLogica.CalcularReceitaLiquidaPorMes(fechaInicial.AddMonths(i), consultor);
                        totalReceitaLiquita = totalReceitaLiquita + gananciaViewModel.ReceitaLiquida;
                        graficoViewModel.ListColumn.Add(gananciaViewModel);                    
                    }
                    i++;
                    if(totalReceitaLiquita != 0)
                        resultViewModel.Add(graficoViewModel);
                }            
            }
            return Json(resultViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}