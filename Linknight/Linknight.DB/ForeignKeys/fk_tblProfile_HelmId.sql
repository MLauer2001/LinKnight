ALTER TABLE [dbo].[tblProfile]
	ADD CONSTRAINT [fk_tblProfile_HelmId]
	FOREIGN KEY (HelmId)
	REFERENCES [tblHelm] (Id)
