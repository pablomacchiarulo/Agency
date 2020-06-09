namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_hist_ocorrencias_os")]
    public partial class cao_hist_ocorrencias_os
    {
        [Key]
        public int idocorrencia { get; set; }

        public int? co_os { get; set; }

        [StringLength(20)]
        public string co_usuario { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? data { get; set; }

        [Required]
        [StringLength(7)]
        public string tipo { get; set; }

        [Required]
        public string descricao { get; set; }

        [Required]
        [StringLength(50)]
        public string responsavel { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? data_fechamento { get; set; }
    }
}
