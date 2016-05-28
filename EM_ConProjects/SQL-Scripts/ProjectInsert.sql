SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Donovan Maasz
-- Create date: 28/05/2016
-- Description:	Script for inserting project into the database
-- =============================================
CREATE PROCEDURE insertProject 
	-- Add the parameters for the stored procedure here
	@projectCode VARCHAR(MAX) = '', 
	@projectName VARCHAR(MAX) = '', 
	@projectStatus VARCHAR(MAX) = '', 
	@projectLeader VARCHAR(MAX) = '', 
	@projectSiteVisits INT = 0,
	@projectStartDate DATETIME, 
	@projectEndDate DATETIME, 
	@projectActualVisits INT = 0,
	@projectId INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Projects]
           ([ProjectCode]
           ,[ProjectName]
           ,[ProjectStatus]
           ,[ProjectLeader]
           ,[SiteVisits]
		   ,[StartDate]
		   ,[EndDate]
		   ,[ActualVisits])
     VALUES
           (@projectCode
           ,@projectName
           ,@projectStatus
           ,@projectLeader
           ,@projectSiteVisits
		   ,@projectStartDate
		   ,@projectEndDate
		   ,@projectActualVisits)

	SET @projectId = IDENT_CURRENT( 'Projects' )

	--This will return the last inserted ID in the database
	RETURN @projectId

END
GO
