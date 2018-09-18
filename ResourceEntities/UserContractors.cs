namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserContractors
    {
        [Key]
        public int IdUserContractor { get; set; }

        public int MemberUserId { get; set; }

        public int ContractorId { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool isActive { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool isDeleted { get; set; }

        public virtual MemberUsers MemberUsers { get; set; }
    }
}
