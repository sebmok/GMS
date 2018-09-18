namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NavConfigTemplates
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NavConfigTemplates()
        {
            MemberUserNavConfigs = new HashSet<MemberUserNavConfigs>();
            MemberUserQuickMenus = new HashSet<MemberUserQuickMenus>();
        }

        public int Id { get; set; }

        public int? MemberId { get; set; }

        public bool IsDeleted { get; set; }

        public int NameId { get; set; }

        public int? SortOrder { get; set; }

        [StringLength(100)]
        public string Controller { get; set; }

        [StringLength(100)]
        public string Action { get; set; }

        [StringLength(200)]
        public string ImageClass { get; set; }

        public bool? IsDefault { get; set; }

        public bool? IsPayed { get; set; }

        public int? MemberUserId { get; set; }

        public bool? IsActionBar { get; set; }

        public bool? IsNavigation { get; set; }

        public int? DefaultFormId { get; set; }

        [StringLength(300)]
        public string FormActionPath { get; set; }

        public int? GlyphId { get; set; }

        public bool? IsMemberVisible { get; set; }

        public virtual GlyphsDicts GlyphsDicts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberUserNavConfigs> MemberUserNavConfigs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberUserQuickMenus> MemberUserQuickMenus { get; set; }

        public virtual NavConfigTemplatesGlobalNameDict NavConfigTemplatesGlobalNameDict { get; set; }
    }
}
