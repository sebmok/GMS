namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProvincesDict")]
    public partial class ProvincesDict
    {
        [Key]
        public int IdProvince { get; set; }

        public int? CountryId { get; set; }

        [StringLength(500)]
        public string ProvinceName { get; set; }

        public virtual Countries Countries { get; set; }
    }
}
