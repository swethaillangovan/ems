/****** Object:  StoredProcedure [dbo].[GetAllEmployees]    Script Date: 19-07-2024 08:50:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAllEmployees]
    @Page INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM Employees
    ORDER BY Id
    OFFSET (@Page - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    SELECT COUNT(*) AS TotalCount
    FROM Employees;
END
GO


