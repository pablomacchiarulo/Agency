namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_conhecimentos_fontes")]
    public partial class cao_conhecimentos_fontes
    {
        [Key]
        public int idfonte { get; set; }

        public int idconhecimento { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime datahora { get; set; }

        [Required]
        [StringLength(50)]
        public string arquivo { get; set; }

        [Required]
        [StringLength(50)]
        public string caminho { get; set; }
    }
}
