namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContractorTypesDict")]
    public partial class ContractorTypesDict
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string ContractorTypeName { get; set; }
    }
}
