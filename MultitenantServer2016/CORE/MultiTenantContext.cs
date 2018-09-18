
using ResourceEntities;
using System.Data.Entity;

namespace MultitenantServer2016.CORE
{

    [DbConfigurationType(typeof(DataConfiguration))]
    public class MultiTenantContext : DbContext
    {
        public virtual DbSet<aboAbonamentDict> aboAbonamentDict { get; set; }
        public virtual DbSet<aboAbonamentServicesDedicated> aboAbonamentServicesDedicated { get; set; }
        public virtual DbSet<aboAbonamentServicesDefault> aboAbonamentServicesDefault { get; set; }
        public virtual DbSet<aboAbonamentServiceTemplateDict> aboAbonamentServiceTemplateDict { get; set; }
        public virtual DbSet<aboPaymentMethodDict> aboPaymentMethodDict { get; set; }
        public virtual DbSet<aboPaymentTerminDict> aboPaymentTerminDict { get; set; }
        public virtual DbSet<aboServiceDefaultPricesDict> aboServiceDefaultPricesDict { get; set; }
        public virtual DbSet<aboServicesDict> aboServicesDict { get; set; }
        public virtual DbSet<BankAccountTypesDict> BankAccountTypesDict { get; set; }
        public virtual DbSet<BankAccountUsageTypeDict> BankAccountUsageTypeDict { get; set; }
        public virtual DbSet<BankCountry> BankCountry { get; set; }
        public virtual DbSet<BankDict> BankDict { get; set; }
        public virtual DbSet<CitiesDict> CitiesDict { get; set; }
        public virtual DbSet<ContractorTypesDict> ContractorTypesDict { get; set; }
        public virtual DbSet<CotrolButtonDict> CotrolButtonDict { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CountryCurrencies> CountryCurrencies { get; set; }
        public virtual DbSet<CountryLanguages> CountryLanguages { get; set; }
        public virtual DbSet<CurrencyDicts> CurrencyDicts { get; set; }
        public virtual DbSet<DataMemberBankAccounts> DataMemberBankAccounts { get; set; }
        public virtual DbSet<Errors> Errors { get; set; }
        public virtual DbSet<FieldTypesDicts> FieldTypesDicts { get; set; }
        public virtual DbSet<FormConfigTemplates> FormConfigTemplates { get; set; }
        public virtual DbSet<FormConfigTemplatesGlobalNameDict> FormConfigTemplatesGlobalNameDict { get; set; }
        public virtual DbSet<FormDefaultConfig> FormDefaultConfig { get; set; }
        public virtual DbSet<FormFieldsClassesDict> FormFieldsClassesDict { get; set; }
        public virtual DbSet<FormFieldsGlobalNameDict> FormFieldsGlobalNameDict { get; set; }
        public virtual DbSet<FormGlobalNameDict> FormGlobalNameDict { get; set; }
        public virtual DbSet<FormGroupsGlobalNameDict> FormGroupsGlobalNameDict { get; set; }
        public virtual DbSet<GlyphGlobalNameDict> GlyphGlobalNameDict { get; set; }
        public virtual DbSet<GlyphsDicts> GlyphsDicts { get; set; }
        public virtual DbSet<IdentitiesDict> IdentitiesDict { get; set; }
        public virtual DbSet<IdentitiesGlobalNameDict> IdentitiesGlobalNameDict { get; set; }
        public virtual DbSet<IdentityTypeDict> IdentityTypeDict { get; set; }
        public virtual DbSet<InterfaceArrDict> InterfaceArrDict { get; set; }
        public virtual DbSet<InterfaceMethodsDict> InterfaceMethodsDict { get; set; }
        public virtual DbSet<InterfaceParamsDict> InterfaceParamsDict { get; set; }
        public virtual DbSet<InterfaceStruArrConf> InterfaceStruArrConf { get; set; }
        public virtual DbSet<InterfaceStructureDict> InterfaceStructureDict { get; set; }
        public virtual DbSet<InterfaceUrlDict> InterfaceUrlDict { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceNumberCombinationTemplate> InvoiceNumberCombinationTemplate { get; set; }
        public virtual DbSet<InvoicePosition> InvoicePosition { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<MemberContractorUser> MemberContractorUser { get; set; }
        public virtual DbSet<MemberEmails> MemberEmails { get; set; }
        public virtual DbSet<MemberIdentity> MemberIdentity { get; set; }
        public virtual DbSet<MemberIds> MemberIds { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<MemberUserNavConfigs> MemberUserNavConfigs { get; set; }
        public virtual DbSet<MemberUserQuickMenus> MemberUserQuickMenus { get; set; }
        public virtual DbSet<MemberUsers> MemberUsers { get; set; }
        public virtual DbSet<NavConfigTemplates> NavConfigTemplates { get; set; }
        public virtual DbSet<NavConfigTemplatesGlobalNameDict> NavConfigTemplatesGlobalNameDict { get; set; }
        public virtual DbSet<PostCodesDict> PostCodesDict { get; set; }
        public virtual DbSet<ProvidersDict> ProvidersDict { get; set; }
        public virtual DbSet<ProvincesDict> ProvincesDict { get; set; }
        public virtual DbSet<StreetsDict> StreetsDict { get; set; }
        public virtual DbSet<SysImportMappingPosition> SysImportMappingPosition { get; set; }
        public virtual DbSet<SysImportPositions> SysImportPositions { get; set; }
        public virtual DbSet<SysImportTemplate> SysImportTemplate { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<UserContractors> UserContractors { get; set; }
        public virtual DbSet<UserLoginProvider> UserLoginProvider { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        public virtual DbSet<UserPasswordHistory> UserPasswordHistory { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<aboAbonamentDict>()
                .HasMany(e => e.aboAbonamentServicesDedicated)
                .WithRequired(e => e.aboAbonamentDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aboAbonamentDict>()
                .HasMany(e => e.aboAbonamentServicesDefault)
                .WithRequired(e => e.aboAbonamentDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aboAbonamentServiceTemplateDict>()
                .HasMany(e => e.aboAbonamentServicesDedicated)
                .WithRequired(e => e.aboAbonamentServiceTemplateDict)
                .HasForeignKey(e => e.TemplateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aboAbonamentServiceTemplateDict>()
                .HasMany(e => e.aboAbonamentServicesDefault)
                .WithOptional(e => e.aboAbonamentServiceTemplateDict)
                .HasForeignKey(e => e.TemplateId);

            modelBuilder.Entity<aboPaymentTerminDict>()
                .HasMany(e => e.aboServiceDefaultPricesDict)
                .WithRequired(e => e.aboPaymentTerminDict)
                .HasForeignKey(e => e.PaymentTerminDictId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aboServiceDefaultPricesDict>()
                .Property(e => e.DefaultPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<aboServiceDefaultPricesDict>()
                .HasMany(e => e.aboAbonamentServicesDefault)
                .WithOptional(e => e.aboServiceDefaultPricesDict)
                .HasForeignKey(e => e.aboServiceDefaultPriceId);

            modelBuilder.Entity<aboServicesDict>()
                .HasMany(e => e.aboAbonamentServicesDedicated)
                .WithRequired(e => e.aboServicesDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aboServicesDict>()
                .HasMany(e => e.aboAbonamentServicesDefault)
                .WithRequired(e => e.aboServicesDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<aboServicesDict>()
                .HasMany(e => e.aboServiceDefaultPricesDict)
                .WithRequired(e => e.aboServicesDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BankDict>()
                .HasMany(e => e.BankCountry)
                .WithRequired(e => e.BankDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BankDict>()
                .HasMany(e => e.DataMemberBankAccounts)
                .WithRequired(e => e.BankDict)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CitiesDict>()
                .HasMany(e => e.PostCodesDict)
                .WithRequired(e => e.CitiesDict)
                .HasForeignKey(e => e.CityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CitiesDict>()
                .HasMany(e => e.StreetsDict)
                .WithOptional(e => e.CitiesDict)
                .HasForeignKey(e => e.CityId);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.aboServiceDefaultPricesDict)
                .WithOptional(e => e.Countries)
                .HasForeignKey(e => e.CountryId);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.BankCountry)
                .WithRequired(e => e.Countries)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.CitiesDict)
                .WithRequired(e => e.Countries)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.CountryCurrencies)
                .WithRequired(e => e.Countries)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.CountryLanguages)
                .WithRequired(e => e.Countries)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.IdentityTypeDict)
                .WithRequired(e => e.Countries)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.PostCodesDict)
                .WithRequired(e => e.Countries)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.ProvincesDict)
                .WithOptional(e => e.Countries)
                .HasForeignKey(e => e.CountryId);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.StreetsDict)
                .WithRequired(e => e.Countries)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CurrencyDicts>()
                .HasMany(e => e.aboServiceDefaultPricesDict)
                .WithRequired(e => e.CurrencyDicts)
                .HasForeignKey(e => e.Currency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CurrencyDicts>()
                .HasMany(e => e.DataMemberBankAccounts)
                .WithRequired(e => e.CurrencyDicts)
                .HasForeignKey(e => e.CurrencyDictId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FieldTypesDicts>()
                .HasMany(e => e.FormDefaultConfig)
                .WithRequired(e => e.FieldTypesDicts)
                .HasForeignKey(e => e.FieldTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FormConfigTemplates>()
                .HasMany(e => e.FormDefaultConfig)
                .WithRequired(e => e.FormConfigTemplates)
                .HasForeignKey(e => e.FormConfgTemplateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FormConfigTemplatesGlobalNameDict>()
                .HasMany(e => e.FormConfigTemplates)
                .WithRequired(e => e.FormConfigTemplatesGlobalNameDict)
                .HasForeignKey(e => e.TemplateNameId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FormFieldsClassesDict>()
                .HasMany(e => e.FormDefaultConfig)
                .WithRequired(e => e.FormFieldsClassesDict)
                .HasForeignKey(e => e.FieldClassId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FormFieldsGlobalNameDict>()
                .HasMany(e => e.FormDefaultConfig)
                .WithRequired(e => e.FormFieldsGlobalNameDict)
                .HasForeignKey(e => e.FormFieldId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FormGlobalNameDict>()
                .HasMany(e => e.FormDefaultConfig)
                .WithRequired(e => e.FormGlobalNameDict)
                .HasForeignKey(e => e.FormNameId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FormGroupsGlobalNameDict>()
                .HasMany(e => e.FormDefaultConfig)
                .WithRequired(e => e.FormGroupsGlobalNameDict)
                .HasForeignKey(e => e.FormGroupId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GlyphGlobalNameDict>()
                .HasMany(e => e.GlyphsDicts)
                .WithOptional(e => e.GlyphGlobalNameDict)
                .HasForeignKey(e => e.GlyphGlobalNameId);

            modelBuilder.Entity<GlyphsDicts>()
                .HasMany(e => e.MemberUserQuickMenus)
                .WithRequired(e => e.GlyphsDicts)
                .HasForeignKey(e => e.GlyphId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GlyphsDicts>()
                .HasMany(e => e.NavConfigTemplates)
                .WithOptional(e => e.GlyphsDicts)
                .HasForeignKey(e => e.GlyphId);

            modelBuilder.Entity<IdentitiesDict>()
                .HasMany(e => e.MemberIdentity)
                .WithRequired(e => e.IdentitiesDict)
                .HasForeignKey(e => e.IdentityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IdentitiesGlobalNameDict>()
                .HasMany(e => e.IdentitiesDict)
                .WithOptional(e => e.IdentitiesGlobalNameDict)
                .HasForeignKey(e => e.IdentrityNameId);

            modelBuilder.Entity<IdentityTypeDict>()
                .HasMany(e => e.IdentitiesDict)
                .WithOptional(e => e.IdentityTypeDict)
                .HasForeignKey(e => e.IdentitiesTypeDictId);

            modelBuilder.Entity<InterfaceArrDict>()
                .HasMany(e => e.InterfaceArrDict1)
                .WithOptional(e => e.InterfaceArrDict2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<InterfaceArrDict>()
                .HasMany(e => e.InterfaceStruArrConf)
                .WithOptional(e => e.InterfaceArrDict)
                .HasForeignKey(e => e.ArrId);

            modelBuilder.Entity<InterfaceMethodsDict>()
                .HasMany(e => e.InterfaceStruArrConf)
                .WithRequired(e => e.InterfaceMethodsDict)
                .HasForeignKey(e => e.MethodId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InterfaceParamsDict>()
                .HasMany(e => e.InterfaceStruArrConf)
                .WithRequired(e => e.InterfaceParamsDict)
                .HasForeignKey(e => e.ParamId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InterfaceStructureDict>()
                .HasMany(e => e.InterfaceStruArrConf)
                .WithOptional(e => e.InterfaceStructureDict)
                .HasForeignKey(e => e.StruId);

            modelBuilder.Entity<InterfaceStructureDict>()
                .HasMany(e => e.InterfaceStructureDict1)
                .WithOptional(e => e.InterfaceStructureDict2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<InterfaceUrlDict>()
                .HasMany(e => e.InterfaceMethodsDict)
                .WithOptional(e => e.InterfaceUrlDict)
                .HasForeignKey(e => e.MethodUrlId);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoicePosition)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoicePosition>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Languages>()
                .HasMany(e => e.CountryLanguages)
                .WithRequired(e => e.Languages)
                .HasForeignKey(e => e.LanguageId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberIds>()
                .HasMany(e => e.DataMemberBankAccounts)
                .WithRequired(e => e.MemberIds)
                .HasForeignKey(e => e.MemberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberIds>()
                .HasMany(e => e.MemberIdentity)
                .WithRequired(e => e.MemberIds)
                .HasForeignKey(e => e.MemberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberIds>()
                .HasMany(e => e.Members)
                .WithRequired(e => e.MemberIds)
                .HasForeignKey(e => e.MemberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberIds>()
                .HasMany(e => e.MemberUsers)
                .WithRequired(e => e.MemberIds)
                .HasForeignKey(e => e.MemberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberUserNavConfigs>()
                .HasMany(e => e.MemberUserNavConfigs1)
                .WithOptional(e => e.MemberUserNavConfigs2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<MemberUsers>()
                .HasMany(e => e.MemberUserNavConfigs)
                .WithOptional(e => e.MemberUsers)
                .HasForeignKey(e => e.MemberUserId);

            modelBuilder.Entity<MemberUsers>()
                .HasMany(e => e.MemberUserQuickMenus)
                .WithOptional(e => e.MemberUsers)
                .HasForeignKey(e => e.MemberUserId);

            modelBuilder.Entity<MemberUsers>()
                .HasMany(e => e.UserContractors)
                .WithRequired(e => e.MemberUsers)
                .HasForeignKey(e => e.MemberUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberUsers>()
                .HasMany(e => e.SysImportMappingPosition)
                .WithRequired(e => e.MemberUsers)
                .HasForeignKey(e => e.insUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberUsers>()
                .HasMany(e => e.SysImportPositions)
                .WithRequired(e => e.MemberUsers)
                .HasForeignKey(e => e.insUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberUsers>()
                .HasMany(e => e.SysImportTemplate)
                .WithRequired(e => e.MemberUsers)
                .HasForeignKey(e => e.insUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NavConfigTemplates>()
                .HasMany(e => e.MemberUserNavConfigs)
                .WithOptional(e => e.NavConfigTemplates)
                .HasForeignKey(e => e.NavConfigTemplateId);

            modelBuilder.Entity<NavConfigTemplates>()
                .HasMany(e => e.MemberUserQuickMenus)
                .WithOptional(e => e.NavConfigTemplates)
                .HasForeignKey(e => e.TemplateId);

            modelBuilder.Entity<NavConfigTemplatesGlobalNameDict>()
                .HasMany(e => e.NavConfigTemplates)
                .WithRequired(e => e.NavConfigTemplatesGlobalNameDict)
                .HasForeignKey(e => e.NameId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProvidersDict>()
                .HasMany(e => e.InterfaceMethodsDict)
                .WithRequired(e => e.ProvidersDict)
                .HasForeignKey(e => e.ProviderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProvidersDict>()
                .HasMany(e => e.UserLoginProvider)
                .WithRequired(e => e.ProvidersDict)
                .HasForeignKey(e => e.ProviderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StreetsDict>()
                .HasMany(e => e.PostCodesDict)
                .WithRequired(e => e.StreetsDict)
                .HasForeignKey(e => e.StreetId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SysImportMappingPosition>()
                .Property(e => e.DestinationServiceName)
                .IsUnicode(false);

            modelBuilder.Entity<SysImportTemplate>()
                .Property(e => e.DateFormat)
                .IsUnicode(false);

            modelBuilder.Entity<SysImportTemplate>()
                .Property(e => e.TimeFormat)
                .IsUnicode(false);

            modelBuilder.Entity<SysImportTemplate>()
                .Property(e => e.DecimalSeparator)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SysImportTemplate>()
                .Property(e => e.ThousendSeparator)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SysImportTemplate>()
                .Property(e => e.JetConnectString)
                .IsUnicode(false);

            modelBuilder.Entity<SysImportTemplate>()
                .Property(e => e.FileExtension)
                .IsUnicode(false);

            modelBuilder.Entity<SysImportTemplate>()
                .Property(e => e.Currency)
                .IsUnicode(false);

            modelBuilder.Entity<SysImportTemplate>()
                .HasMany(e => e.SysImportMappingPosition)
                .WithRequired(e => e.SysImportTemplate)
                .HasForeignKey(e => e.TemplateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SysImportTemplate>()
                .HasMany(e => e.SysImportPositions)
                .WithRequired(e => e.SysImportTemplate)
                .HasForeignKey(e => e.TemplateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserLoginProvider>()
                .HasMany(e => e.UserLogins)
                .WithRequired(e => e.UserLoginProvider)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.MemberUsers)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserLoginProvider)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserLogins)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserPasswordHistory)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
