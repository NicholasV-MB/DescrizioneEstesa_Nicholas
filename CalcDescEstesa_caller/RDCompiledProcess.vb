Imports System
Imports System.Collections
Imports System.Reflection
Imports RuleDesigner.Configurator.Core.RDCoreCompiler
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.CompilerUtil
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.BasicFunctionsProxy

Public Module GlobalScope

    Public _CurrentNode As String = ""
    Public _ExitTarget As String = ""
    Public _ActionResult As ActionResult = Nothing

    Public ReadOnly Property _Main() As RDCompiledProcess
        Get
            Return CompiledProcessMain
        End Get
    End Property

    Public ReadOnly Property _Param() As RDFunctionParam
        Get
            Return CompiledProcessState.ParamVar
        End Get
    End Property

    Public ReadOnly Property _Me() As Object
        Get
            Return CompiledProcessState.MeVar
        End Get
    End Property

End Module

Public Class RDCompiledProcess
    Implements IRDCompiledProcess

#Region " --- STANDARD INFRASTRUCTURE "

    Public ReadOnly Property StaticExpressionsType As Type Implements IRDCompiledProcess.StaticExpressionsType
        Get
            Return GetType(StaticExpressions)
        End Get
    End Property

    Public ReadOnly Property GlobalVarsType As Type Implements IRDCompiledProcess.GlobalVarsType
        Get
            Return GetType(GlobalVars)
        End Get
    End Property

    'Public ReadOnly Property GetDLL As String Implements IRDCompiledProcess.GetDLL
    '    Get
    '        Return Assembly.GetExecutingAssembly().Location
    '    End Get
    'End Property

<RuleDesignerAttribute(IsSystem:=True)>
    Public Sub Main(ByVal Parameters As Generic.List(Of RDParamValue)) Implements IRDCompiledProcess.Main
        Try
			'Recompile removing this comment to debug in VisualStudio
			'Debugger.Launch
			''''
10:         CompilerUtil.ClearGlobalVars(Me)
30:         CompilerUtil.SetInputParameters(Me, Parameters)
			''''
40:         Call ProcessMain()
			''''
50:         CompilerUtil.SetOutputParameters(Me, Parameters)
60:         CompilerUtil.CheckExitTarget(_ExitTarget)
			''''
        Catch ex As Exception
			if _CurrentNode <> "" then
				CompilerUtil.RaiseException(_CurrentNode, ex)
			else
				CompilerUtil.RaiseException(ex.Message)
			end if
        End Try
    End Sub

#End Region

#Region " --- PROCESS DECLARATIONS "

    Private Sub ProcessMain()
		LogFileName = EvalExpression("Set_LogFileName_K_738")


        'CALL TO MAIN PROCESS
        Call Main_Group_K_0008()

    End Sub

#Region " --- PROCESS FUNCTIONS TABLE "



#End Region

#End Region

