namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormFieldsGlobalNameDict")]
    public partial class FormFieldsGlobalNameDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FormFieldsGlobalNameDict()
        {
            FormDefaultConfig = new HashSet<FormDefaultConfig>();
        }

        public int Id { get; set; }

        public bool IsPayed { get; set; }

        public bool IsDedicated { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string PL { get; set; }

        public string DE { get; set; }

        public string ENG { get; set; }

        public string NO { get; set; }

        public string FIN { get; set; }

        public string DK { get; set; }

        public string RUS { get; set; }

        public string CZK { get; set; }

        public string SLK { get; set; }

        public string FR { get; set; }

        public string IT { get; set; }

        public string ESP { get; set; }

        public string SWE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormDefaultConfig> FormDefaultConfig { get; set; }
    }
}
