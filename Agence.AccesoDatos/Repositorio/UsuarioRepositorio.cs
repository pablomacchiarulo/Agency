using Agence.AccesoDatos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence.AccesoDatos.Repositorio
{
    public class UsuarioRepositorio : Repositorio<cao_usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(AgenceDBContext context) : base(context)
        {

        }
    }
}
