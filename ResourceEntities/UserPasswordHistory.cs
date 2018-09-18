namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserPasswordHistory")]
    public partial class UserPasswordHistory
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(450)]
        public string LastPassword { get; set; }

        public DateTime ChangeDate { get; set; }

        public virtual Users Users { get; set; }
    }
}
