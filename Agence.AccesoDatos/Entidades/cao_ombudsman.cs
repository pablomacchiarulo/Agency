namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_ombudsman")]
    public partial class cao_ombudsman
    {
        public int id { get; set; }

        public short idtipo { get; set; }

        public short idcategoria { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime data { get; set; }

        [Required]
        public string comentario { get; set; }

        public short co_escritorio { get; set; }
    }
}
