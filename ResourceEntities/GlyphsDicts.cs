namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GlyphsDicts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GlyphsDicts()
        {
            MemberUserQuickMenus = new HashSet<MemberUserQuickMenus>();
            NavConfigTemplates = new HashSet<NavConfigTemplates>();
        }

        [Key]
        public int IdGlyph { get; set; }

        [Required]
        public string GlyphName { get; set; }

        [Required]
        public string GlyphClass { get; set; }

        [Required]
        public string GlyfhDefaultToolTip { get; set; }

        public int? TemplateId { get; set; }

        public int? GlyphGlobalNameId { get; set; }

        public virtual GlyphGlobalNameDict GlyphGlobalNameDict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberUserQuickMenus> MemberUserQuickMenus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NavConfigTemplates> NavConfigTemplates { get; set; }
    }
}
