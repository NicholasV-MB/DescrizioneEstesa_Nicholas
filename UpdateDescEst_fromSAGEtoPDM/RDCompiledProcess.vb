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
		PDMConnString = "Provider=sqloledb;Initial Catalog=PDM;Data Source=SRV-DB06\SINT;User Id=sa;Password=Ruled2014;"
		PDMConnString_LOCAL = "Provider=sqloledb;Initial Catalog=PDMTest;Data Source=LAPT-IT07\RULEDESIGNER;User Id=sa;Password=MBOffline$;"
		SAGEConnString = "Provider=sqloledb;Initial Catalog=x3v64;Data Source=SRV-DB01\X3V6;User Id=sa;Password=FormulaDB;"


        'CALL TO MAIN PROCESS
        Call Main_Group_K_0008()

    End Sub

#Region " --- PROCESS FUNCTIONS TABLE "



#End Region

#End Region

#Region " --- PROCESS CODE TABLE "

	'Main Group
	Private Sub Main_Group_K_0008()
		_CurrentNode = "RDK:0008"
		'CHECK LOG DIR
		Call CHECK_LOG_DIR_K_471()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'scrive ITMREF articoli speciali con descrizione estesa di SAGE<>PDM che hanno campo 369
		Call scrive_ITMREF_articoli_speciali_con_descrizione_estesa_di_SAGE__PDM_che_hanno_campo_369_K_220()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'scrive ITMREF di articoli di PDM che non hanno riga con cpID=369
		Call scrive_ITMREF_di_articoli_di_PDM_che_non_hanno_riga_con_cpID_369_K_243()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

	End Sub

	'CHECK LOG DIR
	Private Sub CHECK_LOG_DIR_K_471()
		_CurrentNode = "RDK:471"
		'Set log_dir_exists = IsDirectory(ProcPath()+"LOG/")
		_CurrentNode = "RDK:468"
		log_dir_exists = EvalExpression("Set_log_dir_exists_K_468")
		
		'MAKE DIR <log_dir_exists is False>
		Call MAKE_DIR_K_470()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

	End Sub

	'MAKE DIR <log_dir_exists is False>
	Private Sub MAKE_DIR_K_470()
		_CurrentNode = "RDK:470"
		'Group Conditions
		Dim _GroupExecute As Boolean = NOT EvalExpression("CondExp1_K_470")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		'MakeDir (ProcPath()+"LOG")
		_CurrentNode = "RDK:469"		'ACTION RDEngineering_MakeDir
		Dim ActionArgs_K_469 as New Generic.list(of object)
		ActionArgs_K_469.Add(EvalExpression("FolderPath_K_469")) 'FolderPath IN
		ActionArgs_K_469.Add(Nothing) 'ForceCreation IN
		ActionArgs_K_469.Add(Nothing) 'UseRecycleBin IN
		Dim _ActionArgs_K_469 As object() = ActionArgs_K_469.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_MISC","RDEngineering_MakeDir",_ActionArgs_K_469)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'scrive ITMREF articoli speciali con descrizione estesa di SAGE<>PDM che hanno campo 369
	Private Sub scrive_ITMREF_articoli_speciali_con_descrizione_estesa_di_SAGE__PDM_che_hanno_campo_369_K_220()
		_CurrentNode = "RDK:220"
		'Set query = --Articoli speciali o con codparl speciale presenti in PDM select --top 10 codice as codCodice, codID, cpI... (2777 chars)
		_CurrentNode = "RDK:226"
		query = EvalConstant(query.GetType, "--Articoli speciali o con codparl speciale presenti in PDM ç§select --top 10 ç§codice as codCodice, codID, cpID, propValore from ç§(ç§--Articoli attivi da PDM con campo speciale a siç§SELECT C1.codID as ID, C1.codCodice as codice FROM PDM.dbo.CODICI C1 WITH (NOLOCK)ç§       where C1.codLastRev=1 and C1.codExtract=0 and C1.coDBackup=0 and C1.codStatus=3   --and codCodice ='0029513'ç§       and C1.codID in (SELECT P1.codID from PDM.dbo.PROPCOD P1 WITH (NOLOCK) -- deve essere specialeç§							where P1.propValore='2' ç§								and P1.cpID= (SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK) where cpNome='Speciale'))ç§       and C1.codID not in (SELECT P2.codID from PDM.dbo.PROPCOD P2 WITH (NOLOCK)  -- non deve essere materia primaç§								where P2.cpID= (SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK) where cpNome='CodiceParlante') ç§									and P2.propValore like 'K%')ç§       and C1.codID in (SELECT P3.codID from PDM.dbo.PROPCOD P3 WITH (NOLOCK) --deve essere delle categorie produttiveç§							where P3.cpID= (SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK)where cpNome='Categoria_Sage') ç§								  and P3.propValore  in ('SEMI', 'PROD', 'CLAV', 'COMM', 'ALTRI', 'JVIT'))ç§union allç§-- articoli attivi da pdm che non sono speciali ma che hanno cod parlanet stranoç§SELECT C2.codID as ID, C2.codCodice as codice FROM PDM.dbo.CODICI C2 WITH (NOLOCK)ç§       where  C2.codLastRev=1 and C2.codExtract=0 and C2.coDBackup=0 and C2.codStatus=3 ç§	   and C2.codID in (SELECT P4.codID from PDM.dbo.PROPCOD P4 WITH (NOLOCK) -- non deve essere speciale, ovviamente per erroreç§							where P4.propValore<>'2' ç§								and P4.cpID= (SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK) where cpNome='Speciale'))ç§ç§       and C2.codID in (SELECT P5.codID from PDM.dbo.PROPCOD P5 WITH (NOLOCK) --deve essere delle categorie produttiveç§							where P5.cpID=(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK)where cpNome='Categoria_Sage') ç§								and P5.propValore  in ('SEMI', 'PROD', 'CLAV', 'COMM', 'ALTRI', 'JVIT'))ç§       and C2.codID in (SELECT P6.codID FROM PDM.dbo.PROPCOD P6  WITH (NOLOCK)  --deve avere 5° carattere una lettera come sottoç§								WHERE P6.cpID=(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK) where cpNome='CodiceParlante')ç§									and P6.propValore not like 'K%'ç§									and  (SUBSTRING(P6.propValore, 5, 1)='O' or ç§										SUBSTRING(P6.propValore, 5, 1)='V' or ç§										SUBSTRING(P6.propValore, 5, 1)='C' or ç§										SUBSTRING(P6.propValore, 5, 1)='B' or ç§										SUBSTRING(P6.propValore, 5, 1)='R' or ç§										SUBSTRING(P6.propValore, 5, 1)='S' or ç§										SUBSTRING(P6.propValore, 5, 1)='W')ç§										)ç§) as xxç§Inner Join PDM.dbo.PROPCOD P7 on P7.CodID = xx.ID and P7.cpID = (select cpID from CAMPI where cpNome='DescEstesa')ç§---and (codId='492528' or codID='491759')")
		
		'Select DB Structured
		_CurrentNode = "RDK:233"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_233 as New Generic.list(of object)
		ActionArgs_K_233.Add(EvalExpression("ConnectionName_K_233")) 'ConnectionName IN
		ActionArgs_K_233.Add(1) 'SelectQueryMode IN
		ActionArgs_K_233.Add(Nothing) 'SelectTable IN
		ActionArgs_K_233.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_233.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_233.Add(EvalExpression("SelectQuery_K_233")) 'SelectQuery IN
		ActionArgs_K_233.Add(2) 'SelectQueryType IN
		ActionArgs_K_233.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_233.Add(List_PROPCOD_fromPDM) 'AllRows OUT
		ActionArgs_K_233.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_233 As object() = ActionArgs_K_233.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_233,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		List_PROPCOD_fromPDM = _ActionArgs_K_233(8)		'OUT
		
		'FOREACH PROPCOD IN List_PROPCOD_fromPDM BYREF
		Call FOREACHLOOP_K_231()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'FOREACH PROPCOD IN List_PROPCOD_fromPDM BYREF
	Private Sub FOREACHLOOP_K_231()
		_CurrentNode = "RDK:231"
		Dim Values_RDK_231 as object = List_PROPCOD_fromPDM
		Dim MaxCount_RDK_231 as integer = CompilerUtil.Count(Values_RDK_231)
		If MaxCount_RDK_231 <= 0 then return
		i = 0
	next_foreach:
		PROPCOD = Values_RDK_231(i)
		
		'Select DB Values
		_CurrentNode = "RDK:261"		'ACTION RDEngineering_DBSelect
		Dim ActionArgs_K_261 as New Generic.list(of object)
		ActionArgs_K_261.Add(EvalExpression("ConnectionName_K_261")) 'ConnectionName IN
		ActionArgs_K_261.Add(EvalExpression("SelectQuery_K_261")) 'SelectQuery IN
		ActionArgs_K_261.Add(0) 'SelectQueryType IN
		ActionArgs_K_261.Add(DescEst) 'FirstValue OUT
		ActionArgs_K_261.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_261.Add(Nothing) 'AllRows OUT
		ActionArgs_K_261.Add(Nothing) 'FirstColumn OUT
		ActionArgs_K_261.Add(Nothing) 'NumRows OUT
		ActionArgs_K_261.Add(Nothing) 'ColumnHeader OUT
		ActionArgs_K_261.Add(Nothing) 'ColumnHeaders OUT
		ActionArgs_K_261.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_261 As object() = ActionArgs_K_261.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelect",_ActionArgs_K_261)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		DescEst = _ActionArgs_K_261(3)		'OUT
		
		'TROVATA DESC EST SU SAGE DIVERSA <Trim(DescEst)<>Trim(List_PROPCOD_fromPDM[i].propValore) is True AND ...>
		Call TROVATA_DESC_EST_SU_SAGE_DIVERSA_K_238()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		i += 1
		If i >= MaxCount_RDK_231 then return
		goto next_foreach
	End Sub

	'TROVATA DESC EST SU SAGE DIVERSA <Trim(DescEst)<>Trim(List_PROPCOD_fromPDM[i].propValore) is True AND ...>
	Private Sub TROVATA_DESC_EST_SU_SAGE_DIVERSA_K_238()
		_CurrentNode = "RDK:238"
		'Group Conditions
		Dim _GroupExecute As Boolean = True
		if NOT (EvalExpression("CondExp1_K_238") = True) then goto skip_group		'Trim(DescEst)<>Trim(List_PROPCOD_fromPDM[i].propValore)
		if NOT (EvalExpression("CondExp2_K_238") = True) then goto skip_group		'Trim(DescEst)<>" "
		GoTo exec_group
