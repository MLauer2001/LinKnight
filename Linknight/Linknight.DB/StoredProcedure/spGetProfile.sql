CREATE PROCEDURE [dbo].[spGetProfile]
AS
	SELECT p.Id, p.Name, l.LobbyKey, c.Color
	FROM tblProfile p
	JOIN tblCharacter c on p.CharacterId = c.Id
	JOIN tblLobby l on p.LobbyId = l.Id
RETURN 0
