namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CountryLanguages
    {
        [Key]
        public int IdCountryLanguage { get; set; }

        public int CountryId { get; set; }

        public int LanguageId { get; set; }

        public virtual Countries Countries { get; set; }

        public virtual Languages Languages { get; set; }
    }
}
