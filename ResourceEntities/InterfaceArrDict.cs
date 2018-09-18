namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InterfaceArrDict")]
    public partial class InterfaceArrDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InterfaceArrDict()
        {
            InterfaceArrDict1 = new HashSet<InterfaceArrDict>();
            InterfaceStruArrConf = new HashSet<InterfaceStruArrConf>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string ArrName { get; set; }

        public int? ParentId { get; set; }

        public int? SortOrder { get; set; }

        public bool? isDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterfaceArrDict> InterfaceArrDict1 { get; set; }

        public virtual InterfaceArrDict InterfaceArrDict2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterfaceStruArrConf> InterfaceStruArrConf { get; set; }
    }
}
