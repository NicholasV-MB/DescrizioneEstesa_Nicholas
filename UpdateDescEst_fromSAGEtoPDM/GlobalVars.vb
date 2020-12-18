Imports System
Imports System.Collections
Imports System.Reflection
Imports RuleDesigner.Configurator.Core.RDCoreCompiler
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.CompilerUtil

Public Module GlobalVars

#Region " -- Process Parameters Table -- "



#End Region

#Region " -- Process Types Table -- "

Public Class PROPCODType
		<RuleDesignerAttribute(Options:="(DB_PRIMARYKEY)")>
		Public [codID] As string
		<RuleDesignerAttribute(Options:="(DB_PRIMARYKEY)")>
		Public [cpID] As string
		Public [propValore] As string
		<RuleDesignerAttribute(Options:="(DB_IGNORE)")>
		Public [codCodice] As string
End Class



#End Region

#Region " -- Process Variables Table -- "

	Public [PDMConnString] As string
	Public [PDMConnString_LOCAL] As string
	Public [SAGEConnString] As string
	Public [List_PROPCOD_fromPDM] As New Generic.List(Of PROPCODType)
	Public [PROPCOD] As New PROPCODType
	Public [log_dir_exists] As boolean
	Public [DescEst] As string
	Public [result_update] As string
	Public [query] As string
	Public [i] As integer
	Public [ITMREFs] As New Generic.List(Of string)
	Public [ITMREF] As string


#End Region

End Module


