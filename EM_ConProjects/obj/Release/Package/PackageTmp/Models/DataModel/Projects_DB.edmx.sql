
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/09/2016 19:18:37
-- Generated from EDMX file: C:\Users\MaddMike\Downloads\M_con\EM_ConProjects\Models\DataModel\Projects_DB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-EM_ConProjects-20160207093155];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_LocalitiesProjects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Localities] DROP CONSTRAINT [FK_LocalitiesProjects];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractorsProjects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contractors] DROP CONSTRAINT [FK_ContractorsProjects];
GO
IF OBJECT_ID(N'[dbo].[FK_ActionsProjects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actions] DROP CONSTRAINT [FK_ActionsProjects];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Localities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Localities];
GO
IF OBJECT_ID(N'[dbo].[Contractors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contractors];
GO
IF OBJECT_ID(N'[dbo].[Actions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Project_Id] int IDENTITY(1,1) NOT NULL,
    [ProjectCode] nvarchar(max)  NOT NULL,
    [ProjectName] nvarchar(max)  NOT NULL,
    [ProjectStatus] nvarchar(max)  NOT NULL,
    [ProjectLeader] nvarchar(max)  NOT NULL,
    [SiteVisits] int  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NULL
);
GO

-- Creating table 'Localities'
CREATE TABLE [dbo].[Localities] (
    [Locality_Id] int IDENTITY(1,1) NOT NULL,
    [LocalityName] nvarchar(max)  NOT NULL,
    [ProjectsProject_Id] int  NOT NULL
);
GO

-- Creating table 'Contractors'
CREATE TABLE [dbo].[Contractors] (
    [Contractor_Id] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [ContractorName] nvarchar(max)  NOT NULL,
    [ContractorSurname] nvarchar(max)  NOT NULL,
    [ContractorTel] nvarchar(max)  NOT NULL,
    [ProjectsProject_Id] int  NOT NULL
);
GO

-- Creating table 'Actions'
CREATE TABLE [dbo].[Actions] (
    [Actions_Id] int IDENTITY(1,1) NOT NULL,
    [ActionDesc] nvarchar(max)  NOT NULL,
    [ProjectsProject_Id] int  NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Project_Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Project_Id] ASC);
GO

-- Creating primary key on [Locality_Id] in table 'Localities'
ALTER TABLE [dbo].[Localities]
ADD CONSTRAINT [PK_Localities]
    PRIMARY KEY CLUSTERED ([Locality_Id] ASC);
GO

-- Creating primary key on [Contractor_Id] in table 'Contractors'
ALTER TABLE [dbo].[Contractors]
ADD CONSTRAINT [PK_Contractors]
    PRIMARY KEY CLUSTERED ([Contractor_Id] ASC);
GO

-- Creating primary key on [Actions_Id] in table 'Actions'
ALTER TABLE [dbo].[Actions]
ADD CONSTRAINT [PK_Actions]
    PRIMARY KEY CLUSTERED ([Actions_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProjectsProject_Id] in table 'Localities'
ALTER TABLE [dbo].[Localities]
ADD CONSTRAINT [FK_LocalitiesProjects]
    FOREIGN KEY ([ProjectsProject_Id])
    REFERENCES [dbo].[Projects]
        ([Project_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocalitiesProjects'
CREATE INDEX [IX_FK_LocalitiesProjects]
ON [dbo].[Localities]
    ([ProjectsProject_Id]);
GO

-- Creating foreign key on [ProjectsProject_Id] in table 'Contractors'
ALTER TABLE [dbo].[Contractors]
ADD CONSTRAINT [FK_ContractorsProjects]
    FOREIGN KEY ([ProjectsProject_Id])
    REFERENCES [dbo].[Projects]
        ([Project_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractorsProjects'
CREATE INDEX [IX_FK_ContractorsProjects]
ON [dbo].[Contractors]
    ([ProjectsProject_Id]);
GO

-- Creating foreign key on [ProjectsProject_Id] in table 'Actions'
ALTER TABLE [dbo].[Actions]
ADD CONSTRAINT [FK_ActionsProjects]
    FOREIGN KEY ([ProjectsProject_Id])
    REFERENCES [dbo].[Projects]
        ([Project_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionsProjects'
CREATE INDEX [IX_FK_ActionsProjects]
ON [dbo].[Actions]
    ([ProjectsProject_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------