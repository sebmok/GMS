namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InterfaceParamsDict")]
    public partial class InterfaceParamsDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InterfaceParamsDict()
        {
            InterfaceStruArrConf = new HashSet<InterfaceStruArrConf>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ParamName { get; set; }

        public bool? IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterfaceStruArrConf> InterfaceStruArrConf { get; set; }
    }
}
