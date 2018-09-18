namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserLoginProvider")]
    public partial class UserLoginProvider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserLoginProvider()
        {
            UserLogins = new HashSet<UserLogins>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProviderId { get; set; }

        [StringLength(450)]
        public string ProviderUserId { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsLocked { get; set; }

        public bool IsFakeUser { get; set; }

        public virtual ProvidersDict ProvidersDict { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLogins> UserLogins { get; set; }
    }
}
