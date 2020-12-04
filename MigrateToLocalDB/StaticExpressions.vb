Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.BasicFunctionsProxy

Module StaticExpressions

    'This placeholder is for static expression table
	'OriginalExpression: 'PDMServer
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_45(ByVal Main As RDCompiledProcess) As Object
		return PDMServer
	End Function

	'OriginalExpression: 'PDMLocal
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_46(ByVal Main As RDCompiledProcess) As Object
		return PDMLocal
	End Function

	'OriginalExpression: '"IF NOT EXISTS (SELECT *             FROM INFORMATION_SCHEMA.TABLES             WHERE TABLE_TYPE='BASE TABLE'             AND TABLE_NAME='CODVAL')" +CreateCODVAL+" ELSE TRUNCATE TABLE CODVAL"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_44(ByVal Main As RDCompiledProcess) As Object
		return "IF NOT EXISTS (SELECT *             FROM INFORMATION_SCHEMA.TABLES             WHERE TABLE_TYPE='BASE TABLE'             AND TABLE_NAME='CODVAL')" +CreateCODVAL+" ELSE TRUNCATE TABLE CODVAL"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'i>1
	<Extension()>
	Public Function Eval_Static_CondExp1_K_258(ByVal Main As RDCompiledProcess) As Object
		return i>1
	End Function

	'OriginalExpression: 'query_insert+","
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_268(ByVal Main As RDCompiledProcess) As Object
		return query_insert+","
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'row(i-1)<>""
	<Extension()>
	Public Function Eval_Static_CondExp1_K_236(ByVal Main As RDCompiledProcess) As Object
		return row(i-1)<>""
	End Function

	'OriginalExpression: 'query_insert+"'"+StrSql(row(i-1))+"'"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_246(ByVal Main As RDCompiledProcess) As Object
		return query_insert+"'"+StrSql(row(i-1))+"'"
	End Function

	'OriginalExpression: 'query_insert+"''"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_257(ByVal Main As RDCompiledProcess) As Object
		return query_insert+"''"
	End Function

	'OriginalExpression: 'query_insert+")"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_288(ByVal Main As RDCompiledProcess) As Object
		return query_insert+")"
	End Function

	'OriginalExpression: 'query_insert
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_58(ByVal Main As RDCompiledProcess) As Object
		return query_insert
	End Function

	'OriginalExpression: '"IF NOT EXISTS (SELECT *             FROM INFORMATION_SCHEMA.TABLES             WHERE TABLE_TYPE='BASE TABLE'             AND TABLE_NAME='CAMPI')" +CreateCAMPI+" ELSE TRUNCATE TABLE CAMPI"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_388(ByVal Main As RDCompiledProcess) As Object
		return "IF NOT EXISTS (SELECT *             FROM INFORMATION_SCHEMA.TABLES             WHERE TABLE_TYPE='BASE TABLE'             AND TABLE_NAME='CAMPI')" +CreateCAMPI+" ELSE TRUNCATE TABLE CAMPI"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'i>1
	<Extension()>
	Public Function Eval_Static_CondExp1_K_393(ByVal Main As RDCompiledProcess) As Object
		return i>1
	End Function

	'OriginalExpression: 'query_insert+","
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_391(ByVal Main As RDCompiledProcess) As Object
		return query_insert+","
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'row(i-1)<>""
	<Extension()>
	Public Function Eval_Static_CondExp1_K_398(ByVal Main As RDCompiledProcess) As Object
		return row(i-1)<>""
	End Function

	'OriginalExpression: 'query_insert+"'"+StrSql(row(i-1))+"'"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_394(ByVal Main As RDCompiledProcess) As Object
		return query_insert+"'"+StrSql(row(i-1))+"'"
	End Function

	'OriginalExpression: 'query_insert+"''"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_396(ByVal Main As RDCompiledProcess) As Object
		return query_insert+"''"
	End Function

	'OriginalExpression: 'query_insert+")"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_400(ByVal Main As RDCompiledProcess) As Object
		return query_insert+")"
	End Function

	'OriginalExpression: 'query_insert
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_401(ByVal Main As RDCompiledProcess) As Object
		return query_insert
	End Function

	'OriginalExpression: '"IF NOT EXISTS (SELECT *             FROM INFORMATION_SCHEMA.TABLES             WHERE TABLE_TYPE='BASE TABLE'             AND TABLE_NAME='CODICI')" +CreateCODICI+" ELSE TRUNCATE TABLE CODICI"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_449(ByVal Main As RDCompiledProcess) As Object
		return "IF NOT EXISTS (SELECT *             FROM INFORMATION_SCHEMA.TABLES             WHERE TABLE_TYPE='BASE TABLE'             AND TABLE_NAME='CODICI')" +CreateCODICI+" ELSE TRUNCATE TABLE CODICI"
	End Function

	'OriginalExpression: 'False
	<Extension()>
	Public Function Eval_Static_Set_endwhile_K_545(ByVal Main As RDCompiledProcess) As Object
		return False
	End Function

	'Condition for group WHILE
	'OriginalExpression: 'endwhile
	<Extension()>
	Public Function Eval_Static_CondExp1_K_575(ByVal Main As RDCompiledProcess) As Object
		return endwhile
	End Function

	'OriginalExpression: '"SELECT * FROM CODICI WHERE  codID>="+RDToString(MinCounter)+" AND codID<"+RDToString(MaxCounter)
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_562(ByVal Main As RDCompiledProcess) As Object
		return "SELECT * FROM CODICI WHERE  codID>="+RDToString(MinCounter)+" AND codID<"+RDToString(MaxCounter)
	End Function

	'OriginalExpression: 'IIF(k=0, True, False)
	<Extension()>
	Public Function Eval_Static_Set_endwhile_K_563(ByVal Main As RDCompiledProcess) As Object
		return IIF(k=0, True, False)
	End Function

	'OriginalExpression: 'MaxCounter
	<Extension()>
	Public Function Eval_Static_Set_MinCounter_K_564(ByVal Main As RDCompiledProcess) As Object
		return MaxCounter
	End Function

	'OriginalExpression: 'MaxCounter+100000
	<Extension()>
	Public Function Eval_Static_Set_MaxCounter_K_565(ByVal Main As RDCompiledProcess) As Object
		return MaxCounter+100000
	End Function

	'OriginalExpression: '"SET DATEFORMAT dmy; INSERT INTO CODICI VALUES("
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_566(ByVal Main As RDCompiledProcess) As Object
		return "SET DATEFORMAT dmy; INSERT INTO CODICI VALUES("
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'j>1
	<Extension()>
	Public Function Eval_Static_CondExp1_K_569(ByVal Main As RDCompiledProcess) As Object
		return j>1
	End Function

	'OriginalExpression: 'query_insert+","
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_567(ByVal Main As RDCompiledProcess) As Object
		return query_insert+","
	End Function

	'OriginalExpression: 'query_insert+IIF(field<>"","'"+StrSql(field)+"'", "null")
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_570(ByVal Main As RDCompiledProcess) As Object
		return query_insert+IIF(field<>"","'"+StrSql(field)+"'", "null")
	End Function

	'OriginalExpression: 'query_insert+")"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_572(ByVal Main As RDCompiledProcess) As Object
		return query_insert+")"
	End Function

	'OriginalExpression: 'query_insert
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_573(ByVal Main As RDCompiledProcess) As Object
		return query_insert
	End Function

	'OriginalExpression: 'False
	<Extension()>
	Public Function Eval_Static_Set_endwhile_K_589(ByVal Main As RDCompiledProcess) As Object
		return False
	End Function

	'Condition for group WHILE
	'OriginalExpression: 'endwhile
	<Extension()>
	Public Function Eval_Static_CondExp1_K_627(ByVal Main As RDCompiledProcess) As Object
		return endwhile
	End Function

	'OriginalExpression: '"SELECT * FROM PROPCOD ORDER BY codID OFFSET "+RDToString(MinCounter)+" ROWS FETCH FIRST 20000 ROWS ONLY"
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_614(ByVal Main As RDCompiledProcess) As Object
		return "SELECT * FROM PROPCOD ORDER BY codID OFFSET "+RDToString(MinCounter)+" ROWS FETCH FIRST 20000 ROWS ONLY"
	End Function

	'OriginalExpression: 'IIF(k=0, True, False)
	<Extension()>
	Public Function Eval_Static_Set_endwhile_K_615(ByVal Main As RDCompiledProcess) As Object
		return IIF(k=0, True, False)
	End Function

	'OriginalExpression: 'MaxCounter
	<Extension()>
	Public Function Eval_Static_Set_MinCounter_K_616(ByVal Main As RDCompiledProcess) As Object
		return MaxCounter
	End Function

	'OriginalExpression: 'MaxCounter+20000
	<Extension()>
	Public Function Eval_Static_Set_MaxCounter_K_617(ByVal Main As RDCompiledProcess) As Object
		return MaxCounter+20000
	End Function

	'OriginalExpression: '"SET DATEFORMAT dmy; INSERT INTO PROPCOD VALUES("
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_618(ByVal Main As RDCompiledProcess) As Object
		return "SET DATEFORMAT dmy; INSERT INTO PROPCOD VALUES("
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'j>1
	<Extension()>
	Public Function Eval_Static_CondExp1_K_621(ByVal Main As RDCompiledProcess) As Object
		return j>1
	End Function

	'OriginalExpression: 'query_insert+","
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_619(ByVal Main As RDCompiledProcess) As Object
		return query_insert+","
	End Function

	'OriginalExpression: 'query_insert+IIF(field<>"","'"+StrSql(StrReplace(field, ",", "."))+"'", "null")
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_622(ByVal Main As RDCompiledProcess) As Object
		return query_insert+IIF(field<>"","'"+StrSql(StrReplace(field, ",", "."))+"'", "null")
	End Function

	'OriginalExpression: 'query_insert+")"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_624(ByVal Main As RDCompiledProcess) As Object
		return query_insert+")"
	End Function

	'OriginalExpression: 'query_insert
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_625(ByVal Main As RDCompiledProcess) As Object
		return query_insert
	End Function

	'OriginalExpression: 'SAGEServer
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_644(ByVal Main As RDCompiledProcess) As Object
		return SAGEServer
	End Function

	'OriginalExpression: 'SAGELocal
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_648(ByVal Main As RDCompiledProcess) As Object
		return SAGELocal
	End Function

	'OriginalExpression: '"IF NOT EXISTS (SELECT *             FROM INFORMATION_SCHEMA.TABLES             WHERE TABLE_TYPE='BASE TABLE'             AND TABLE_NAME='ITMMASTER')" +CreateITMMASTERT+" ELSE TRUNCATE TABLE ITMMASTER"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_658(ByVal Main As RDCompiledProcess) As Object
		return "IF NOT EXISTS (SELECT *             FROM INFORMATION_SCHEMA.TABLES             WHERE TABLE_TYPE='BASE TABLE'             AND TABLE_NAME='ITMMASTER')" +CreateITMMASTERT+" ELSE TRUNCATE TABLE ITMMASTER"
	End Function

	'OriginalExpression: 'False
	<Extension()>
	Public Function Eval_Static_Set_endwhile_K_664(ByVal Main As RDCompiledProcess) As Object
		return False
	End Function

	'Condition for group WHILE
	'OriginalExpression: 'endwhile
	<Extension()>
	Public Function Eval_Static_CondExp1_K_694(ByVal Main As RDCompiledProcess) As Object
		return endwhile
	End Function

	'OriginalExpression: '"SELECT * FROM [MBKPROD].[ITMMASTER] WHERE ROWID>="+RDToString(MinCounter)+" AND ROWID<"+RDToString(MaxCounter)
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_681(ByVal Main As RDCompiledProcess) As Object
		return "SELECT * FROM [MBKPROD].[ITMMASTER] WHERE ROWID>="+RDToString(MinCounter)+" AND ROWID<"+RDToString(MaxCounter)
	End Function

	'OriginalExpression: 'IIF(k=0, True, False)
	<Extension()>
	Public Function Eval_Static_Set_endwhile_K_682(ByVal Main As RDCompiledProcess) As Object
		return IIF(k=0, True, False)
	End Function

	'OriginalExpression: 'MaxCounter
	<Extension()>
	Public Function Eval_Static_Set_MinCounter_K_683(ByVal Main As RDCompiledProcess) As Object
		return MaxCounter
	End Function

	'OriginalExpression: 'MaxCounter+20000
	<Extension()>
	Public Function Eval_Static_Set_MaxCounter_K_684(ByVal Main As RDCompiledProcess) As Object
		return MaxCounter+20000
	End Function

	'OriginalExpression: '"SET IDENTITY_INSERT ITMMASTER ON; SET DATEFORMAT dmy; INSERT INTO ITMMASTER  ("+StrListToStr(headers, ", ")+") VALUES("
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_685(ByVal Main As RDCompiledProcess) As Object
		return "SET IDENTITY_INSERT ITMMASTER ON; SET DATEFORMAT dmy; INSERT INTO ITMMASTER  ("+StrListToStr(headers, ", ")+") VALUES("
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'j>1
	<Extension()>
	Public Function Eval_Static_CondExp1_K_688(ByVal Main As RDCompiledProcess) As Object
		return j>1
	End Function

	'OriginalExpression: 'query_insert+","
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_686(ByVal Main As RDCompiledProcess) As Object
		return query_insert+","
	End Function

	'OriginalExpression: 'query_insert+IIF(field<>"","'"+StrSql(StrReplace(field, ",", "."))+"'", "null")
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_689(ByVal Main As RDCompiledProcess) As Object
		return query_insert+IIF(field<>"","'"+StrSql(StrReplace(field, ",", "."))+"'", "null")
	End Function

	'OriginalExpression: 'query_insert+")"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_691(ByVal Main As RDCompiledProcess) As Object
		return query_insert+")"
	End Function

	'OriginalExpression: 'query_insert
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_692(ByVal Main As RDCompiledProcess) As Object
		return query_insert
	End Function



End Module
