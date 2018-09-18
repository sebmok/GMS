namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysImportMappingPosition")]
    public partial class SysImportMappingPosition
    {
        public int Id { get; set; }

        public int OwnerMemberId { get; set; }

        [Required]
        [StringLength(100)]
        public string SourceServiceName { get; set; }

        [Required]
        [StringLength(25)]
        public string DestinationServiceName { get; set; }

        public int TemplateId { get; set; }

        public int insUser { get; set; }

        public DateTime insDate { get; set; }

        public virtual MemberUsers MemberUsers { get; set; }

        public virtual SysImportTemplate SysImportTemplate { get; set; }
    }
}
