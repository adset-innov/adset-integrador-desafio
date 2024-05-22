BEGIN TRAN
BEGIN TRY

	INSERT INTO [dbo].[Opcional] (Id, Nome) VALUES
	(1, 'Ar Condicionado'),
	(2, 'Alarme'),
	(3, 'Airbag'),
	(4, 'Freio ABS');

    COMMIT

END TRY
BEGIN CATCH

    PRINT ERROR_MESSAGE()
    ROLLBACK

END CATCH
