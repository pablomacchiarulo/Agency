using Agence.AccesoDatos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence.AccesoDatos.Repositorio
{
    public class SalarioRepositorio : Repositorio<cao_salario>, ISalarioRepositorio
    {
        public SalarioRepositorio(AgenceDBContext context) : base(context)
        {

        }
    }
}
