IF OBJECT_ID(N'dbo.VictorianMaternityRecord', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.VictorianMaternityRecord
    (
        Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_VictorianMaternityRecord PRIMARY KEY,
        LabId INT NOT NULL,
        PatientId INT NOT NULL,
        FormDataJson NVARCHAR(MAX) NOT NULL CONSTRAINT DF_VMR_FormDataJson DEFAULT (N'{}'),
        LastUpdatedBy NVARCHAR(120) NULL,
        LastUpdatedRole NVARCHAR(40) NULL,
        LastUpdatedAt DATETIME2(0) NOT NULL CONSTRAINT DF_VMR_LastUpdatedAt DEFAULT (SYSUTCDATETIME()),
        SupervisorReviewNotes NVARCHAR(MAX) NULL,
        SupervisorReviewedBy NVARCHAR(120) NULL,
        SupervisorReviewedAt DATETIME2(0) NULL,
        CONSTRAINT UQ_VMR_LabPatient UNIQUE (LabId, PatientId),
        CONSTRAINT FK_VMR_Patient FOREIGN KEY (PatientId) REFERENCES dbo.Patient(Id) ON DELETE CASCADE
    );
END;
