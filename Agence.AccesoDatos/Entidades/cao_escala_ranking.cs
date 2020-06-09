namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_escala_ranking")]
    public partial class cao_escala_ranking
    {
        [Key]
        public short idescala { get; set; }

        public short qtd_visual { get; set; }

        public int pontuacao { get; set; }
    }
}
