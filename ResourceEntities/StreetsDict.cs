namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StreetsDict")]
    public partial class StreetsDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StreetsDict()
        {
            PostCodesDict = new HashSet<PostCodesDict>();
        }

        public long Id { get; set; }

        public int CountryId { get; set; }

        public long? CityId { get; set; }

        [Required]
        [StringLength(450)]
        public string StreetName { get; set; }

        [Required]
        [StringLength(450)]
        public string PreviousSteetName { get; set; }

        public virtual CitiesDict CitiesDict { get; set; }

        public virtual Countries Countries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostCodesDict> PostCodesDict { get; set; }
    }
}
