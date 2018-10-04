/*


						BdTp_Feugere_Adipietro_Garrach.sql - Creation de la bd BdTpFeugere_Adipietro_Garrach


*/
GO

set nocount    on
set dateformat mdy

USE master

declare @dttm varchar(55)
select  @dttm=convert(varchar,getdate(),113)
raiserror('BdTp_Feugere_Adipietro_Garrach.sql at %s ....',1,1,@dttm) with nowait

GO

if exists (select * from sysdatabases where name='BdTpFeugere_Adipietro_Garrach')
begin
  raiserror('Dropping existing BdTpFeugere_Adipietro_Garrach database ....',0,1)
  DROP database BdTpFeugere_Adipietro_Garrach
end
GO

CHECKPOINT
go

raiserror('Creating BdTpFeugere_Adipietro_Garrach database....',0,1)
go
/*
   If SQL Server 4.2, 6.0, or 6.5, create a 3MB database.
   Use default size with autogrow if SQL Server 7.0 or later.
*/

IF (CHARINDEX('4.2', @@version) > 0 OR
    CHARINDEX('6.00', @@version) > 0 OR
    CHARINDEX('6.50', @@version) > 0 )

   CREATE DATABASE BdTpFeugere_Adipietro_Garrach
ELSE
   CREATE DATABASE BdTpFeugere_Adipietro_Garrach
GO

CHECKPOINT

GO

USE BdTpFeugere_Adipietro_Garrach

GO

if db_name() <> 'BdTpFeugere_Adipietro_Garrach'
   raiserror('Error in BdTp_Feugere_Adipietro_Garrach.sql, ''USE BdTpFeugere_Adipietro_Garrach'' failed!  Killing the SPID now.'
            ,22,127) with log

GO

CREATE TABLE Users
(
   Id					int				IDENTITY(1,1)				NOT NULL,
   Login				varchar(25)									NOT NULL,
   Password				varchar(25)									NOT NULL,
   
   Constraint PK_Users PRIMARY KEY (Id)
   
)

GO

CREATE TABLE Contact
(
   Id					int				IDENTITY(1,1)				NOT NULL,
   Nom					varchar(25)									NOT NULL,
   Prenom				varchar(25)									NOT NULL,
   Adresse				varchar(30)									NOT NULL,
   Ville				varchar(30)									NOT NULL,
   Etat					varchar(30)									NOT NULL,
   Pays					varchar(30)									NOT NULL,
   Telephone			varchar(13)									NULL
   CHECK (
					   Telephone like '([0-9][0-9][0-9])[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'
					),
	IdUser				int											NOT NULL,
   
   Constraint PK_Contact PRIMARY KEY (Id),
   FOREIGN KEY (IdUser) REFERENCES Users(Id)
)

GO

insert Users values ('toto', '123456')
insert Users values ('tata', 'abcd')

insert Contact values ('Toto','Toto', '1 Place Ville-Marie', 'Montréal', 'QC', 'Canada', '(514)999-9999',1)
insert Contact values ('Tata','Tata', '2 Place Ville-Marie', 'Montréal', 'QC', 'Canada', '(514)999-9998',1)
insert Contact values ('Titi','Titi', '3 Place Ville-Marie', 'Montréal', 'QC', 'Canada', '(514)999-9997',2)
GO

select * from Contact where IdUser = 1
