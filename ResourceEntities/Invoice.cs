namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            InvoicePosition = new HashSet<InvoicePosition>();
        }

        public int Id { get; set; }

        public int MemberId { get; set; }

        public int MemberUserId { get; set; }

        public int ContractorId { get; set; }

        public Guid UniqueIncoiceId { get; set; }

        public int InvoiceNumberTemplateId { get; set; }

        public DateTime? InvoiceCommitDate { get; set; }

        public DateTime InvoiceCreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InvoiceDate { get; set; }

        public bool IsTemplate { get; set; }

        public bool IsCommited { get; set; }

        public bool IsPayed { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoicePosition> InvoicePosition { get; set; }
    }
}
