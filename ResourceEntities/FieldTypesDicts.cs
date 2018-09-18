namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FieldTypesDicts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FieldTypesDicts()
        {
            FormDefaultConfig = new HashSet<FormDefaultConfig>();
        }

        [Key]
        public short IdFieldType { get; set; }

        [Required]
        [StringLength(30)]
        public string TypeName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public bool? IsDeleted { get; set; }

        public bool IsBootstrapType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormDefaultConfig> FormDefaultConfig { get; set; }
    }
}
