namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormFieldsClassesDict")]
    public partial class FormFieldsClassesDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FormFieldsClassesDict()
        {
            FormDefaultConfig = new HashSet<FormDefaultConfig>();
        }

        public short Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassName { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBootstrapClass { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormDefaultConfig> FormDefaultConfig { get; set; }
    }
}
