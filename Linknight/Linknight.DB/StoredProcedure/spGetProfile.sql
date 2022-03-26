CREATE PROCEDURE [dbo].[spGetProfile]
AS
	SELECT p.Id, p.Name, l.LobbyKey, c.Color, a.ArmorType, h.HelmType
	FROM tblProfile p
	JOIN tblColor c on p.ColorId = c.Id
	JOIN tblArmor a on p.ArmorId = a.Id
	JOIN tblHelm h on p.HelmId = h.Id
	JOIN tblLobby l on p.LobbyId = l.Id

RETURN 0
