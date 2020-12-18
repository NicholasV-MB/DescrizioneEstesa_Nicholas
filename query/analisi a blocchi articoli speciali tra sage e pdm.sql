--Articoli attivi e speciali di sage
 SELECT ITMREF_0 COLLATE DATABASE_DEFAULT as codCodice, YDESEST_0 COLLATE DATABASE_DEFAULT as Descestesa
       FROM [SRV-DB01\X3V6].[x3v64].[MBKPROD].[ITMMASTER] where  
       YSPECIALE_0=2 and ITMSTA_0 = '1' and TCLCOD_0 in ('SEMI', 'PROD', 'CLAV', 'COMM', 'ALTRI', 'JVIT')
-- Articoli attivi non marcati come speciali ma che lo sono in sage
 SELECT ITMREF_0 COLLATE DATABASE_DEFAULT as codCodice , YDESEST_0 COLLATE DATABASE_DEFAULT as Descestesa
       FROM [SRV-DB01\X3V6].[x3v64].[MBKPROD].[ITMMASTER] where  
       YSPECIALE_0=1 and ITMSTA_0 = '1' and TCLCOD_0 in ('SEMI', 'PROD', 'CLAV', 'COMM', 'ALTRI', 'JVIT')
	   and (SUBSTRING(PLMITMREF_0, 5, 1)='O' or 
			SUBSTRING(PLMITMREF_0, 5, 1)='V' or 
			SUBSTRING(PLMITMREF_0, 5, 1)='C' or 
			SUBSTRING(PLMITMREF_0, 5, 1)='B' or 
			SUBSTRING(PLMITMREF_0, 5, 1)='R' or 
			SUBSTRING(PLMITMREF_0, 5, 1)='S' or 
			SUBSTRING(PLMITMREF_0, 5, 1)='W')


----------------------------------------------------------------------------


--Articoli attivi da PDM con campo speciale a si
SELECT CODICI.codID, codCodice  FROM PDM.dbo.CODICI  WITH (NOLOCK)
       where codLastRev=1 and codExtract=0 and coDBackup=0 and codStatus=3   --and codCodice ='0029513'
       and CODICI.codID in (SELECT codID from PDM.dbo.PROPCOD WITH (NOLOCK) -- deve essere speciale
							where propValore='2' 
								and cpID= '337') --(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK) where cpNome='Speciale'))
       and CODICI.codID not in (SELECT codID from PDM.dbo.PROPCOD WITH (NOLOCK)  -- non deve essere materia prima
								where cpID= '333' --(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK) where cpNome='CodiceParlante') 
									and propValore like 'K%')
       and CODICI.codID in (SELECT codID from PDM.dbo.PROPCOD WITH (NOLOCK) --deve essere delle categorie produttive
							where cpID= '367' --(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK)where cpNome='Categoria_Sage') 
								  and propValore  in ('SEMI', 'PROD', 'CLAV', 'COMM', 'ALTRI', 'JVIT'))

-- articoli attivi da pdm che non sono speciali ma che hanno cod parlante strano
SELECT CODICI.codID, codCodice FROM PDM.dbo.CODICI  WITH (NOLOCK)
       where  codLastRev=1 and codExtract=0 and coDBackup=0 and codStatus=3 
	   and CODICI.codID in (SELECT codID from PDM.dbo.PROPCOD WITH (NOLOCK) -- non deve essere speciale, ovviamente per errore
							where propValore<>'2' 
								and cpID= '337') --(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK) where cpNome='Speciale'))

       and CODICI.codID in (SELECT codID from PDM.dbo.PROPCOD WITH (NOLOCK) --deve essere delle categorie produttive
							where cpID='367' --(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK)where cpNome='Categoria_Sage') 
								and propValore  in ('SEMI', 'PROD', 'CLAV', 'COMM', 'ALTRI', 'JVIT'))
       and CODICI.codID in (SELECT codID FROM PDM.dbo.PROPCOD  WITH (NOLOCK)  --deve avere 5° carattere una lettera come sotto
								WHERE cpID='333' --(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK) where cpNome='CodiceParlante')
									and PROPCOD.propValore not like 'K%'
									and  (SUBSTRING(propValore, 5, 1)='O' or 
										SUBSTRING(propValore, 5, 1)='V' or 
										SUBSTRING(propValore, 5, 1)='C' or 
										SUBSTRING(propValore, 5, 1)='B' or 
										SUBSTRING(propValore, 5, 1)='R' or 
										SUBSTRING(propValore, 5, 1)='S' or 
										SUBSTRING(propValore, 5, 1)='W')
										)
