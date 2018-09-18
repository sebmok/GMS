namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("aboServicesDict")]
    public partial class aboServicesDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public aboServicesDict()
        {
            aboAbonamentServicesDedicated = new HashSet<aboAbonamentServicesDedicated>();
            aboAbonamentServicesDefault = new HashSet<aboAbonamentServicesDefault>();
            aboServiceDefaultPricesDict = new HashSet<aboServiceDefaultPricesDict>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsPublicFree { get; set; }

        public bool? IsConfigAvailable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aboAbonamentServicesDedicated> aboAbonamentServicesDedicated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aboAbonamentServicesDefault> aboAbonamentServicesDefault { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aboServiceDefaultPricesDict> aboServiceDefaultPricesDict { get; set; }
    }
}
