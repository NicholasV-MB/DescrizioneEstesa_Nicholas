Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.BasicFunctionsProxy

Module StaticExpressions

    'This placeholder is for static expression table
	'OriginalExpression: 'IsDirectory(ProcPath()+"LOG/")
	<Extension()>
	Public Function Eval_Static_Set_log_dir_exists_K_468(ByVal Main As RDCompiledProcess) As Object
		return IsDirectory(ProcPath()+"LOG/")
	End Function

	'Condition for group MAKE DIR
	'OriginalExpression: 'log_dir_exists
	<Extension()>
	Public Function Eval_Static_CondExp1_K_470(ByVal Main As RDCompiledProcess) As Object
		return log_dir_exists
	End Function

	'OriginalExpression: 'ProcPath()+"LOG"
	<Extension()>
	Public Function Eval_Static_FolderPath_K_469(ByVal Main As RDCompiledProcess) As Object
		return ProcPath()+"LOG"
	End Function

	'OriginalExpression: 'PDMConnString
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_233(ByVal Main As RDCompiledProcess) As Object
		return PDMConnString
	End Function

	'OriginalExpression: 'query
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_233(ByVal Main As RDCompiledProcess) As Object
		return query
	End Function

	'OriginalExpression: 'SAGEConnString
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_261(ByVal Main As RDCompiledProcess) As Object
		return SAGEConnString
	End Function

	'OriginalExpression: '"SELECT YDESEST_0 from MBKPROD.ITMMASTER WHERE ITMREF_0='"+List_PROPCOD_fromPDM(i).codCodice+"'"
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_261(ByVal Main As RDCompiledProcess) As Object
		return "SELECT YDESEST_0 from MBKPROD.ITMMASTER WHERE ITMREF_0='"+List_PROPCOD_fromPDM(i).codCodice+"'"
	End Function

	'Condition for group: TROVATA DESC EST SU SAGE DIVERSA
	'OriginalExpression: 'Trim(DescEst)<>Trim(List_PROPCOD_fromPDM(i).propValore)
	<Extension()>
	Public Function Eval_Static_CondExp1_K_238(ByVal Main As RDCompiledProcess) As Object
		return Trim(DescEst)<>Trim(List_PROPCOD_fromPDM(i).propValore)
	End Function

	'Condition for group: TROVATA DESC EST SU SAGE DIVERSA
	'OriginalExpression: 'Trim(DescEst)<>" "
	<Extension()>
	Public Function Eval_Static_CondExp2_K_238(ByVal Main As RDCompiledProcess) As Object
		return Trim(DescEst)<>" "
	End Function

	'OriginalExpression: 'ProcPath()+"LOG/LISTA_ITMREF_DA_AGGIORNARE_SU_PDM.log"
	<Extension()>
	Public Function Eval_Static_FileName_K_595(ByVal Main As RDCompiledProcess) As Object
		return ProcPath()+"LOG/LISTA_ITMREF_DA_AGGIORNARE_SU_PDM.log"
	End Function

	'OriginalExpression: 'PROPCOD.codCodice
	<Extension()>
	Public Function Eval_Static_TextLine_K_595(ByVal Main As RDCompiledProcess) As Object
		return PROPCOD.codCodice
	End Function

	'OriginalExpression: 'PDMConnString
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_604(ByVal Main As RDCompiledProcess) As Object
		return PDMConnString
	End Function

	'OriginalExpression: 'query
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_604(ByVal Main As RDCompiledProcess) As Object
		return query
	End Function

	'OriginalExpression: 'ProcPath()+"LOG/LISTA_ITMREF_DA_AGGIORNARE_SU_PDM__NoCampo369.log"
	<Extension()>
	Public Function Eval_Static_FileName_K_609(ByVal Main As RDCompiledProcess) As Object
		return ProcPath()+"LOG/LISTA_ITMREF_DA_AGGIORNARE_SU_PDM__NoCampo369.log"
	End Function

	'OriginalExpression: 'ITMREF
	<Extension()>
	Public Function Eval_Static_TextLine_K_609(ByVal Main As RDCompiledProcess) As Object
		return ITMREF
	End Function



End Module
