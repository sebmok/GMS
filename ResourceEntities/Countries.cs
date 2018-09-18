namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Countries
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Countries()
        {
            aboServiceDefaultPricesDict = new HashSet<aboServiceDefaultPricesDict>();
            BankCountry = new HashSet<BankCountry>();
            CitiesDict = new HashSet<CitiesDict>();
            CountryCurrencies = new HashSet<CountryCurrencies>();
            CountryLanguages = new HashSet<CountryLanguages>();
            IdentityTypeDict = new HashSet<IdentityTypeDict>();
            PostCodesDict = new HashSet<PostCodesDict>();
            ProvincesDict = new HashSet<ProvincesDict>();
            StreetsDict = new HashSet<StreetsDict>();
        }

        [Key]
        public int IdCountry { get; set; }

        [Required]
        [StringLength(300)]
        public string CountryName { get; set; }

        [Required]
        [StringLength(5)]
        public string ISO3166_1 { get; set; }

        public DateTime CreatedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aboServiceDefaultPricesDict> aboServiceDefaultPricesDict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BankCountry> BankCountry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CitiesDict> CitiesDict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CountryCurrencies> CountryCurrencies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CountryLanguages> CountryLanguages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IdentityTypeDict> IdentityTypeDict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostCodesDict> PostCodesDict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProvincesDict> ProvincesDict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StreetsDict> StreetsDict { get; set; }
    }
}
