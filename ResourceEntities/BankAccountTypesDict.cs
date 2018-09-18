namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BankAccountTypesDict")]
    public partial class BankAccountTypesDict
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string AccountTypeName { get; set; }
    }
}
