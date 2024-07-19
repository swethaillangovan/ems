
/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 19-07-2024 08:45:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[AddEmployee]
    @Name NVARCHAR(100),
    @Position NVARCHAR(100),
    @Department NVARCHAR(100),
    @Salary DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO Employees (Name, Position, Department, Salary)
    VALUES (@Name, @Position, @Department, @Salary)

    SELECT SCOPE_IDENTITY() AS Id
END
GO


