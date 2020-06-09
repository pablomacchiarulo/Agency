using Agence.AccesoDatos;
using Agence.AccesoDatos.Contratos;
using Agence.LogicaNegocio.Contratos;
using Agence.LogicaNegocio.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence.LogicaNegocio
{
    public class GananciaLogica : IGananciaLogica
    {
        private IUnitOfWork _IUnitOfWork;
        public GananciaLogica(IUnitOfWork iUnitOfWork)
        {
            _IUnitOfWork = iUnitOfWork;
        }

        /// <summary>
        /// Obtener una lista de consultores.
        /// </summary>
        /// <returns>Devuelve la lista de consultores</returns>
        public IList<ConsultorDto> ObtenerConsultores()
        {
            var listConsultores = from usuarios in _IUnitOfWork.Usuarios.GetAll()
                                  join permisos in _IUnitOfWork.PermisosSistemas.GetAll() on usuarios.co_usuario equals permisos.co_usuario
                                  where permisos.co_sistema == 1
                                  && permisos.in_ativo == "S"
                                  && (permisos.co_tipo_usuario == 0
                                  || permisos.co_tipo_usuario == 1
                                  || permisos.co_tipo_usuario == 2)
                                  select new ConsultorDto
                                  {
                                      co_usuario = usuarios.co_usuario,
                                      no_usuario = usuarios.no_usuario,
                                      ds_senha = usuarios.ds_senha,
                                      co_usuario_autorizacao = usuarios.co_usuario_autorizacao,
                                      nu_matricula = usuarios.nu_matricula
                                  };
            return listConsultores.ToList();
        }

        /// <summary>
        /// Obtener el nombre del consultor.
        /// </summary>
        /// <returns>Devuelve el nombre del consultor</returns>
        public string ObtenerNombreConsulto(string co_usuario)
        {
            return _IUnitOfWork.Usuarios.Find(s => s.co_usuario == co_usuario).FirstOrDefault().no_usuario;
        }

        /// <summary>
        /// Calcular receita liquida por mes y consultor.
        /// </summary>
        /// <returns>Devuelve la receita liquida por mes y consultor</returns>
        public double CalcularReceitaLiquidaPorMes(DateTime mesActual, string co_usuario)
        {
            
            DateTime mesHasta = mesActual.AddMonths(1);
            var listConsultores = from facturas in _IUnitOfWork.Facturas.GetAll()
                                  join ordenServicio in _IUnitOfWork.OrdenServicios.GetAll() on facturas.co_os equals ordenServicio.co_os
                                  where ordenServicio.co_usuario == co_usuario
                                  && facturas.data_emissao >= mesActual && facturas.data_emissao < mesHasta
                                  select new 
                                  {
                                      Valor = facturas.valor,
                                      Total_imp = facturas.total_imp_inc
                                  };
            int totalCount = listConsultores.Count();
            double valor = listConsultores.ToList().Sum(v => v.Valor);
            double total_imp = listConsultores.ToList().Sum(v => v.Total_imp);

            double result = 0;
            if (totalCount > 0)
                result = valor - (valor * ((total_imp / totalCount) / 100));

            return result;
        }

        /// <summary>
        /// Calcular Comissao por mes y consultor.
        /// </summary>
        /// <returns>Devuelve la Comissao por mes y consultor</returns>
        public double CalcularComissaoPorMes(DateTime mesActual, string co_usuario)
        {

            DateTime mesHasta = mesActual.AddMonths(1);
            var listConsultores = from facturas in _IUnitOfWork.Facturas.GetAll()
                                  join ordenServicio in _IUnitOfWork.OrdenServicios.GetAll() on facturas.co_os equals ordenServicio.co_os
                                  where ordenServicio.co_usuario == co_usuario
                                  && facturas.data_emissao >= mesActual && facturas.data_emissao < mesHasta
                                  select new
                                  {
                                      Valor = facturas.valor,
                                      Total_imp = facturas.total_imp_inc,
                                      Comissao = facturas.comissao_cn
                                  };
            int totalCount = listConsultores.Count();
            double valor = listConsultores.ToList().Sum(v => v.Valor);
            double total_imp = listConsultores.ToList().Sum(v => v.Total_imp);
            double comissao = listConsultores.ToList().Sum(v => v.Comissao);

            double result = 0;
            if (totalCount > 0)
                result = (valor - (valor * ((total_imp / totalCount) / 100))) * ((comissao / totalCount) / 100);

            return result;
        }

        /// <summary>
        /// Calcular Custo Fixo por mes y consultor.
        /// </summary>
        /// <returns>Devuelve la Custo Fixo por mes y consultor</returns>
        public double CalcularCustoFixo(string co_usuario)
        {
            double result = 0;
            var custoFico = _IUnitOfWork.Salarios.Find(s => s.co_usuario == co_usuario).FirstOrDefault();

            if(custoFico != null)
                result = custoFico.brut_salario;

            return result;
        }

    }
}
