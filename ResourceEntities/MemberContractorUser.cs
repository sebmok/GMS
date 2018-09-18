namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberContractorUser")]
    public partial class MemberContractorUser
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int? MemberUserId { get; set; }

        public int ContractorId { get; set; }

        public DateTime InsDate { get; set; }

        public DateTime? ModDate { get; set; }

        public int? InsUser { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DelDate { get; set; }

        public bool? isUserOnly { get; set; }
    }
}
