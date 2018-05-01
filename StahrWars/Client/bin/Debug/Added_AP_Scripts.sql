USE [AP]
GO

/*******************************************************************************************************************************/
CREATE TABLE [dbo].[ErrorLog](
	[errorLogId]		[int]			NOT NULL	IDENTITY(1,1)  PRIMARY KEY,
	[ERROR_NUMBER]		[int]			NOT NULL,
	[ERROR_SEVERITY]	[int]			NOT NULL,
	[ERROR_STATE]		[int]			NOT NULL,
	[ERROR_LINE]		[int]			NOT NULL,
	[ERROR_PROCEDURE]	[varchar](50)	NOT NULL,
	[ERROR_MESSAGE]		[varchar](500)	NOT NULL,
	[errorDate]			[datetime]		NOT NULL,
	[fixedDate]			[datetime]		NULL		DEFAULT (getdate())
)
GO


/*******************************************************************************************************************************/
CREATE PROCEDURE [dbo].[spRecordError] 
AS
BEGIN
	BEGIN TRY
		INSERT INTO ErrorLog (ERROR_NUMBER,ERROR_SEVERITY,ERROR_STATE,ERROR_PROCEDURE,ERROR_LINE,ERROR_MESSAGE)
		SELECT ERROR_NUMBER(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE(), ERROR_MESSAGE()
	END TRY BEGIN CATCH END CATCH
END
GO

/*******************************************************************************************************************************/
CREATE PROCEDURE [dbo].[spAddUpdateDelete_Invoice]
	 @InvoiceID			[int]
	,@VendorID			[int]
	,@InvoiceNumber		[varchar](50)
	,@InvoiceDate		[smalldatetime]
	,@InvoiceTotal		[money]
	,@PaymentTotal		[money]
	,@CreditTotal		[money]
	,@TermsID			[int]
	,@InvoiceDueDate	[smalldatetime]
	,@PaymentDate		[smalldatetime]
	,@isDeleted			[bit]
	,@hardDelete		[bit] = 0
AS
BEGIN
	BEGIN TRAN
		BEGIN TRY
			--==================================================================== DELETE
			IF(@hardDelete = 1) BEGIN											
				DELETE FROM InvoiceLineItems WHERE InvoiceID = @InvoiceID
				DELETE FROM Invoices WHERE InvoiceID = @InvoiceID
				SELECT [InvoiceID] = 0, [ErroCode] = 0, [ErroMsg] = ''
			
			--==================================================================== ADD
			END ELSE IF(@InvoiceID = 0) BEGIN									
				IF NOT EXISTS(SELECT NULL FROM Invoices WHERE InvoiceNumber = @InvoiceNumber) AND
					   EXISTS(SELECT NULL FROM Vendors WHERE VendorID = @VendorID) AND
					   EXISTS(SELECT NULL FROM Terms WHERE TermsID = @TermsID) BEGIN

					   INSERT INTO Invoices (VendorID,InvoiceNumber,InvoiceDate,InvoiceTotal,PaymentTotal,CreditTotal,TermsID,InvoiceDueDate,PaymentDate,isDeleted)
					   VALUES (@VendorID,@InvoiceNumber,@InvoiceDate,@InvoiceTotal,@PaymentTotal,@CreditTotal,@TermsID,@InvoiceDueDate,@PaymentDate,0)

					   SELECT [InvoiceID] = @@IDENTITY, [ErroCode] = 0, [ErroMsg] = ''
				END ELSE BEGIN
					SELECT [InvoiceID] = 0, [ErroCode] = 1, [ErroMsg] = 'Invoice Number alread used OR VendorID/TermsID not found in dB.'
				END

			--==================================================================== UPDATE
			END ELSE IF(@InvoiceID > 0) BEGIN
				IF		EXISTS(SELECT NULL FROM Invoices WHERE (InvoiceNumber = @InvoiceNumber) AND (InvoiceID = @InvoiceID)) AND
						EXISTS(SELECT NULL FROM Vendors WHERE VendorID = @VendorID) AND
						EXISTS(SELECT NULL FROM Terms WHERE TermsID = @TermsID) BEGIN

					UPDATE Invoices SET VendorID = @VendorID, InvoiceDate = @InvoiceDate, InvoiceTotal = @InvoiceTotal, PaymentTotal = @PaymentTotal,
										CreditTotal = @CreditTotal, TermsID = @TermsID, InvoiceDueDate = @InvoiceDueDate, PaymentDate = @PaymentDate,
										isDeleted = @isDeleted
					WHERE InvoiceID = @InvoiceID
					SELECT [InvoiceID] = @InvoiceID, [ErroCode] = 0, [ErroMsg] = ''

				END ELSE BEGIN
					SELECT [InvoiceID] = @InvoiceID, [ErroCode] = 1, [ErroMsg] = 'Update didn''t work. Possible issue with VerndorID/TermsID, or InvoiceNumber'
				END

			END ELSE BEGIN
				SELECT [InvoiceID] = @InvoiceID, [ErroCode] = 1, [ErroMsg] = ''
			END
		END TRY BEGIN CATCH
			IF(@@TRANCOUNT > 0) ROLLBACK TRAN;
			EXEC spRecordError;
		END CATCH
	IF(@@TRANCOUNT > 0) COMMIT TRAN;
END
GO