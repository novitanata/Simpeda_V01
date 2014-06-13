
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/13/2014 21:07:48
-- Generated from EDMX file: G:\hihi\net\SIMPEDA_V01\SIMPEDA_V01\Models\Simpeda.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Simpeda];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Dosen_JurusanInstansi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dosen] DROP CONSTRAINT [FK_Dosen_JurusanInstansi];
GO
IF OBJECT_ID(N'[dbo].[FK_Mahasiswa_JurusanInstansi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mahasiswa] DROP CONSTRAINT [FK_Mahasiswa_JurusanInstansi];
GO
IF OBJECT_ID(N'[dbo].[FK_Pegawai_JurusanInstansi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pegawai] DROP CONSTRAINT [FK_Pegawai_JurusanInstansi];
GO
IF OBJECT_ID(N'[dbo].[FK_Sepeda_Shelter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sepeda] DROP CONSTRAINT [FK_Sepeda_Shelter];
GO
IF OBJECT_ID(N'[dbo].[FK_Transaksi_Dosen1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaksi] DROP CONSTRAINT [FK_Transaksi_Dosen1];
GO
IF OBJECT_ID(N'[dbo].[FK_Transaksi_Mahasiswa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaksi] DROP CONSTRAINT [FK_Transaksi_Mahasiswa];
GO
IF OBJECT_ID(N'[dbo].[FK_Transaksi_Pegawai]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaksi] DROP CONSTRAINT [FK_Transaksi_Pegawai];
GO
IF OBJECT_ID(N'[dbo].[FK_Transaksi_Sepeda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaksi] DROP CONSTRAINT [FK_Transaksi_Sepeda];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Dosen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dosen];
GO
IF OBJECT_ID(N'[dbo].[JurusanInstansi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JurusanInstansi];
GO
IF OBJECT_ID(N'[dbo].[Mahasiswa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mahasiswa];
GO
IF OBJECT_ID(N'[dbo].[Pegawai]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pegawai];
GO
IF OBJECT_ID(N'[dbo].[Sepeda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sepeda];
GO
IF OBJECT_ID(N'[dbo].[Shelter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Shelter];
GO
IF OBJECT_ID(N'[dbo].[Transaksi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transaksi];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Dosens'
CREATE TABLE [dbo].[Dosens] (
    [NIP] varchar(50)  NOT NULL,
    [idJurusan] int  NOT NULL,
    [namaDosen] varchar(50)  NOT NULL,
    [teleponDosen] varchar(50)  NOT NULL,
    [alamatDosen] varchar(50)  NOT NULL,
    [emailDosen] varchar(50)  NOT NULL,
    [poinPunishmentDosen] int  NULL,
    [barcodeImageDosen] varchar(max)  NULL,
    [barcodeDosen] nvarchar(50)  NULL
);
GO

-- Creating table 'JurusanInstansis'
CREATE TABLE [dbo].[JurusanInstansis] (
    [idJurusan] int  NOT NULL,
    [namaJurusan] varchar(50)  NOT NULL,
    [alamatJurusan] varchar(50)  NOT NULL,
    [teleponJurusan] varchar(50)  NOT NULL
);
GO

-- Creating table 'Mahasiswas'
CREATE TABLE [dbo].[Mahasiswas] (
    [NRP] varchar(50)  NOT NULL,
    [idJurusan] int  NOT NULL,
    [namaMhs] varchar(50)  NOT NULL,
    [teleponMhs] varchar(50)  NOT NULL,
    [alamatMhs] varchar(50)  NOT NULL,
    [emailMhs] varchar(50)  NOT NULL,
    [poinPunishmentMhs] int  NULL,
    [barcodeImageMhs] varchar(max)  NULL,
    [barcodeMhs] nvarchar(50)  NULL
);
GO

-- Creating table 'Pegawais'
CREATE TABLE [dbo].[Pegawais] (
    [idPegawai] varchar(50)  NOT NULL,
    [idJurusan] int  NOT NULL,
    [namaPegawai] varchar(50)  NOT NULL,
    [jabatan] varchar(50)  NOT NULL,
    [teleponPegawai] varchar(50)  NOT NULL,
    [alamatPegawai] varchar(50)  NOT NULL,
    [emailPegawai] varchar(50)  NOT NULL,
    [poinPunishmetPegawai] int  NULL,
    [barcodeImagePegawai] varchar(max)  NULL,
    [barcodePegawai] nvarchar(50)  NULL
);
GO

-- Creating table 'Sepedas'
CREATE TABLE [dbo].[Sepedas] (
    [idSepeda] int  NOT NULL,
    [idShelter] int  NOT NULL,
    [merkSepeda] varchar(50)  NOT NULL,
    [warnaSepeda] varchar(50)  NOT NULL,
    [ketersediaan] smallint  NOT NULL,
    [keterangan] varchar(100)  NULL
);
GO

-- Creating table 'Shelters'
CREATE TABLE [dbo].[Shelters] (
    [idShelter] int  NOT NULL,
    [lokasiShelter] varchar(50)  NOT NULL,
    [deskripsiShelter] varchar(max)  NULL,
    [fotoshelter] varchar(255)  NULL
);
GO

-- Creating table 'Transaksis'
CREATE TABLE [dbo].[Transaksis] (
    [idTransaksi] int  NOT NULL,
    [idPeminjamDosen] varchar(50)  NULL,
    [idPeminjamPegawai] varchar(50)  NULL,
    [idPeminjamMhs] varchar(50)  NULL,
    [idSepeda] int  NOT NULL,
    [waktuPinjam] datetime  NULL,
    [waktuKembali] datetime  NULL,
    [status] smallint  NOT NULL,
    [shelterKembali] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [NIP] in table 'Dosens'
ALTER TABLE [dbo].[Dosens]
ADD CONSTRAINT [PK_Dosens]
    PRIMARY KEY CLUSTERED ([NIP] ASC);
GO

-- Creating primary key on [idJurusan] in table 'JurusanInstansis'
ALTER TABLE [dbo].[JurusanInstansis]
ADD CONSTRAINT [PK_JurusanInstansis]
    PRIMARY KEY CLUSTERED ([idJurusan] ASC);
GO

-- Creating primary key on [NRP] in table 'Mahasiswas'
ALTER TABLE [dbo].[Mahasiswas]
ADD CONSTRAINT [PK_Mahasiswas]
    PRIMARY KEY CLUSTERED ([NRP] ASC);
GO

-- Creating primary key on [idPegawai] in table 'Pegawais'
ALTER TABLE [dbo].[Pegawais]
ADD CONSTRAINT [PK_Pegawais]
    PRIMARY KEY CLUSTERED ([idPegawai] ASC);
GO

-- Creating primary key on [idSepeda] in table 'Sepedas'
ALTER TABLE [dbo].[Sepedas]
ADD CONSTRAINT [PK_Sepedas]
    PRIMARY KEY CLUSTERED ([idSepeda] ASC);
GO

-- Creating primary key on [idShelter] in table 'Shelters'
ALTER TABLE [dbo].[Shelters]
ADD CONSTRAINT [PK_Shelters]
    PRIMARY KEY CLUSTERED ([idShelter] ASC);
GO

-- Creating primary key on [idTransaksi] in table 'Transaksis'
ALTER TABLE [dbo].[Transaksis]
ADD CONSTRAINT [PK_Transaksis]
    PRIMARY KEY CLUSTERED ([idTransaksi] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idJurusan] in table 'Dosens'
ALTER TABLE [dbo].[Dosens]
ADD CONSTRAINT [FK_Dosen_JurusanInstansi]
    FOREIGN KEY ([idJurusan])
    REFERENCES [dbo].[JurusanInstansis]
        ([idJurusan])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Dosen_JurusanInstansi'
CREATE INDEX [IX_FK_Dosen_JurusanInstansi]
ON [dbo].[Dosens]
    ([idJurusan]);
GO

-- Creating foreign key on [idPeminjamDosen] in table 'Transaksis'
ALTER TABLE [dbo].[Transaksis]
ADD CONSTRAINT [FK_Transaksi_Dosen1]
    FOREIGN KEY ([idPeminjamDosen])
    REFERENCES [dbo].[Dosens]
        ([NIP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Transaksi_Dosen1'
CREATE INDEX [IX_FK_Transaksi_Dosen1]
ON [dbo].[Transaksis]
    ([idPeminjamDosen]);
GO

-- Creating foreign key on [idJurusan] in table 'Mahasiswas'
ALTER TABLE [dbo].[Mahasiswas]
ADD CONSTRAINT [FK_Mahasiswa_JurusanInstansi]
    FOREIGN KEY ([idJurusan])
    REFERENCES [dbo].[JurusanInstansis]
        ([idJurusan])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Mahasiswa_JurusanInstansi'
CREATE INDEX [IX_FK_Mahasiswa_JurusanInstansi]
ON [dbo].[Mahasiswas]
    ([idJurusan]);
GO

-- Creating foreign key on [idJurusan] in table 'Pegawais'
ALTER TABLE [dbo].[Pegawais]
ADD CONSTRAINT [FK_Pegawai_JurusanInstansi]
    FOREIGN KEY ([idJurusan])
    REFERENCES [dbo].[JurusanInstansis]
        ([idJurusan])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pegawai_JurusanInstansi'
CREATE INDEX [IX_FK_Pegawai_JurusanInstansi]
ON [dbo].[Pegawais]
    ([idJurusan]);
GO

-- Creating foreign key on [idPeminjamMhs] in table 'Transaksis'
ALTER TABLE [dbo].[Transaksis]
ADD CONSTRAINT [FK_Transaksi_Mahasiswa]
    FOREIGN KEY ([idPeminjamMhs])
    REFERENCES [dbo].[Mahasiswas]
        ([NRP])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Transaksi_Mahasiswa'
CREATE INDEX [IX_FK_Transaksi_Mahasiswa]
ON [dbo].[Transaksis]
    ([idPeminjamMhs]);
GO

-- Creating foreign key on [idPeminjamPegawai] in table 'Transaksis'
ALTER TABLE [dbo].[Transaksis]
ADD CONSTRAINT [FK_Transaksi_Pegawai]
    FOREIGN KEY ([idPeminjamPegawai])
    REFERENCES [dbo].[Pegawais]
        ([idPegawai])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Transaksi_Pegawai'
CREATE INDEX [IX_FK_Transaksi_Pegawai]
ON [dbo].[Transaksis]
    ([idPeminjamPegawai]);
GO

-- Creating foreign key on [idShelter] in table 'Sepedas'
ALTER TABLE [dbo].[Sepedas]
ADD CONSTRAINT [FK_Sepeda_Shelter]
    FOREIGN KEY ([idShelter])
    REFERENCES [dbo].[Shelters]
        ([idShelter])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Sepeda_Shelter'
CREATE INDEX [IX_FK_Sepeda_Shelter]
ON [dbo].[Sepedas]
    ([idShelter]);
GO

-- Creating foreign key on [idSepeda] in table 'Transaksis'
ALTER TABLE [dbo].[Transaksis]
ADD CONSTRAINT [FK_Transaksi_Sepeda]
    FOREIGN KEY ([idSepeda])
    REFERENCES [dbo].[Sepedas]
        ([idSepeda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Transaksi_Sepeda'
CREATE INDEX [IX_FK_Transaksi_Sepeda]
ON [dbo].[Transaksis]
    ([idSepeda]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------