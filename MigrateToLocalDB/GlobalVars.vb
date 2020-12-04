Imports System
Imports System.Collections
Imports System.Reflection
Imports RuleDesigner.Configurator.Core.RDCoreCompiler
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.CompilerUtil

Public Module GlobalVars

#Region " -- Process Parameters Table -- "



#End Region

#Region " -- Process Types Table -- "



#End Region

#Region " -- Process Variables Table -- "

	Public [CreateCODVAL] As string
	Public [CreateCAMPI] As string
	Public [CreateCODICI] As string
	Public [CreatePROPCOD] As string
	Public [PDMServer] As string
	Public [PDMLocal] As string
	Public [CreateITMMASTERT] As string
	Public [SAGEServer] As string
	Public [SAGELocal] As string
	Public [table] As New Generic.List(Of Generic.List(of string))
	Public [row] As New Generic.List(Of string)
	Public [field] As string
	Public [query_insert] As string
	Public [i] As integer
	Public [j] As integer
	Public [MinCounter] As integer
	Public [MaxCounter] As integer
	Public [endwhile] As boolean
	Public [k] As integer
	Public [headers] As New Generic.List(Of string)


#End Region

End Module


