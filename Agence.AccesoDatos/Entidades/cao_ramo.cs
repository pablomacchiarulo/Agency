namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_ramo")]
    public partial class cao_ramo
    {
        [Key]
        public long co_ramo { get; set; }

        [Required]
        [StringLength(60)]
        public string ds_ramo { get; set; }
    }
}
