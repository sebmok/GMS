namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberUserQuickMenus
    {
        [Key]
        public int IdQuickMenu { get; set; }

        public int? MemberId { get; set; }

        public int? MemberUserId { get; set; }

        public int GlyphId { get; set; }

        public int? ImageId { get; set; }

        public string UserToolTipId { get; set; }

        public int? SortOrder { get; set; }

        public bool? IsDeleted { get; set; }

        public int? TemplateId { get; set; }

        public bool? IsDefault { get; set; }

        public virtual GlyphsDicts GlyphsDicts { get; set; }

        public virtual MemberUsers MemberUsers { get; set; }

        public virtual NavConfigTemplates NavConfigTemplates { get; set; }
    }
}
