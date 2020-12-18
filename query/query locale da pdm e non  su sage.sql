SELECT DISTINCT Y.codCodice as ITMREF, PROPCOD.propValore as DESCRIZIONE from PDMTest.dbo.PROPCOD WITH (NOLOCK) inner join
(
	SELECT CODICI.codID, codCodice  FROM PDMTest.dbo.CODICI  WITH (NOLOCK)
	where codLastRev=1 and codExtract=0 and coDBackup=0 and codStatus=3  
	and CODICI.codID in (SELECT codID from PDMTest.dbo.PROPCOD WITH (NOLOCK) where propValore='2' and cpID=(SELECT cpID FROM PDMTest.dbo.CAMPI WITH (NOLOCK) where cpNome='Speciale'))
	and CODICI.codID not in (SELECT codID from PDMTest.dbo.PROPCOD WITH (NOLOCK) where cpID=(SELECT cpID FROM PDMTest.dbo.CAMPI WITH (NOLOCK) where cpNome='CodiceParlante') and propValore like 'K%')
	and CODICI.codID in (SELECT codID from PDMTest.dbo.PROPCOD WITH (NOLOCK) where cpID=(SELECT cpID FROM PDMTest.dbo.CAMPI WITH (NOLOCK) where cpNome='Categoria_Sage') and propValore  in ('SEMI', 'PROD', 'CLAV', 'COMM', 'ALTRI', 'JVIT'))
UNION
	SELECT CODICI.codID, codCodice FROM PDMTest.dbo.CODICI  WITH (NOLOCK)
	where  codLastRev=1 and codExtract=0 and coDBackup=0 and codStatus=3 
	and CODICI.codID in (SELECT codID from PDMTest.dbo.PROPCOD WITH (NOLOCK) where cpID=(SELECT cpID FROM PDMTest.dbo.CAMPI WITH (NOLOCK) where cpNome='Categoria_Sage') and propValore  in ('SEMI', 'PROD', 'CLAV', 'COMM', 'ALTRI', 'JVIT'))
	and CODICI.codID in (
	SELECT X.codID FROM(
		SELECT codID, propValore, SUBSTRING(propValore, 5, 1) AS FifthCh FROM PDMTest.dbo.PROPCOD  WITH (NOLOCK) 
		WHERE cpID=(SELECT cpID FROM PDMTest.dbo.CAMPI  WITH (NOLOCK) where cpNome='CodiceParlante') and PROPCOD.propValore not like 'K%'
	) as X
	WHERE X.FifthCh='O' or 
	X.FifthCh='V' or 
	X.FifthCh='C' or 
	X.FifthCh='B' or 
	X.FifthCh='R' or 
	X.FifthCh='S' or 
	X.FifthCh='W' 
)) as Y on PROPCOD.codID=Y.codID where PROPCOD.cpID=(select cpID from PDMTest.dbo.CAMPI where cpNome ='Descrizione')
and codCodice  in (
	SELECT ITMREF_0 as codCodice
	FROM [x3v64].[dbo].[ITMMASTER] where YDESEST_0<>'' and YSPECIALE_0=2)
order by codCodice