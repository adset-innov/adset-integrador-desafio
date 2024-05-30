BEGIN TRAN
BEGIN TRY

	INSERT INTO [dbo].[Opcional] (Nome) VALUES
	('Ar Condicionado'),
	('Alarme'),
	('Airbag'),
	('Freio ABS');

    COMMIT

END TRY
BEGIN CATCH

    PRINT ERROR_MESSAGE()
    ROLLBACK

END CATCH
