SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Donovan Maasz
-- Create date: 28/05/2016
-- Description:	Script for inserting actions into the database
-- =============================================
CREATE PROCEDURE insertAction
	-- Add the parameters for the stored procedure here
	@actionName VARCHAR(MAX) = '',
	@actionStatus VARCHAR(MAX) = '',
	@projectId INT = 0

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO [dbo].[Actions]
           ([ActionDesc]
           ,[ProjectsProject_Id]
		   ,[Status])
     VALUES
           (@actionName
           ,@projectId
		   ,@actionStatus)

END
GO