#Region " --- PROCESS CODE TABLE "

	'Main Group *LOG_DISABLED
	Private Sub Main_Group_K_0008()
		_CurrentNode = "RDK:0008"
		'If IsEmpty(URL) is True
		Call IFTHENELSE_K_50645054()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Login e SnapShot *ERROR_PROTECTED
		Call Login_e_SnapShot_K_50645063()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Open DB Connection
		_CurrentNode = "RDK:654"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_654 as New Generic.list(of object)
		ActionArgs_K_654.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_654.Add(EvalExpression("ConnectionString_K_654")) 'ConnectionString IN
		ActionArgs_K_654.Add(-1) 'Transaction IN
		ActionArgs_K_654.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_654 As object() = ActionArgs_K_654.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_654)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Open DB Connection
		_CurrentNode = "RDK:656"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_656 as New Generic.list(of object)
		ActionArgs_K_656.Add("DB_SAGE") 'ConnectionName IN
		ActionArgs_K_656.Add(EvalExpression("ConnectionString_K_656")) 'ConnectionString IN
		ActionArgs_K_656.Add(-1) 'Transaction IN
		ActionArgs_K_656.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_656 As object() = ActionArgs_K_656.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_656)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Set upd_rows = 0
		_CurrentNode = "RDK:576"
		upd_rows = EvalConstant(upd_rows.GetType, "0")
		
		_CurrentNode = "RDK:606"
		'----------------- Select Case Input.Tipo_agg
		Dim _CaseTaken as boolean = false
		Dim _SelectValue as object = EvalExpression("SwitchExpr_K_606")
		
		'CASE A
		Call CASEGROUP_K_599(_SelectValue, _CaseTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'CASE F
		Call CASEGROUP_K_602(_SelectValue, _CaseTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'CASE T
		Call CASEGROUP_K_605(_SelectValue, _CaseTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'---------------- End Select
		'FOREACH ITMREF IN List_ITMREF BYREF
		Call FOREACHLOOP_K_651()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Close DB Connection
		_CurrentNode = "RDK:662"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_662 as New Generic.list(of object)
		ActionArgs_K_662.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_662.Add(-1) 'Transaction IN
		Dim _ActionArgs_K_662 As object() = ActionArgs_K_662.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_662)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Close DB Connection
		_CurrentNode = "RDK:660"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_660 as New Generic.list(of object)
		ActionArgs_K_660.Add("DB_SAGE") 'ConnectionName IN
		ActionArgs_K_660.Add(-1) 'Transaction IN
		Dim _ActionArgs_K_660 As object() = ActionArgs_K_660.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_660)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'If IsEmpty(URL) is True
	Private Sub IFTHENELSE_K_50645054()
		_CurrentNode = "RDK:50645054"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_50645054")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If IsEmpty(URL) is True
			Call THENGROUP_K_50645053()

		End if
	End Sub

	'If IsEmpty(URL) is True
	Private Sub THENGROUP_K_50645053()
		_CurrentNode = "RDK:50645053"
		'Set URL = http://testsint.modulblok.com/FUSIONTEST/
		_CurrentNode = "RDK:50645052"
		URL = EvalConstant(URL.GetType, "http://testsint.modulblok.com/FUSIONTEST/")
		
	End Sub

	'Login e SnapShot *ERROR_PROTECTED
	Private Sub Login_e_SnapShot_K_50645063()
		_CurrentNode = "RDK:50645063"
		'Login
		_CurrentNode = "RDK:50645061"		'ACTION RDEngineering_FUSIONLogin
		Dim ActionArgs_K_50645061 as New Generic.list(of object)
		ActionArgs_K_50645061.Add(0) 'loginType IN
		ActionArgs_K_50645061.Add("001") 'companyID IN
		ActionArgs_K_50645061.Add("configuratoruser") 'username IN
		ActionArgs_K_50645061.Add("configuratoruser") 'password IN
		ActionArgs_K_50645061.Add(Nothing) 'contextID IN
		ActionArgs_K_50645061.Add(Nothing) 'pdmUrl IN
		ActionArgs_K_50645061.Add(Nothing) 'docUrl IN
		ActionArgs_K_50645061.Add(EvalExpression("serverUrl_K_50645061")) 'serverUrl IN
		ActionArgs_K_50645061.Add(LoginSuccess) 'success OUT
		ActionArgs_K_50645061.Add(Nothing) 'outContextID OUT
		ActionArgs_K_50645061.Add(Nothing) 'options IN
		Dim _ActionArgs_K_50645061 As object() = ActionArgs_K_50645061.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_RULEDESIGNER","RDEngineering_FUSIONLogin",_ActionArgs_K_50645061)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		LoginSuccess = _ActionArgs_K_50645061(8)		'OUT
		
		'Check Login <LoginSuccess is False>
		Call Check_Login_K_50645062()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

	End Sub

	'Check Login <LoginSuccess is False>
	Private Sub Check_Login_K_50645062()
		_CurrentNode = "RDK:50645062"
		'Group Conditions
		Dim _GroupExecute As Boolean = NOT EvalExpression("CondExp1_K_50645062")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
	End Sub

	'CASE A
	Private Sub CASEGROUP_K_599(ByVal _SelectValue As object, ByRef _CaseTaken As Boolean)
		_CurrentNode = "RDK:599"
		if NOT _SelectValue = "A" then
			return
		end if
		_CaseTaken = True
		'Add List_ITMREF <-- Input.ITMREF
		_CurrentNode = "RDK:597"
		List_ITMREF.Add(CompilerUtil.Clone(EvalExpression("ListAddItem_K_597")))
		'Set LogFileName = LogFileName+"_"+Input.ITMREF+".log"
		_CurrentNode = "RDK:598"
		LogFileName = EvalExpression("Set_LogFileName_K_598")
		
	End Sub

	'CASE F
	Private Sub CASEGROUP_K_602(ByVal _SelectValue As object, ByRef _CaseTaken As Boolean)
		_CurrentNode = "RDK:602"
		if NOT _SelectValue = "F" then
			return
		end if
		_CaseTaken = True
		'Select DB Values
		_CurrentNode = "RDK:600"		'ACTION RDEngineering_DBSelect
		Dim ActionArgs_K_600 as New Generic.list(of object)
		ActionArgs_K_600.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_600.Add(EvalExpression("SelectQuery_K_600")) 'SelectQuery IN
		ActionArgs_K_600.Add(2) 'SelectQueryType IN
		ActionArgs_K_600.Add(Nothing) 'FirstValue OUT
		ActionArgs_K_600.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_600.Add(List_ITMREF) 'AllRows OUT
		ActionArgs_K_600.Add(Nothing) 'FirstColumn OUT
		ActionArgs_K_600.Add(Nothing) 'NumRows OUT
		ActionArgs_K_600.Add(Nothing) 'ColumnHeader OUT
		ActionArgs_K_600.Add(Nothing) 'ColumnHeaders OUT
		ActionArgs_K_600.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_600 As object() = ActionArgs_K_600.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelect",_ActionArgs_K_600)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		List_ITMREF = _ActionArgs_K_600(5)		'OUT
		
		'Set LogFileName = LogFileName+"_"+Input.TipoArt+".log"
		_CurrentNode = "RDK:601"
		LogFileName = EvalExpression("Set_LogFileName_K_601")
		
	End Sub

	'CASE T
	Private Sub CASEGROUP_K_605(ByVal _SelectValue As object, ByRef _CaseTaken As Boolean)
		_CurrentNode = "RDK:605"
		if NOT _SelectValue = "T" then
			return
		end if
		_CaseTaken = True
		'Select DB Values
		_CurrentNode = "RDK:603"		'ACTION RDEngineering_DBSelect
		Dim ActionArgs_K_603 as New Generic.list(of object)
		ActionArgs_K_603.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_603.Add(EvalExpression("SelectQuery_K_603")) 'SelectQuery IN
		ActionArgs_K_603.Add(2) 'SelectQueryType IN
		ActionArgs_K_603.Add(Nothing) 'FirstValue OUT
		ActionArgs_K_603.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_603.Add(List_ITMREF) 'AllRows OUT
		ActionArgs_K_603.Add(Nothing) 'FirstColumn OUT
		ActionArgs_K_603.Add(Nothing) 'NumRows OUT
		ActionArgs_K_603.Add(Nothing) 'ColumnHeader OUT
		ActionArgs_K_603.Add(Nothing) 'ColumnHeaders OUT
		ActionArgs_K_603.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_603 As object() = ActionArgs_K_603.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelect",_ActionArgs_K_603)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		List_ITMREF = _ActionArgs_K_603(5)		'OUT
		
		'Set LogFileName = LogFileName+"_"+Input.Macrofamiglia+".log"
		_CurrentNode = "RDK:604"
		LogFileName = EvalExpression("Set_LogFileName_K_604")
		
	End Sub

	'FOREACH ITMREF IN List_ITMREF BYREF
	Private Sub FOREACHLOOP_K_651()
		_CurrentNode = "RDK:651"
		Dim Values_RDK_651 as object = EvalExpression("ForEachValues_K_651")
		Dim Index_RDK_651 as integer
		Dim MaxCount_RDK_651 as integer = CompilerUtil.Count(Values_RDK_651)
		If MaxCount_RDK_651 <= 0 then return
		Index_RDK_651 = 0
		i = 1
	next_foreach:
		ITMREF = Values_RDK_651(Index_RDK_651)
		
		'Get Code Prop *ERROR_PROTECTED
		Call Get_Code_Prop_K_634()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'If bResult is False
		Call IFTHENELSE_K_637()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'Append Text Line
		_CurrentNode = "RDK:638"		'ACTION RDEngineering_AppendTextLine
		Dim ActionArgs_K_638 as New Generic.list(of object)
		ActionArgs_K_638.Add(EvalExpression("FileName_K_638")) 'FileName IN
		ActionArgs_K_638.Add(EvalExpression("TextLine_K_638")) 'TextLine IN
		ActionArgs_K_638.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_638 As object() = ActionArgs_K_638.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_FILE_TEXT","RDEngineering_AppendTextLine",_ActionArgs_K_638)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'If OutDescEst<>"" is True
		Call IFTHENELSE_K_650()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		Index_RDK_651 += 1
		If Index_RDK_651 >= MaxCount_RDK_651 then return
		i += 1
		goto next_foreach
	End Sub

	'Get Code Prop *ERROR_PROTECTED
	Private Sub Get_Code_Prop_K_634()
		_CurrentNode = "RDK:634"
		'Get Code Props
		_CurrentNode = "RDK:631"		'ACTION RDEngineering_GetPropsByCode
		Dim ActionArgs_K_631 as New Generic.list(of object)
		ActionArgs_K_631.Add(EvalExpression("Cod_K_631")) 'Cod IN
		ActionArgs_K_631.Add(Nothing) 'Rev IN
		ActionArgs_K_631.Add(2) 'SelectSearchType IN
		ActionArgs_K_631.Add(Nothing) 'FieldNames OUT
		ActionArgs_K_631.Add(Nothing) 'FieldValues OUT
		ActionArgs_K_631.Add(Nothing) 'FoundItemNumber OUT
		ActionArgs_K_631.Add(Nothing) 'FieldName IN
		ActionArgs_K_631.Add(Nothing) 'FieldValue OUT
		ActionArgs_K_631.Add(TABDATI) 'FieldStruct OUT
		ActionArgs_K_631.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_631 As object() = ActionArgs_K_631.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_RULEDESIGNER","RDEngineering_GetPropsByCode",_ActionArgs_K_631)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		TABDATI = _ActionArgs_K_631(8)		'OUT
		
		'Get Code Props
		_CurrentNode = "RDK:632"		'ACTION RDEngineering_GetPropsByCode
		Dim ActionArgs_K_632 as New Generic.list(of object)
		ActionArgs_K_632.Add(EvalExpression("Cod_K_632")) 'Cod IN
		ActionArgs_K_632.Add(Nothing) 'Rev IN
		ActionArgs_K_632.Add(2) 'SelectSearchType IN
		ActionArgs_K_632.Add(Nothing) 'FieldNames OUT
		ActionArgs_K_632.Add(Nothing) 'FieldValues OUT
		ActionArgs_K_632.Add(Nothing) 'FoundItemNumber OUT
		ActionArgs_K_632.Add(Nothing) 'FieldName IN
		ActionArgs_K_632.Add(Nothing) 'FieldValue OUT
		ActionArgs_K_632.Add(TABSAGE) 'FieldStruct OUT
		ActionArgs_K_632.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_632 As object() = ActionArgs_K_632.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_RULEDESIGNER","RDEngineering_GetPropsByCode",_ActionArgs_K_632)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		TABSAGE = _ActionArgs_K_632(8)		'OUT
		
		'Set OutDescEst = NOTHING
		_CurrentNode = "RDK:633"
		OutDescEst = CompilerUtil.CreateInstanceByType(OutDescEst.GetType)
		
	End Sub

	'If bResult is False
	Private Sub IFTHENELSE_K_637()
		_CurrentNode = "RDK:637"
		'Group Conditions
		Dim _GroupExecute As Boolean = NOT EvalExpression("CondExp1_K_637")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If bResult is False
			Call THENGROUP_K_636()

		End if
	End Sub

	'If bResult is False
	Private Sub THENGROUP_K_636()
		_CurrentNode = "RDK:636"
		'Call ../CalcDescEstesa.rdx
		_CurrentNode = "RDK:635"		'PROCESSCALL ../CalcDescEstesa.rdx
		Dim ProcCallFile_K_635 as string = "../CalcDescEstesa.rdx"
		Dim ProcCallOptions_K_635 as string = ""
		Dim ProcArgs_K_635 as New Generic.List(of RDParamValue)
		ProcArgs_K_635.Add(new RDParamValue("ITMREF",EvalExpression("ITMREF_K_635"),RDParamValue.E_RDPAR_DIR.IN)) 'ProcessCall Parameter
		ProcArgs_K_635.Add(new RDParamValue("OutDescEst",OutDescEst,RDParamValue.E_RDPAR_DIR.OUT)) 'ProcessCall Parameter
		ProcArgs_K_635.Add(new RDParamValue("bResult",bResult,RDParamValue.E_RDPAR_DIR.OUT)) 'ProcessCall Parameter
		ProcArgs_K_635.Add(new RDParamValue("ErrorMessage",ErrorMessage,RDParamValue.E_RDPAR_DIR.OUT)) 'ProcessCall Parameter
		ProcArgs_K_635.Add(new RDParamValue("TABDATI",TABDATI,RDParamValue.E_RDPAR_DIR.IN)) 'ProcessCall Parameter
		ProcArgs_K_635.Add(new RDParamValue("TABSAGE",TABSAGE,RDParamValue.E_RDPAR_DIR.IN)) 'ProcessCall Parameter
		ProcArgs_K_635.Add(new RDParamValue("PDMConnString",EvalExpression("PDMConnString_K_635"),RDParamValue.E_RDPAR_DIR.IN)) 'ProcessCall Parameter
		ProcArgs_K_635.Add(new RDParamValue("MBKConnString",EvalExpression("MBKConnString_K_635"),RDParamValue.E_RDPAR_DIR.IN)) 'ProcessCall Parameter
		ProcArgs_K_635.Add(new RDParamValue("URL",EvalExpression("URL_K_635"),RDParamValue.E_RDPAR_DIR.IN)) 'ProcessCall Parameter
		ProcArgs_K_635.Add(new RDParamValue("INTAPG",EvalExpression("INTAPG_K_635"),RDParamValue.E_RDPAR_DIR.IN)) 'ProcessCall Parameter
		ProcArgs_K_635.Add(new RDParamValue("ESTAPG",EvalExpression("ESTAPG_K_635"),RDParamValue.E_RDPAR_DIR.IN)) 'ProcessCall Parameter
		_ActionResult = CompilerUtil.ExecuteSubProcess(ProcCallFile_K_635,ProcCallOptions_K_635,ProcArgs_K_635)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		OutDescEst = ProcArgs_K_635(1).GetDotNetValue(OutDescEst.GetType)		'OUT
		bResult = ProcArgs_K_635(2).GetDotNetValue(bResult.GetType)		'OUT
		ErrorMessage = ProcArgs_K_635(3).GetDotNetValue(ErrorMessage.GetType)		'OUT
	End Sub

	'If OutDescEst<>"" is True
	Private Sub IFTHENELSE_K_650()
		_CurrentNode = "RDK:650"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_650")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If OutDescEst<>"" is True
			Call THENGROUP_K_647()

		else
			'Set upd_rows = upd_rows+1
			Call ELSEGROUP_K_649()

		End if
	End Sub

	'If OutDescEst<>"" is True
	Private Sub THENGROUP_K_647()
		_CurrentNode = "RDK:647"
		'Set upd_rows = upd_rows+1
		_CurrentNode = "RDK:639"
		upd_rows = EvalExpression("Set_upd_rows_K_639")
		
	End Sub

	'Set upd_rows = upd_rows+1
	Private Sub ELSEGROUP_K_649()
		_CurrentNode = "RDK:649"
	End Sub



#End Region

End Class