skip_group:
		_GroupExecute = False
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		'Append Text Line
		_CurrentNode = "RDK:595"		'ACTION RDEngineering_AppendTextLine
		Dim ActionArgs_K_595 as New Generic.list(of object)
		ActionArgs_K_595.Add(EvalExpression("FileName_K_595")) 'FileName IN
		ActionArgs_K_595.Add(EvalExpression("TextLine_K_595")) 'TextLine IN
		ActionArgs_K_595.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_595 As object() = ActionArgs_K_595.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_FILE_TEXT","RDEngineering_AppendTextLine",_ActionArgs_K_595)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Set DescEst = NOTHING
		_CurrentNode = "RDK:254"
		DescEst = CompilerUtil.CreateInstanceByType(DescEst.GetType)
		
	End Sub

	'scrive ITMREF di articoli di PDM che non hanno riga con cpID=369
	Private Sub scrive_ITMREF_di_articoli_di_PDM_che_non_hanno_riga_con_cpID_369_K_243()
		_CurrentNode = "RDK:243"
		'Set query = SELECT distinct c.codCodice FROM PROPCOD as p inner join CODICI as c on c.codID=p.codIDwhere p.codID not i... (194 chars)
		_CurrentNode = "RDK:602"
		query = EvalConstant(query.GetType, "SELECT distinct c.codCodice FROM PROPCOD as p ç§inner join CODICI as c on c.codID=p.codIDç§where p.codID not in (SELECT distinct codID FROM PROPCOD WHERE cpID='369') order by codCodice")
		
		'Select DB Values
		_CurrentNode = "RDK:604"		'ACTION RDEngineering_DBSelect
		Dim ActionArgs_K_604 as New Generic.list(of object)
		ActionArgs_K_604.Add(EvalExpression("ConnectionName_K_604")) 'ConnectionName IN
		ActionArgs_K_604.Add(EvalExpression("SelectQuery_K_604")) 'SelectQuery IN
		ActionArgs_K_604.Add(2) 'SelectQueryType IN
		ActionArgs_K_604.Add(Nothing) 'FirstValue OUT
		ActionArgs_K_604.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_604.Add(ITMREFs) 'AllRows OUT
		ActionArgs_K_604.Add(Nothing) 'FirstColumn OUT
		ActionArgs_K_604.Add(Nothing) 'NumRows OUT
		ActionArgs_K_604.Add(Nothing) 'ColumnHeader OUT
		ActionArgs_K_604.Add(Nothing) 'ColumnHeaders OUT
		ActionArgs_K_604.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_604 As object() = ActionArgs_K_604.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelect",_ActionArgs_K_604)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		ITMREFs = _ActionArgs_K_604(5)		'OUT
		
		'FOREACH ITMREF IN ITMREFs
		Call FOREACHLOOP_K_607()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'FOREACH ITMREF IN ITMREFs
	Private Sub FOREACHLOOP_K_607()
		_CurrentNode = "RDK:607"
		Dim Values_RDK_607 as object = ITMREFs
		Dim MaxCount_RDK_607 as integer = CompilerUtil.Count(Values_RDK_607)
		If MaxCount_RDK_607 <= 0 then return
		i = 0
	next_foreach:
		ITMREF = CompilerUtil.Clone(Values_RDK_607(i))
		
		'Append Text Line
		_CurrentNode = "RDK:609"		'ACTION RDEngineering_AppendTextLine
		Dim ActionArgs_K_609 as New Generic.list(of object)
		ActionArgs_K_609.Add(EvalExpression("FileName_K_609")) 'FileName IN
		ActionArgs_K_609.Add(EvalExpression("TextLine_K_609")) 'TextLine IN
		ActionArgs_K_609.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_609 As object() = ActionArgs_K_609.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_FILE_TEXT","RDEngineering_AppendTextLine",_ActionArgs_K_609)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		i += 1
		If i >= MaxCount_RDK_607 then return
		goto next_foreach
	End Sub



#End Region

End Class
