namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysImportTemplate")]
    public partial class SysImportTemplate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SysImportTemplate()
        {
            SysImportMappingPosition = new HashSet<SysImportMappingPosition>();
            SysImportPositions = new HashSet<SysImportPositions>();
        }

        public int Id { get; set; }

        public int? ImportDestinationType { get; set; }

        [Required]
        [StringLength(50)]
        public string TemplateName { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime? ActiveTo { get; set; }

        public int OwnerMemberId { get; set; }

        [StringLength(100)]
        public string SourceTable { get; set; }

        [StringLength(50)]
        public string DateFormat { get; set; }

        [StringLength(50)]
        public string TimeFormat { get; set; }

        [StringLength(1)]
        public string DecimalSeparator { get; set; }

        [StringLength(1)]
        public string ThousendSeparator { get; set; }

        [StringLength(200)]
        public string JetConnectString { get; set; }

        [StringLength(7)]
        public string FileExtension { get; set; }

        [StringLength(3)]
        public string Currency { get; set; }

        public bool FirstRowIsHeader { get; set; }

        public int? SkipRowBeforeHeader { get; set; }

        public int? SkipRowAfterHeader { get; set; }

        public int insUser { get; set; }

        public DateTime insDate { get; set; }

        public virtual MemberUsers MemberUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysImportMappingPosition> SysImportMappingPosition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysImportPositions> SysImportPositions { get; set; }
    }
}
