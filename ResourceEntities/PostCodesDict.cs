namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostCodesDict")]
    public partial class PostCodesDict
    {
        public long Id { get; set; }

        public int CountryId { get; set; }

        public long CityId { get; set; }

        public long StreetId { get; set; }

        [Required]
        [StringLength(50)]
        public string BuildingNo { get; set; }

        [Required]
        [StringLength(100)]
        public string PostalCodeId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual CitiesDict CitiesDict { get; set; }

        public virtual Countries Countries { get; set; }

        public virtual StreetsDict StreetsDict { get; set; }
    }
}
