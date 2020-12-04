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
		CreateCODVAL = EvalConstant(GetType(string),"CREATE TABLE [dbo].[CODVAL](ç§	[cvalID] [int] NOT NULL,ç§	[cpID] [int] NOT NULL,ç§	[cvalValore] [nvarchar](255) NOT NULL,ç§	[cvalCodice] [nvarchar](15) NULL,ç§	[cvalTags] [nvarchar](128) NULL,ç§	[cvalTrans1] [nvarchar](255) NULL,ç§	[cvalTrans2] [nvarchar](255) NULL,ç§	[cvalTrans3] [nvarchar](255) NULL,ç§	[cvalTrans4] [nvarchar](255) NULL,ç§	[cvalTrans5] [nvarchar](255) NULL,ç§	[cvalMountTime] [float] NULL,ç§	[cvalPos] [int] NOT NULL,ç§	[cvalImageUrl] [nvarchar](255) NULL,ç§PRIMARY KEY CLUSTERED ç§(ç§	[cvalID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]")
		CreateCAMPI = EvalConstant(GetType(string),"CREATE TABLE [dbo].[CAMPI](ç§	[cpID] [int] NOT NULL,ç§	[cpNome] [nvarchar](64) NOT NULL,ç§	[cpTipo] [smallint] NOT NULL,ç§	[cpForm] [int] NOT NULL,ç§	[cpLock] [bit] NULL,ç§	[cpReq] [bit] NULL,ç§	[cpInit] [bit] NULL,ç§	[cpUM] [nvarchar](10) NULL,ç§	[cpAbb] [nvarchar](20) NULL,ç§	[cpSep] [nvarchar](10) NULL,ç§	[cpUso] [smallint] NOT NULL,ç§	[cpDesc] [nvarchar](255) NULL,ç§	[cpPermission] [int] NULL,ç§	[cpTags] [nvarchar](128) NULL,ç§	[cpTrans1] [nvarchar](64) NULL,ç§	[cpTrans2] [nvarchar](64) NULL,ç§	[cpTrans3] [nvarchar](64) NULL,ç§	[cpTrans4] [nvarchar](64) NULL,ç§	[cpTrans5] [nvarchar](64) NULL,ç§PRIMARY KEY CLUSTERED ç§(ç§	[cpID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]")
		CreateCODICI = EvalConstant(GetType(string),"CREATE TABLE [dbo].[CODICI](ç§	[codID] [int] NOT NULL,ç§	[codCodice] [nvarchar](30) NOT NULL,ç§	[codRevisione] [smallint] NULL,ç§	[codLastRev] [bit] NULL,ç§	[codTitle] [nvarchar](128) NULL,ç§	[codStatus] [smallint] NULL,ç§	[codStUser] [nvarchar](50) NULL,ç§	[codStDate] [datetime] NULL,ç§	[codModUser] [nvarchar](50) NULL,ç§	[codModDate] [datetime] NULL,ç§	[codCrUser] [nvarchar](50) NULL,ç§	[codCrDate] [datetime] NULL,ç§	[catID] [int] NULL,ç§	[codAnaUpd] [smallint] NULL,ç§	[codExtract] [bit] NULL,ç§	[codExtHost] [nvarchar](255) NULL,ç§	[codSvrPath] [nvarchar](512) NULL,ç§	[codBackup] [bit] NULL,ç§	[codFullDesc] [nvarchar](255) NULL,ç§	[codNote] [nvarchar](255) NULL,ç§	[codArchived] [bit] NULL,ç§	[codNoteArchived] [nvarchar](255) NULL,ç§	[codVaulted] [bit] NULL,ç§	[codIsVersion] [bit] NULL,ç§	[codVersion] [smallint] NULL,ç§	[codVersDesc] [nvarchar](255) NULL,ç§	[binID] [int] NULL,ç§	[codTags] [nvarchar](128) NULL,ç§	[codWFPending] [bit] NULL,ç§	[codProcessed] [bit] NULL,ç§PRIMARY KEY CLUSTERED ç§(ç§	[codID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]")
		CreatePROPCOD = EvalConstant(GetType(string),"CREATE TABLE [dbo].[PROPCOD](ç§	[codID] [int] NOT NULL,ç§	[cpID] [int] NOT NULL,ç§	[cpIDAlias] [int] NULL,ç§	[propValore] [nvarchar](255) NULL,ç§	[propValDec] [float] NULL,ç§	[propValDate] [datetime] NULL,ç§	[propPos] [smallint] NOT NULL,ç§	[propTransl1] [nvarchar](255) NULL,ç§	[propTransl2] [nvarchar](255) NULL,ç§	[propTransl3] [nvarchar](255) NULL,ç§	[propTransl4] [nvarchar](255) NULL,ç§	[propTransl5] [nvarchar](255) NULL,ç§PRIMARY KEY CLUSTERED ç§(ç§	[codID] ASC,ç§	[cpID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]")
		PDMServer = "Provider=sqloledb;Initial Catalog=PDMTest;Data Source=SRV-DB06\TSINT;User Id=sa;Password=Ruled2014;"
		PDMLocal = "Provider=sqloledb;Initial Catalog=PDMtest;Data Source=LAPT-IT07\RULEDESIGNER;User Id=SA;Password=MBOffline$;"
		CreateITMMASTERT = EvalConstant(GetType(string),"CREATE TABLE [ITMMASTER](ç§	[ITMREF_0] [nvarchar](20) NOT NULL,ç§	[TSICOD_0] [nvarchar](20) NOT NULL,ç§	[TSICOD_1] [nvarchar](20) NOT NULL,ç§	[TSICOD_2] [nvarchar](20) NOT NULL,ç§	[TSICOD_3] [nvarchar](20) NOT NULL,ç§	[TSICOD_4] [nvarchar](20) NOT NULL,ç§	[TCLCOD_0] [nvarchar](5) NOT NULL,ç§	[SEAKEY_0] [nvarchar](20) NOT NULL,ç§	[DIE_0] [nvarchar](3) NOT NULL,ç§	[DIE_1] [nvarchar](3) NOT NULL,ç§	[DIE_2] [nvarchar](3) NOT NULL,ç§	[DIE_3] [nvarchar](3) NOT NULL,ç§	[DIE_4] [nvarchar](3) NOT NULL,ç§	[DIE_5] [nvarchar](3) NOT NULL,ç§	[DIE_6] [nvarchar](3) NOT NULL,ç§	[DIE_7] [nvarchar](3) NOT NULL,ç§	[DIE_8] [nvarchar](3) NOT NULL,ç§	[DIE_9] [nvarchar](3) NOT NULL,ç§	[DIE_10] [nvarchar](3) NOT NULL,ç§	[DIE_11] [nvarchar](3) NOT NULL,ç§	[DIE_12] [nvarchar](3) NOT NULL,ç§	[DIE_13] [nvarchar](3) NOT NULL,ç§	[DIE_14] [nvarchar](3) NOT NULL,ç§	[DIE_15] [nvarchar](3) NOT NULL,ç§	[DIE_16] [nvarchar](3) NOT NULL,ç§	[DIE_17] [nvarchar](3) NOT NULL,ç§	[DIE_18] [nvarchar](3) NOT NULL,ç§	[DIE_19] [nvarchar](3) NOT NULL,ç§	[CCE_0] [nvarchar](15) NOT NULL,ç§	[CCE_1] [nvarchar](15) NOT NULL,ç§	[CCE_2] [nvarchar](15) NOT NULL,ç§	[CCE_3] [nvarchar](15) NOT NULL,ç§	[CCE_4] [nvarchar](15) NOT NULL,ç§	[CCE_5] [nvarchar](15) NOT NULL,ç§	[CCE_6] [nvarchar](15) NOT NULL,ç§	[CCE_7] [nvarchar](15) NOT NULL,ç§	[CCE_8] [nvarchar](15) NOT NULL,ç§	[CCE_9] [nvarchar](15) NOT NULL,ç§	[CCE_10] [nvarchar](15) NOT NULL,ç§	[CCE_11] [nvarchar](15) NOT NULL,ç§	[CCE_12] [nvarchar](15) NOT NULL,ç§	[CCE_13] [nvarchar](15) NOT NULL,ç§	[CCE_14] [nvarchar](15) NOT NULL,ç§	[CCE_15] [nvarchar](15) NOT NULL,ç§	[CCE_16] [nvarchar](15) NOT NULL,ç§	[CCE_17] [nvarchar](15) NOT NULL,ç§	[CCE_18] [nvarchar](15) NOT NULL,ç§	[CCE_19] [nvarchar](15) NOT NULL,ç§	[ACCCOD_0] [nvarchar](10) NOT NULL,ç§	[ITMDES1_0] [nvarchar](60) NOT NULL,ç§	[ITMDES2_0] [nvarchar](60) NOT NULL,ç§	[ITMDES3_0] [nvarchar](60) NOT NULL,ç§	[STDFLG_0] [tinyint] NOT NULL,ç§	[ITMSTD_0] [nvarchar](20) NOT NULL,ç§	[EANCOD_0] [nvarchar](20) NOT NULL,ç§	[ITMSTA_0] [tinyint] NOT NULL,ç§	[DEFPOT_0] [numeric](14, 5) NOT NULL,ç§	[DEFACT_0] [numeric](14, 5) NOT NULL,ç§	[LIFSTRDAT_0] [datetime] NOT NULL,ç§	[LIFENDDAT_0] [datetime] NOT NULL,ç§	[STOCRD_0] [nvarchar](8) NOT NULL,ç§	[STU_0] [nvarchar](3) NOT NULL,ç§	[PUU_0] [nvarchar](3) NOT NULL,ç§	[SAU_0] [nvarchar](3) NOT NULL,ç§	[SSU_0] [nvarchar](3) NOT NULL,ç§	[EEU_0] [nvarchar](3) NOT NULL,ç§	[PUUSTUCOE_0] [numeric](18, 7) NOT NULL,ç§	[DACPUUCOE_0] [tinyint] NOT NULL,ç§	[SAUSTUCOE_0] [numeric](18, 7) NOT NULL,ç§	[DACSAUCOE_0] [tinyint] NOT NULL,ç§	[SSUSTUCOE_0] [numeric](18, 7) NOT NULL,ç§	[EEUSTUCOE_0] [numeric](18, 7) NOT NULL,ç§	[WEU_0] [nvarchar](3) NOT NULL,ç§	[ITMWEI_0] [numeric](17, 6) NOT NULL,ç§	[VOU_0] [nvarchar](3) NOT NULL,ç§	[ITMVOU_0] [numeric](12, 4) NOT NULL,ç§	[PCU_0] [nvarchar](3) NOT NULL,ç§	[PCU_1] [nvarchar](3) NOT NULL,ç§	[PCU_2] [nvarchar](3) NOT NULL,ç§	[PCU_3] [nvarchar](3) NOT NULL,ç§	[PCUSTUCOE_0] [numeric](18, 7) NOT NULL,ç§	[PCUSTUCOE_1] [numeric](18, 7) NOT NULL,ç§	[PCUSTUCOE_2] [numeric](18, 7) NOT NULL,ç§	[PCUSTUCOE_3] [numeric](18, 7) NOT NULL,ç§	[DACPCUCOE_0] [tinyint] NOT NULL,ç§	[DACPCUCOE_1] [tinyint] NOT NULL,ç§	[DACPCUCOE_2] [tinyint] NOT NULL,ç§	[DACPCUCOE_3] [tinyint] NOT NULL,ç§	[PCURUL_0] [tinyint] NOT NULL,ç§	[PCURUL_1] [tinyint] NOT NULL,ç§	[PCURUL_2] [tinyint] NOT NULL,ç§	[PCURUL_3] [tinyint] NOT NULL,ç§	[LBEFMT_0] [nvarchar](15) NOT NULL,ç§	[LBEFMT_1] [nvarchar](15) NOT NULL,ç§	[LBEFMT_2] [nvarchar](15) NOT NULL,ç§	[LBEFMT_3] [nvarchar](15) NOT NULL,ç§	[STOMGTCOD_0] [tinyint] NOT NULL,ç§	[LOTMGTCOD_0] [tinyint] NOT NULL,ç§	[LOTCOU_0] [nvarchar](5) NOT NULL,ç§	[SERCOU_0] [nvarchar](5) NOT NULL,ç§	[SERMGTCOD_0] [tinyint] NOT NULL,ç§	[EXYMGTCOD_0] [tinyint] NOT NULL,ç§	[EXYSTA_0] [nvarchar](1) NOT NULL,ç§	[SHL_0] [smallint] NOT NULL,ç§	[SHLLTI_0] [smallint] NOT NULL,ç§	[NEGSTO_0] [tinyint] NOT NULL,ç§	[CSTGRP_0] [nvarchar](10) NOT NULL,ç§	[BRDCOD_0] [tinyint] NOT NULL,ç§	[PLAACS_0] [nvarchar](10) NOT NULL,ç§	[RPLITM_0] [nvarchar](20) NOT NULL,ç§	[EECGES_0] [tinyint] NOT NULL,ç§	[CUSREF_0] [nvarchar](12) NOT NULL,ç§	[VACITM_0] [nvarchar](20) NOT NULL,ç§	[VACITM_1] [nvarchar](20) NOT NULL,ç§	[VACITM_2] [nvarchar](20) NOT NULL,ç§	[FRTHORUOM_0] [tinyint] NOT NULL,ç§	[FRTHOR_0] [smallint] NOT NULL,ç§	[FIMHOR_0] [smallint] NOT NULL,ç§	[FIMHORUOM_0] [tinyint] NOT NULL,ç§	[BUY_0] [nvarchar](5) NOT NULL,ç§	[PLANNER_0] [nvarchar](5) NOT NULL,ç§	[OFS_0] [smallint] NOT NULL,ç§	[MINRMNPRC_0] [numeric](8, 3) NOT NULL,ç§	[RCPFLG_0] [tinyint] NOT NULL,ç§	[PRQFLG_0] [tinyint] NOT NULL,ç§	[PURTEX_0] [nvarchar](12) NOT NULL,ç§	[MFGTEX_0] [nvarchar](12) NOT NULL,ç§	[ITMEXNFLG_0] [nvarchar](1) NOT NULL,ç§	[STATAXFLG_0] [nvarchar](1) NOT NULL,ç§	[CFGLIN_0] [nvarchar](5) NOT NULL,ç§	[CFGFLDNUM1_0] [numeric](28, 13) NOT NULL,ç§	[CFGFLDNUM2_0] [numeric](28, 13) NOT NULL,ç§	[CFGFLDNUM3_0] [numeric](28, 13) NOT NULL,ç§	[CFGFLDNUM4_0] [numeric](28, 13) NOT NULL,ç§	[CFGFLDNUM5_0] [numeric](28, 13) NOT NULL,ç§	[CFGFLDNUM6_0] [numeric](28, 13) NOT NULL,ç§	[CFGFLDALP1_0] [nvarchar](20) NOT NULL,ç§	[CFGFLDALP2_0] [nvarchar](20) NOT NULL,ç§	[CFGFLDALP3_0] [nvarchar](20) NOT NULL,ç§	[CFGFLDALP4_0] [nvarchar](20) NOT NULL,ç§	[CFGFLDALP5_0] [nvarchar](20) NOT NULL,ç§	[CFGFLDALP6_0] [nvarchar](20) NOT NULL,ç§	[CFGVCRNUM_0] [nvarchar](20) NOT NULL,ç§	[CFGBPRNUM_0] [nvarchar](15) NOT NULL,ç§	[CFGBPRREF_0] [nvarchar](20) NOT NULL,ç§	[CFGITMREF_0] [nvarchar](20) NOT NULL,ç§	[CFGDELDAT_0] [datetime] NOT NULL,ç§	[CREMAC_0] [tinyint] NOT NULL,ç§	[FLYCAT_0] [nvarchar](20) NOT NULL,ç§	[TPLCONLND_0] [nvarchar](20) NOT NULL,ç§	[TPLCONGUA_0] [nvarchar](20) NOT NULL,ç§	[TPLCONSRV_0] [nvarchar](20) NOT NULL,ç§	[PITCDT_0] [int] NOT NULL,ç§	[PITCDTUOM_0] [nvarchar](3) NOT NULL,ç§	[STULBEFMT_0] [nvarchar](15) NOT NULL,ç§	[ALTBOMHDK_0] [smallint] NOT NULL,ç§	[HDKITMTYP_0] [tinyint] NOT NULL,ç§	[STOISSDEF_0] [tinyint] NOT NULL,ç§	[DAYUOM_0] [nvarchar](3) NOT NULL,ç§	[HOUUOM_0] [nvarchar](3) NOT NULL,ç§	[MNTUOM_0] [nvarchar](3) NOT NULL,ç§	[DTY_0] [numeric](18, 7) NOT NULL,ç§	[TRKCOD_0] [tinyint] NOT NULL,ç§	[PURFLG_0] [tinyint] NOT NULL,ç§	[MFGFLG_0] [tinyint] NOT NULL,ç§	[SCPFLG_0] [tinyint] NOT NULL,ç§	[SCSFLG_0] [tinyint] NOT NULL,ç§	[PHAFLG_0] [tinyint] NOT NULL,ç§	[GENFLG_0] [tinyint] NOT NULL,ç§	[TOOFLG_0] [tinyint] NOT NULL,ç§	[DLVFLG_0] [tinyint] NOT NULL,ç§	[SALFLG_0] [tinyint] NOT NULL,ç§	[INTFLG_0] [tinyint] NOT NULL,ç§	[FLGFAS_0] [tinyint] NOT NULL,ç§	[NEWLTISTA_0] [nvarchar](1) NOT NULL,ç§	[DLU_0] [numeric](18, 7) NOT NULL,ç§	[SHLUOM_0] [tinyint] NOT NULL,ç§	[SHLLTIUOM_0] [tinyint] NOT NULL,ç§	[EXPNUM_0] [int] NOT NULL,ç§	[XINTRACPA_0] [nvarchar](10) NOT NULL,ç§	[CREDAT_0] [datetime] NOT NULL,ç§	[CREUSR_0] [nvarchar](5) NOT NULL,ç§	[XINTRCPADE_0] [nvarchar](100) NOT NULL,ç§	[UPDDAT_0] [datetime] NOT NULL,ç§	[UPDUSR_0] [nvarchar](5) NOT NULL,ç§	[XINTRAEROG_0] [tinyint] NOT NULL,ç§	[STAFED_0] [nvarchar](20) NOT NULL,ç§	[PLMITMREF_0] [nvarchar](70) NOT NULL,ç§	[PLMATTURL_0] [nvarchar](250) NOT NULL,ç§	[PLMHISURL_0] [nvarchar](250) NOT NULL,ç§	[CRESTP_0] [nvarchar](14) NOT NULL,ç§	[UPDSTP_0] [nvarchar](14) NOT NULL,ç§	[IDTSGL_0] [nvarchar](36) NOT NULL,ç§	[MATTOL_0] [nvarchar](5) NOT NULL,ç§	[YCOLOR_0] [nvarchar](10) NOT NULL,ç§	[YDIMLUN_0] [numeric](11, 3) NOT NULL,ç§	[YDIMALT_0] [numeric](11, 3) NOT NULL,ç§	[YDIMLAR_0] [numeric](11, 3) NOT NULL,ç§	[YDIAMETRO_0] [numeric](11, 3) NOT NULL,ç§	[YMATPRI_0] [nvarchar](4) NOT NULL,ç§	[YMRP_0] [tinyint] NOT NULL,ç§	[YPAINTQTY_0] [numeric](15, 4) NOT NULL,ç§	[YPAINTUN_0] [int] NOT NULL,ç§	[YUTILMAT_0] [nvarchar](20) NOT NULL,ç§	[YSPESFLG_0] [tinyint] NOT NULL,ç§	[YPROVFLG_0] [tinyint] NOT NULL,ç§	[YPESAFLG_0] [tinyint] NOT NULL,ç§	[YLA6FLG_0] [tinyint] NOT NULL,ç§	[YPCERTFLG_0] [tinyint] NOT NULL,ç§	[YCERT_0] [tinyint] NOT NULL,ç§	[YFAMALTM_0] [nvarchar](20) NOT NULL,ç§	[YPACKFLG_0] [tinyint] NOT NULL,ç§	[YCOEFALTM_0] [numeric](15, 4) NOT NULL,ç§	[YDEST_0] [nvarchar](20) NOT NULL,ç§	[YKANQTY_0] [numeric](28, 13) NOT NULL,ç§	[YKANRPL_0] [numeric](28, 13) NOT NULL,ç§	[YKANLBL_0] [numeric](28, 13) NOT NULL,ç§	[YKANMFG_0] [nvarchar](12) NOT NULL,ç§	[YOFFSET_0] [numeric](6, 1) NOT NULL,ç§	[YSPESS_0] [numeric](11, 4) NOT NULL,ç§	[YLAVSUPP_0] [nvarchar](4) NOT NULL,ç§	[YTPCONN_0] [nvarchar](5) NOT NULL,ç§	[YCOSTOMB_0] [numeric](24, 7) NOT NULL,ç§	[YTYPSUP_0] [tinyint] NOT NULL,ç§	[YCMQTY_0] [numeric](14, 3) NOT NULL,ç§	[YCMTOLL_0] [numeric](8, 3) NOT NULL,ç§	[YNASTRO_0] [nvarchar](20) NOT NULL,ç§	[YIMBBPS_0] [nvarchar](20) NOT NULL,ç§	[YFAMIGLIA_0] [nvarchar](20) NOT NULL,ç§	[YMAT_0] [nvarchar](20) NOT NULL,ç§	[YPDMPJTREF_0] [nvarchar](20) NOT NULL,ç§	[YCLALC_0] [nvarchar](20) NOT NULL,ç§	[YFINIT_0] [nvarchar](1) NOT NULL,ç§	[YTMVER_0] [numeric](12, 4) NOT NULL,ç§	[YSPECIALE_0] [tinyint] NOT NULL,ç§	[YLTROU_0] [tinyint] NOT NULL,ç§	[YASSEMB_0] [tinyint] NOT NULL,ç§	[YFORAT_0] [nvarchar](4) NOT NULL,ç§	[YINCLINAZ_0] [numeric](8, 3) NOT NULL,ç§	[YINDVAR_0] [nvarchar](4) NOT NULL,ç§	[YTIPOPROF_0] [nvarchar](5) NOT NULL,ç§	[YSUPERF_0] [numeric](14, 3) NOT NULL,ç§	[YCODRIELAB_0] [nvarchar](20) NOT NULL,ç§	[YNGANCI_0] [smallint] NOT NULL,ç§	[YNPEZZI_0] [smallint] NOT NULL,ç§	[YFLG_YCSOH_0] [tinyint] NOT NULL,ç§	[YDESEST_0] [nvarchar](250) NOT NULL,ç§	[CRETIM_0] [int] NOT NULL,ç§	[UPDTIM_0] [int] NOT NULL,ç§	[YCPINFINT_0] [tinyint] NOT NULL,ç§	[MCRFAM_0] [nvarchar](2) NOT NULL,ç§	[REFITMMAS_0] [nvarchar](20) NOT NULL,ç§	[YSTULBEFMT_0] [nvarchar](15) NOT NULL,ç§	[YPROVINT_0] [tinyint] NOT NULL,ç§	[YGLAM_0] [tinyint] NOT NULL,ç§	[OFSCYB_0] [smallint] NOT NULL,ç§	[YTIPSPEC_0] [tinyint] NOT NULL,ç§	[YTIPODIS_0] [tinyint] NOT NULL,ç§	[YCODDIS_0] [nvarchar](10) NOT NULL,ç§	[YSTRUTTURALE_0] [tinyint] NOT NULL,ç§	[YIDENT_0] [nvarchar](250) NOT NULL,ç§	[YMATCUM_0] [nvarchar](60) NOT NULL,ç§	[YPORTATA_0] [int] NOT NULL,ç§	[YSAMPLER_0] [tinyint] NOT NULL,ç§	[YWEISAMPLE_0] [numeric](17, 6) NOT NULL,ç§	[ROWID] [int] IDENTITY(1,1) NOT NULL,ç§ CONSTRAINT [ITMMASTER_ROWID] PRIMARY KEY NONCLUSTERED ç§(ç§	[ROWID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]")
		SAGEServer = "Provider=sqloledb;Initial Catalog=x3v64;Data Source=SRV-DB02\AX3V6;User Id=sa;Password=FormulaDB;"
		SAGELocal = "Provider=sqloledb;Initial Catalog=x3v64;Data Source=LAPT-IT07\RULEDESIGNER;User Id=SA;Password=MBOffline$;"
		endwhile = false


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
		'PDM
		Call PDM_K_27()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'SAGE
		Call SAGE_K_629()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

	End Sub

	'PDM
	Private Sub PDM_K_27()
		_CurrentNode = "RDK:27"
		'Open DB Connection (PDM SERVER)
		_CurrentNode = "RDK:45"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_45 as New Generic.list(of object)
		ActionArgs_K_45.Add("PDMTest") 'ConnectionName IN
		ActionArgs_K_45.Add(EvalExpression("ConnectionString_K_45")) 'ConnectionString IN
		ActionArgs_K_45.Add(1) 'Transaction IN
		ActionArgs_K_45.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_45 As object() = ActionArgs_K_45.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_45)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Open DB Connection (PDM LOCAL)
		_CurrentNode = "RDK:46"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_46 as New Generic.list(of object)
		ActionArgs_K_46.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_46.Add(EvalExpression("ConnectionString_K_46")) 'ConnectionString IN
		ActionArgs_K_46.Add(-1) 'Transaction IN
		ActionArgs_K_46.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_46 As object() = ActionArgs_K_46.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_46)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'CODVAL
		Call CODVAL_K_366()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'CAMPI
		Call CAMPI_K_403()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'CODICI
		Call CODICI_K_464()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'PROPCOD *LOG_DISABLED
		Call PROPCOD_K_500()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Close DB Connection (PDM SERVER)
		_CurrentNode = "RDK:52"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_52 as New Generic.list(of object)
		ActionArgs_K_52.Add("PDMTest") 'ConnectionName IN
		ActionArgs_K_52.Add(2) 'Transaction IN
		Dim _ActionArgs_K_52 As object() = ActionArgs_K_52.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_52)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Close DB Connection (PDM LOCAL)
		_CurrentNode = "RDK:65"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_65 as New Generic.list(of object)
		ActionArgs_K_65.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_65.Add(-1) 'Transaction IN
		Dim _ActionArgs_K_65 As object() = ActionArgs_K_65.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_65)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'CODVAL
	Private Sub CODVAL_K_366()
		_CurrentNode = "RDK:366"
		'Select DB Values
		_CurrentNode = "RDK:51"		'ACTION RDEngineering_DBSelect
		Dim ActionArgs_K_51 as New Generic.list(of object)
		ActionArgs_K_51.Add("PDMTest") 'ConnectionName IN
		ActionArgs_K_51.Add("SELECT * FROM CODVAL") 'SelectQuery IN
		ActionArgs_K_51.Add(2) 'SelectQueryType IN
		ActionArgs_K_51.Add(Nothing) 'FirstValue OUT
		ActionArgs_K_51.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_51.Add(table) 'AllRows OUT
		ActionArgs_K_51.Add(Nothing) 'FirstColumn OUT
		ActionArgs_K_51.Add(Nothing) 'NumRows OUT
		ActionArgs_K_51.Add(Nothing) 'ColumnHeader OUT
		ActionArgs_K_51.Add(Nothing) 'ColumnHeaders OUT
		ActionArgs_K_51.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_51 As object() = ActionArgs_K_51.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelect",_ActionArgs_K_51)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		table = _ActionArgs_K_51(5)		'OUT
		
		'Execute SQL Statement
		_CurrentNode = "RDK:44"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_44 as New Generic.list(of object)
		ActionArgs_K_44.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_44.Add(EvalExpression("SqlStatement_K_44")) 'SqlStatement IN
		ActionArgs_K_44.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_44.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_44 As object() = ActionArgs_K_44.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_44)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'FOREACH row IN table BYREF
		Call FOREACHLOOP_K_55()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'FOREACH row IN table BYREF
	Private Sub FOREACHLOOP_K_55()
		_CurrentNode = "RDK:55"
		Dim Values_RDK_55 as object = table
		Dim Index_RDK_55 as integer
		Dim MaxCount_RDK_55 as integer = CompilerUtil.Count(Values_RDK_55)
		If MaxCount_RDK_55 <= 0 then return
		Index_RDK_55 = 0
	next_foreach:
		row = Values_RDK_55(Index_RDK_55)
		
		'Set query_insert = INSERT INTO CODVAL VALUES(
		_CurrentNode = "RDK:57"
		query_insert = EvalConstant(query_insert.GetType, "INSERT INTO CODVAL VALUES(")
		
		'FOREACH field IN row BYREF
		Call FOREACHLOOP_K_66()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set query_insert = query_insert+")"
		_CurrentNode = "RDK:288"
		query_insert = EvalExpression("Set_query_insert_K_288")
		
		'Execute SQL Statement
		_CurrentNode = "RDK:58"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_58 as New Generic.list(of object)
		ActionArgs_K_58.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_58.Add(EvalExpression("SqlStatement_K_58")) 'SqlStatement IN
		ActionArgs_K_58.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_58.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_58 As object() = ActionArgs_K_58.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_58)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		Index_RDK_55 += 1
		If Index_RDK_55 >= MaxCount_RDK_55 then return
		goto next_foreach
	End Sub

	'FOREACH field IN row BYREF
	Private Sub FOREACHLOOP_K_66()
		_CurrentNode = "RDK:66"
		Dim Values_RDK_66 as object = row
		Dim Index_RDK_66 as integer
		Dim MaxCount_RDK_66 as integer = CompilerUtil.Count(Values_RDK_66)
		If MaxCount_RDK_66 <= 0 then return
		Index_RDK_66 = 0
		i = 1
	next_foreach:
		field = Values_RDK_66(Index_RDK_66)
		
		'If i>1 is True
		Call IFTHENELSE_K_258()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'If row[i-1]<>"" is True
		Call IFTHENELSE_K_236()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		Index_RDK_66 += 1
		If Index_RDK_66 >= MaxCount_RDK_66 then return
		i += 1
		goto next_foreach
	End Sub

	'If i>1 is True
	Private Sub IFTHENELSE_K_258()
		_CurrentNode = "RDK:258"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_258")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If i>1 is True
			Call THENGROUP_K_259()

		End if
	End Sub

	'If i>1 is True
	Private Sub THENGROUP_K_259()
		_CurrentNode = "RDK:259"
		'Set query_insert = query_insert+","
		_CurrentNode = "RDK:268"
		query_insert = EvalExpression("Set_query_insert_K_268")
		
	End Sub

	'If row[i-1]<>"" is True
	Private Sub IFTHENELSE_K_236()
		_CurrentNode = "RDK:236"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_236")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If row[i-1]<>"" is True
			Call THENGROUP_K_237()

		else
			'Set query_insert = query_insert+"'"+StrSql(row[i-1])+"'"
			Call ELSEGROUP_K_238()

		End if
	End Sub

	'If row[i-1]<>"" is True
	Private Sub THENGROUP_K_237()
		_CurrentNode = "RDK:237"
		'Set query_insert = query_insert+"'"+StrSql(row[i-1])+"'"
		_CurrentNode = "RDK:246"
		query_insert = EvalExpression("Set_query_insert_K_246")
		
	End Sub

	'Set query_insert = query_insert+"'"+StrSql(row[i-1])+"'"
	Private Sub ELSEGROUP_K_238()
		_CurrentNode = "RDK:238"
		'Set query_insert = query_insert+"''"
		_CurrentNode = "RDK:257"
		query_insert = EvalExpression("Set_query_insert_K_257")
		
	End Sub

	'CAMPI
	Private Sub CAMPI_K_403()
		_CurrentNode = "RDK:403"
		'Select DB Values
		_CurrentNode = "RDK:387"		'ACTION RDEngineering_DBSelect
		Dim ActionArgs_K_387 as New Generic.list(of object)
		ActionArgs_K_387.Add("PDMTest") 'ConnectionName IN
		ActionArgs_K_387.Add("SELECT * FROM CAMPI") 'SelectQuery IN
		ActionArgs_K_387.Add(2) 'SelectQueryType IN
		ActionArgs_K_387.Add(Nothing) 'FirstValue OUT
		ActionArgs_K_387.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_387.Add(table) 'AllRows OUT
		ActionArgs_K_387.Add(Nothing) 'FirstColumn OUT
		ActionArgs_K_387.Add(Nothing) 'NumRows OUT
		ActionArgs_K_387.Add(Nothing) 'ColumnHeader OUT
		ActionArgs_K_387.Add(Nothing) 'ColumnHeaders OUT
		ActionArgs_K_387.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_387 As object() = ActionArgs_K_387.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelect",_ActionArgs_K_387)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		table = _ActionArgs_K_387(5)		'OUT
		
		'Execute SQL Statement
		_CurrentNode = "RDK:388"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_388 as New Generic.list(of object)
		ActionArgs_K_388.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_388.Add(EvalExpression("SqlStatement_K_388")) 'SqlStatement IN
		ActionArgs_K_388.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_388.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_388 As object() = ActionArgs_K_388.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_388)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'FOREACH row IN table BYREF
		Call FOREACHLOOP_K_402()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'FOREACH row IN table BYREF
	Private Sub FOREACHLOOP_K_402()
		_CurrentNode = "RDK:402"
		Dim Values_RDK_402 as object = table
		Dim Index_RDK_402 as integer
		Dim MaxCount_RDK_402 as integer = CompilerUtil.Count(Values_RDK_402)
		If MaxCount_RDK_402 <= 0 then return
		Index_RDK_402 = 0
	next_foreach:
		row = Values_RDK_402(Index_RDK_402)
		
		'Set query_insert = INSERT INTO CAMPI VALUES(
		_CurrentNode = "RDK:389"
		query_insert = EvalConstant(query_insert.GetType, "INSERT INTO CAMPI VALUES(")
		
		'FOREACH field IN row BYREF
		Call FOREACHLOOP_K_399()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set query_insert = query_insert+")"
		_CurrentNode = "RDK:400"
		query_insert = EvalExpression("Set_query_insert_K_400")
		
		'Execute SQL Statement
		_CurrentNode = "RDK:401"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_401 as New Generic.list(of object)
		ActionArgs_K_401.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_401.Add(EvalExpression("SqlStatement_K_401")) 'SqlStatement IN
		ActionArgs_K_401.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_401.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_401 As object() = ActionArgs_K_401.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_401)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		Index_RDK_402 += 1
		If Index_RDK_402 >= MaxCount_RDK_402 then return
		goto next_foreach
	End Sub

	'FOREACH field IN row BYREF
	Private Sub FOREACHLOOP_K_399()
		_CurrentNode = "RDK:399"
		Dim Values_RDK_399 as object = row
		Dim Index_RDK_399 as integer
		Dim MaxCount_RDK_399 as integer = CompilerUtil.Count(Values_RDK_399)
		If MaxCount_RDK_399 <= 0 then return
		Index_RDK_399 = 0
		i = 1
	next_foreach:
		field = Values_RDK_399(Index_RDK_399)
		
		'If i>1 is True
		Call IFTHENELSE_K_393()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'If row[i-1]<>"" is True
		Call IFTHENELSE_K_398()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		Index_RDK_399 += 1
		If Index_RDK_399 >= MaxCount_RDK_399 then return
		i += 1
		goto next_foreach
	End Sub

	'If i>1 is True
	Private Sub IFTHENELSE_K_393()
		_CurrentNode = "RDK:393"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_393")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If i>1 is True
			Call THENGROUP_K_392()

		End if
	End Sub

	'If i>1 is True
	Private Sub THENGROUP_K_392()
		_CurrentNode = "RDK:392"
		'Set query_insert = query_insert+","
		_CurrentNode = "RDK:391"
		query_insert = EvalExpression("Set_query_insert_K_391")
		
	End Sub

	'If row[i-1]<>"" is True
	Private Sub IFTHENELSE_K_398()
		_CurrentNode = "RDK:398"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_398")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If row[i-1]<>"" is True
			Call THENGROUP_K_395()

		else
			'Set query_insert = query_insert+"'"+StrSql(row[i-1])+"'"
			Call ELSEGROUP_K_397()

		End if
	End Sub

	'If row[i-1]<>"" is True
	Private Sub THENGROUP_K_395()
		_CurrentNode = "RDK:395"
		'Set query_insert = query_insert+"'"+StrSql(row[i-1])+"'"
		_CurrentNode = "RDK:394"
		query_insert = EvalExpression("Set_query_insert_K_394")
		
	End Sub

	'Set query_insert = query_insert+"'"+StrSql(row[i-1])+"'"
	Private Sub ELSEGROUP_K_397()
		_CurrentNode = "RDK:397"
		'Set query_insert = query_insert+"''"
		_CurrentNode = "RDK:396"
		query_insert = EvalExpression("Set_query_insert_K_396")
		
	End Sub

	'CODICI
	Private Sub CODICI_K_464()
		_CurrentNode = "RDK:464"
		'Execute SQL Statement
		_CurrentNode = "RDK:449"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_449 as New Generic.list(of object)
		ActionArgs_K_449.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_449.Add(EvalExpression("SqlStatement_K_449")) 'SqlStatement IN
		ActionArgs_K_449.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_449.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_449 As object() = ActionArgs_K_449.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_449)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Set MinCounter = 55000
		_CurrentNode = "RDK:541"
		MinCounter = EvalConstant(MinCounter.GetType, "55000")
		
		'Set MaxCounter = 165000
		_CurrentNode = "RDK:543"
		MaxCounter = EvalConstant(MaxCounter.GetType, "165000")
		
		'Set endwhile = False
		_CurrentNode = "RDK:545"
		endwhile = EvalExpression("Set_endwhile_K_545")
		
		'While endwhile is False
		Call WHILELOOP_K_575()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'While endwhile is False
	Private Sub WHILELOOP_K_575()
