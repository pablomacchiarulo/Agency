using Agence.LogicaNegocio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence.LogicaNegocio.Contratos
{
    public interface IGananciaLogica
    {
        /// <summary>
        /// Obtener una lista de consultores.
        /// </summary>
        /// <returns>Devuelve la lista de consultores</returns>
        IList<ConsultorDto> ObtenerConsultores();

        /// <summary>
        /// Obtener el nombre del consultor.
        /// </summary>
        /// <returns>Devuelve el nombre del consultor</returns>
        string ObtenerNombreConsulto(string co_usuario);

        /// <summary>
        /// Calcular receita liquida por mes y consultor.
        /// </summary>
        /// <returns>Devuelve la receita liquida por mes y consultor</returns>
        double CalcularReceitaLiquidaPorMes(DateTime mesActual, string co_usuario);

        /// <summary>
        /// Calcular Comissao por mes y consultor.
        /// </summary>
        /// <returns>Devuelve la Comissao por mes y consultor</returns>
        double CalcularComissaoPorMes(DateTime mesActual, string co_usuario);

        /// <summary>
        /// Calcular Custo Fixo por mes y consultor.
        /// </summary>
        /// <returns>Devuelve la Custo Fixo por mes y consultor</returns>
        double CalcularCustoFixo(string co_usuario);
    }
}
