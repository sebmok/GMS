namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FormConfigTemplates
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FormConfigTemplates()
        {
            FormDefaultConfig = new HashSet<FormDefaultConfig>();
        }

        public int Id { get; set; }

        public int? MemberId { get; set; }

        public bool IsDeleted { get; set; }

        public int TemplateNameId { get; set; }

        public int? SectorDedicated { get; set; }

        public bool IsDefault { get; set; }

        public bool IsPayed { get; set; }

        public int? MemberUserId { get; set; }

        public virtual FormConfigTemplatesGlobalNameDict FormConfigTemplatesGlobalNameDict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormDefaultConfig> FormDefaultConfig { get; set; }
    }
}
