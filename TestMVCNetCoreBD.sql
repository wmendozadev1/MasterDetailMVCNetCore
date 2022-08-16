USE TestMVCNetCoreBD

CREATE TABLE Company ( [Comp_Id] INT IDENTITY(1,1) PRIMARY KEY NOT null, [Comp_Name] nvarchar(max), [Comp_CreateDate] datetime2(7), [Comp_Active] bit )
INSERT INTO Company
VALUES
( N'Empresa X', N'2022-06-19T08:03:09.287', 1 )



SELECT * FROM dbo.Company


----
CREATE TABLE AspNetUsers ( [Id] nvarchar(450), [UserName] nvarchar(256), [NormalizedUserName] nvarchar(256), [Email] nvarchar(256), [NormalizedEmail] nvarchar(256), [EmailConfirmed] bit, [PasswordHash] nvarchar(max), [SecurityStamp] nvarchar(max), [ConcurrencyStamp] nvarchar(max), [PhoneNumber] nvarchar(max), [PhoneNumberConfirmed] bit, [TwoFactorEnabled] bit, [LockoutEnd] datetimeoffset(7), [LockoutEnabled] bit, [AccessFailedCount] int )
INSERT INTO AspNetUsers
VALUES
( N'16c80548-c92a-4028-948e-ac562bb393c9', N'useradmin@gmail.com', N'useradmin@GMAIL.COM', N'useradmin@gmail.com', N'USERADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEI5Po71mcXej8wMR+3O3KqHzFJwWy7Q9TUbjwcgmPvpWFUCDFGIsewDeKCpGTpBs/A==', N'UZPF2DZ6CD5NXKQLTFBUV7MAXF4NCU2Q', N'c6791683-0012-44fa-be5f-f30d510a05ab', NULL, 0, 0, NULL, 1, 0 ), 
( N'34a46103-a0d7-433e-a412-96909b1bfdc3', N'user1@gmail.com', N'user1@GMAIL.COM', N'user1@gmail.com', N'USER1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHEYnoA+OfIT7GFDUFUwaP2GEeQQsbj+y5WPmeqD72BfpGP3F/3P9tn5rcDOm5XfAQ==', N'AMBXPURD5NPZBYA7JGS64NDRQT5TSLIR', N'2086d04b-fe23-4646-8ae1-2ae118591e8c', NULL, 0, 0, NULL, 1, 0 )



----



CREATE TABLE UserCompany ( [UserComp_Id] int IDENTITY(1,1) PRIMARY KEY NOT null, [AspNetUser_Id] nvarchar(max), [Comp_Id] int, [UserComp_CreateDate] datetime2(7), [UserComp_DisableDate] datetime2(7), [UserComp_Active] bit )
INSERT INTO UserCompany
VALUES
(  N'16c80548-c92a-4028-948e-ac562bb393c9', 1, N'2022-06-23T01:39:28.713', NULL, 1 ), 
(  N'9998781b-d48e-4d47-abc3-8656dd686d5f', 1, N'2022-06-23T08:32:45.633', NULL, 1 )


SELECT * FROM dbo.UserCompany

SELECT * FROM dbo.AspNetUsers
SELECT * FROM dbo.Company


SELECT * FROM asp



