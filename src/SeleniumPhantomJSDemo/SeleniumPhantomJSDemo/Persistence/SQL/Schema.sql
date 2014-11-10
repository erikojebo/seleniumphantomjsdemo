CREATE DATABASE [SeleniumPhantomJSDemo]

GO 

USE [master]

GO

IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'seleniumuser')
DROP LOGIN [seleniumuser]
GO

CREATE LOGIN [seleniumuser] WITH PASSWORD='foobar', DEFAULT_DATABASE=[SeleniumPhantomJSDemo], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

USE [SeleniumPhantomJSDemo]

-- Delete existing user.
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'seleniumuser')
DROP USER [seleniumuser]
GO

CREATE USER [seleniumuser] FOR LOGIN [seleniumuser] WITH DEFAULT_SCHEMA=[dbo]
GO

EXEC sp_addrolemember 'db_datareader', 'seleniumuser'
EXEC sp_addrolemember 'db_datawriter', 'seleniumuser'

GO

CREATE TABLE [dbo].[Customers](
	[Id]				[int] IDENTITY(1,1)	NOT	NULL	PRIMARY KEY,
	[FirstName]			[nvarchar](255)		NOT	NULL,
	[LastName]			[nvarchar](255)		NOT	NULL,
	[Email]				[nvarchar](255)		NOT	NULL	UNIQUE,
	[CreatedDate]		[datetime]			NOT NULL)
GO

