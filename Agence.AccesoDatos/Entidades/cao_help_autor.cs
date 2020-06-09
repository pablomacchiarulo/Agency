namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_help_autor")]
    public partial class cao_help_autor
    {
        [Key]
        public int co_autor { get; set; }

        [Required]
        [StringLength(80)]
        public string no_autor { get; set; }

        public int co_filial { get; set; }

        [StringLength(4)]
        public string nu_ddd1 { get; set; }

        [StringLength(15)]
        public string nu_tel1 { get; set; }

        [StringLength(6)]
        public string nu_ramal1 { get; set; }

        [StringLength(4)]
        public string nu_ddd2 { get; set; }

        [StringLength(15)]
        public string nu_tel2 { get; set; }

        [StringLength(6)]
        public string nu_ramal2 { get; set; }

        [StringLength(50)]
        public string ds_email { get; set; }

        [Required]
        [StringLength(100)]
        public string ds_funcao { get; set; }
    }
}
