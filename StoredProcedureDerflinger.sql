USE Lab3;
GO
CREATE PROCEDURE DerflingerInsertSkill
	@skillName varchar(35),
	@skillDesc varchar(90),
	@lastUpdatedBy varchar(50),
	@lastUpdated date
AS
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Skill]
	([SkillName],
	[SkillDescription],
    [LastUpdatedBy],
	[LastUpdated])
	VALUES 
	(@skillName,
	@skillDesc,
	@lastUpdatedBy,
	@lastUpdated)
GO