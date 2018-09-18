namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CountryCurrencies
    {
        [Key]
        public int IdCountryCurrency { get; set; }

        public int CountryId { get; set; }

        public int CurrencyId { get; set; }

        public short IsDefault { get; set; }

        public virtual Countries Countries { get; set; }
    }
}
