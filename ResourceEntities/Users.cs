namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            MemberUsers = new HashSet<MemberUsers>();
            UserLoginProvider = new HashSet<UserLoginProvider>();
            UserLogins = new HashSet<UserLogins>();
            UserPasswordHistory = new HashSet<UserPasswordHistory>();
        }

        [Key]
        public int IdUser { get; set; }

        [Required]
        [StringLength(450)]
        public string Email { get; set; }

        public bool isEmailConfirmed { get; set; }

        public int? CountryNoPrefix { get; set; }

        public int? PhoneNumber { get; set; }

        public bool? isPhoneNumberConfirmed { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime SignedUpDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsConfigured { get; set; }

        public Guid RefKey { get; set; }

        public bool? IsMultiLoginEnabled { get; set; }

        public int? PassChangeDaysOffset { get; set; }

        public DateTime? PassValidDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberUsers> MemberUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLoginProvider> UserLoginProvider { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLogins> UserLogins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserPasswordHistory> UserPasswordHistory { get; set; }
    }
}
