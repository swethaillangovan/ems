
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetEmployeeBySearch] 
    @Text nvarchar(200)
AS
BEGIN
    SELECT * FROM Employees WHERE Name Like '%'+@Text+'%'
END
GO