next_iteration:
		_CurrentNode = "RDK:575"
		'Group Conditions
		Dim _GroupExecute As Boolean = NOT EvalExpression("CondExp1_K_575")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		
		'Select DB Values
		_CurrentNode = "RDK:562"		'ACTION RDEngineering_DBSelect
		Dim ActionArgs_K_562 as New Generic.list(of object)
		ActionArgs_K_562.Add("PDMTest") 'ConnectionName IN
		ActionArgs_K_562.Add(EvalExpression("SelectQuery_K_562")) 'SelectQuery IN
		ActionArgs_K_562.Add(2) 'SelectQueryType IN
		ActionArgs_K_562.Add(Nothing) 'FirstValue OUT
		ActionArgs_K_562.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_562.Add(table) 'AllRows OUT
		ActionArgs_K_562.Add(Nothing) 'FirstColumn OUT
		ActionArgs_K_562.Add(k) 'NumRows OUT
		ActionArgs_K_562.Add(Nothing) 'ColumnHeader OUT
		ActionArgs_K_562.Add(Nothing) 'ColumnHeaders OUT
		ActionArgs_K_562.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_562 As object() = ActionArgs_K_562.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelect",_ActionArgs_K_562)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		table = _ActionArgs_K_562(5)		'OUT
		k = _ActionArgs_K_562(7)		'OUT
		
		'Set endwhile = IIF(k=0, True, False)
		_CurrentNode = "RDK:563"
		endwhile = EvalExpression("Set_endwhile_K_563")
		
		'Set MinCounter = MaxCounter
		_CurrentNode = "RDK:564"
		MinCounter = EvalExpression("Set_MinCounter_K_564")
		
		'Set MaxCounter = MaxCounter+100000
		_CurrentNode = "RDK:565"
		MaxCounter = EvalExpression("Set_MaxCounter_K_565")
		
		'FOREACH row IN table BYREF
		Call FOREACHLOOP_K_574()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		goto next_iteration
	End Sub

	'FOREACH row IN table BYREF
	Private Sub FOREACHLOOP_K_574()
		_CurrentNode = "RDK:574"
		Dim Values_RDK_574 as object = table
		Dim Index_RDK_574 as integer
		Dim MaxCount_RDK_574 as integer = CompilerUtil.Count(Values_RDK_574)
		If MaxCount_RDK_574 <= 0 then return
		Index_RDK_574 = 0
	next_foreach:
		row = Values_RDK_574(Index_RDK_574)
		
		'Set query_insert = "SET DATEFORMAT dmy;INSERT INTO CODICI VALUES("
		_CurrentNode = "RDK:566"
		query_insert = EvalExpression("Set_query_insert_K_566")
		
		'FOREACH field IN row BYREF
		Call FOREACHLOOP_K_571()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set query_insert = query_insert+")"
		_CurrentNode = "RDK:572"
		query_insert = EvalExpression("Set_query_insert_K_572")
		
		'Execute SQL Statement
		_CurrentNode = "RDK:573"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_573 as New Generic.list(of object)
		ActionArgs_K_573.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_573.Add(EvalExpression("SqlStatement_K_573")) 'SqlStatement IN
		ActionArgs_K_573.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_573.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_573 As object() = ActionArgs_K_573.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_573)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		Index_RDK_574 += 1
		If Index_RDK_574 >= MaxCount_RDK_574 then return
		goto next_foreach
	End Sub

	'FOREACH field IN row BYREF
	Private Sub FOREACHLOOP_K_571()
		_CurrentNode = "RDK:571"
		Dim Values_RDK_571 as object = row
		Dim Index_RDK_571 as integer
		Dim MaxCount_RDK_571 as integer = CompilerUtil.Count(Values_RDK_571)
		If MaxCount_RDK_571 <= 0 then return
		Index_RDK_571 = 0
		j = 1
	next_foreach:
		field = Values_RDK_571(Index_RDK_571)
		
		'If j>1 is True
		Call IFTHENELSE_K_569()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'Set query_insert = query_insert+IIF(field<>"","'"+StrSql(field)+"'", "null")
		_CurrentNode = "RDK:570"
		query_insert = EvalExpression("Set_query_insert_K_570")
		
	next_iteration:
		Index_RDK_571 += 1
		If Index_RDK_571 >= MaxCount_RDK_571 then return
		j += 1
		goto next_foreach
	End Sub

	'If j>1 is True
	Private Sub IFTHENELSE_K_569()
		_CurrentNode = "RDK:569"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_569")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If j>1 is True
			Call THENGROUP_K_568()

		End if
	End Sub

	'If j>1 is True
	Private Sub THENGROUP_K_568()
		_CurrentNode = "RDK:568"
		'Set query_insert = query_insert+","
		_CurrentNode = "RDK:567"
		query_insert = EvalExpression("Set_query_insert_K_567")
		
	End Sub

	'PROPCOD *LOG_DISABLED
	Private Sub PROPCOD_K_500()
		_CurrentNode = "RDK:500"
		'Set MinCounter = 0
		_CurrentNode = "RDK:585"
		MinCounter = EvalConstant(MinCounter.GetType, "0")
		
		'Set MaxCounter = 20000
		_CurrentNode = "RDK:587"
		MaxCounter = EvalConstant(MaxCounter.GetType, "20000")
		
		'Set endwhile = False
		_CurrentNode = "RDK:589"
		endwhile = EvalExpression("Set_endwhile_K_589")
		
		'While endwhile is False
		Call WHILELOOP_K_627()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'While endwhile is False
	Private Sub WHILELOOP_K_627()
