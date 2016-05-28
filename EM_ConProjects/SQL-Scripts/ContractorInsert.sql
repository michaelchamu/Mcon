SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Donovan Maasz
-- Create date: 28/05/2016
-- Description:	Script for inserting contractors into the database
-- =============================================
CREATE PROCEDURE insertContractor 
	-- Add the parameters for the stored procedure here
	@companyName VARCHAR(MAX) = '',
	@contractorName VARCHAR(MAX) = '',
	@contractorSurname VARCHAR(MAX) = '',
	@contractorTel VARCHAR(MAX) = '',
	@projectId INT = 0

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Contractors]
           ([CompanyName]
           ,[ContractorName]
           ,[ContractorSurname]
           ,[ContractorTel]
           ,[ProjectsProject_Id])
     VALUES
           (@companyName
           ,@contractorName
           ,@contractorSurname
           ,@contractorTel
           ,@projectId)

END
GO
