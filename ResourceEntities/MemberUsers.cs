namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberUsers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberUsers()
        {
            MemberUserNavConfigs = new HashSet<MemberUserNavConfigs>();
            MemberUserQuickMenus = new HashSet<MemberUserQuickMenus>();
            UserContractors = new HashSet<UserContractors>();
            SysImportMappingPosition = new HashSet<SysImportMappingPosition>();
            SysImportPositions = new HashSet<SysImportPositions>();
            SysImportTemplate = new HashSet<SysImportTemplate>();
        }

        [Key]
        public int IdMemberUser { get; set; }

        public int MemberId { get; set; }

        public int? CountryId { get; set; }

        public int UserId { get; set; }

        public Guid UserRefId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModDate { get; set; }

        public int? UserMod { get; set; }

        public bool? IsExternalUser { get; set; }

        public bool IsIpCheck { get; set; }

        public bool IsDefaultMember { get; set; }

        public int? SortOrder { get; set; }

        public bool? IsMemberDedicatedConfig { get; set; }

        public virtual MemberIds MemberIds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberUserNavConfigs> MemberUserNavConfigs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberUserQuickMenus> MemberUserQuickMenus { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserContractors> UserContractors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysImportMappingPosition> SysImportMappingPosition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysImportPositions> SysImportPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SysImportTemplate> SysImportTemplate { get; set; }
    }
}
