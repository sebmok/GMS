namespace ResourceEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FormDefaultConfig")]
    public partial class FormDefaultConfig
    {
        public int Id { get; set; }

        public int? MemberId { get; set; }

        public int? MemberUserId { get; set; }

        public int FormNameId { get; set; }

        public int FormConfgTemplateId { get; set; }

        public int FormGroupId { get; set; }

        public short GroupSortOrder { get; set; }

        public int FormFieldId { get; set; }

        public short FieldSortOrder { get; set; }

        public short FieldTypeId { get; set; }

        public short FieldClassId { get; set; }

        public bool? IsEditAvailable { get; set; }

        public bool? IsReadOnly { get; set; }

        public bool? IsHidden { get; set; }

        public DateTime? insDate { get; set; }

        public virtual FieldTypesDicts FieldTypesDicts { get; set; }

        public virtual FormConfigTemplates FormConfigTemplates { get; set; }

        public virtual FormFieldsClassesDict FormFieldsClassesDict { get; set; }

        public virtual FormFieldsGlobalNameDict FormFieldsGlobalNameDict { get; set; }

        public virtual FormGlobalNameDict FormGlobalNameDict { get; set; }

        public virtual FormGroupsGlobalNameDict FormGroupsGlobalNameDict { get; set; }
    }
}
