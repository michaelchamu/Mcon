SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Donovan Maasz
-- Create date: 28/05/2016
-- Description:	Script for inserting localities into the database
-- =============================================
CREATE PROCEDURE insertLocality
	-- Add the parameters for the stored procedure here
	@localityName VARCHAR(MAX) = '', 
	@projectId INT = 0

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Localities]
           ([LocalityName]
           ,[ProjectsProject_Id])
     VALUES
           (@localityName,
			@projectId)

END
GO
