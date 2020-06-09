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
            DateTime fechaInicial = Convert.ToDateTime("01-" + fr.MesDesde.ToString() + "-" + fr.AnoDesde.ToString());
            DateTime fechaFinal = Convert.ToDateTime("01-" + fr.MesHasta.ToString() + "-" + fr.AnoHasta.ToString());
            PerformanceComercialResultViewModel resultViewModel = new PerformanceComercialResultViewModel();
            if (fr.SelectedConsultorIds != null && fechaInicial <= fechaFinal)
            {              
                resultViewModel.ListRelatorio = new List<RelatorioViewModel>();
                foreach (string consultor in fr.SelectedConsultorIds)
                {
                    int diferenciaMeses = Common.MonthDifference(fechaFinal, fechaInicial);
                    RelatorioViewModel relatorioViewModel = new RelatorioViewModel();
                    relatorioViewModel.ListGanancia = new List<GananciaViewModel>();
                    relatorioViewModel.Consultor = _gananciaLogica.ObtenerNombreConsulto(consultor);
                    var i = 0;
                    while (i < diferenciaMeses)
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

            DateTime fechaInicial = Convert.ToDateTime("01-" + fr.MesDesde.ToString() + "-" + fr.AnoDesde.ToString());
            DateTime fechaFinal = Convert.ToDateTime("01-" + fr.MesHasta.ToString() + "-" + fr.AnoHasta.ToString());
            if (fr.SelectedConsultorIds != null && fechaInicial <= fechaFinal)
            {
                foreach (string consultor in fr.SelectedConsultorIds)
                {

                    int diferenciaMeses = Common.MonthDifference(fechaFinal, fechaInicial);
                    PizzaViewModel pizzaViewModel = new PizzaViewModel();
                    RelatorioViewModel relatorioViewModel = new RelatorioViewModel();
                    relatorioViewModel.ListGanancia = new List<GananciaViewModel>();
                    pizzaViewModel.Consultor = _gananciaLogica.ObtenerNombreConsulto(consultor);
                    var i = 0;
                    while (i < diferenciaMeses)
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
        public JsonResult BarGrafico(PerformanceComercialViewModel fr)
        {
            List<GraficoViewModel> resultViewModel = new List<GraficoViewModel>();
            DateTime fechaInicial = Convert.ToDateTime("01-" + fr.MesDesde.ToString() + "-" + fr.AnoDesde.ToString());
            DateTime fechaFinal = Convert.ToDateTime("01-" + fr.MesHasta.ToString() + "-" + fr.AnoHasta.ToString());
            if (fr.SelectedConsultorIds != null && fechaInicial <= fechaFinal)
            {
                foreach (string consultor in fr.SelectedConsultorIds)
                {


                    int diferenciaMeses = Common.MonthDifference(fechaFinal, fechaInicial);

                    RelatorioViewModel relatorioViewModel = new RelatorioViewModel();
                    var consultorName = _gananciaLogica.ObtenerNombreConsulto(consultor);
                    var i = 0;
                    while (i < diferenciaMeses)
                    {
                        GraficoViewModel graficoViewModel = new GraficoViewModel();
                        DateTimeFormatInfo mfi = new DateTimeFormatInfo();
                        string strMonthName = mfi.GetMonthName(fechaInicial.AddMonths(i).Month).ToString();
                        GananciaViewModel gananciaViewModel = new GananciaViewModel();
                        graficoViewModel.Consultor = consultorName;
                        graficoViewModel.Periodo = strMonthName + " del " + fechaInicial.AddMonths(i).Year.ToString();
                        graficoViewModel.ReceitaLiquida = _gananciaLogica.CalcularReceitaLiquidaPorMes(fechaInicial.AddMonths(i), consultor);
                        if (graficoViewModel.ReceitaLiquida != 0)
                            resultViewModel.Add(graficoViewModel);

                        i++;
                    }
                }
            }
            return Json(resultViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}