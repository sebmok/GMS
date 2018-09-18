namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("aboPaymentTerminDict")]
    public partial class aboPaymentTerminDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public aboPaymentTerminDict()
        {
            aboServiceDefaultPricesDict = new HashSet<aboServiceDefaultPricesDict>();
        }

        public short Id { get; set; }

        [StringLength(50)]
        public string TerminName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aboServiceDefaultPricesDict> aboServiceDefaultPricesDict { get; set; }
    }
}