next_iteration:
		_CurrentNode = "RDK:627"
		'Group Conditions
		Dim _GroupExecute As Boolean = NOT EvalExpression("CondExp1_K_627")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		
		'Select DB Values
		_CurrentNode = "RDK:614"		'ACTION RDEngineering_DBSelect
		Dim ActionArgs_K_614 as New Generic.list(of object)
		ActionArgs_K_614.Add("PDMTest") 'ConnectionName IN
		ActionArgs_K_614.Add(EvalExpression("SelectQuery_K_614")) 'SelectQuery IN
		ActionArgs_K_614.Add(2) 'SelectQueryType IN
		ActionArgs_K_614.Add(Nothing) 'FirstValue OUT
		ActionArgs_K_614.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_614.Add(table) 'AllRows OUT
		ActionArgs_K_614.Add(Nothing) 'FirstColumn OUT
		ActionArgs_K_614.Add(k) 'NumRows OUT
		ActionArgs_K_614.Add(Nothing) 'ColumnHeader OUT
		ActionArgs_K_614.Add(Nothing) 'ColumnHeaders OUT
		ActionArgs_K_614.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_614 As object() = ActionArgs_K_614.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelect",_ActionArgs_K_614)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		table = _ActionArgs_K_614(5)		'OUT
		k = _ActionArgs_K_614(7)		'OUT
		
		'Set endwhile = IIF(k=0, True, False)
		_CurrentNode = "RDK:615"
		endwhile = EvalExpression("Set_endwhile_K_615")
		
		'Set MinCounter = MaxCounter
		_CurrentNode = "RDK:616"
		MinCounter = EvalExpression("Set_MinCounter_K_616")
		
		'Set MaxCounter = MaxCounter+20000
		_CurrentNode = "RDK:617"
		MaxCounter = EvalExpression("Set_MaxCounter_K_617")
		
		'FOREACH row IN table BYREF
		Call FOREACHLOOP_K_626()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		goto next_iteration
	End Sub

	'FOREACH row IN table BYREF
	Private Sub FOREACHLOOP_K_626()
		_CurrentNode = "RDK:626"
		Dim Values_RDK_626 as object = table
		Dim Index_RDK_626 as integer
		Dim MaxCount_RDK_626 as integer = CompilerUtil.Count(Values_RDK_626)
		If MaxCount_RDK_626 <= 0 then return
		Index_RDK_626 = 0
	next_foreach:
		row = Values_RDK_626(Index_RDK_626)
		
		'Set query_insert = "SET DATEFORMAT dmy;INSERT INTO PROPCOD VALUES("
		_CurrentNode = "RDK:618"
		query_insert = EvalExpression("Set_query_insert_K_618")
		
		'FOREACH field IN row BYREF
		Call FOREACHLOOP_K_623()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set query_insert = query_insert+")"
		_CurrentNode = "RDK:624"
		query_insert = EvalExpression("Set_query_insert_K_624")
		
		'Execute SQL Statement
		_CurrentNode = "RDK:625"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_625 as New Generic.list(of object)
		ActionArgs_K_625.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_625.Add(EvalExpression("SqlStatement_K_625")) 'SqlStatement IN
		ActionArgs_K_625.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_625.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_625 As object() = ActionArgs_K_625.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_625)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		Index_RDK_626 += 1
		If Index_RDK_626 >= MaxCount_RDK_626 then return
		goto next_foreach
	End Sub

	'FOREACH field IN row BYREF
	Private Sub FOREACHLOOP_K_623()
		_CurrentNode = "RDK:623"
		Dim Values_RDK_623 as object = row
		Dim Index_RDK_623 as integer
		Dim MaxCount_RDK_623 as integer = CompilerUtil.Count(Values_RDK_623)
		If MaxCount_RDK_623 <= 0 then return
		Index_RDK_623 = 0
		j = 1
	next_foreach:
		field = Values_RDK_623(Index_RDK_623)
		
		'If j>1 is True
		Call IFTHENELSE_K_621()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'Set query_insert = query_insert+IIF(field<>"","'"+StrSql(StrReplace(field, ",", "."))+"'", "null")
		_CurrentNode = "RDK:622"
		query_insert = EvalExpression("Set_query_insert_K_622")
		
	next_iteration:
		Index_RDK_623 += 1
		If Index_RDK_623 >= MaxCount_RDK_623 then return
		j += 1
		goto next_foreach
	End Sub

	'If j>1 is True
	Private Sub IFTHENELSE_K_621()
		_CurrentNode = "RDK:621"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_621")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If j>1 is True
			Call THENGROUP_K_620()

		End if
	End Sub

	'If j>1 is True
	Private Sub THENGROUP_K_620()
		_CurrentNode = "RDK:620"
		'Set query_insert = query_insert+","
		_CurrentNode = "RDK:619"
		query_insert = EvalExpression("Set_query_insert_K_619")
		
	End Sub

	'SAGE
	Private Sub SAGE_K_629()
		_CurrentNode = "RDK:629"
		'Open DB Connection (SAGE SERVER)
		_CurrentNode = "RDK:644"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_644 as New Generic.list(of object)
		ActionArgs_K_644.Add("SAGETest") 'ConnectionName IN
		ActionArgs_K_644.Add(EvalExpression("ConnectionString_K_644")) 'ConnectionString IN
		ActionArgs_K_644.Add(1) 'Transaction IN
		ActionArgs_K_644.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_644 As object() = ActionArgs_K_644.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_644)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Open DB Connection (SAGE LOCAL)
		_CurrentNode = "RDK:648"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_648 as New Generic.list(of object)
		ActionArgs_K_648.Add("SAGE_Local") 'ConnectionName IN
		ActionArgs_K_648.Add(EvalExpression("ConnectionString_K_648")) 'ConnectionString IN
		ActionArgs_K_648.Add(-1) 'Transaction IN
		ActionArgs_K_648.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_648 As object() = ActionArgs_K_648.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_648)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'ITMMASTER
		Call ITMMASTER_K_653()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Close DB Connection (SAGE SERVER)
		_CurrentNode = "RDK:650"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_650 as New Generic.list(of object)
		ActionArgs_K_650.Add("SAGETest") 'ConnectionName IN
		ActionArgs_K_650.Add(2) 'Transaction IN
		Dim _ActionArgs_K_650 As object() = ActionArgs_K_650.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_650)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Close DB Connection (SAGE LOCAL)
		_CurrentNode = "RDK:652"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_652 as New Generic.list(of object)
		ActionArgs_K_652.Add("SAGE_Local") 'ConnectionName IN
		ActionArgs_K_652.Add(-1) 'Transaction IN
		Dim _ActionArgs_K_652 As object() = ActionArgs_K_652.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_652)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'ITMMASTER
	Private Sub ITMMASTER_K_653()
		_CurrentNode = "RDK:653"
		'Execute SQL Statement
		_CurrentNode = "RDK:658"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_658 as New Generic.list(of object)
		ActionArgs_K_658.Add("SAGE_Local") 'ConnectionName IN
		ActionArgs_K_658.Add(EvalExpression("SqlStatement_K_658")) 'SqlStatement IN
		ActionArgs_K_658.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_658.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_658 As object() = ActionArgs_K_658.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_658)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Set MinCounter = 0
		_CurrentNode = "RDK:660"
		MinCounter = EvalConstant(MinCounter.GetType, "0")
		
		'Set MaxCounter = 100000
		_CurrentNode = "RDK:662"
		MaxCounter = EvalConstant(MaxCounter.GetType, "100000")
		
		'Set endwhile = False
		_CurrentNode = "RDK:664"
		endwhile = EvalExpression("Set_endwhile_K_664")
		
		'While endwhile is False
		Call WHILELOOP_K_694()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'While endwhile is False
	Private Sub WHILELOOP_K_694()
