namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InvoiceNumberCombinationTemplate")]
    public partial class InvoiceNumberCombinationTemplate
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        public int MemberId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdInlineAttribute { get; set; }

        public int FirstAttribId { get; set; }

        public int? NextAttribId { get; set; }

        public bool IsLastAttribute { get; set; }

        public byte? InlineNextAttributeSeparatorId { get; set; }

        public bool? InlineGoNext { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdMemberInvoiceTemplate { get; set; }

        public bool? IsDefaultTemplate { get; set; }

        [StringLength(10)]
        public string FirstAttributeDefaultValue { get; set; }
    }
}
