namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IdentitiesGlobalNameDict")]
    public partial class IdentitiesGlobalNameDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IdentitiesGlobalNameDict()
        {
            IdentitiesDict = new HashSet<IdentitiesDict>();
        }

        public int Id { get; set; }

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
        public virtual ICollection<IdentitiesDict> IdentitiesDict { get; set; }
    }
}
