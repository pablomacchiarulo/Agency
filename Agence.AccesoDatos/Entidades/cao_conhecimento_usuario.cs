namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_conhecimento_usuario")]
    public partial class cao_conhecimento_usuario
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string co_usuario { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long co_conhecimento { get; set; }

        public long? nv_conhecimento { get; set; }

        public byte? is_certificado { get; set; }
    }
}
