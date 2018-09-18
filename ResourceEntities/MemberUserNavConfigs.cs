namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberUserNavConfigs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberUserNavConfigs()
        {
            MemberUserNavConfigs1 = new HashSet<MemberUserNavConfigs>();
        }

        [Key]
        public int IdNavConfig { get; set; }

        public int? MemberId { get; set; }

        public int? MemberUserId { get; set; }

        public int NavItemId { get; set; }

        public int? ParentId { get; set; }

        public bool? IsActive { get; set; }

        public int? DisplayOrder { get; set; }

        public int? SitePositionId { get; set; }

        public bool? IsDefault { get; set; }

        public int? NavConfigTemplateId { get; set; }

        public virtual MemberUsers MemberUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberUserNavConfigs> MemberUserNavConfigs1 { get; set; }

        public virtual MemberUserNavConfigs MemberUserNavConfigs2 { get; set; }

        public virtual NavConfigTemplates NavConfigTemplates { get; set; }
    }
}
