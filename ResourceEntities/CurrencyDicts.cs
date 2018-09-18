namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CurrencyDicts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CurrencyDicts()
        {
            aboServiceDefaultPricesDict = new HashSet<aboServiceDefaultPricesDict>();
            DataMemberBankAccounts = new HashSet<DataMemberBankAccounts>();
        }

        [Key]
        public int IdCurrency { get; set; }

        [Required]
        [StringLength(500)]
        public string CurrencyName { get; set; }

        [Required]
        [StringLength(5)]
        public string ISO4217 { get; set; }

        public DateTime CreatedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aboServiceDefaultPricesDict> aboServiceDefaultPricesDict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataMemberBankAccounts> DataMemberBankAccounts { get; set; }
    }
}
