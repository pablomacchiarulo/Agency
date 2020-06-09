namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_pontos_conhecimento")]
    public partial class cao_pontos_conhecimento
    {
        [Key]
        public int idpontos { get; set; }

        public short pontuacao { get; set; }

        [Required]
        [StringLength(50)]
        public string co_coordenador { get; set; }

        public int idconhecimento { get; set; }
    }
}
