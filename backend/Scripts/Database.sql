CREATE DATABASE BUILTCODE_DOCTOR
GO

USE BUILTCODE_DOCTOR
GO

CREATE TABLE dbo.MEDICO(
      ID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	NOME VARCHAR(255) NOT NULL,
	CRM VARCHAR(60) NOT NULL,
      CRM_UF VARCHAR(10) NOT NULL
)
GO

CREATE TABLE dbo.PACIENTE(
      ID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	NOME VARCHAR(255) NOT NULL,
	CPF VARCHAR(60) NOT NULL,
	DATA_NASCIMENTO DATETIME NOT NULL
)
GO


INSERT INTO dbo.MEDICO
           (NOME
           ,CRM
           ,CRM_UF)
     VALUES
           ('MÉDICO 1'
           ,'31337'
           ,'SP'
           )

INSERT INTO dbo.MEDICO
           (NOME
           ,CRM
           ,CRM_UF)
     VALUES
           ('MÉDICO 2'
           ,'314149'
           ,'RJ'
           )
GO

INSERT INTO dbo.PACIENTE
           (NOME
           ,CPF
           ,DATA_NASCIMENTO)
     VALUES
           ('PACIENTE 1'
           ,'12345678909'
           ,GETDATE()-30*12*30
           )        

GO

SELECT * FROM dbo.PACIENTE 
SELECT * FROM dbo.MEDICO