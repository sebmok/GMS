namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProvidersDict")]
    public partial class ProvidersDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProvidersDict()
        {
            InterfaceMethodsDict = new HashSet<InterfaceMethodsDict>();
            UserLoginProvider = new HashSet<UserLoginProvider>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(450)]
        public string ProviderName { get; set; }

        public int ProviderCountry { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsIntegrated { get; set; }

        public bool? IsSessionAccess { get; set; }

        public bool? IsTokenAccess { get; set; }

        public bool? IsTwoFactorAccess { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterfaceMethodsDict> InterfaceMethodsDict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLoginProvider> UserLoginProvider { get; set; }
    }
}
