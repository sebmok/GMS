namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("aboServiceDefaultPricesDict")]
    public partial class aboServiceDefaultPricesDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public aboServiceDefaultPricesDict()
        {
            aboAbonamentServicesDefault = new HashSet<aboAbonamentServicesDefault>();
        }

        public int Id { get; set; }

        public int aboServicesDictId { get; set; }

        public decimal DefaultPrice { get; set; }

        public int Currency { get; set; }

        public int? CountryId { get; set; }

        public DateTime insDate { get; set; }

        public short? PaymentMethodId { get; set; }

        public short PaymentTerminDictId { get; set; }

        public int? DefaultTemplateId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aboAbonamentServicesDefault> aboAbonamentServicesDefault { get; set; }

        public virtual aboPaymentTerminDict aboPaymentTerminDict { get; set; }

        public virtual aboServicesDict aboServicesDict { get; set; }

        public virtual Countries Countries { get; set; }

        public virtual CurrencyDicts CurrencyDicts { get; set; }
    }
}
