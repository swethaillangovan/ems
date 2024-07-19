/****** Object:  StoredProcedure [dbo].[GetEmployeeById]    Script Date: 19-07-2024 08:52:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetEmployeeById]
    @Id INT
AS
BEGIN
    SELECT * FROM Employees WHERE Id = @Id
END
GO


