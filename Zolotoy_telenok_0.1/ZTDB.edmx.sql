
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/22/2022 14:16:30
-- Generated from EDMX file: C:\Users\zzmin\source\repos\Diplom\Zolotoy_telenok_0.1\ZTDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DbAidar];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Запись_Машина]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Запись] DROP CONSTRAINT [FK_Запись_Машина];
GO
IF OBJECT_ID(N'[dbo].[FK_Запись_Работник]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Запись] DROP CONSTRAINT [FK_Запись_Работник];
GO
IF OBJECT_ID(N'[dbo].[FK_Запись_Услуги]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Запись] DROP CONSTRAINT [FK_Запись_Услуги];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Запись]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Запись];
GO
IF OBJECT_ID(N'[dbo].[Клиент]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Клиент];
GO
IF OBJECT_ID(N'[dbo].[Машина]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Машина];
GO
IF OBJECT_ID(N'[dbo].[Работник]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Работник];
GO
IF OBJECT_ID(N'[dbo].[Услуги]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Услуги];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Запись'
CREATE TABLE [dbo].[Запись] (
    [ИД_Записи] int IDENTITY(1,1) NOT NULL,
    [ИД_Машины] int  NOT NULL,
    [ИД_Работнка] int  NOT NULL,
    [ИД_Услуги] int  NOT NULL,
    [Сумма] decimal(19,4)  NULL
);
GO

-- Creating table 'Клиент'
CREATE TABLE [dbo].[Клиент] (
    [ИД_Клиента] int IDENTITY(1,1) NOT NULL,
    [Номер_авто] nvarchar(50)  NULL
);
GO

-- Creating table 'Машина'
CREATE TABLE [dbo].[Машина] (
    [ИД_Машины] int IDENTITY(1,1) NOT NULL,
    [Марка] nvarchar(50)  NOT NULL,
    [Модель] nvarchar(50)  NOT NULL,
    [Класс] int  NOT NULL
);
GO

-- Creating table 'Работник'
CREATE TABLE [dbo].[Работник] (
    [ИД_Работника] int IDENTITY(1,1) NOT NULL,
    [Фамилия] nvarchar(50)  NOT NULL,
    [Имя] nvarchar(50)  NOT NULL,
    [Отчество] nvarchar(50)  NOT NULL,
    [Телефон] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Услуги'
CREATE TABLE [dbo].[Услуги] (
    [ИД_Услуги] int IDENTITY(1,1) NOT NULL,
    [Наименование] nvarchar(50)  NOT NULL,
    [Описание] nvarchar(max)  NOT NULL,
    [Цена] decimal(19,4)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ИД_Записи] in table 'Запись'
ALTER TABLE [dbo].[Запись]
ADD CONSTRAINT [PK_Запись]
    PRIMARY KEY CLUSTERED ([ИД_Записи] ASC);
GO

-- Creating primary key on [ИД_Клиента] in table 'Клиент'
ALTER TABLE [dbo].[Клиент]
ADD CONSTRAINT [PK_Клиент]
    PRIMARY KEY CLUSTERED ([ИД_Клиента] ASC);
GO

-- Creating primary key on [ИД_Машины] in table 'Машина'
ALTER TABLE [dbo].[Машина]
ADD CONSTRAINT [PK_Машина]
    PRIMARY KEY CLUSTERED ([ИД_Машины] ASC);
GO

-- Creating primary key on [ИД_Работника] in table 'Работник'
ALTER TABLE [dbo].[Работник]
ADD CONSTRAINT [PK_Работник]
    PRIMARY KEY CLUSTERED ([ИД_Работника] ASC);
GO

-- Creating primary key on [ИД_Услуги] in table 'Услуги'
ALTER TABLE [dbo].[Услуги]
ADD CONSTRAINT [PK_Услуги]
    PRIMARY KEY CLUSTERED ([ИД_Услуги] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ИД_Машины] in table 'Запись'
ALTER TABLE [dbo].[Запись]
ADD CONSTRAINT [FK_Запись_Машина]
    FOREIGN KEY ([ИД_Машины])
    REFERENCES [dbo].[Машина]
        ([ИД_Машины])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Запись_Машина'
CREATE INDEX [IX_FK_Запись_Машина]
ON [dbo].[Запись]
    ([ИД_Машины]);
GO

-- Creating foreign key on [ИД_Работнка] in table 'Запись'
ALTER TABLE [dbo].[Запись]
ADD CONSTRAINT [FK_Запись_Работник]
    FOREIGN KEY ([ИД_Работнка])
    REFERENCES [dbo].[Работник]
        ([ИД_Работника])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Запись_Работник'
CREATE INDEX [IX_FK_Запись_Работник]
ON [dbo].[Запись]
    ([ИД_Работнка]);
GO

-- Creating foreign key on [ИД_Услуги] in table 'Запись'
ALTER TABLE [dbo].[Запись]
ADD CONSTRAINT [FK_Запись_Услуги]
    FOREIGN KEY ([ИД_Услуги])
    REFERENCES [dbo].[Услуги]
        ([ИД_Услуги])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Запись_Услуги'
CREATE INDEX [IX_FK_Запись_Услуги]
ON [dbo].[Запись]
    ([ИД_Услуги]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------