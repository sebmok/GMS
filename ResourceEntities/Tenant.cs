namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tenant")]
    public partial class Tenant
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string DomainName { get; set; }

        public bool Default { get; set; }

        public string DataServerIP { get; set; }

        public string DataServerHttpAddress { get; set; }

        public string DataServerAccessInfo { get; set; }
    }
}
