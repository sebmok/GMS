namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IdentityTypeDict")]
    public partial class IdentityTypeDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IdentityTypeDict()
        {
            IdentitiesDict = new HashSet<IdentitiesDict>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string IdentityTypeName { get; set; }

        public int CountryId { get; set; }

        public virtual Countries Countries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IdentitiesDict> IdentitiesDict { get; set; }
    }
}
