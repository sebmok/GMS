namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DataMemberBankAccounts
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int? MemberUserId { get; set; }

        public int BankDictId { get; set; }

        public int AccountNo { get; set; }

        public int IBAN { get; set; }

        [StringLength(15)]
        public string SWIFT { get; set; }

        public int CurrencyDictId { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool? IsActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfIssue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }

        public Guid BankAccountRefId { get; set; }

        public virtual BankDict BankDict { get; set; }

        public virtual CurrencyDicts CurrencyDicts { get; set; }

        public virtual MemberIds MemberIds { get; set; }
    }
}
