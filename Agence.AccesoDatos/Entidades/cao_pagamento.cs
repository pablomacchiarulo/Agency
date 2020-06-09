namespace Agence.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bd_agence.cao_pagamento")]
    public partial class cao_pagamento
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal co_pagamento { get; set; }

        [Required]
        [StringLength(20)]
        public string co_usuario { get; set; }

        [Required]
        [StringLength(2)]
        public string tp_pagamento { get; set; }

        [Column(TypeName = "date")]
        public DateTime dt_pagamento { get; set; }

        public float vl_pagamento { get; set; }

        [Column(TypeName = "date")]
        public DateTime dt_referencia_pagamento { get; set; }
    }
}
