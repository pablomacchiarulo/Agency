using Agence.AccesoDatos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence.AccesoDatos.Repositorio
{
    public class OrdenServicioRepositorio : Repositorio<cao_os>, IOrdenServicioRepositorio
    {
        public OrdenServicioRepositorio(AgenceDBContext context) : base(context)
        {

        }
    }
}
