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

--Articoli speciali o con codparl speciale presenti in PDM e con desc estesa diversa da sage
select --top 10 
* from 
(
--Articoli attivi da PDM con campo speciale a si
SELECT C1.codID as ID, C1.codCodice as codice FROM PDM.dbo.CODICI C1 WITH (NOLOCK)
       where C1.codLastRev=1 and C1.codExtract=0 and C1.coDBackup=0 and C1.codStatus=3   --and codCodice ='0029513'
       and C1.codID in (SELECT P1.codID from PDM.dbo.PROPCOD P1 WITH (NOLOCK) -- deve essere speciale
							where P1.propValore='2' 
								and P1.cpID= '337') --(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK) where cpNome='Speciale'))
       and C1.codID not in (SELECT P2.codID from PDM.dbo.PROPCOD P2 WITH (NOLOCK)  -- non deve essere materia prima
								where P2.cpID= '333' --(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK) where cpNome='CodiceParlante') 
									and P2.propValore like 'K%')
       and C1.codID in (SELECT P3.codID from PDM.dbo.PROPCOD P3 WITH (NOLOCK) --deve essere delle categorie produttive
							where P3.cpID= '367' --(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK)where cpNome='Categoria_Sage') 
								  and P3.propValore  in ('SEMI', 'PROD', 'CLAV', 'COMM', 'ALTRI', 'JVIT'))
union all
-- articoli attivi da pdm che non sono speciali ma che hanno cod parlanet strano
SELECT C2.codID as ID, C2.codCodice as codice FROM PDM.dbo.CODICI C2 WITH (NOLOCK)
       where  C2.codLastRev=1 and C2.codExtract=0 and C2.coDBackup=0 and C2.codStatus=3 
	   and C2.codID in (SELECT P4.codID from PDM.dbo.PROPCOD P4 WITH (NOLOCK) -- non deve essere speciale, ovviamente per errore
							where P4.propValore<>'2' 
								and P4.cpID= '337') --(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK) where cpNome='Speciale'))

       and C2.codID in (SELECT P5.codID from PDM.dbo.PROPCOD P5 WITH (NOLOCK) --deve essere delle categorie produttive
							where P5.cpID='367' --(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK)where cpNome='Categoria_Sage') 
								and P5.propValore  in ('SEMI', 'PROD', 'CLAV', 'COMM', 'ALTRI', 'JVIT'))
       and C2.codID in (SELECT P6.codID FROM PDM.dbo.PROPCOD P6  WITH (NOLOCK)  --deve avere 5° carattere una lettera come sotto
								WHERE P6.cpID='333' --(SELECT cpID FROM PDM.dbo.CAMPI WITH (NOLOCK) where cpNome='CodiceParlante')
									and P6.propValore not like 'K%'
									and  (SUBSTRING(P6.propValore, 5, 1)='O' or 
										SUBSTRING(P6.propValore, 5, 1)='V' or 
										SUBSTRING(P6.propValore, 5, 1)='C' or 
										SUBSTRING(P6.propValore, 5, 1)='B' or 
										SUBSTRING(P6.propValore, 5, 1)='R' or 
										SUBSTRING(P6.propValore, 5, 1)='S' or 
										SUBSTRING(P6.propValore, 5, 1)='W')
										)
) as xx
Inner Join PDM.dbo.PROPCOD P7 on P7.CodID = xx.ID and P7.cpID = '369'
 where P7.propValore <> (SELECT YDESEST_0 COLLATE DATABASE_DEFAULT as Descestesa
							FROM [SRV-DB01\X3V6].[x3v64].[MBKPROD].[ITMMASTER] 
							where  ITMREF_0 COLLATE DATABASE_DEFAULT = xx.codice)

