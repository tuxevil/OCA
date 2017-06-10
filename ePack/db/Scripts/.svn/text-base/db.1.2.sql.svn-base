 set xact_abort on;
go

begin transaction;
go

exec sp_rename 'dbo.Users', 'tmp__Users_0', 'OBJECT';
go

create table dbo.Users(
  UserId                 int           not null identity primary key,
  Profile_Company        nvarchar(100),
  Profile_Industry       nvarchar(100),
  Profile_Website        nvarchar(100),
  Profile_Position       nvarchar(100),
  Profile_PrePhone       nchar(10),
  Profile_Phone          nvarchar(100),
  Profile_PreCelPhone    nchar(10),
  Profile_CelPhone       nvarchar(100),
  Profile_CuitNumber     nvarchar(100),
  Profile_OcaNumber      nvarchar(100),
  Profile_ContactMe      bit,
  Profile_GetInformation bit,
  Profile_PostalCode     nvarchar(100),
  Profile_City           nvarchar(100),
  InternetActivityId     int,
  UserName               nvarchar(100) not null unique,
  Password               nvarchar(100) not null,
  PasswordSalt           nvarchar(100),
  Email                  nvarchar(100) not null,
  FirstName              nvarchar(100) not null,
  LastName               nvarchar(100) not null,
  Status                 int           not null,
  CompanyId              int
);
go

set identity_insert dbo.Users on;
go

insert into dbo.Users(UserId,Profile_Company,Profile_Industry,Profile_Website,Profile_Position,Profile_Phone,Profile_CelPhone,Profile_CuitNumber,Profile_OcaNumber,Profile_ContactMe,Profile_GetInformation,InternetActivityId,UserName,Password,PasswordSalt,Email,FirstName,LastName,Status,CompanyId) select UserId,Profile_Company,Profile_Industry,Profile_Website,Profile_Position,Profile_Phone,Profile_CelPhone,Profile_CuitNumber,Profile_OcaNumber,Profile_ContactMe,Profile_GetInformation,InternetActivityId,UserName,Password,PasswordSalt,Email,FirstName,LastName,Status,CompanyId from dbo.tmp__Users_0;
go

set identity_insert dbo.Users off;
go

drop table dbo.tmp__Users_0;
go

commit;
go