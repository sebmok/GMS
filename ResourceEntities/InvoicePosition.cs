namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvoicePosition")]
    public partial class InvoicePosition
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int MemberUserId { get; set; }

        public int ContractorIId { get; set; }

        public int InvoiceId { get; set; }

        public int ProductId { get; set; }

        public int? InvoiceProductGroupDetailId { get; set; }

        public decimal Quantity { get; set; }

        public bool? IsSeparatePosition { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
