/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 19-07-2024 08:53:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateEmployee]
    @Id INT,
    @Name NVARCHAR(100),
    @Position NVARCHAR(100),
    @Department NVARCHAR(100),
    @Salary DECIMAL(18, 2)
AS
BEGIN
    UPDATE Employees
    SET Name = @Name, Position = @Position, Department = @Department, Salary = @Salary
    WHERE Id = @Id
END

GO


