/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DROP TABLE IF EXISTS dbo.tblProfile
DROP TABLE IF EXISTS dbo.tblVideo
DROP TABLE IF EXISTS dbo.tblLobby
DROP TABLE IF EXISTS dbo.tblCharacter
DROP TABLE IF EXISTS dbo.tblArmor
DROP TABLE IF EXISTS dbo.tblHelm