namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("aboAbonamentServicesDedicated")]
    public partial class aboAbonamentServicesDedicated
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int aboAbonamentDictId { get; set; }

        public int aboServicesDictId { get; set; }

        public decimal ServicePrice { get; set; }

        public int Currency { get; set; }

        public bool Monthly { get; set; }

        public bool Year { get; set; }

        public bool Day { get; set; }

        public bool PayedOnlyOnce { get; set; }

        public short PayedOnDayOfMonth { get; set; }

        public int TemplateId { get; set; }

        public virtual aboAbonamentDict aboAbonamentDict { get; set; }

        public virtual aboAbonamentServiceTemplateDict aboAbonamentServiceTemplateDict { get; set; }

        public virtual aboServicesDict aboServicesDict { get; set; }
    }
}
