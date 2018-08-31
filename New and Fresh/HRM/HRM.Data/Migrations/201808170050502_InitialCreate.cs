namespace HRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertiserLists",
                c => new
                    {
                        AdvertiserListId = c.Int(nullable: false, identity: true),
                        AdvertiserName = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false),
                        ContactInfo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdvertiserListId);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        MonthName = c.String(nullable: false),
                        Value = c.String(nullable: false),
                        MonthlyAbsence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceId);
            
            CreateTable(
                "dbo.Bonus",
                c => new
                    {
                        BonusId = c.Int(nullable: false, identity: true),
                        BonusValue = c.Int(nullable: false),
                        BonusTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BonusId);
            
            CreateTable(
                "dbo.BudgetTransactions",
                c => new
                    {
                        BudgetTransactionId = c.Int(nullable: false, identity: true),
                        MonthlyBudgetId = c.Int(nullable: false),
                        Type = c.String(),
                        TypeId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Description = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BudgetTransactionId);
            
            CreateTable(
                "dbo.CircularTemplates",
                c => new
                    {
                        CircularTemplateId = c.Int(nullable: false, identity: true),
                        TemplateName = c.String(nullable: false),
                        Template = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CircularTemplateId);
            
            CreateTable(
                "dbo.CompanyPolicies",
                c => new
                    {
                        CompanyPolicyId = c.Int(nullable: false, identity: true),
                        PolicyName = c.String(),
                        PolicyDescription = c.String(),
                    })
                .PrimaryKey(t => t.CompanyPolicyId);
            
            CreateTable(
                "dbo.DepartmentDesignations",
                c => new
                    {
                        DepartmentDesignationId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentDesignationId);
            
            CreateTable(
                "dbo.DepartmentHistories",
                c => new
                    {
                        DepartmentHistoryId = c.Int(nullable: false, identity: true),
                        ColumnName = c.String(nullable: false, maxLength: 100),
                        PreviousValue = c.String(),
                        NewValue = c.String(),
                        Date = c.DateTime(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentHistoryId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 30),
                        DepartmentLocation = c.String(nullable: false, maxLength: 30),
                        DepartmentDescription = c.String(),
                        DepartmentHeadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.EmployeeAttendances",
                c => new
                    {
                        EmployeeAttendanceId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        AttendanceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeAttendanceId);
            
            CreateTable(
                "dbo.EmployeeBios",
                c => new
                    {
                        EmployeeBioId = c.Int(nullable: false, identity: true),
                        EmployeeContactNo = c.String(nullable: false, maxLength: 11),
                        EmployeeAddress = c.String(nullable: false),
                        DateofBirth = c.DateTime(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        Intro = c.String(),
                        Objectives = c.String(),
                        Hobbies = c.String(),
                        Interests = c.String(),
                        Certificates = c.String(),
                        JobExperience = c.String(),
                        Eduction = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeBioId);
            
            CreateTable(
                "dbo.EmployeeDepartments",
                c => new
                    {
                        EmployeeDepartmentId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeDepartmentId);
            
            CreateTable(
                "dbo.EmployeeDesignations",
                c => new
                    {
                        EmployeeDesignationId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeDesignationId);
            
            CreateTable(
                "dbo.EmployeeHistories",
                c => new
                    {
                        EmployeeHistoryId = c.Int(nullable: false, identity: true),
                        ColumnName = c.String(),
                        PreviousValue = c.String(),
                        NewValue = c.String(),
                        Date = c.DateTime(nullable: false),
                        EmployeetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeHistoryId);
            
            CreateTable(
                "dbo.EmployeeIdentificationCards",
                c => new
                    {
                        EmployeeIdentificationCardId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CardHolderName = c.String(),
                        CardHolderImage = c.String(),
                        CardExpiry = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeIdentificationCardId);
            
            CreateTable(
                "dbo.EmployeePerformanceMetrics",
                c => new
                    {
                        EmployeePerformanceMetricId = c.Int(nullable: false, identity: true),
                        IllegalLeave = c.Int(nullable: false),
                        ProjectMissedDateLineCount = c.Int(nullable: false),
                        TotalProjects = c.Int(nullable: false),
                        AverageProjectScore = c.Int(nullable: false),
                        TotalTraining = c.Int(nullable: false),
                        AverageTrainingScore = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeePerformanceMetricId);
            
            CreateTable(
                "dbo.EmployeePrivileges",
                c => new
                    {
                        EmployeePrivilegeId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        PrivilegeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeePrivilegeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 30),
                        EmployeeEmail = c.String(nullable: false, maxLength: 50),
                        EmployeePassword = c.String(nullable: false, maxLength: 20),
                        MGR = c.Int(nullable: false),
                        DateofBirth = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeSalaries",
                c => new
                    {
                        EmployeeSalaryId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        BasicSalary = c.Int(nullable: false),
                        TotalSalary = c.Int(nullable: false),
                        SalaryMonth = c.String(),
                        Year = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        BonusId = c.Int(nullable: false),
                        BonusValue = c.Int(nullable: false),
                        SalaryRankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeSalaryId);
            
            CreateTable(
                "dbo.EmployeeTransportAreas",
                c => new
                    {
                        EmployeeTransportAreaId = c.Int(nullable: false, identity: true),
                        TransportAreaId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeTransportAreaId);
            
            CreateTable(
                "dbo.EquipmentAndDepartments",
                c => new
                    {
                        EquipmentAndDepartmentId = c.Int(nullable: false, identity: true),
                        EquipmentId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentAndDepartmentId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentId = c.Int(nullable: false, identity: true),
                        EquipmentTypeId = c.Int(nullable: false),
                        Status = c.String(),
                        BuyPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentId);
            
            CreateTable(
                "dbo.EquipmentTransactions",
                c => new
                    {
                        EquipmentTransactionId = c.Int(nullable: false, identity: true),
                        TransactionType = c.String(),
                        TransactionAmount = c.Int(nullable: false),
                        InvolvedPartType = c.String(),
                        ReceivingPartyId = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentTransactionId);
            
            CreateTable(
                "dbo.EquipmentTypes",
                c => new
                    {
                        EquipmentTypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Model = c.String(),
                        TotalNumberPresent = c.Int(nullable: false),
                        TotalNumberAssigned = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentTypeId);
            
            CreateTable(
                "dbo.HireRequests",
                c => new
                    {
                        HireRequestId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                        EmployeeRequired = c.Int(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        Urgency = c.String(),
                        HireRequestStatus = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HireRequestId);
            
            CreateTable(
                "dbo.HireThreads",
                c => new
                    {
                        HireThreadId = c.Int(nullable: false, identity: true),
                        Budget = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        HireThreadStatus = c.Int(nullable: false),
                        HireRequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HireThreadId);
            
            CreateTable(
                "dbo.Interviewees",
                c => new
                    {
                        IntervieweeId = c.Int(nullable: false, identity: true),
                        InterviewId = c.Int(nullable: false),
                        TemporaryCVId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IntervieweeId);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        InterviewId = c.Int(nullable: false, identity: true),
                        Schedule = c.DateTime(nullable: false),
                        HireThreadId = c.Int(nullable: false),
                        NumberOfCandidatesAssigned = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InterviewId);
            
            CreateTable(
                "dbo.Bonuses",
                c => new
                    {
                        BonusesId = c.Int(nullable: false, identity: true),
                        BonusId = c.Int(nullable: false),
                        BonusValue = c.Int(nullable: false),
                        BonusDescription = c.String(nullable: false),
                        BonusesDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BonusesId);
            
            CreateTable(
                "dbo.LeaveApplicationCategories",
                c => new
                    {
                        LeaveApplicationCategoryId = c.Int(nullable: false, identity: true),
                        LeaveApplicationCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.LeaveApplicationCategoryId);
            
            CreateTable(
                "dbo.LeaveApplications",
                c => new
                    {
                        LeaveApplicationId = c.Int(nullable: false, identity: true),
                        LeaveApplicationCategoryId = c.Int(nullable: false),
                        ApplicationDescription = c.String(),
                        LeaveApplicationDuration = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndtDate = c.DateTime(nullable: false),
                        Applydate = c.DateTime(nullable: false),
                        ApplicationsStatus = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveApplicationId);
            
            CreateTable(
                "dbo.MonthlyBudgets",
                c => new
                    {
                        MonthlyBudgetId = c.Int(nullable: false, identity: true),
                        BudgetPeriod = c.DateTime(nullable: false),
                        TotalAmountAllocated = c.Int(nullable: false),
                        TotalSalaryEpenditure = c.Int(nullable: false),
                        TotalTrainingExpenditure = c.Int(nullable: false),
                        TotalProjectExpenditure = c.Int(nullable: false),
                        TotalHiringExpenditure = c.Int(nullable: false),
                        OverAllExpenditure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MonthlyBudgetId);
            
            CreateTable(
                "dbo.NoticeComments",
                c => new
                    {
                        NoticeCommentId = c.Int(nullable: false, identity: true),
                        NoticeId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        EmployeeName = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.NoticeCommentId);
            
            CreateTable(
                "dbo.NoticeEmployees",
                c => new
                    {
                        NoticeEmployeeId = c.Int(nullable: false, identity: true),
                        NoticeId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NoticeEmployeeId);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        NoticeId = c.Int(nullable: false, identity: true),
                        NoticeTitle = c.String(nullable: false),
                        NoticeDetails = c.String(nullable: false),
                        NoticeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NoticeId);
            
            CreateTable(
                "dbo.Privileges",
                c => new
                    {
                        PrivilegeId = c.Int(nullable: false, identity: true),
                        PrivilegeName = c.String(),
                    })
                .PrimaryKey(t => t.PrivilegeId);
            
            CreateTable(
                "dbo.ProjectEmployees",
                c => new
                    {
                        ProjectEmployeeId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectEmployeeId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false),
                        ProjectDescription = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        SuccessRate = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.RankHierarchies",
                c => new
                    {
                        RankHierarchyId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        SalaryRankId = c.Int(nullable: false),
                        NextSalaryRankId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RankHierarchyId);
            
            CreateTable(
                "dbo.SalaryComponents",
                c => new
                    {
                        SalaryComponentsId = c.Int(nullable: false, identity: true),
                        ComponentName = c.String(),
                        ComponentValue = c.Int(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.SalaryComponentsId);
            
            CreateTable(
                "dbo.SalaryRanks",
                c => new
                    {
                        SalaryRankId = c.Int(nullable: false, identity: true),
                        RankName = c.String(),
                        RankValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalaryRankId);
            
            CreateTable(
                "dbo.SalgradeHistories",
                c => new
                    {
                        SalgradeHistoryId = c.Int(nullable: false, identity: true),
                        ColumnName = c.String(),
                        PreviousValue = c.String(),
                        NewValue = c.String(),
                        Date = c.DateTime(nullable: false),
                        SalgradetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalgradeHistoryId);
            
            CreateTable(
                "dbo.Salgrades",
                c => new
                    {
                        SalgradeId = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                        LowSalary = c.Int(nullable: false),
                        HighSalary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalgradeId);
            
            CreateTable(
                "dbo.SupportingDocuments",
                c => new
                    {
                        SupportingDocumentId = c.Int(nullable: false, identity: true),
                        SupportingDocumentName = c.String(),
                        SupportingDocumentLink = c.String(),
                        LeaveApplicationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupportingDocumentId);
            
            CreateTable(
                "dbo.TemporaryCVs",
                c => new
                    {
                        TemporaryCVId = c.Int(nullable: false, identity: true),
                        CandidateName = c.String(),
                        CVLink = c.String(),
                        IntervieweeScore = c.Int(nullable: false),
                        HireThreadId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.TemporaryCVId);
            
            CreateTable(
                "dbo.TrainingEmployees",
                c => new
                    {
                        TrainingEmployeeId = c.Int(nullable: false, identity: true),
                        TrainingId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainingEmployeeId);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        TrainingId = c.Int(nullable: false, identity: true),
                        TrainingName = c.String(),
                        TrainingDescription = c.String(maxLength: 1024),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        SuccessRate = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainingId);
            
            CreateTable(
                "dbo.TransportAreas",
                c => new
                    {
                        TransportAreaId = c.Int(nullable: false, identity: true),
                        AreaName = c.String(),
                        Description = c.String(),
                        AreaDemand = c.Int(nullable: false),
                        AssignedCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransportAreaId);
            
            CreateTable(
                "dbo.TransportAreaVehicles",
                c => new
                    {
                        TransportAreaVehicleId = c.Int(nullable: false, identity: true),
                        TransportAreaId = c.Int(nullable: false),
                        TransportVehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransportAreaVehicleId);
            
            CreateTable(
                "dbo.TransportVehicles",
                c => new
                    {
                        TransportVehicleId = c.Int(nullable: false, identity: true),
                        VehicleNumber = c.String(),
                        DriverName = c.String(),
                        Capacity = c.Int(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.TransportVehicleId);
            
            CreateTable(
                "dbo.WorkDays",
                c => new
                    {
                        WorkDayId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ExtraTimeInMinutes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkDayId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkDays");
            DropTable("dbo.TransportVehicles");
            DropTable("dbo.TransportAreaVehicles");
            DropTable("dbo.TransportAreas");
            DropTable("dbo.Trainings");
            DropTable("dbo.TrainingEmployees");
            DropTable("dbo.TemporaryCVs");
            DropTable("dbo.SupportingDocuments");
            DropTable("dbo.Salgrades");
            DropTable("dbo.SalgradeHistories");
            DropTable("dbo.SalaryRanks");
            DropTable("dbo.SalaryComponents");
            DropTable("dbo.RankHierarchies");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectEmployees");
            DropTable("dbo.Privileges");
            DropTable("dbo.Notices");
            DropTable("dbo.NoticeEmployees");
            DropTable("dbo.NoticeComments");
            DropTable("dbo.MonthlyBudgets");
            DropTable("dbo.LeaveApplications");
            DropTable("dbo.LeaveApplicationCategories");
            DropTable("dbo.Bonuses");
            DropTable("dbo.Interviews");
            DropTable("dbo.Interviewees");
            DropTable("dbo.HireThreads");
            DropTable("dbo.HireRequests");
            DropTable("dbo.EquipmentTypes");
            DropTable("dbo.EquipmentTransactions");
            DropTable("dbo.Equipments");
            DropTable("dbo.EquipmentAndDepartments");
            DropTable("dbo.EmployeeTransportAreas");
            DropTable("dbo.EmployeeSalaries");
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeePrivileges");
            DropTable("dbo.EmployeePerformanceMetrics");
            DropTable("dbo.EmployeeIdentificationCards");
            DropTable("dbo.EmployeeHistories");
            DropTable("dbo.EmployeeDesignations");
            DropTable("dbo.EmployeeDepartments");
            DropTable("dbo.EmployeeBios");
            DropTable("dbo.EmployeeAttendances");
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
            DropTable("dbo.DepartmentHistories");
            DropTable("dbo.DepartmentDesignations");
            DropTable("dbo.CompanyPolicies");
            DropTable("dbo.CircularTemplates");
            DropTable("dbo.BudgetTransactions");
            DropTable("dbo.Bonus");
            DropTable("dbo.Attendances");
            DropTable("dbo.AdvertiserLists");
        }
    }
}
