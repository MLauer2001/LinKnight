CREATE PROCEDURE [dbo].[spGetVideos]
AS
	SELECT v.Id, v.VideoURL, l.LobbyKey
	FROM tblVideo v
	JOIN tblLobby l on v.LobbyId = l.Id
RETURN 0
