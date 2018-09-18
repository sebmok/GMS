namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("aboAbonamentServicesDefault")]
    public partial class aboAbonamentServicesDefault
    {
        public int Id { get; set; }

        public int aboAbonamentDictId { get; set; }

        public int aboServicesDictId { get; set; }

        public int? aboServiceDefaultPriceId { get; set; }

        public int? TemplateId { get; set; }

        public int? SystemConfigId { get; set; }

        public virtual aboAbonamentDict aboAbonamentDict { get; set; }

        public virtual aboAbonamentServiceTemplateDict aboAbonamentServiceTemplateDict { get; set; }

        public virtual aboServiceDefaultPricesDict aboServiceDefaultPricesDict { get; set; }

        public virtual aboServicesDict aboServicesDict { get; set; }
    }
}
