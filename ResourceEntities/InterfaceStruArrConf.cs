namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InterfaceStruArrConf")]
    public partial class InterfaceStruArrConf
    {
        public int Id { get; set; }

        public int? StruId { get; set; }

        public int? ArrId { get; set; }

        public int ParamId { get; set; }

        public int? ParamSortOrder { get; set; }

        public int MethodId { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual InterfaceArrDict InterfaceArrDict { get; set; }

        public virtual InterfaceMethodsDict InterfaceMethodsDict { get; set; }

        public virtual InterfaceParamsDict InterfaceParamsDict { get; set; }

        public virtual InterfaceStructureDict InterfaceStructureDict { get; set; }
    }
}
