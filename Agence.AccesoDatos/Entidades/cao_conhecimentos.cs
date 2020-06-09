namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_conhecimentos")]
    public partial class cao_conhecimentos
    {
        [Key]
        public int idconhecimento { get; set; }

        [Required]
        [StringLength(100)]
        public string assunto { get; set; }

        [Required]
        public string conhecimento { get; set; }

        [Required]
        [StringLength(255)]
        public string url { get; set; }

        [Required]
        public string tags { get; set; }

        [Required]
        [StringLength(20)]
        public string usuario { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime datahora { get; set; }
    }
}
