CREATE PROCEDURE [dbo].[spGetProfile]
AS
	SELECT p.Id, p.Name, l.LobbyKey, h.HelmType, a.ArmorType, c.ColorType
	FROM tblProfile p
	JOIN tblArmor a on p.ArmorId = a.Id
	JOIN tblColor c on p.ColorId = c.Id
	JOIN tblHelm h on p.HelmId = h.Id
	JOIN tblLobby l on p.LobbyId = l.Id
RETURN 0
