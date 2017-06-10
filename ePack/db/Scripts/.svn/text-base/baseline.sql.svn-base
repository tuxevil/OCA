set xact_abort on;
go

begin transaction;
go

create table dbo.Blog(
  BlogId  int          not null constraint PK_Blog primary key,
  Title   varchar(50)  not null,
  Address varchar(100) not null
);
go

create table dbo.Companies(
  CompanyId int           not null identity primary key,
  [Name]    nvarchar(100) not null
);
go

create table dbo.Contacts(
  ContactId int           not null identity primary key,
  FirstName nvarchar(100) not null,
  LastName  nvarchar(100) not null,
  Phone     nvarchar(100) not null,
  Email     nvarchar(100) not null,
  Company   nvarchar(100),
  WebSite   nvarchar(100),
  Comment   ntext         not null
);
go

create table dbo.Feed(
  FeedId    int           not null constraint PK_Feed primary key,
  BlogId    int           not null,
  Title     ntext,
  Feed      ntext,
  ImagePath nvarchar(512)
);
go

alter table dbo.Feed add
  constraint FK_Feed_Blog foreign key(BlogId) references dbo.Blog(BlogId);
go

create table dbo.Functions(
  FunctionId int           not null identity primary key,
  [Name]     nvarchar(100) not null,
  SiteId     int
);
go

create table dbo.InternetActivities(
  InternetActivityId int           not null primary key,
  Descrition         nvarchar(100) not null
);
go

create table dbo.Sites(
  SiteId      int           not null identity primary key,
  LegalName   nvarchar(100) not null,
  SiteAddress nvarchar(100) not null unique
);
go

create table dbo.Sites_Users(
  SiteId int not null,
  UserId int not null
);
go

create table dbo.UserRoles(
  UserRoleId int not null primary key,
  Role       int not null,
  UserId     int,
  SiteId     int
);
go

create table dbo.Users(
  UserId                 int           not null identity primary key,
  Profile_Company        nvarchar(100),
  Profile_Industry       nvarchar(100),
  Profile_Website        nvarchar(100),
  Profile_Position       nvarchar(100),
  Profile_Phone          nvarchar(100),
  Profile_CelPhone       nvarchar(100),
  Profile_CuitNumber     nvarchar(100),
  Profile_OcaNumber      nvarchar(100),
  Profile_ContactMe      bit,
  Profile_GetInformation bit,
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

create table dbo.Users_Functions(
  UserId     int not null,
  FunctionId int not null
);
go

alter table dbo.Functions add
  constraint FKF2FCDCF2E1E50039 foreign key(SiteId) references dbo.Sites(SiteId);
go

set identity_insert dbo.Sites on
go

INSERT INTO dbo.Sites
  (SiteId, LegalName, SiteAddress)
  VALUES (1, N'Oca ePak', N'envios.oca.com.ar')
go

set identity_insert dbo.Sites off
go

commit;
go