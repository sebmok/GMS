namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NavItemsDicts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NavItemsDicts()
        {
            MemberUserNavConfigs = new HashSet<MemberUserNavConfigs>();
        }

        [Key]
        public int IdNavItem { get; set; }

        [Required]
        [StringLength(30)]
        public string NavItemName { get; set; }

        [StringLength(60)]
        public string NavItemController { get; set; }

        [StringLength(100)]
        public string NavItemAction { get; set; }

        [StringLength(100)]
        public string NavItemImageClass { get; set; }

        public bool IsActiveLi { get; set; }

        public bool IsDeleted { get; set; }

        public int? DefaultFormId { get; set; }

        [StringLength(300)]
        public string FormActionPath { get; set; }

        public int? MemberId { get; set; }

        public int? GlyphId { get; set; }

        public virtual GlyphsDicts GlyphsDicts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberUserNavConfigs> MemberUserNavConfigs { get; set; }
    }
}
