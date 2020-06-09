namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_tipo_ombudsman")]
    public partial class cao_tipo_ombudsman
    {
        [Key]
        public short idtipo { get; set; }

        [Required]
        [StringLength(100)]
        public string descricao { get; set; }
    }
}
