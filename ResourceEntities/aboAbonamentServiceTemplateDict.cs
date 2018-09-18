namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("aboAbonamentServiceTemplateDict")]
    public partial class aboAbonamentServiceTemplateDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public aboAbonamentServiceTemplateDict()
        {
            aboAbonamentServicesDedicated = new HashSet<aboAbonamentServicesDedicated>();
            aboAbonamentServicesDefault = new HashSet<aboAbonamentServicesDefault>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TemplateName { get; set; }

        public bool? IsFreeOfCharge { get; set; }

        public int? MemberId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aboAbonamentServicesDedicated> aboAbonamentServicesDedicated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aboAbonamentServicesDefault> aboAbonamentServicesDefault { get; set; }
    }
}
