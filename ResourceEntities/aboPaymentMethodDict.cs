namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("aboPaymentMethodDict")]
    public partial class aboPaymentMethodDict
    {
        public short Id { get; set; }

        [StringLength(100)]
        public string PaymentMethodName { get; set; }
    }
}
