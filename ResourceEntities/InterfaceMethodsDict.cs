namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InterfaceMethodsDict")]
    public partial class InterfaceMethodsDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InterfaceMethodsDict()
        {
            InterfaceStruArrConf = new HashSet<InterfaceStruArrConf>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(70)]
        public string MethodName { get; set; }

        public int ProviderId { get; set; }

        public bool? IsRequest { get; set; }

        public bool? IsResponse { get; set; }

        public bool? IsCommit { get; set; }

        public int? MethodUrlId { get; set; }

        public bool? IsComplete { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual InterfaceUrlDict InterfaceUrlDict { get; set; }

        public virtual ProvidersDict ProvidersDict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterfaceStruArrConf> InterfaceStruArrConf { get; set; }
    }
}
