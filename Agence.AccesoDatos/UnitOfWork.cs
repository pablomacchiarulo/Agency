using Agence.AccesoDatos.Contratos;
using Agence.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence.AccesoDatos
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AgenceDBContext _context;
        public UnitOfWork(AgenceDBContext context)
        {
            _context = context;

            Usuarios = new UsuarioRepositorio(_context);
            PermisosSistemas = new PermisosSistemaRepositorio(_context);
            Facturas = new FacturaRepositorio(_context);
            OrdenServicios = new OrdenServicioRepositorio(_context);
            Salarios = new SalarioRepositorio(_context);

        }

        public IUsuarioRepositorio Usuarios { get; private set; }
        public IPermisosSistemaRepositorio PermisosSistemas { get; private set; }
        public IFacturaRepositorio Facturas { get; private set; }
        public IOrdenServicioRepositorio OrdenServicios { get; private set; }
        public ISalarioRepositorio Salarios { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
