namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Members
    {
        public int Id { get; set; }

        [Required]
        public string LongName { get; set; }

        [Required]
        public string ShortName { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        public bool isMember { get; set; }

        [StringLength(450)]
        public string insUser { get; set; }

        public int? CountryId { get; set; }

        public bool? IsDataConfirmed { get; set; }

        public int MemberId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTo { get; set; }

        public virtual MemberIds MemberIds { get; set; }
    }
}
