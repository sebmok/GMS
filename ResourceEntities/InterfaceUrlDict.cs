namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InterfaceUrlDict")]
    public partial class InterfaceUrlDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InterfaceUrlDict()
        {
            InterfaceMethodsDict = new HashSet<InterfaceMethodsDict>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(450)]
        public string Url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterfaceMethodsDict> InterfaceMethodsDict { get; set; }
    }
}
