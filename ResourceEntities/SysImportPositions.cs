namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SysImportPositions
    {
        public int Id { get; set; }

        public int OwnerMemberId { get; set; }

        [Required]
        [StringLength(100)]
        public string SourceColumnName { get; set; }

        [Required]
        [StringLength(100)]
        public string DestinationColumnName { get; set; }

        [StringLength(100)]
        public string DestinationTableName { get; set; }

        public int TemplateId { get; set; }

        public int insUser { get; set; }

        public DateTime? insDate { get; set; }

        public bool IsDeleted { get; set; }

        public virtual MemberUsers MemberUsers { get; set; }

        public virtual SysImportTemplate SysImportTemplate { get; set; }
    }
}
