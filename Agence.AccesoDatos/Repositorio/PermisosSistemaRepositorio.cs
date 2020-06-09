using Agence.AccesoDatos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence.AccesoDatos.Repositorio
{
    public class PermisosSistemaRepositorio : Repositorio<permissao_sistema>, IPermisosSistemaRepositorio
    {
        public PermisosSistemaRepositorio(AgenceDBContext context) : base(context)
        {

        }
    }
}
