Imports System
Imports System.Collections
Imports System.Reflection
Imports RuleDesigner.Configurator.Core.RDCoreCompiler
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.CompilerUtil

Public Module GlobalVars

#Region " -- Process Parameters Table -- "

	Public [upd_rows] As integer	'OUT
	Public [PDMConnString] As string	'IN
	Public [SAGEConnString] As string	'IN
	Public [MBKConnString] As string	'IN
	Public [Input] As New input1	'IN


#End Region

#Region " -- Process Types Table -- "

Public Class TabDATIType
		Public [TipoArticolo] As string
		Public [IndVar] As string
		Public [TipoProfilo] As string
		Public [Lunghezza] As double
		Public [TipCon] As string
		Public [DirezConn] As string
		Public [Zin] As string
		Public [Ver] As string
		Public [Kit] As boolean
		Public [Speciale] As string
		Public [Specialita] As string
		Public [Lunghezza1] As double
		Public [Larghezza] As double
		Public [Altezza] As double
		Public [Spessore] As double
		Public [ID_Staffa] As string
		Public [Diametro] As double
		Public [Foratura] As string
		Public [Foro] As string
		Public [CodiceParlante] As string
		Public [ForTub] As string
		Public [Inclinazione] As string
		Public [OffsetCon] As double
		Public [OffsetDx] As double
		Public [OffsetSx] As double
		Public [TAGLIOCON] As string
		Public [LAR_CON_SPEC] As integer
		Public [AngInterno] As string
		Public [AngInterno_Value] As string
		Public [AngEsterno] As string
		Public [AngEsterno_Value] As string
		Public [ForInterna] As boolean
		Public [ForInterna_Value] As string
		Public [ForEsterna] As boolean
		Public [ForEsterna_Value] As string
		Public [Altezza_1] As string
		Public [Altezza_PC] As string
		Public [Config_Vern] As string
		Public [Config_Tralic] As string
		Public [Tipo_piede] As string
		Public [Tappata] As string
		Public [Chiuso] As string
		Public [Passi_Chiusi] As string
		Public [Tipo_rinforzo] As string
		Public [Lunghezza_rinforzo] As string
		Public [Tipo_profilo_base] As string
		Public [Tipo_piastra_base] As string
		Public [Tipo_bullonatura] As string
		Public [Mono_bifronte] As string
		Public [Prof_carico] As string
		Public [Bicchiere] As string
		Public [Tipo_Apertura] As string
		Public [Tipo_men_DI] As string
		Public [Fermapallet] As boolean
		Public [Stocchetto_CVV] As boolean
		Public [Tipo_tenditore] As string
		Public [Tipologia_utilizzo] As string
End Class

Public Class TabSAGEType
		Public [Categoria_Sage] As string
		Public [Descrizione] As string
		Public [Descrizione_ITA] As string
		Public [Descrizione_ENG] As string
		Public [Descrizione_DEU] As string
		Public [Descrizione_FRA] As string
		Public [Descrizione_ESP] As string
		Public [DescEstesa] As string
		Public [DescEstesa_ITA] As string
		Public [DescEstesa_ENG] As string
		Public [DescEstesa_DEU] As string
		Public [DescEstesa_FRA] As string
		Public [DescEstesa_ESP] As string
		Public [ArtGlam] As string
		Public [Settore] As string
		Public [Ragg_DetSeq] As string
		Public [Dest_Uso] As string
		Public [Tipo_Disegno] As string
		Public [Codice_Disegno] As string
		Public [ArtAlias] As string
		Public [Qta_Ver] As string
		Public [Tempo_medio_vern] As string
		Public [Superfice] As string
		Public [N_Ganci] As string
		Public [N_Pezzi] As string
		Public [Colore] As string
		Public [Colore_ITA] As string
		Public [Colore_ENG] As string
		Public [Colore_DEU] As string
		Public [Colore_FRA] As string
		Public [Colore_ESP] As string
		Public [CodNastroGen] As string
		Public [Materiale] As string
		Public [Utilizzo] As string
		Public [Peso] As string
		Public [Portata] As string
		Public [Unita_Mag] As string
		Public [Unita_Peso] As string
		Public [Unita_acq] As string
		Public [Coeff_UA_UM] As string
		Public [Unita_ven] As string
		Public [Coeff_UV_UM] As string
		Public [Unita_conf1] As string
		Public [Coeff_Con1_UM] As string
		Public [Unita_conf2] As string
		Public [Coeff_Con2_UM] As string
		Public [Unita_conf3] As string
		Public [Coeff_Con3_UM] As string
		Public [Temporaneo] As string
		Public [Strutturale] As boolean
End Class

Public Class TabCOSTIType
		Public [Prezzo] As string
		Public [PrezzoMagg] As string
		Public [Costo_Tot] As string
		Public [Costo_Tot_Materiali] As string
		Public [Costo_Tot_Macchina] As string
		Public [Costo_Tot_CL] As string
		Public [Prezzo_da_Costo] As boolean
		Public [Data_agg_prezzo] As date
End Class

Public Class TabCICLOType
		Public [CDL] As string
		Public [Tempo] As string
		Public [UM] As string
		Public [Qty] As string
		Public [CostoLAV] As string
End Class

Public Class TABDATI_PType
		Public [TipoArticolo] As string
		Public [TipoProfilo] As string
		Public [Lunghezza] As integer
		Public [Lunghezza1] As integer
		Public [Altezza] As integer
		Public [Larghezza] As integer
		Public [Spessore] As double
		Public [TipoConn] As string
		Public [Diametro] As double
		Public [ID_staffa] As string
		Public [VER] As string
		Public [ZIN] As string
End Class

Public Class input1
		Public [ITMREF] As string
		Public [Tipo_agg] As string
		Public [Agg_param] As boolean
		Public [TipoArt] As string
		Public [Origine] As string
		Public [Macrofamiglia] As string
		Public [Agg_Sage] As boolean
		Public [Speciali] As boolean
End Class



#End Region

#Region " -- Process Variables Table -- "

	Public [List_ITMREF] As New Generic.List(Of string)
	Public [LoginSuccess] As boolean
	Public [LogFileName] As string
	Public [ITMREF] As string
	Public [TABDATI] As New TabDATIType
	Public [TABSAGE] As New TabSAGEType
	Public [INTAPG] As string
	Public [ESTAPG] As string
	Public [URL] As string
	Public [OutDescEst] As string
	Public [bResult] As boolean
	Public [ErrorMessage] As string
	Public [i] As integer


#End Region

End Module


