namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_os_status")]
    public partial class cao_os_status
    {
        [Key]
        public long co_status_atual { get; set; }

        [Required]
        [StringLength(50)]
        public string ds_status { get; set; }
    }
}
