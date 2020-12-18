Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.BasicFunctionsProxy

Module StaticExpressions

    'This placeholder is for static expression table
	'OriginalExpression: 'ProcPath()+ "LOG\" + File2Base(ProcFile()) + "_"+FormatDate(Now(), "yyyy-MM-dd_HH-mm-ss")
	<Extension()>
	Public Function Eval_Static_Set_LogFileName_K_738(ByVal Main As RDCompiledProcess) As Object
		return ProcPath()+ "LOG\" + File2Base(ProcFile()) + "_"+FormatDate(Now(), "yyyy-MM-dd_HH-mm-ss")
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'IsEmpty(URL)
	<Extension()>
	Public Function Eval_Static_CondExp1_K_50645054(ByVal Main As RDCompiledProcess) As Object
		return IsEmpty(URL)
	End Function

	'OriginalExpression: 'URL
	<Extension()>
	Public Function Eval_Static_serverUrl_K_50645061(ByVal Main As RDCompiledProcess) As Object
		return URL
	End Function

	'Condition for group Check Login
	'OriginalExpression: 'LoginSuccess
	<Extension()>
	Public Function Eval_Static_CondExp1_K_50645062(ByVal Main As RDCompiledProcess) As Object
		return LoginSuccess
	End Function

	'OriginalExpression: 'PDMConnString
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_654(ByVal Main As RDCompiledProcess) As Object
		return PDMConnString
	End Function

	'OriginalExpression: 'SAGEConnString
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_656(ByVal Main As RDCompiledProcess) As Object
		return SAGEConnString
	End Function

	'OriginalExpression: 'Input.Tipo_agg
	<Extension()>
	Public Function Eval_Static_SwitchExpr_K_606(ByVal Main As RDCompiledProcess) As Object
		return Input.Tipo_agg
	End Function

	'OriginalExpression: 'Input.ITMREF
	<Extension()>
	Public Function Eval_Static_ListAddItem_K_597(ByVal Main As RDCompiledProcess) As Object
		return Input.ITMREF
	End Function

	'OriginalExpression: 'LogFileName+"_"+Input.ITMREF+".log"
	<Extension()>
	Public Function Eval_Static_Set_LogFileName_K_598(ByVal Main As RDCompiledProcess) As Object
		return LogFileName+"_"+Input.ITMREF+".log"
	End Function

	'OriginalExpression: '"SELECT codCodice FROM CODICI inner join PROPCOD on PROPCOD.codID = CODICI.codID inner join CAMPI on CAMPI.cpID=PROPCOD.cpID where PROPCOD.propValore = '" + Input.TipoArt + "' and PROPCOD.cpID = '329' and codLastRev=1 and codExtract=0 and coDBackup=0 and codStatus=3 order by codCodice"
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_600(ByVal Main As RDCompiledProcess) As Object
		return "SELECT codCodice FROM CODICI inner join PROPCOD on PROPCOD.codID = CODICI.codID inner join CAMPI on CAMPI.cpID=PROPCOD.cpID where PROPCOD.propValore = '" + Input.TipoArt + "' and PROPCOD.cpID = '329' and codLastRev=1 and codExtract=0 and coDBackup=0 and codStatus=3 order by codCodice"
	End Function

	'OriginalExpression: 'LogFileName+"_"+Input.TipoArt+".log"
	<Extension()>
	Public Function Eval_Static_Set_LogFileName_K_601(ByVal Main As RDCompiledProcess) As Object
		return LogFileName+"_"+Input.TipoArt+".log"
	End Function

	'OriginalExpression: '"select codCodice from CODICI  inner join PROPCOD on PROPCOD.codID = CODICI.codID inner join PROPCOD Y on Y.codID = CODICI.codID where codLastRev=1 and codExtract=0 and coDBackup=0 and codStatus=3 and  (PROPCOD.cpID = '333'  and PROPCOD.PropValore not Like 'K%' and PROPCOD.PropValore not Like '99%' and PROPCOD.PropValore not Like 'VVER%' and PROPCOD.PropValore not Like '\_%' ESCAPE '\'  and PROPCOD.PropValore not Like 'VER%' and PROPCOD.PropValore not Like 'X%' and PROPCOD.PropValore not Like 'Y%' and  PROPCOD.PropValore not Like 'J$$%') and (Y.cpID = '328' and Y.PropValore='" + Input.Macrofamiglia + "')"
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_603(ByVal Main As RDCompiledProcess) As Object
		return "select codCodice from CODICI  inner join PROPCOD on PROPCOD.codID = CODICI.codID inner join PROPCOD Y on Y.codID = CODICI.codID where codLastRev=1 and codExtract=0 and coDBackup=0 and codStatus=3 and  (PROPCOD.cpID = '333'  and PROPCOD.PropValore not Like 'K%' and PROPCOD.PropValore not Like '99%' and PROPCOD.PropValore not Like 'VVER%' and PROPCOD.PropValore not Like '\_%' ESCAPE '\'  and PROPCOD.PropValore not Like 'VER%' and PROPCOD.PropValore not Like 'X%' and PROPCOD.PropValore not Like 'Y%' and  PROPCOD.PropValore not Like 'J$$%') and (Y.cpID = '328' and Y.PropValore='" + Input.Macrofamiglia + "')"
	End Function

	'OriginalExpression: 'LogFileName+"_"+Input.Macrofamiglia+".log"
	<Extension()>
	Public Function Eval_Static_Set_LogFileName_K_604(ByVal Main As RDCompiledProcess) As Object
		return LogFileName+"_"+Input.Macrofamiglia+".log"
	End Function

	'FOREACH ITMREF IN List_ITMREF BYREF
	'OriginalExpression: 'List_ITMREF
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_651(ByVal Main As RDCompiledProcess) As Object
		return List_ITMREF
	End Function

	'OriginalExpression: 'List_ITMREF(i-1)
	<Extension()>
	Public Function Eval_Static_Cod_K_631(ByVal Main As RDCompiledProcess) As Object
		return List_ITMREF(i-1)
	End Function

	'OriginalExpression: 'List_ITMREF(i-1)
	<Extension()>
	Public Function Eval_Static_Cod_K_632(ByVal Main As RDCompiledProcess) As Object
		return List_ITMREF(i-1)
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'bResult
	<Extension()>
	Public Function Eval_Static_CondExp1_K_637(ByVal Main As RDCompiledProcess) As Object
		return bResult
	End Function

	'OriginalExpression: '""
	<Extension()>
	Public Function Eval_Static_ITMREF_K_635(ByVal Main As RDCompiledProcess) As Object
		return ""
	End Function

	'OriginalExpression: 'PDMConnString
	<Extension()>
	Public Function Eval_Static_PDMConnString_K_635(ByVal Main As RDCompiledProcess) As Object
		return PDMConnString
	End Function

	'OriginalExpression: 'MBKConnString
	<Extension()>
	Public Function Eval_Static_MBKConnString_K_635(ByVal Main As RDCompiledProcess) As Object
		return MBKConnString
	End Function

	'OriginalExpression: 'URL
	<Extension()>
	Public Function Eval_Static_URL_K_635(ByVal Main As RDCompiledProcess) As Object
		return URL
	End Function

	'OriginalExpression: 'INTAPG
	<Extension()>
	Public Function Eval_Static_INTAPG_K_635(ByVal Main As RDCompiledProcess) As Object
		return INTAPG
	End Function

	'OriginalExpression: 'ESTAPG
	<Extension()>
	Public Function Eval_Static_ESTAPG_K_635(ByVal Main As RDCompiledProcess) As Object
		return ESTAPG
	End Function

	'OriginalExpression: 'LogFileName
	<Extension()>
	Public Function Eval_Static_FileName_K_638(ByVal Main As RDCompiledProcess) As Object
		return LogFileName
	End Function

	'OriginalExpression: 'ITMREF+":     - bResult: '"+bResult+"'     - OutDescEst: '"+OutDescEst+"'      - ErrorMessage: '"+ErrorMessage+"'" 
	<Extension()>
	Public Function Eval_Static_TextLine_K_638(ByVal Main As RDCompiledProcess) As Object
		return ITMREF+":     - bResult: '"+bResult+"'     - OutDescEst: '"+OutDescEst+"'      - ErrorMessage: '"+ErrorMessage+"'" 
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'OutDescEst<>""
	<Extension()>
	Public Function Eval_Static_CondExp1_K_650(ByVal Main As RDCompiledProcess) As Object
		return OutDescEst<>""
	End Function

	'OriginalExpression: 'upd_rows+1
	<Extension()>
	Public Function Eval_Static_Set_upd_rows_K_639(ByVal Main As RDCompiledProcess) As Object
		return upd_rows+1
	End Function



End Module
