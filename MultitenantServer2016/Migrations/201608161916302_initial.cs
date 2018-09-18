namespace MultitenantServer2016.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.aboAbonamentDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 300),
                        IsPublicFree = c.Boolean(nullable: false),
                        IsConfigAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.aboAbonamentServicesDedicated",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        aboAbonamentDictId = c.Int(nullable: false),
                        aboServicesDictId = c.Int(nullable: false),
                        ServicePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        Monthly = c.Boolean(nullable: false),
                        Year = c.Boolean(nullable: false),
                        Day = c.Boolean(nullable: false),
                        PayedOnlyOnce = c.Boolean(nullable: false),
                        PayedOnDayOfMonth = c.Short(nullable: false),
                        TemplateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.aboAbonamentServiceTemplateDict", t => t.TemplateId)
                .ForeignKey("dbo.aboServicesDict", t => t.aboServicesDictId)
                .ForeignKey("dbo.aboAbonamentDict", t => t.aboAbonamentDictId)
                .Index(t => t.aboAbonamentDictId)
                .Index(t => t.aboServicesDictId)
                .Index(t => t.TemplateId);
            
            CreateTable(
                "dbo.aboAbonamentServiceTemplateDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TemplateName = c.String(nullable: false, maxLength: 50),
                        IsFreeOfCharge = c.Boolean(),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.aboAbonamentServicesDefault",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        aboAbonamentDictId = c.Int(nullable: false),
                        aboServicesDictId = c.Int(nullable: false),
                        aboServiceDefaultPriceId = c.Int(),
                        TemplateId = c.Int(),
                        SystemConfigId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.aboServiceDefaultPricesDict", t => t.aboServiceDefaultPriceId)
                .ForeignKey("dbo.aboServicesDict", t => t.aboServicesDictId)
                .ForeignKey("dbo.aboAbonamentServiceTemplateDict", t => t.TemplateId)
                .ForeignKey("dbo.aboAbonamentDict", t => t.aboAbonamentDictId)
                .Index(t => t.aboAbonamentDictId)
                .Index(t => t.aboServicesDictId)
                .Index(t => t.aboServiceDefaultPriceId)
                .Index(t => t.TemplateId);
            
            CreateTable(
                "dbo.aboServiceDefaultPricesDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        aboServicesDictId = c.Int(nullable: false),
                        DefaultPrice = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Currency = c.Int(nullable: false),
                        CountryId = c.Int(),
                        insDate = c.DateTime(nullable: false),
                        PaymentMethodId = c.Short(),
                        PaymentTerminDictId = c.Short(nullable: false),
                        DefaultTemplateId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.aboPaymentTerminDict", t => t.PaymentTerminDictId)
                .ForeignKey("dbo.aboServicesDict", t => t.aboServicesDictId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.CurrencyDicts", t => t.Currency)
                .Index(t => t.aboServicesDictId)
                .Index(t => t.Currency)
                .Index(t => t.CountryId)
                .Index(t => t.PaymentTerminDictId);
            
            CreateTable(
                "dbo.aboPaymentTerminDict",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        TerminName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.aboServicesDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsPublicFree = c.Boolean(nullable: false),
                        IsConfigAvailable = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        IdCountry = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false, maxLength: 300),
                        ISO3166_1 = c.String(nullable: false, maxLength: 5),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdCountry);
            
            CreateTable(
                "dbo.BankCountry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankDictId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BankDict", t => t.BankDictId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.BankDictId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.BankDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataMemberBankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        MemberUserId = c.Int(),
                        BankDictId = c.Int(nullable: false),
                        AccountNo = c.Int(nullable: false),
                        IBAN = c.Int(nullable: false),
                        SWIFT = c.String(maxLength: 15),
                        CurrencyDictId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsActive = c.Boolean(),
                        DateOfIssue = c.DateTime(storeType: "date"),
                        ExpirationDate = c.DateTime(storeType: "date"),
                        BankAccountRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CurrencyDicts", t => t.CurrencyDictId)
                .ForeignKey("dbo.MemberIds", t => t.MemberId)
                .ForeignKey("dbo.BankDict", t => t.BankDictId)
                .Index(t => t.MemberId)
                .Index(t => t.BankDictId)
                .Index(t => t.CurrencyDictId);
            
            CreateTable(
                "dbo.CurrencyDicts",
                c => new
                    {
                        IdCurrency = c.Int(nullable: false, identity: true),
                        CurrencyName = c.String(nullable: false, maxLength: 500),
                        ISO4217 = c.String(nullable: false, maxLength: 5),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdCurrency);
            
            CreateTable(
                "dbo.MemberIds",
                c => new
                    {
                        IdMember = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        modDate = c.DateTime(),
                        uniqueRefId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdMember);
            
            CreateTable(
                "dbo.MemberIdentity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityId = c.Int(nullable: false),
                        IdentityValue = c.String(nullable: false, maxLength: 200),
                        MemberId = c.Int(nullable: false),
                        isActive = c.Boolean(),
                        ValidFrom = c.DateTime(storeType: "date"),
                        ValidTo = c.DateTime(storeType: "date"),
                        insDate = c.DateTime(),
                        userMod = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentitiesDict", t => t.IdentityId)
                .ForeignKey("dbo.MemberIds", t => t.MemberId)
                .Index(t => t.IdentityId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.IdentitiesDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(),
                        IdentitiesTypeDictId = c.Int(),
                        IsUnique = c.Boolean(),
                        IsTerminal = c.Boolean(),
                        MonthValid = c.Int(),
                        YearValid = c.Int(),
                        DaysValid = c.Int(),
                        IdentrityNameId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentitiesGlobalNameDict", t => t.IdentrityNameId)
                .ForeignKey("dbo.IdentityTypeDict", t => t.IdentitiesTypeDictId)
                .Index(t => t.IdentitiesTypeDictId)
                .Index(t => t.IdentrityNameId);
            
            CreateTable(
                "dbo.IdentitiesGlobalNameDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PL = c.String(nullable: false),
                        DE = c.String(),
                        ENG = c.String(),
                        NO = c.String(),
                        FIN = c.String(),
                        DK = c.String(),
                        RUS = c.String(),
                        CZK = c.String(),
                        SLK = c.String(),
                        FR = c.String(),
                        IT = c.String(),
                        ESP = c.String(),
                        SWE = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityTypeDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityTypeName = c.String(nullable: false, maxLength: 100),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LongName = c.String(nullable: false),
                        ShortName = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        isMember = c.Boolean(nullable: false),
                        insUser = c.String(maxLength: 450),
                        CountryId = c.Int(),
                        IsDataConfirmed = c.Boolean(),
                        MemberId = c.Int(nullable: false),
                        DateFrom = c.DateTime(storeType: "date"),
                        DateTo = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberIds", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.MemberUsers",
                c => new
                    {
                        IdMemberUser = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        CountryId = c.Int(),
                        UserId = c.Int(nullable: false),
                        UserRefId = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModDate = c.DateTime(),
                        UserMod = c.Int(),
                        IsExternalUser = c.Boolean(),
                        IsIpCheck = c.Boolean(nullable: false),
                        IsDefaultMember = c.Boolean(nullable: false),
                        SortOrder = c.Int(),
                        IsMemberDedicatedConfig = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdMemberUser)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.MemberIds", t => t.MemberId)
                .Index(t => t.MemberId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MemberUserNavConfigs",
                c => new
                    {
                        IdNavConfig = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(),
                        MemberUserId = c.Int(),
                        NavItemId = c.Int(nullable: false),
                        ParentId = c.Int(),
                        IsActive = c.Boolean(),
                        DisplayOrder = c.Int(),
                        SitePositionId = c.Int(),
                        IsDefault = c.Boolean(),
                        NavConfigTemplateId = c.Int(),
                    })
                .PrimaryKey(t => t.IdNavConfig)
                .ForeignKey("dbo.MemberUserNavConfigs", t => t.ParentId)
                .ForeignKey("dbo.NavConfigTemplates", t => t.NavConfigTemplateId)
                .ForeignKey("dbo.MemberUsers", t => t.MemberUserId)
                .Index(t => t.MemberUserId)
                .Index(t => t.ParentId)
                .Index(t => t.NavConfigTemplateId);
            
            CreateTable(
                "dbo.NavConfigTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        NameId = c.Int(nullable: false),
                        SortOrder = c.Int(),
                        Controller = c.String(maxLength: 100),
                        Action = c.String(maxLength: 100),
                        ImageClass = c.String(maxLength: 200),
                        IsDefault = c.Boolean(),
                        IsPayed = c.Boolean(),
                        MemberUserId = c.Int(),
                        IsActionBar = c.Boolean(),
                        IsNavigation = c.Boolean(),
                        DefaultFormId = c.Int(),
                        FormActionPath = c.String(maxLength: 300),
                        GlyphId = c.Int(),
                        IsMemberVisible = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GlyphsDicts", t => t.GlyphId)
                .ForeignKey("dbo.NavConfigTemplatesGlobalNameDict", t => t.NameId)
                .Index(t => t.NameId)
                .Index(t => t.GlyphId);
            
            CreateTable(
                "dbo.GlyphsDicts",
                c => new
                    {
                        IdGlyph = c.Int(nullable: false, identity: true),
                        GlyphName = c.String(nullable: false),
                        GlyphClass = c.String(nullable: false),
                        GlyfhDefaultToolTip = c.String(nullable: false),
                        TemplateId = c.Int(),
                        GlyphGlobalNameId = c.Int(),
                    })
                .PrimaryKey(t => t.IdGlyph)
                .ForeignKey("dbo.GlyphGlobalNameDict", t => t.GlyphGlobalNameId)
                .Index(t => t.GlyphGlobalNameId);
            
            CreateTable(
                "dbo.GlyphGlobalNameDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PL = c.String(nullable: false),
                        DE = c.String(),
                        ENG = c.String(),
                        NO = c.String(),
                        FIN = c.String(),
                        DK = c.String(),
                        RUS = c.String(),
                        CZK = c.String(),
                        SLK = c.String(),
                        FR = c.String(),
                        IT = c.String(),
                        ESP = c.String(),
                        SWE = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberUserQuickMenus",
                c => new
                    {
                        IdQuickMenu = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(),
                        MemberUserId = c.Int(),
                        GlyphId = c.Int(nullable: false),
                        ImageId = c.Int(),
                        UserToolTipId = c.String(),
                        SortOrder = c.Int(),
                        IsDeleted = c.Boolean(),
                        TemplateId = c.Int(),
                        IsDefault = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdQuickMenu)
                .ForeignKey("dbo.GlyphsDicts", t => t.GlyphId)
                .ForeignKey("dbo.NavConfigTemplates", t => t.TemplateId)
                .ForeignKey("dbo.MemberUsers", t => t.MemberUserId)
                .Index(t => t.MemberUserId)
                .Index(t => t.GlyphId)
                .Index(t => t.TemplateId);
            
            CreateTable(
                "dbo.NavConfigTemplatesGlobalNameDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PL = c.String(nullable: false),
                        DE = c.String(),
                        ENG = c.String(),
                        NO = c.String(),
                        FIN = c.String(),
                        DK = c.String(),
                        RUS = c.String(),
                        CZK = c.String(),
                        SLK = c.String(),
                        FR = c.String(),
                        IT = c.String(),
                        ESP = c.String(),
                        SWE = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysImportMappingPosition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerMemberId = c.Int(nullable: false),
                        SourceServiceName = c.String(nullable: false, maxLength: 100),
                        DestinationServiceName = c.String(nullable: false, maxLength: 25, unicode: false),
                        TemplateId = c.Int(nullable: false),
                        insUser = c.Int(nullable: false),
                        insDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysImportTemplate", t => t.TemplateId)
                .ForeignKey("dbo.MemberUsers", t => t.insUser)
                .Index(t => t.TemplateId)
                .Index(t => t.insUser);
            
            CreateTable(
                "dbo.SysImportTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImportDestinationType = c.Int(),
                        TemplateName = c.String(nullable: false, maxLength: 50),
                        ActiveFrom = c.DateTime(nullable: false),
                        ActiveTo = c.DateTime(),
                        OwnerMemberId = c.Int(nullable: false),
                        SourceTable = c.String(maxLength: 100),
                        DateFormat = c.String(maxLength: 50, unicode: false),
                        TimeFormat = c.String(maxLength: 50, unicode: false),
                        DecimalSeparator = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        ThousendSeparator = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        JetConnectString = c.String(maxLength: 200, unicode: false),
                        FileExtension = c.String(maxLength: 7, unicode: false),
                        Currency = c.String(maxLength: 3, unicode: false),
                        FirstRowIsHeader = c.Boolean(nullable: false),
                        SkipRowBeforeHeader = c.Int(),
                        SkipRowAfterHeader = c.Int(),
                        insUser = c.Int(nullable: false),
                        insDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberUsers", t => t.insUser)
                .Index(t => t.insUser);
            
            CreateTable(
                "dbo.SysImportPositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerMemberId = c.Int(nullable: false),
                        SourceColumnName = c.String(nullable: false, maxLength: 100),
                        DestinationColumnName = c.String(nullable: false, maxLength: 100),
                        DestinationTableName = c.String(maxLength: 100),
                        TemplateId = c.Int(nullable: false),
                        insUser = c.Int(nullable: false),
                        insDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysImportTemplate", t => t.TemplateId)
                .ForeignKey("dbo.MemberUsers", t => t.insUser)
                .Index(t => t.TemplateId)
                .Index(t => t.insUser);
            
            CreateTable(
                "dbo.UserContractors",
                c => new
                    {
                        IdUserContractor = c.Int(nullable: false, identity: true),
                        MemberUserId = c.Int(nullable: false),
                        ContractorId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUserContractor)
                .ForeignKey("dbo.MemberUsers", t => t.MemberUserId)
                .Index(t => t.MemberUserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 450),
                        isEmailConfirmed = c.Boolean(nullable: false),
                        CountryNoPrefix = c.Int(),
                        PhoneNumber = c.Int(),
                        isPhoneNumberConfirmed = c.Boolean(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        SignedUpDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsConfigured = c.Boolean(nullable: false),
                        RefKey = c.Guid(nullable: false),
                        IsMultiLoginEnabled = c.Boolean(),
                        PassChangeDaysOffset = c.Int(),
                        PassValidDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdUser);
            
            CreateTable(
                "dbo.UserLoginProvider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProviderId = c.Int(nullable: false),
                        ProviderUserId = c.String(maxLength: 450),
                        IsDeleted = c.Boolean(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        IsFakeUser = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProvidersDict", t => t.ProviderId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.ProvidersDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProviderName = c.String(nullable: false, maxLength: 450),
                        ProviderCountry = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                        IsIntegrated = c.Boolean(),
                        IsSessionAccess = c.Boolean(),
                        IsTokenAccess = c.Boolean(),
                        IsTwoFactorAccess = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InterfaceMethodsDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MethodName = c.String(nullable: false, maxLength: 70),
                        ProviderId = c.Int(nullable: false),
                        IsRequest = c.Boolean(),
                        IsResponse = c.Boolean(),
                        IsCommit = c.Boolean(),
                        MethodUrlId = c.Int(),
                        IsComplete = c.Boolean(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InterfaceUrlDict", t => t.MethodUrlId)
                .ForeignKey("dbo.ProvidersDict", t => t.ProviderId)
                .Index(t => t.ProviderId)
                .Index(t => t.MethodUrlId);
            
            CreateTable(
                "dbo.InterfaceStruArrConf",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StruId = c.Int(),
                        ArrId = c.Int(),
                        ParamId = c.Int(nullable: false),
                        ParamSortOrder = c.Int(),
                        MethodId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InterfaceArrDict", t => t.ArrId)
                .ForeignKey("dbo.InterfaceParamsDict", t => t.ParamId)
                .ForeignKey("dbo.InterfaceStructureDict", t => t.StruId)
                .ForeignKey("dbo.InterfaceMethodsDict", t => t.MethodId)
                .Index(t => t.StruId)
                .Index(t => t.ArrId)
                .Index(t => t.ParamId)
                .Index(t => t.MethodId);
            
            CreateTable(
                "dbo.InterfaceArrDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArrName = c.String(nullable: false, maxLength: 70),
                        ParentId = c.Int(),
                        SortOrder = c.Int(),
                        isDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InterfaceArrDict", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.InterfaceParamsDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParamName = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InterfaceStructureDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StructureName = c.String(nullable: false, maxLength: 70),
                        ParentId = c.Int(),
                        SortOrderr = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InterfaceStructureDict", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.InterfaceUrlDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserLoginProviderId = c.Int(nullable: false),
                        LoginDate = c.DateTime(nullable: false),
                        LoginCountToday = c.Int(nullable: false),
                        LastKnownIP = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserLoginProvider", t => t.UserLoginProviderId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.UserLoginProviderId);
            
            CreateTable(
                "dbo.UserPasswordHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LastPassword = c.String(nullable: false, maxLength: 450),
                        ChangeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CitiesDict",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 450),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.PostCodesDict",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Long(nullable: false),
                        StreetId = c.Long(nullable: false),
                        BuildingNo = c.String(nullable: false, maxLength: 50),
                        PostalCodeId = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StreetsDict", t => t.StreetId)
                .ForeignKey("dbo.CitiesDict", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId)
                .Index(t => t.StreetId);
            
            CreateTable(
                "dbo.StreetsDict",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Long(),
                        StreetName = c.String(nullable: false, maxLength: 450),
                        PreviousSteetName = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CitiesDict", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.CountryCurrencies",
                c => new
                    {
                        IdCountryCurrency = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        IsDefault = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.IdCountryCurrency)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.CountryLanguages",
                c => new
                    {
                        IdCountryLanguage = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCountryLanguage)
                .ForeignKey("dbo.Languages", t => t.LanguageId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        IdLanguage = c.Int(nullable: false, identity: true),
                        Family = c.String(),
                        LanguageName = c.String(),
                        NativeName = c.String(),
                        s639_1 = c.String(),
                        s639_2 = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdLanguage);
            
            CreateTable(
                "dbo.ProvincesDict",
                c => new
                    {
                        IdProvince = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(),
                        ProvinceName = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.IdProvince)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.aboPaymentMethodDict",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        PaymentMethodName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BankAccountTypesDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountTypeName = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BankAccountUsageTypeDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsageTypeName = c.String(maxLength: 50),
                        ObjId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContractorTypesDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractorTypeName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CotrolButtonDict",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ActionDescription = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FieldTypesDicts",
                c => new
                    {
                        IdFieldType = c.Short(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(maxLength: 200),
                        IsDeleted = c.Boolean(),
                        IsBootstrapType = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdFieldType);
            
            CreateTable(
                "dbo.FormDefaultConfig",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(),
                        MemberUserId = c.Int(),
                        FormNameId = c.Int(nullable: false),
                        FormConfgTemplateId = c.Int(nullable: false),
                        FormGroupId = c.Int(nullable: false),
                        GroupSortOrder = c.Short(nullable: false),
                        FormFieldId = c.Int(nullable: false),
                        FieldSortOrder = c.Short(nullable: false),
                        FieldTypeId = c.Short(nullable: false),
                        FieldClassId = c.Short(nullable: false),
                        IsEditAvailable = c.Boolean(),
                        IsReadOnly = c.Boolean(),
                        IsHidden = c.Boolean(),
                        insDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FormConfigTemplates", t => t.FormConfgTemplateId)
                .ForeignKey("dbo.FormFieldsClassesDict", t => t.FieldClassId)
                .ForeignKey("dbo.FormFieldsGlobalNameDict", t => t.FormFieldId)
                .ForeignKey("dbo.FormGlobalNameDict", t => t.FormNameId)
                .ForeignKey("dbo.FormGroupsGlobalNameDict", t => t.FormGroupId)
                .ForeignKey("dbo.FieldTypesDicts", t => t.FieldTypeId)
                .Index(t => t.FormNameId)
                .Index(t => t.FormConfgTemplateId)
                .Index(t => t.FormGroupId)
                .Index(t => t.FormFieldId)
                .Index(t => t.FieldTypeId)
                .Index(t => t.FieldClassId);
            
            CreateTable(
                "dbo.FormConfigTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        TemplateNameId = c.Int(nullable: false),
                        SectorDedicated = c.Int(),
                        IsDefault = c.Boolean(nullable: false),
                        IsPayed = c.Boolean(nullable: false),
                        MemberUserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FormConfigTemplatesGlobalNameDict", t => t.TemplateNameId)
                .Index(t => t.TemplateNameId);
            
            CreateTable(
                "dbo.FormConfigTemplatesGlobalNameDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PL = c.String(nullable: false),
                        DE = c.String(),
                        ENG = c.String(),
                        NO = c.String(),
                        FIN = c.String(),
                        DK = c.String(),
                        RUS = c.String(),
                        CZK = c.String(),
                        SLK = c.String(),
                        FR = c.String(),
                        IT = c.String(),
                        ESP = c.String(),
                        SWE = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FormFieldsClassesDict",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        ClassName = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        IsBootstrapClass = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FormFieldsGlobalNameDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsPayed = c.Boolean(nullable: false),
                        IsDedicated = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        PL = c.String(nullable: false),
                        DE = c.String(),
                        ENG = c.String(),
                        NO = c.String(),
                        FIN = c.String(),
                        DK = c.String(),
                        RUS = c.String(),
                        CZK = c.String(),
                        SLK = c.String(),
                        FR = c.String(),
                        IT = c.String(),
                        ESP = c.String(),
                        SWE = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FormGlobalNameDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsageType = c.Int(),
                        IsPayed = c.Boolean(nullable: false),
                        IsDedicated = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        PL = c.String(nullable: false),
                        DE = c.String(),
                        ENG = c.String(),
                        NO = c.String(),
                        FIN = c.String(),
                        DK = c.String(),
                        RUS = c.String(),
                        CZK = c.String(),
                        SLK = c.String(),
                        FR = c.String(),
                        IT = c.String(),
                        ESP = c.String(),
                        SWE = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FormGroupsGlobalNameDict",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsageType = c.Int(),
                        IsPayed = c.Boolean(nullable: false),
                        IsDedicated = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        PL = c.String(nullable: false),
                        DE = c.String(),
                        ENG = c.String(),
                        NO = c.String(),
                        FIN = c.String(),
                        DK = c.String(),
                        RUS = c.String(),
                        CZK = c.String(),
                        SLK = c.String(),
                        FR = c.String(),
                        IT = c.String(),
                        ESP = c.String(),
                        SWE = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        MemberUserId = c.Int(nullable: false),
                        ContractorId = c.Int(nullable: false),
                        UniqueIncoiceId = c.Guid(nullable: false),
                        InvoiceNumberTemplateId = c.Int(nullable: false),
                        InvoiceCommitDate = c.DateTime(),
                        InvoiceCreateDate = c.DateTime(nullable: false),
                        InvoiceDate = c.DateTime(storeType: "date"),
                        IsTemplate = c.Boolean(nullable: false),
                        IsCommited = c.Boolean(nullable: false),
                        IsPayed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoicePosition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        MemberUserId = c.Int(nullable: false),
                        ContractorIId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        InvoiceProductGroupDetailId = c.Int(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 5),
                        IsSeparatePosition = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.InvoiceNumberCombinationTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdInlineAttribute = c.Int(nullable: false),
                        IdMemberInvoiceTemplate = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        FirstAttribId = c.Int(nullable: false),
                        NextAttribId = c.Int(),
                        IsLastAttribute = c.Boolean(nullable: false),
                        InlineNextAttributeSeparatorId = c.Byte(),
                        InlineGoNext = c.Boolean(),
                        IsDefaultTemplate = c.Boolean(),
                        FirstAttributeDefaultValue = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => new { t.Id, t.IdInlineAttribute, t.IdMemberInvoiceTemplate });
            
            CreateTable(
                "dbo.MemberContractorUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        MemberUserId = c.Int(),
                        ContractorId = c.Int(nullable: false),
                        InsDate = c.DateTime(nullable: false),
                        ModDate = c.DateTime(),
                        InsUser = c.Int(),
                        IsActive = c.Boolean(),
                        IsDeleted = c.Boolean(nullable: false),
                        DelDate = c.DateTime(),
                        isUserOnly = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberEmails",
                c => new
                    {
                        IdEmail = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(),
                        EmailAddress = c.String(),
                        IsConfirmed = c.Boolean(),
                        IsPublic = c.Boolean(),
                        UsageType = c.Int(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdEmail);
            
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        DomainName = c.String(nullable: false),
                        Default = c.Boolean(nullable: false),
                        DataServerIP = c.String(),
                        DataServerHttpAddress = c.String(),
                        DataServerAccessInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoicePosition", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.FormDefaultConfig", "FieldTypeId", "dbo.FieldTypesDicts");
            DropForeignKey("dbo.FormDefaultConfig", "FormGroupId", "dbo.FormGroupsGlobalNameDict");
            DropForeignKey("dbo.FormDefaultConfig", "FormNameId", "dbo.FormGlobalNameDict");
            DropForeignKey("dbo.FormDefaultConfig", "FormFieldId", "dbo.FormFieldsGlobalNameDict");
            DropForeignKey("dbo.FormDefaultConfig", "FieldClassId", "dbo.FormFieldsClassesDict");
            DropForeignKey("dbo.FormDefaultConfig", "FormConfgTemplateId", "dbo.FormConfigTemplates");
            DropForeignKey("dbo.FormConfigTemplates", "TemplateNameId", "dbo.FormConfigTemplatesGlobalNameDict");
            DropForeignKey("dbo.aboAbonamentServicesDefault", "aboAbonamentDictId", "dbo.aboAbonamentDict");
            DropForeignKey("dbo.aboAbonamentServicesDedicated", "aboAbonamentDictId", "dbo.aboAbonamentDict");
            DropForeignKey("dbo.aboAbonamentServicesDefault", "TemplateId", "dbo.aboAbonamentServiceTemplateDict");
            DropForeignKey("dbo.StreetsDict", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.ProvincesDict", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.PostCodesDict", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.IdentityTypeDict", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.CountryLanguages", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.CountryLanguages", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.CountryCurrencies", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.CitiesDict", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.StreetsDict", "CityId", "dbo.CitiesDict");
            DropForeignKey("dbo.PostCodesDict", "CityId", "dbo.CitiesDict");
            DropForeignKey("dbo.PostCodesDict", "StreetId", "dbo.StreetsDict");
            DropForeignKey("dbo.BankCountry", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.DataMemberBankAccounts", "BankDictId", "dbo.BankDict");
            DropForeignKey("dbo.MemberUsers", "MemberId", "dbo.MemberIds");
            DropForeignKey("dbo.UserPasswordHistory", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLoginProvider", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserLoginProviderId", "dbo.UserLoginProvider");
            DropForeignKey("dbo.UserLoginProvider", "ProviderId", "dbo.ProvidersDict");
            DropForeignKey("dbo.InterfaceMethodsDict", "ProviderId", "dbo.ProvidersDict");
            DropForeignKey("dbo.InterfaceMethodsDict", "MethodUrlId", "dbo.InterfaceUrlDict");
            DropForeignKey("dbo.InterfaceStruArrConf", "MethodId", "dbo.InterfaceMethodsDict");
            DropForeignKey("dbo.InterfaceStructureDict", "ParentId", "dbo.InterfaceStructureDict");
            DropForeignKey("dbo.InterfaceStruArrConf", "StruId", "dbo.InterfaceStructureDict");
            DropForeignKey("dbo.InterfaceStruArrConf", "ParamId", "dbo.InterfaceParamsDict");
            DropForeignKey("dbo.InterfaceStruArrConf", "ArrId", "dbo.InterfaceArrDict");
            DropForeignKey("dbo.InterfaceArrDict", "ParentId", "dbo.InterfaceArrDict");
            DropForeignKey("dbo.MemberUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserContractors", "MemberUserId", "dbo.MemberUsers");
            DropForeignKey("dbo.SysImportTemplate", "insUser", "dbo.MemberUsers");
            DropForeignKey("dbo.SysImportPositions", "insUser", "dbo.MemberUsers");
            DropForeignKey("dbo.SysImportMappingPosition", "insUser", "dbo.MemberUsers");
            DropForeignKey("dbo.SysImportPositions", "TemplateId", "dbo.SysImportTemplate");
            DropForeignKey("dbo.SysImportMappingPosition", "TemplateId", "dbo.SysImportTemplate");
            DropForeignKey("dbo.MemberUserQuickMenus", "MemberUserId", "dbo.MemberUsers");
            DropForeignKey("dbo.MemberUserNavConfigs", "MemberUserId", "dbo.MemberUsers");
            DropForeignKey("dbo.NavConfigTemplates", "NameId", "dbo.NavConfigTemplatesGlobalNameDict");
            DropForeignKey("dbo.MemberUserQuickMenus", "TemplateId", "dbo.NavConfigTemplates");
            DropForeignKey("dbo.MemberUserNavConfigs", "NavConfigTemplateId", "dbo.NavConfigTemplates");
            DropForeignKey("dbo.NavConfigTemplates", "GlyphId", "dbo.GlyphsDicts");
            DropForeignKey("dbo.MemberUserQuickMenus", "GlyphId", "dbo.GlyphsDicts");
            DropForeignKey("dbo.GlyphsDicts", "GlyphGlobalNameId", "dbo.GlyphGlobalNameDict");
            DropForeignKey("dbo.MemberUserNavConfigs", "ParentId", "dbo.MemberUserNavConfigs");
            DropForeignKey("dbo.Members", "MemberId", "dbo.MemberIds");
            DropForeignKey("dbo.MemberIdentity", "MemberId", "dbo.MemberIds");
            DropForeignKey("dbo.MemberIdentity", "IdentityId", "dbo.IdentitiesDict");
            DropForeignKey("dbo.IdentitiesDict", "IdentitiesTypeDictId", "dbo.IdentityTypeDict");
            DropForeignKey("dbo.IdentitiesDict", "IdentrityNameId", "dbo.IdentitiesGlobalNameDict");
            DropForeignKey("dbo.DataMemberBankAccounts", "MemberId", "dbo.MemberIds");
            DropForeignKey("dbo.DataMemberBankAccounts", "CurrencyDictId", "dbo.CurrencyDicts");
            DropForeignKey("dbo.aboServiceDefaultPricesDict", "Currency", "dbo.CurrencyDicts");
            DropForeignKey("dbo.BankCountry", "BankDictId", "dbo.BankDict");
            DropForeignKey("dbo.aboServiceDefaultPricesDict", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.aboServiceDefaultPricesDict", "aboServicesDictId", "dbo.aboServicesDict");
            DropForeignKey("dbo.aboAbonamentServicesDefault", "aboServicesDictId", "dbo.aboServicesDict");
            DropForeignKey("dbo.aboAbonamentServicesDedicated", "aboServicesDictId", "dbo.aboServicesDict");
            DropForeignKey("dbo.aboServiceDefaultPricesDict", "PaymentTerminDictId", "dbo.aboPaymentTerminDict");
            DropForeignKey("dbo.aboAbonamentServicesDefault", "aboServiceDefaultPriceId", "dbo.aboServiceDefaultPricesDict");
            DropForeignKey("dbo.aboAbonamentServicesDedicated", "TemplateId", "dbo.aboAbonamentServiceTemplateDict");
            DropIndex("dbo.InvoicePosition", new[] { "InvoiceId" });
            DropIndex("dbo.FormConfigTemplates", new[] { "TemplateNameId" });
            DropIndex("dbo.FormDefaultConfig", new[] { "FieldClassId" });
            DropIndex("dbo.FormDefaultConfig", new[] { "FieldTypeId" });
            DropIndex("dbo.FormDefaultConfig", new[] { "FormFieldId" });
            DropIndex("dbo.FormDefaultConfig", new[] { "FormGroupId" });
            DropIndex("dbo.FormDefaultConfig", new[] { "FormConfgTemplateId" });
            DropIndex("dbo.FormDefaultConfig", new[] { "FormNameId" });
            DropIndex("dbo.ProvincesDict", new[] { "CountryId" });
            DropIndex("dbo.CountryLanguages", new[] { "LanguageId" });
            DropIndex("dbo.CountryLanguages", new[] { "CountryId" });
            DropIndex("dbo.CountryCurrencies", new[] { "CountryId" });
            DropIndex("dbo.StreetsDict", new[] { "CityId" });
            DropIndex("dbo.StreetsDict", new[] { "CountryId" });
            DropIndex("dbo.PostCodesDict", new[] { "StreetId" });
            DropIndex("dbo.PostCodesDict", new[] { "CityId" });
            DropIndex("dbo.PostCodesDict", new[] { "CountryId" });
            DropIndex("dbo.CitiesDict", new[] { "CountryId" });
            DropIndex("dbo.UserPasswordHistory", new[] { "UserId" });
            DropIndex("dbo.UserLogins", new[] { "UserLoginProviderId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.InterfaceStructureDict", new[] { "ParentId" });
            DropIndex("dbo.InterfaceArrDict", new[] { "ParentId" });
            DropIndex("dbo.InterfaceStruArrConf", new[] { "MethodId" });
            DropIndex("dbo.InterfaceStruArrConf", new[] { "ParamId" });
            DropIndex("dbo.InterfaceStruArrConf", new[] { "ArrId" });
            DropIndex("dbo.InterfaceStruArrConf", new[] { "StruId" });
            DropIndex("dbo.InterfaceMethodsDict", new[] { "MethodUrlId" });
            DropIndex("dbo.InterfaceMethodsDict", new[] { "ProviderId" });
            DropIndex("dbo.UserLoginProvider", new[] { "ProviderId" });
            DropIndex("dbo.UserLoginProvider", new[] { "UserId" });
            DropIndex("dbo.UserContractors", new[] { "MemberUserId" });
            DropIndex("dbo.SysImportPositions", new[] { "insUser" });
            DropIndex("dbo.SysImportPositions", new[] { "TemplateId" });
            DropIndex("dbo.SysImportTemplate", new[] { "insUser" });
            DropIndex("dbo.SysImportMappingPosition", new[] { "insUser" });
            DropIndex("dbo.SysImportMappingPosition", new[] { "TemplateId" });
            DropIndex("dbo.MemberUserQuickMenus", new[] { "TemplateId" });
            DropIndex("dbo.MemberUserQuickMenus", new[] { "GlyphId" });
            DropIndex("dbo.MemberUserQuickMenus", new[] { "MemberUserId" });
            DropIndex("dbo.GlyphsDicts", new[] { "GlyphGlobalNameId" });
            DropIndex("dbo.NavConfigTemplates", new[] { "GlyphId" });
            DropIndex("dbo.NavConfigTemplates", new[] { "NameId" });
            DropIndex("dbo.MemberUserNavConfigs", new[] { "NavConfigTemplateId" });
            DropIndex("dbo.MemberUserNavConfigs", new[] { "ParentId" });
            DropIndex("dbo.MemberUserNavConfigs", new[] { "MemberUserId" });
            DropIndex("dbo.MemberUsers", new[] { "UserId" });
            DropIndex("dbo.MemberUsers", new[] { "MemberId" });
            DropIndex("dbo.Members", new[] { "MemberId" });
            DropIndex("dbo.IdentityTypeDict", new[] { "CountryId" });
            DropIndex("dbo.IdentitiesDict", new[] { "IdentrityNameId" });
            DropIndex("dbo.IdentitiesDict", new[] { "IdentitiesTypeDictId" });
            DropIndex("dbo.MemberIdentity", new[] { "MemberId" });
            DropIndex("dbo.MemberIdentity", new[] { "IdentityId" });
            DropIndex("dbo.DataMemberBankAccounts", new[] { "CurrencyDictId" });
            DropIndex("dbo.DataMemberBankAccounts", new[] { "BankDictId" });
            DropIndex("dbo.DataMemberBankAccounts", new[] { "MemberId" });
            DropIndex("dbo.BankCountry", new[] { "CountryId" });
            DropIndex("dbo.BankCountry", new[] { "BankDictId" });
            DropIndex("dbo.aboServiceDefaultPricesDict", new[] { "PaymentTerminDictId" });
            DropIndex("dbo.aboServiceDefaultPricesDict", new[] { "CountryId" });
            DropIndex("dbo.aboServiceDefaultPricesDict", new[] { "Currency" });
            DropIndex("dbo.aboServiceDefaultPricesDict", new[] { "aboServicesDictId" });
            DropIndex("dbo.aboAbonamentServicesDefault", new[] { "TemplateId" });
            DropIndex("dbo.aboAbonamentServicesDefault", new[] { "aboServiceDefaultPriceId" });
            DropIndex("dbo.aboAbonamentServicesDefault", new[] { "aboServicesDictId" });
            DropIndex("dbo.aboAbonamentServicesDefault", new[] { "aboAbonamentDictId" });
            DropIndex("dbo.aboAbonamentServicesDedicated", new[] { "TemplateId" });
            DropIndex("dbo.aboAbonamentServicesDedicated", new[] { "aboServicesDictId" });
            DropIndex("dbo.aboAbonamentServicesDedicated", new[] { "aboAbonamentDictId" });
            DropTable("dbo.Tenant");
            DropTable("dbo.MemberEmails");
            DropTable("dbo.MemberContractorUser");
            DropTable("dbo.InvoiceNumberCombinationTemplate");
            DropTable("dbo.InvoicePosition");
            DropTable("dbo.Invoice");
            DropTable("dbo.FormGroupsGlobalNameDict");
            DropTable("dbo.FormGlobalNameDict");
            DropTable("dbo.FormFieldsGlobalNameDict");
            DropTable("dbo.FormFieldsClassesDict");
            DropTable("dbo.FormConfigTemplatesGlobalNameDict");
            DropTable("dbo.FormConfigTemplates");
            DropTable("dbo.FormDefaultConfig");
            DropTable("dbo.FieldTypesDicts");
            DropTable("dbo.Errors");
            DropTable("dbo.CotrolButtonDict");
            DropTable("dbo.ContractorTypesDict");
            DropTable("dbo.BankAccountUsageTypeDict");
            DropTable("dbo.BankAccountTypesDict");
            DropTable("dbo.aboPaymentMethodDict");
            DropTable("dbo.ProvincesDict");
            DropTable("dbo.Languages");
            DropTable("dbo.CountryLanguages");
            DropTable("dbo.CountryCurrencies");
            DropTable("dbo.StreetsDict");
            DropTable("dbo.PostCodesDict");
            DropTable("dbo.CitiesDict");
            DropTable("dbo.UserPasswordHistory");
            DropTable("dbo.UserLogins");
            DropTable("dbo.InterfaceUrlDict");
            DropTable("dbo.InterfaceStructureDict");
            DropTable("dbo.InterfaceParamsDict");
            DropTable("dbo.InterfaceArrDict");
            DropTable("dbo.InterfaceStruArrConf");
            DropTable("dbo.InterfaceMethodsDict");
            DropTable("dbo.ProvidersDict");
            DropTable("dbo.UserLoginProvider");
            DropTable("dbo.Users");
            DropTable("dbo.UserContractors");
            DropTable("dbo.SysImportPositions");
            DropTable("dbo.SysImportTemplate");
            DropTable("dbo.SysImportMappingPosition");
            DropTable("dbo.NavConfigTemplatesGlobalNameDict");
            DropTable("dbo.MemberUserQuickMenus");
            DropTable("dbo.GlyphGlobalNameDict");
            DropTable("dbo.GlyphsDicts");
            DropTable("dbo.NavConfigTemplates");
            DropTable("dbo.MemberUserNavConfigs");
            DropTable("dbo.MemberUsers");
            DropTable("dbo.Members");
            DropTable("dbo.IdentityTypeDict");
            DropTable("dbo.IdentitiesGlobalNameDict");
            DropTable("dbo.IdentitiesDict");
            DropTable("dbo.MemberIdentity");
            DropTable("dbo.MemberIds");
            DropTable("dbo.CurrencyDicts");
            DropTable("dbo.DataMemberBankAccounts");
            DropTable("dbo.BankDict");
            DropTable("dbo.BankCountry");
            DropTable("dbo.Countries");
            DropTable("dbo.aboServicesDict");
            DropTable("dbo.aboPaymentTerminDict");
            DropTable("dbo.aboServiceDefaultPricesDict");
            DropTable("dbo.aboAbonamentServicesDefault");
            DropTable("dbo.aboAbonamentServiceTemplateDict");
            DropTable("dbo.aboAbonamentServicesDedicated");
            DropTable("dbo.aboAbonamentDict");
        }
    }
}
