# RD per UpdateDescrizioneEstesa

## Logica 
La gestione dell'aggiornamento delle descrizioni estese è così strutturata:
1. L'utente sceglie uno specifico ITMREF, il tipo articolo di una famiglia o una macrofamiglia da aggiornare
2. Viene generata la lista di ITMREF per famiglia o macrofamiglia e ciclata
  - ad ogni iterazione del ciclo viene chiamato il processo CalcDescEstesa.rdx che fornisce la descrizione estesa o eventuali errori
  - viene controllato che la descrizione ricevuta dal sottoprocesso sia valorizzato, se si viene aggiornato il campo propValore della tabella PROPCOD della descrizione estesa, se no viene scritto un log riguardante quell'ITMREF e l'errore relativo
    - inoltre, se la descrizione estesa è valorizzata, se è stato scelto di aggiornare anche SAGE, verrà aggiornato il campo YDESEST_0 della tabella ITMMASTER, altrimenti verrà aggiornato il campo codModDate di CODICI ad indicare che la descrizione è stata aggiornata sul PDM e non su SAGE, l'aggiornamento di SAGE sarà effettuato in automatico da un'altra prrocedura che confronta le date di modifica

## Setup
Per testare in locale gli RDX sviluppati per la gestione delle traduzioni bisognerà seguire i seguenti passaggi:
- se necessario, configurare il db locale in modo da emulare le tabelle del PDM e di SAGE e lanciare il migrator per le tabelle interessate
- in ambiente di test o produzione, togliere la soppressione sul nodo che chiama Process per usare le stringhe di default e sopprire il nodo che fa il login nel RDX CalcDescEstesa
- copiare il processo CalcDescEstesa dentro la cartella system (fuori da DescrizioneEstesa_Nicholas) sovrascrivendo l'attuale 

## Note sull'esecuzione
- la lista di tipi articolo delle famiglie dipende dai nodi CASE non soppressi del processo CalcDescEstesa.rdx, infatti, all'avvio del programma viene fatta una copia del file dentro la cartella e salvata come txt, vengono cercati tutti i nodi EXP figli di un nodo CASEGROUP, fratello di un nodo EXP che ha un campo di testo uguale a "$TABDATI.TipoArticolo"; a cui vengono tolti quelli soppressi


