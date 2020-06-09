using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence.AccesoDatos.Contratos
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepositorio Usuarios { get; }
        IPermisosSistemaRepositorio PermisosSistemas { get; }
        IFacturaRepositorio Facturas { get; }
        IOrdenServicioRepositorio OrdenServicios { get; }
        ISalarioRepositorio Salarios { get; }

        int Complete();

    }
}
