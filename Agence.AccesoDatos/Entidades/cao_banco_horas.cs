namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_banco_horas")]
    public partial class cao_banco_horas
    {
        [Key]
        public long co_banc_horas { get; set; }

        [Required]
        [StringLength(20)]
        public string co_usuario { get; set; }

        [Required]
        [StringLength(7)]
        public string periodo { get; set; }

        public int min_mes { get; set; }

        public int min_ferias { get; set; }

        public int min_pago { get; set; }

        public int min_total { get; set; }
    }
}
