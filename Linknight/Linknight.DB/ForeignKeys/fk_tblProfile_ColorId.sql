ALTER TABLE [dbo].[tblProfile]
	ADD CONSTRAINT [fk_tblProfile_ColorId]
	FOREIGN KEY (ColorId)
	REFERENCES [tblColor] (Id)
