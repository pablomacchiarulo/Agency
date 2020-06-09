namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_valor_descanso")]
    public partial class cao_valor_descanso
    {
        public int id { get; set; }

        [Required]
        [StringLength(40)]
        public string co_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string segundos { get; set; }

        [Required]
        [StringLength(50)]
        public string mes_referencia { get; set; }
    }
}
