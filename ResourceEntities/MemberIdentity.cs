namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberIdentity")]
    public partial class MemberIdentity
    {
        public int Id { get; set; }

        public int IdentityId { get; set; }

        [Required]
        [StringLength(200)]
        public string IdentityValue { get; set; }

        public int MemberId { get; set; }

        public bool? isActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ValidFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ValidTo { get; set; }

        public DateTime? insDate { get; set; }

        public int? userMod { get; set; }

        public virtual IdentitiesDict IdentitiesDict { get; set; }

        public virtual MemberIds MemberIds { get; set; }
    }
}
