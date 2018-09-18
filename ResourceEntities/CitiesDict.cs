namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CitiesDict")]
    public partial class CitiesDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CitiesDict()
        {
            PostCodesDict = new HashSet<PostCodesDict>();
            StreetsDict = new HashSet<StreetsDict>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(450)]
        public string CityName { get; set; }

        public int CountryId { get; set; }

        public virtual Countries Countries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostCodesDict> PostCodesDict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StreetsDict> StreetsDict { get; set; }
    }
}
