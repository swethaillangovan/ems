
/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 19-07-2024 08:49:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[DeleteEmployee]
    @Id INT
AS
BEGIN
    DELETE FROM Employees WHERE Id = @Id
END
GO


