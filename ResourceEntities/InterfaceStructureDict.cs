namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InterfaceStructureDict")]
    public partial class InterfaceStructureDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InterfaceStructureDict()
        {
            InterfaceStruArrConf = new HashSet<InterfaceStruArrConf>();
            InterfaceStructureDict1 = new HashSet<InterfaceStructureDict>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string StructureName { get; set; }

        public int? ParentId { get; set; }

        public int? SortOrderr { get; set; }

        public bool? IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterfaceStruArrConf> InterfaceStruArrConf { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterfaceStructureDict> InterfaceStructureDict1 { get; set; }

        public virtual InterfaceStructureDict InterfaceStructureDict2 { get; set; }
    }
}
