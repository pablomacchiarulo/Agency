namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_complemento")]
    public partial class cao_complemento
    {
        [Key]
        public long co_complemento { get; set; }

        public string ds_complemento { get; set; }
    }
}
