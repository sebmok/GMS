namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BankCountry")]
    public partial class BankCountry
    {
        public int Id { get; set; }

        public int BankDictId { get; set; }

        public int CountryId { get; set; }

        public virtual BankDict BankDict { get; set; }

        public virtual Countries Countries { get; set; }
    }
}
