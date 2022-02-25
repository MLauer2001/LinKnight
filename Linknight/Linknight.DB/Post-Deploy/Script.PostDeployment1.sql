/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\DefaultData\Helms.sql
:r .\DefaultData\Armors.sql
:r .\DefaultData\Characters.sql
:r .\DefaultData\Lobbys.sql
:r .\DefaultData\Videos.sql
:r .\DefaultData\Profiles.sql