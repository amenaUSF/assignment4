CREATE TABLE [dbo].[UserReviews] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [name]     NVARCHAR (MAX) NOT NULL,
    [email]    CHAR (50)      NULL,
    [comments] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_UserReviews] PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Vehicle_Years] (
    [year_id]   INT IDENTITY (1, 1) NOT NULL,
    [ModelYear] INT NOT NULL,
    CONSTRAINT [PK_Vehicle_Years] PRIMARY KEY CLUSTERED ([year_id] ASC)
);
CREATE TABLE [dbo].[Vehicle_Models] (
    [model_id] INT            IDENTITY (1, 1) NOT NULL,
    [Model]    NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Vehicle_Models] PRIMARY KEY CLUSTERED ([model_id] ASC)
);

CREATE TABLE [dbo].[Vehicle_Makes] (
    [make_id] INT            IDENTITY (1, 1) NOT NULL,
    [Make]    NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Vehicle_Makes] PRIMARY KEY CLUSTERED ([make_id] ASC)
);

CREATE TABLE [dbo].[Vehicle_Variants] (
    [VehicleId] INT NOT NULL,
    [year_id]   INT NOT NULL,
    [make_id]   INT NOT NULL,
    [model_id]  INT NOT NULL,
    CONSTRAINT [PK_Vehicle_Variants] PRIMARY KEY CLUSTERED ([VehicleId] ASC),
    CONSTRAINT [FK_Vehicle_Variants_Vehicle_Makes_make_id] FOREIGN KEY ([make_id]) REFERENCES [dbo].[Vehicle_Makes] ([make_id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Vehicle_Variants_Vehicle_Models_model_id] FOREIGN KEY ([model_id]) REFERENCES [dbo].[Vehicle_Models] ([model_id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Vehicle_Variants_Vehicle_Years_year_id] FOREIGN KEY ([year_id]) REFERENCES [dbo].[Vehicle_Years] ([year_id]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_Variants_make_id]
    ON [dbo].[Vehicle_Variants]([make_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_Variants_year_id]
    ON [dbo].[Vehicle_Variants]([year_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Vehicle_Variants_model_id]
    ON [dbo].[Vehicle_Variants]([model_id] ASC);

CREATE TABLE [dbo].[Vehicle_Safetyratings] (
    [VehicleId]                     INT            NOT NULL,
    [VehicleDescription]            NVARCHAR (MAX) NULL,
    [OverallRating]                 NVARCHAR (MAX) NULL,
    [OverallFrontCrashRating]       NVARCHAR (MAX) NULL,
    [FrontCrashDriversideRating]    NVARCHAR (MAX) NULL,
    [FrontCrashPassengersideRating] NVARCHAR (MAX) NULL,
    [OverallSideCrashRating]        NVARCHAR (MAX) NULL,
    [SideCrashDriversideRating]     NVARCHAR (MAX) NULL,
    [SideCrashPassengersideRating]  NVARCHAR (MAX) NULL,
    [RolloverRating]                NVARCHAR (MAX) NULL,
    [RolloverPossibility]           NVARCHAR (MAX) NULL,
    [SidePoleCrashRating]           NVARCHAR (MAX) NULL,
    [ComplaintsCount]               NVARCHAR (MAX) NULL,
    [RecallsCount]                  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Vehicle_Safetyratings] PRIMARY KEY CLUSTERED ([VehicleId] ASC)
);