next_iteration:
		_CurrentNode = "RDK:694"
		'Group Conditions
		Dim _GroupExecute As Boolean = NOT EvalExpression("CondExp1_K_694")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		
		'Select DB Values
		_CurrentNode = "RDK:681"		'ACTION RDEngineering_DBSelect
		Dim ActionArgs_K_681 as New Generic.list(of object)
		ActionArgs_K_681.Add("SAGETest") 'ConnectionName IN
		ActionArgs_K_681.Add(EvalExpression("SelectQuery_K_681")) 'SelectQuery IN
		ActionArgs_K_681.Add(2) 'SelectQueryType IN
		ActionArgs_K_681.Add(Nothing) 'FirstValue OUT
		ActionArgs_K_681.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_681.Add(table) 'AllRows OUT
		ActionArgs_K_681.Add(Nothing) 'FirstColumn OUT
		ActionArgs_K_681.Add(k) 'NumRows OUT
		ActionArgs_K_681.Add(Nothing) 'ColumnHeader OUT
		ActionArgs_K_681.Add(headers) 'ColumnHeaders OUT
		ActionArgs_K_681.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_681 As object() = ActionArgs_K_681.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelect",_ActionArgs_K_681)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		table = _ActionArgs_K_681(5)		'OUT
		k = _ActionArgs_K_681(7)		'OUT
		headers = _ActionArgs_K_681(9)		'OUT
		
		'Set endwhile = IIF(k=0, True, False)
		_CurrentNode = "RDK:682"
		endwhile = EvalExpression("Set_endwhile_K_682")
		
		'Set MinCounter = MaxCounter
		_CurrentNode = "RDK:683"
		MinCounter = EvalExpression("Set_MinCounter_K_683")
		
		'Set MaxCounter = MaxCounter+20000
		_CurrentNode = "RDK:684"
		MaxCounter = EvalExpression("Set_MaxCounter_K_684")
		
		'FOREACH row IN table BYREF
		Call FOREACHLOOP_K_693()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		goto next_iteration
	End Sub

	'FOREACH row IN table BYREF
	Private Sub FOREACHLOOP_K_693()
		_CurrentNode = "RDK:693"
		Dim Values_RDK_693 as object = table
		Dim Index_RDK_693 as integer
		Dim MaxCount_RDK_693 as integer = CompilerUtil.Count(Values_RDK_693)
		If MaxCount_RDK_693 <= 0 then return
		Index_RDK_693 = 0
	next_foreach:
		row = Values_RDK_693(Index_RDK_693)
		
		'Set query_insert = "SET IDENTITY_INSERT ITMMASTER ON;SET DATEFORMAT dmy;INSERT INTO ITMMASTER  ("+StrListToStr(headers... (139 chars)
		_CurrentNode = "RDK:685"
		query_insert = EvalExpression("Set_query_insert_K_685")
		
		'FOREACH field IN row BYREF
		Call FOREACHLOOP_K_690()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set query_insert = query_insert+")"
		_CurrentNode = "RDK:691"
		query_insert = EvalExpression("Set_query_insert_K_691")
		
		'Execute SQL Statement
		_CurrentNode = "RDK:692"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_692 as New Generic.list(of object)
		ActionArgs_K_692.Add("SAGE_Local") 'ConnectionName IN
		ActionArgs_K_692.Add(EvalExpression("SqlStatement_K_692")) 'SqlStatement IN
		ActionArgs_K_692.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_692.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_692 As object() = ActionArgs_K_692.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_692)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		Index_RDK_693 += 1
		If Index_RDK_693 >= MaxCount_RDK_693 then return
		goto next_foreach
	End Sub

	'FOREACH field IN row BYREF
	Private Sub FOREACHLOOP_K_690()
		_CurrentNode = "RDK:690"
		Dim Values_RDK_690 as object = row
		Dim Index_RDK_690 as integer
		Dim MaxCount_RDK_690 as integer = CompilerUtil.Count(Values_RDK_690)
		If MaxCount_RDK_690 <= 0 then return
		Index_RDK_690 = 0
		j = 1
	next_foreach:
		field = Values_RDK_690(Index_RDK_690)
		
		'If j>1 is True
		Call IFTHENELSE_K_688()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'Set query_insert = query_insert+IIF(field<>"","'"+StrSql(StrReplace(field, ",", "."))+"'", "null")
		_CurrentNode = "RDK:689"
		query_insert = EvalExpression("Set_query_insert_K_689")
		
	next_iteration:
		Index_RDK_690 += 1
		If Index_RDK_690 >= MaxCount_RDK_690 then return
		j += 1
		goto next_foreach
	End Sub

	'If j>1 is True
	Private Sub IFTHENELSE_K_688()
		_CurrentNode = "RDK:688"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_688")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If j>1 is True
			Call THENGROUP_K_687()

		End if
	End Sub

	'If j>1 is True
	Private Sub THENGROUP_K_687()
		_CurrentNode = "RDK:687"
		'Set query_insert = query_insert+","
		_CurrentNode = "RDK:686"
		query_insert = EvalExpression("Set_query_insert_K_686")
		
	End Sub



#End Region

End Class
