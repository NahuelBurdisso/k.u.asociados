
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/12/2016 15:05:56
-- Generated from EDMX file: C:\Users\Usuario1\Desktop\Facultad\Capacitacion\TrabajoPráctico\Webpage\k.u.asociados\kuasociados\kuasociados.Data\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Kuasociados];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_LawyersSpecialties]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People_Lawyers] DROP CONSTRAINT [FK_LawyersSpecialties];
GO
IF OBJECT_ID(N'[dbo].[FK_CasesStates]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StatesSet] DROP CONSTRAINT [FK_CasesStates];
GO
IF OBJECT_ID(N'[dbo].[FK_LawyersCases]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CasesSet] DROP CONSTRAINT [FK_LawyersCases];
GO
IF OBJECT_ID(N'[dbo].[FK_NotificationsLawyers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NotificationsSet] DROP CONSTRAINT [FK_NotificationsLawyers];
GO
IF OBJECT_ID(N'[dbo].[FK_CasesClients]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CasesSet] DROP CONSTRAINT [FK_CasesClients];
GO
IF OBJECT_ID(N'[dbo].[FK_Lawyers_inherits_People]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People_Lawyers] DROP CONSTRAINT [FK_Lawyers_inherits_People];
GO
IF OBJECT_ID(N'[dbo].[FK_Clients_inherits_People]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People_Clients] DROP CONSTRAINT [FK_Clients_inherits_People];
GO
IF OBJECT_ID(N'[dbo].[FK_Employees_inherits_People]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People_Employees] DROP CONSTRAINT [FK_Employees_inherits_People];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[SpecialtiesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpecialtiesSet];
GO
IF OBJECT_ID(N'[dbo].[CasesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CasesSet];
GO
IF OBJECT_ID(N'[dbo].[StatesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatesSet];
GO
IF OBJECT_ID(N'[dbo].[NewsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NewsSet];
GO
IF OBJECT_ID(N'[dbo].[NotificationsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NotificationsSet];
GO
IF OBJECT_ID(N'[dbo].[People_Lawyers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People_Lawyers];
GO
IF OBJECT_ID(N'[dbo].[People_Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People_Clients];
GO
IF OBJECT_ID(N'[dbo].[People_Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People_Employees];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] int  NOT NULL,
    [FirstName] nchar(10)  NOT NULL,
    [LastName] nchar(10)  NOT NULL,
    [Email] nchar(50)  NOT NULL,
    [Dni] nchar(10)  NOT NULL,
    [BornDate] datetime  NOT NULL,
    [Gender] nchar(1)  NOT NULL,
    [Tel] nchar(20)  NOT NULL,
    [ProfileImg] nvarchar(max)  NULL
);
GO

-- Creating table 'SpecialtiesSet'
CREATE TABLE [dbo].[SpecialtiesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CasesSet'
CREATE TABLE [dbo].[CasesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InitiationDate] datetime  NOT NULL,
    [LawyersId] int  NOT NULL,
    [ClientsId] int  NOT NULL
);
GO

-- Creating table 'StatesSet'
CREATE TABLE [dbo].[StatesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [InitiationDate] datetime  NOT NULL,
    [Comment] nvarchar(max)  NULL,
    [CasesId] int  NOT NULL
);
GO

-- Creating table 'NewsSet'
CREATE TABLE [dbo].[NewsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Subtitle] nvarchar(max)  NOT NULL,
    [Img] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [PublishDate] datetime  NOT NULL,
    [Author] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NotificationsSet'
CREATE TABLE [dbo].[NotificationsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [LawyersId] int  NOT NULL
);
GO

-- Creating table 'People_Lawyers'
CREATE TABLE [dbo].[People_Lawyers] (
    [SpecialtiesId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'People_Clients'
CREATE TABLE [dbo].[People_Clients] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'People_Employees'
CREATE TABLE [dbo].[People_Employees] (
    [Job] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpecialtiesSet'
ALTER TABLE [dbo].[SpecialtiesSet]
ADD CONSTRAINT [PK_SpecialtiesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CasesSet'
ALTER TABLE [dbo].[CasesSet]
ADD CONSTRAINT [PK_CasesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StatesSet'
ALTER TABLE [dbo].[StatesSet]
ADD CONSTRAINT [PK_StatesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NewsSet'
ALTER TABLE [dbo].[NewsSet]
ADD CONSTRAINT [PK_NewsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NotificationsSet'
ALTER TABLE [dbo].[NotificationsSet]
ADD CONSTRAINT [PK_NotificationsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People_Lawyers'
ALTER TABLE [dbo].[People_Lawyers]
ADD CONSTRAINT [PK_People_Lawyers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People_Clients'
ALTER TABLE [dbo].[People_Clients]
ADD CONSTRAINT [PK_People_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People_Employees'
ALTER TABLE [dbo].[People_Employees]
ADD CONSTRAINT [PK_People_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SpecialtiesId] in table 'People_Lawyers'
ALTER TABLE [dbo].[People_Lawyers]
ADD CONSTRAINT [FK_LawyersSpecialties]
    FOREIGN KEY ([SpecialtiesId])
    REFERENCES [dbo].[SpecialtiesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LawyersSpecialties'
CREATE INDEX [IX_FK_LawyersSpecialties]
ON [dbo].[People_Lawyers]
    ([SpecialtiesId]);
GO

-- Creating foreign key on [CasesId] in table 'StatesSet'
ALTER TABLE [dbo].[StatesSet]
ADD CONSTRAINT [FK_CasesStates]
    FOREIGN KEY ([CasesId])
    REFERENCES [dbo].[CasesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CasesStates'
CREATE INDEX [IX_FK_CasesStates]
ON [dbo].[StatesSet]
    ([CasesId]);
GO

-- Creating foreign key on [LawyersId] in table 'CasesSet'
ALTER TABLE [dbo].[CasesSet]
ADD CONSTRAINT [FK_LawyersCases]
    FOREIGN KEY ([LawyersId])
    REFERENCES [dbo].[People_Lawyers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LawyersCases'
CREATE INDEX [IX_FK_LawyersCases]
ON [dbo].[CasesSet]
    ([LawyersId]);
GO

-- Creating foreign key on [LawyersId] in table 'NotificationsSet'
ALTER TABLE [dbo].[NotificationsSet]
ADD CONSTRAINT [FK_NotificationsLawyers]
    FOREIGN KEY ([LawyersId])
    REFERENCES [dbo].[People_Lawyers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NotificationsLawyers'
CREATE INDEX [IX_FK_NotificationsLawyers]
ON [dbo].[NotificationsSet]
    ([LawyersId]);
GO

-- Creating foreign key on [ClientsId] in table 'CasesSet'
ALTER TABLE [dbo].[CasesSet]
ADD CONSTRAINT [FK_CasesClients]
    FOREIGN KEY ([ClientsId])
    REFERENCES [dbo].[People_Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CasesClients'
CREATE INDEX [IX_FK_CasesClients]
ON [dbo].[CasesSet]
    ([ClientsId]);
GO

-- Creating foreign key on [Id] in table 'People_Lawyers'
ALTER TABLE [dbo].[People_Lawyers]
ADD CONSTRAINT [FK_Lawyers_inherits_People]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'People_Clients'
ALTER TABLE [dbo].[People_Clients]
ADD CONSTRAINT [FK_Clients_inherits_People]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'People_Employees'
ALTER TABLE [dbo].[People_Employees]
ADD CONSTRAINT [FK_Employees_inherits_People]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------