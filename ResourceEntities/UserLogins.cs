namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserLogins
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int UserLoginProviderId { get; set; }

        public DateTime LoginDate { get; set; }

        public int LoginCountToday { get; set; }

        [StringLength(40)]
        public string LastKnownIP { get; set; }

        public virtual UserLoginProvider UserLoginProvider { get; set; }

        public virtual Users Users { get; set; }
    }
}
