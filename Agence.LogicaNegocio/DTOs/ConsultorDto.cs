using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence.LogicaNegocio.DTOs
{
    public class ConsultorDto
    {
        public string co_usuario { get; set; }

        public string no_usuario { get; set; }

        public string ds_senha { get; set; }

        public string co_usuario_autorizacao { get; set; }

        public decimal? nu_matricula { get; set; }
    }
}
