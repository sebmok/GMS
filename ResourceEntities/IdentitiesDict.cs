namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IdentitiesDict")]
    public partial class IdentitiesDict
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IdentitiesDict()
        {
            MemberIdentity = new HashSet<MemberIdentity>();
        }

        public int Id { get; set; }

        public int? CountryId { get; set; }

        public int? IdentitiesTypeDictId { get; set; }

        public bool? IsUnique { get; set; }

        public bool? IsTerminal { get; set; }

        public int? MonthValid { get; set; }

        public int? YearValid { get; set; }

        public int? DaysValid { get; set; }

        public int? IdentrityNameId { get; set; }

        public virtual IdentitiesGlobalNameDict IdentitiesGlobalNameDict { get; set; }

        public virtual IdentityTypeDict IdentityTypeDict { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberIdentity> MemberIdentity { get; set; }
    }
}
