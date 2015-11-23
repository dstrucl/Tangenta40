using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogFile
{
    class SQL_LogTables
    {

                private Log_DBConnection m_LogDB_con = null;



             public SQL_LogTables(Log_DBConnection x_LogDB_con)
             {
                 m_LogDB_con = x_LogDB_con;
             }

             public bool Create_SQL_LogTables()
             {
                 string Err = null;
                 string sDelete_LogConstraints = @"
					IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'Log') 
                                                                AND (CONSTRAINT_NAME = 'fkLog_Log_Type_id'))) ALTER TABLE Log DROP CONSTRAINT fkLog_Log_Type_id;     

                    IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'Log') 
                                                                AND (CONSTRAINT_NAME = 'fkLog_Log_Description_id'))) ALTER TABLE Log DROP CONSTRAINT fkLog_Log_Description_id;     

                    IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'Log') 
                                                                AND (CONSTRAINT_NAME = 'fkLog_Log_Computer_id'))) ALTER TABLE Log DROP CONSTRAINT fkLog_Log_Computer_id;     

                    IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'Log') 
                                                                AND (CONSTRAINT_NAME = 'fkLog_Log_UserName_id'))) ALTER TABLE Log DROP CONSTRAINT fkLog_Log_UserName_id;     

                    IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'Log') 
                                                                AND (CONSTRAINT_NAME = 'fkLog_Log_Program_id'))) ALTER TABLE Log DROP CONSTRAINT fkLog_Log_Program_id;     

                    IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LogFile') 
                                                                AND (CONSTRAINT_NAME = 'fkLogFile_Log_Computer_id'))) ALTER TABLE LogFile DROP CONSTRAINT fkLogFile_Log_Computer_id;     

                    IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LogFile') 
                                                                AND (CONSTRAINT_NAME = 'fkLogFile_Log_UserName_id'))) ALTER TABLE LogFile DROP CONSTRAINT fkLogFile_Log_UserName_id;     

                    IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LogFile') 
                                                                AND (CONSTRAINT_NAME = 'fkLogFile_LogFile_Description_id'))) ALTER TABLE LogFile DROP CONSTRAINT fkLogFile_LogFile_Description_id;

                    IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LogFile') 
                                                                AND (CONSTRAINT_NAME = 'fkLogFile_Log_Program_id'))) ALTER TABLE LogFile DROP CONSTRAINT fkLogFile_Log_Program_id;     

                    IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LogFile') 
                                                                AND (CONSTRAINT_NAME = 'fkLogFile_Log_PathFile_id'))) ALTER TABLE LogFile DROP CONSTRAINT fkLogFile_Log_PathFile_id;     

                    IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'Log') 
                                                                AND (CONSTRAINT_NAME = 'fkLog_LogFile_id'))) ALTER TABLE Log DROP CONSTRAINT fkLog_LogFile_id;     

                    IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LogFile_Attachment') 
                                                                AND (CONSTRAINT_NAME = 'fkLogFile_Attachment_LogFile_id'))) ALTER TABLE LogFile_Attachment DROP CONSTRAINT fkLogFile_Attachment_LogFile_id;     

                    IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LogFile_Attachment') 
                                                                AND (CONSTRAINT_NAME = 'fkLogFile_Attachment_LogFile_Attachment_Type_id'))) ALTER TABLE LogFile_Attachment DROP CONSTRAINT fkLogFile_Attachment_LogFile_Attachment_Type_id;     

                    ";

                 if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sDelete_LogConstraints, null, ref Err))
                 {
                     string sDrop_Tables = @"

                        IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Log') DROP TABLE [Log];

                        IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Log_Type') DROP TABLE Log_Type;

                        IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Log_Description') DROP TABLE Log_Description;

                        IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Log_Computer') DROP TABLE Log_Computer;

                        IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Log_UserName') DROP TABLE Log_UserName;

                        IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Log_Program') DROP TABLE Log_Program;

                        IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LogFile') DROP TABLE LogFile;

                        IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Log_PathFile') DROP TABLE Log_PathFile;

                        IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LogFile_Description') DROP TABLE LogFile_Description;

		                IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LogFile_Attachment') DROP TABLE LogFile_Attachment;

		                IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LogFile_Attachment_Type') DROP TABLE LogFile_Attachment_Type;
                    ";
                     if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sDrop_Tables, null, ref Err))
                     {
                         string sCreateLogTables = @"
					        CREATE TABLE [dbo].[Log_Computer]
					        (
                             [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
                             ComputerName [nvarchar](1000) NOT NULL
                             )

                             CREATE TABLE [dbo].[Log_UserName]
				             (
                             [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
                             UserName [nvarchar](1000) NOT NULL
                             )

                             CREATE TABLE [dbo].[Log_Program]
				             (
                             [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
                             Program [nvarchar](1000) NOT NULL
                             )

                             CREATE TABLE [dbo].[Log_Type]
				             (
                             [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
                             TypeName [nvarchar](1000) NOT NULL
                             )

                             CREATE TABLE [dbo].[Log_Description]
				             (
                             [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
                             [Description] [nvarchar](2000) NOT NULL
                             )

					         CREATE TABLE [dbo].[Log_PathFile]
				             (
                             [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
                             [PathFile] [nvarchar](1024) NOT NULL
                             )

					         CREATE TABLE [dbo].[LogFile_Description]
				             (
                             [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
                             [Description] [nvarchar](2000) NOT NULL
                             )

                             CREATE TABLE [dbo].[LogFile]
				             (
						         [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
						         LogFileImportTime datetime NOT NULL,
						         Log_Computer_id int NOT NULL,
						         Log_UserName_id int NULL,
						         Log_Program_id int NOT NULL,
						         Log_PathFile_id int NOT NULL,
	                             LogFile_Description_id int NULL
					         )

                             CREATE TABLE [dbo].[LogFile_Attachment_Type]
				             (
						         [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
						         Attachment_type [nvarchar](64),
					         )

                             CREATE TABLE [dbo].[LogFile_Attachment]
				             (
						         [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
						         LogFile_id int NOT NULL,
						         LogFile_Attachment_Type_id int NOT NULL,
						         Attachment varbinary(max),
	                             [Description] [nvarchar](2000) NULL
					         )

                             CREATE TABLE [dbo].[Log]
				             (
						         [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
						         LogFile_id int NOT NULL,
						         LogTime datetime NOT NULL,
						         Log_Type_id int NOT NULL,
						         Log_Description_id int NOT NULL
				             )
                            ";
                         if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sCreateLogTables, null, ref Err))
                         {

                             string sCreateLogConstraints = @"
					        ALTER TABLE [dbo].[Log]
                            ADD CONSTRAINT fkLog_Log_Type_id
                            FOREIGN KEY (Log_Type_id) REFERENCES Log_Type(id);

                            ALTER TABLE [dbo].[Log]
                            ADD CONSTRAINT fkLog_Log_Description_id
                            FOREIGN KEY (Log_Description_id) REFERENCES Log_Description(id);


                            ALTER TABLE [dbo].[Log]
                            ADD CONSTRAINT fkLog_LogFile_id
                            FOREIGN KEY (LogFile_id) REFERENCES LogFile(id);

                            ALTER TABLE [dbo].[LogFile_Attachment]
                            ADD CONSTRAINT fkLogFile_Attachment_LogFile_id
                            FOREIGN KEY (LogFile_id) REFERENCES LogFile(id);

                            ALTER TABLE [dbo].[LogFile_Attachment]
                            ADD CONSTRAINT fkLogFile_Attachment_LogFile_Attachment_Type_id
                            FOREIGN KEY (LogFile_Attachment_Type_id) REFERENCES LogFile_Attachment_Type(id);

                            ALTER TABLE [dbo].[LogFile]
                            ADD CONSTRAINT fkLogFile_Log_Computer_id
                            FOREIGN KEY (Log_Computer_id) REFERENCES Log_Computer(id);

                            ALTER TABLE [dbo].[LogFile]
                            ADD CONSTRAINT fkLogFile_Log_UserName_id
                            FOREIGN KEY (Log_UserName_id) REFERENCES Log_UserName(id);

                            ALTER TABLE [dbo].[LogFile]
                            ADD CONSTRAINT fkLogFile_Log_Program_id
                            FOREIGN KEY (Log_Program_id) REFERENCES Log_Program(id);

                            ALTER TABLE [dbo].[LogFile]
                            ADD CONSTRAINT fkLogFile_Log_PathFile_id
                            FOREIGN KEY (Log_PathFile_id) REFERENCES Log_PathFile(id);

                            ALTER TABLE [dbo].[LogFile]
                            ADD CONSTRAINT fkLogFile_LogFile_Description_id
                            FOREIGN KEY (LogFile_Description_id) REFERENCES LogFile_Description(id);

                        ";
                             if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sCreateLogConstraints, null, ref Err))
                             {
                                 string sDrop_Log_VIEW = @"
                                IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS
                                WHERE TABLE_NAME = 'Log_VIEW')
                                BEGIN
                                DROP VIEW Log_VIEW
                                END;
                                ";
                                 if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sDrop_Log_VIEW, null, ref Err))
                                 {
                                     string sCreate_Log_VIEW = @"
                                        CREATE VIEW [dbo].[Log_VIEW] as
                                        SELECT        
			                                        lgf.id as LogFile_id, 
			                                        lg.LogTime as Log_Time, 
			                                        lgt.TypeName as Log_TypeName, 
			                                        lg.Log_Type_id,
			                                        lgd.[Description] as Log_Description,
			                                        lg.Log_Description_id, 
			                                        lgc.ComputerName, 
			                                        lgf.Log_Computer_id, 
			                                        lgu.UserName,
                                                    lgf.Log_UserName_id, 
			                                        lgp.Program, 
			                                        lgf.Log_Program_id,
			                                        lgfd.[Description] as LogFile_Description,
			                                        lgf.LogFile_Description_id
                                        			
                                        FROM  dbo.[LogFile]  lgf
                                        INNER JOIN dbo.Log_Computer lgc ON lgf.Log_Computer_id = lgc.id 
                                        INNER JOIN dbo.Log_Program lgp ON lgf.Log_Program_id = lgp.id 
                                        INNER JOIN dbo.Log_UserName lgu ON lgf.Log_UserName_id = lgu.id
                                        INNER JOIN dbo.[Log] lg on lg.LogFile_id = lgf.id
                                        INNER JOIN dbo.Log_Description lgd ON lg.Log_Description_id = lgd.id 
                                        INNER JOIN dbo.Log_Type lgt ON lg.Log_Type_id = lgt.id
                                        INNER JOIN dbo.LogFile_Description lgfd  ON lgf.LogFile_Description_id = lgfd.id                                        ";
                                     if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sCreate_Log_VIEW, null, ref Err))
                                     {
                                         string sDropProcedure_LogFile_Import = @"
                                          IF EXISTS (
				                                    SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
				                                    WHERE ROUTINE_NAME = 'LogFile_Import'
				                                    AND ROUTINE_SCHEMA = 'dbo'
				                                    AND ROUTINE_TYPE = 'PROCEDURE'
				                                    )
				                                    BEGIN
				                                    DROP PROCEDURE dbo.LogFile_Import
				                                    -- PRINT 'Dropped dbo.LogFile_Import'
				                                    END
                                                        ";
                                         if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sDropProcedure_LogFile_Import, null, ref Err))
                                         {
                                             string sCreate_LogFile_Import = @"
			                                CREATE PROCEDURE [dbo].[LogFile_Import](

			                                @LogComputer nvarchar(264),
			                                @LogProgram nvarchar(264),
			                                @LogUserName nvarchar(264),
			                                @LogPathFile nvarchar(1000),
			                                @Description nvarchar(2000),

			                                @LogFile_id int OUTPUT, 
			                                @Res nvarchar(265) OUTPUT)
	                                        WITH EXECUTE AS CALLER
	                                        AS
	                                        begin
				                                begin try
			                                    BEGIN TRANSACTION
					                                declare @LogComputer_id  int
					                                declare	@LogUserName_id int
					                                declare @LogProgram_id int 
					                                declare @LogPathFile_id int
					                                declare @LogFile_Description_id int

					                                set @LogComputer_id  = null
					                                set	@LogUserName_id = null
					                                set @LogProgram_id = null
					                                set @LogPathFile_id = null;
					                                set @LogFile_Description_id = null;

					                                Select @LogComputer_id = lgc.id from dbo.Log_Computer lgc where lgc.Computername = @LogComputer
					                                if (@LogComputer_id is null)
					                                begin
					                                  insert into Log_Computer 
					                                  (
						                                Computername
					                                  )
					                                  values 
					                                  (
						                                @LogComputer
					                                  )
					                                  set @LogComputer_id = IDENT_CURRENT('Log_Computer')
					                                end

					                                Select @LogUserName_id = lgusr.id from dbo.Log_UserName lgusr where lgusr.UserName = @LogUserName
					                                if (@LogUserName_id is null)
					                                begin
					                                  insert into Log_UserName 
					                                  (
						                                UserName
					                                  )
					                                  values 
					                                  (
						                                @LogUserName
					                                  )
					                                  set @LogUserName_id = IDENT_CURRENT('Log_UserName')
					                                end
                                				
					                                Select @LogProgram_id = lgprg.id from dbo.Log_Program lgprg where lgprg.Program = @LogProgram
					                                if (@LogProgram_id is null)
					                                begin
					                                  insert into Log_Program 
					                                  (
						                                Program
					                                  )
					                                  values 
					                                  (
						                                @LogProgram
					                                  )
					                                  set @LogProgram_id = IDENT_CURRENT('Log_Program')
					                                end

					                                Select @LogPathFile_id = lgpf.id from dbo.Log_PathFile lgpf where lgpf.PathFile = @LogPathFile
					                                if (@LogPathFile_id is null)
					                                begin
					                                  insert into Log_PathFile 
					                                  (
						                                PathFile
					                                  )
					                                  values 
					                                  (
						                                @LogPathFile
					                                  )
					                                  set @LogPathFile_id = IDENT_CURRENT('Log_PathFile')
					                                end

					                                Select @LogFile_Description_id = lgfd.id from dbo.LogFile_Description lgfd where lgfd.[Description] = @Description
					                                if (@LogFile_Description_id is null)
					                                begin
					                                  insert into LogFile_Description 
					                                  (
						                                [Description]
					                                  )
					                                  values 
					                                  (
						                                @Description
					                                  )
					                                  set @LogFile_Description_id = IDENT_CURRENT('LogFile_Description')
					                                end

					                                insert into dbo.LogFile
					                                (
					                                LogFileImportTime,
					                                Log_Computer_id,
					                                Log_UserName_id,
					                                Log_Program_id,
					                                Log_PathFile_id,
					                                LogFile_Description_id
					                                )
					                                values
					                                (
					                                GetDate(),
					                                @LogComputer_id,
					                                @LogUserName_id,
					                                @LogProgram_id,
					                                @LogPathFile_id,
					                                @LogFile_Description_id
					                                )

					                                set @LogFile_id = IDENT_CURRENT('LogFile')
					                                set @Res = 'OK'
					                                COMMIT TRANSACTION
					                                return 0
				                                end try
				                                begin catch
					                                set @Res = 'ERROR in LogFile_Import: ' + ERROR_MESSAGE()
					                                set @LogFile_id = -1
				                                    ROLLBACK
				                                end catch
                                            end
                                            ";
                                             if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sCreate_LogFile_Import, null, ref Err))
                                             {
                                                 string sDropProcedure_LogWrite = @"
                                                  IF EXISTS (
				                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
				                                            WHERE ROUTINE_NAME = 'LogWrite'
				                                            AND ROUTINE_SCHEMA = 'dbo'
				                                            AND ROUTINE_TYPE = 'PROCEDURE'
				                                            )
				                                            BEGIN
				                                            DROP PROCEDURE dbo.LogWrite
				                                            -- PRINT 'Dropped dbo.LogWrite'
				                                            END
                                                                    ";
                                                 if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sDropProcedure_LogWrite, null, ref Err))
                                                 {

                                                     string sCreate_LogWrite = @"
			                                        CREATE PROCEDURE [dbo].[LogWrite](
			                                        @LogFile_id int,		
			                                        @LogTime datetime, 
			                                        @LogType nvarchar(10),		
                                                    @LogDescription nvarchar(2000),		
			                                        @Log_id int OUTPUT, 
			                                        @Res nvarchar(265) OUTPUT)

	                                                WITH EXECUTE AS CALLER
	                                                AS
	                                                begin
				                                        begin try
				                                            BEGIN TRANSACTION
					                                        declare	@LogType_id int
					                                        declare	@LogDescription_id int 

					                                        set	@LogType_id = null
					                                        set	@LogDescription_id = null

					                                        Select @LogType_id = lgtype.id from dbo.Log_Type lgtype where lgtype.TypeName = @LogType
					                                        if (@LogType_id is null)
					                                        begin
					                                          insert into Log_Type 
					                                          (
						                                        TypeName
					                                          )
					                                          values 
					                                          (
						                                        @LogType
					                                          )
					                                          set @LogType_id = IDENT_CURRENT('Log_Type')
					                                        end

					                                        Select @LogDescription_id = lgd.id from dbo.Log_Description lgd where lgd.[Description] = @LogDescription
					                                        if (@LogDescription_id is null)
					                                        begin
					                                          insert into Log_Description 
					                                          (
						                                        [Description]
					                                          )
					                                          values 
					                                          (
						                                        @LogDescription
					                                          )
					                                          set @LogDescription_id = IDENT_CURRENT('Log_Description')
					                                        end


					                                        insert into dbo.[Log]
					                                        (
					                                         LogFile_id,
					                                         LogTime,
	                                                         Log_Type_id,
                                                             Log_Description_id
					                                        )
					                                        values 
					                                        (
					                                        @LogFile_id,
					                                        @LogTime,
					                                        @LogType_id,
					                                        @LogDescription_id
					                                        )
					                                        set @Res = 'OK'
					                                        set @Log_id = IDENT_CURRENT('Log')

					                                        COMMIT TRANSACTION
					                                        return 0

				                                        end try
				                                        begin catch
					                                        set @Res = 'ERROR in LogWrite: ' + ERROR_MESSAGE()
					                                        set @Log_id = -1
				                                            ROLLBACK
				                                            return -1
				                                        end catch
                                                    end
                                                    ";
                                                     if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sCreate_LogWrite, null, ref Err))
                                                     {
                                                         string sDrop_LogFile_VIEW = @"
                                                            IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS
                                                            WHERE TABLE_NAME = 'LogFile_VIEW')
                                                            BEGIN
                                                            DROP VIEW LogFile_VIEW
                                                            END;
                                                            ";
                                                         if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sDrop_LogFile_VIEW, null, ref Err))
                                                         {

                                                             string sCreate_LogFile_VIEW = @"
                                                                CREATE VIEW [dbo].[LogFile_VIEW] as
                                                                SELECT                   
					                                                                     lgf.id,
						                                                                 lgf.LogFileImportTime, 
						                                                                 lgfc.ComputerName, 
						                                                                 lgfd.[Description], 
						                                                                 lgfp.Program, 
						                                                                 lgfpf.PathFile, 
                                                                                         lgfu.UserName,
					                                                                     lgf.Log_Computer_id, 
						                                                                 lgf.Log_UserName_id, 
						                                                                 lgf.Log_Program_id, 
						                                                                 lgf.LogFile_Description_id, 
                                                                                         lgf.Log_PathFile_id 
                                                                FROM            dbo.LogFile lgf 
                                                                INNER JOIN  dbo.Log_Computer lgfc ON lgf.Log_Computer_id = lgfc.id 
                                                                INNER JOIN  dbo.LogFile_Description lgfd ON lgf.LogFile_Description_id = lgfd.id 
                                                                INNER JOIN  dbo.Log_Program lgfp ON lgf.Log_Program_id = lgfp.id 
                                                                INNER JOIN  dbo.Log_PathFile lgfpf ON lgf.Log_PathFile_id = lgfpf.id 
                                                                INNER JOIN  dbo.Log_UserName lgfu ON lgf.Log_UserName_id = lgfu.id
                                                            ";

                                                             if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sCreate_LogFile_VIEW, null, ref Err))
                                                             {
                                                                 string sDrop_LogFile_Attachment_VIEW = @"
                                                                    IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS
                                                                    WHERE TABLE_NAME = 'LogFile_Attachment_VIEW')
                                                                    BEGIN
                                                                    DROP VIEW LogFile_Attachment_VIEW
                                                                    END;
                                                                    ";
                                                                 if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sDrop_LogFile_Attachment_VIEW, null, ref Err))
                                                                 {

                                                                     string sCreate_LogFile_Attachment_VIEW = @"
                                                                            CREATE VIEW [dbo].[LogFile_Attachment_VIEW] as
                                                                            SELECT        
		                                                                                  dbo.LogFile_Attachment.id, 
			                                                                              dbo.LogFile_Attachment.LogFile_id, 
			                                                                              dbo.LogFile_Attachment.Attachment, 
                                                                                          dbo.LogFile_Attachment_Type.Attachment_type,
			                                                                              dbo.LogFile_Attachment.LogFile_Attachment_Type_id
                                                                            FROM            dbo.LogFile_Attachment 
                                                                            INNER JOIN     dbo.LogFile_Attachment_Type ON dbo.LogFile_Attachment.LogFile_Attachment_Type_id = dbo.LogFile_Attachment_Type.id
                                                                            ";
                                                                     if (m_LogDB_con.ExecuteNonQuerySQL_NoMultiTrans(sCreate_LogFile_Attachment_VIEW, null, ref Err))
                                                                     {
                                                                         return true;
                                                                     }
                                                                     else
                                                                     {
                                                                         Error.Show("ERROR:Can not create LogFile_Attachment_VIEW: Err=" + Err);
                                                                     }
                                                                 }
                                                                 else
                                                                 {
                                                                     Error.Show("ERROR:Can not drop LogFile_Attachment_VIEW: Err=" + Err);
                                                                 }
                                                             }
                                                             else
                                                             {
                                                                 Error.Show("ERROR:Can not create LogFile_VIEW: Err=" + Err);
                                                             }
                                                         }
                                                         else
                                                         {
                                                             Error.Show("ERROR:Can not drop LogFile_VIEW: Err=" + Err);
                                                         }

                                                     }
                                                     else
                                                     {
                                                         Error.Show("ERROR:Can not create LogWrite Procedure: Err=" + Err);
                                                     }
                                                 }
                                                 else
                                                 {
                                                     Error.Show("ERROR:Can not drop LogWrite Procedure: Err=" + Err);
                                                 }
                                             }
                                             else
                                             {
                                                 Error.Show("ERROR:Can not create LogFile_Import Procedure: Err=" + Err);
                                             }
                                         }
                                         else
                                         {
                                             Error.Show("ERROR:Can not drop LogFile_Import Procedure: Err=" + Err);
                                         }
                                     }
                                     else
                                     {
                                         Error.Show("ERROR:Can not create Log_VIEW: Err=" + Err);
                                     }
                                 }
                                 else
                                 {
                                     Error.Show("ERROR:Can not drop Log_VIEW: Err=" + Err);
                                 }
                             }
                             else
                             {
                                 Error.Show("ERROR:Can not create LogFile Constraints: Err=" + Err);
                             }
                         }
                         else
                         {
                             Error.Show("ERROR:Can not create LogFile tables: Err=" + Err);
                         }
                     }
                     else
                     {
                         Error.Show("ERROR:Can not drop LogFile tables: Err=" + Err);
                     }
                 }
                 else
                 {
                     Error.Show("ERROR:Can not drop LogFile constraints: Err=" + Err);
                 }
                 return false;
             }
    }
}
