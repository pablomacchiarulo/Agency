namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_categorias_ombudsman")]
    public partial class cao_categorias_ombudsman
    {
        [Key]
        public short idcategoria { get; set; }

        [Required]
        [StringLength(100)]
        public string descricao { get; set; }
    }
}
