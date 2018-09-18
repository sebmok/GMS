namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Languages
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Languages()
        {
            CountryLanguages = new HashSet<CountryLanguages>();
        }

        [Key]
        public int IdLanguage { get; set; }

        public string Family { get; set; }

        public string LanguageName { get; set; }

        public string NativeName { get; set; }

        public string s639_1 { get; set; }

        public string s639_2 { get; set; }

        public DateTime CreatedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CountryLanguages> CountryLanguages { get; set; }
    }
}
