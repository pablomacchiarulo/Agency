using Agence.AccesoDatos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence.AccesoDatos.Repositorio
{
    public class FacturaRepositorio : Repositorio<cao_fatura>, IFacturaRepositorio
    {
        public FacturaRepositorio(AgenceDBContext context) : base(context)
        {

        }
    }
}
