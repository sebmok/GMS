namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberEmails
    {
        [Key]
        public int IdEmail { get; set; }

        public int? MemberId { get; set; }

        public string EmailAddress { get; set; }

        public bool? IsConfirmed { get; set; }

        public bool? IsPublic { get; set; }

        public int? UsageType { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
