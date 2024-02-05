## TRACCIA ALIMENTI FRIGORIFERO

Programma che tiene traccia di tutti gli alimenti inseriti nel frigorifero. Si possono inserire i dati da tastiera o da file.csv.  
Avvisa ad ogni avvio gli alimenti prossimi alla scadenza o quelli che stanno per finire (ad esempio ne rimane solo 1).  
Si tiene traccia del nome prodotto, quantità e data di scadenza.

## DEFINIZIONE DEI REQUISITI E ANALISI

- [x] L'applicazione deve consentire all'utente di inserire un prodotto da tastiera.
- [x] L'applicazione deve mostrare un messaggio di errore in caso di inserimento quantita nel formato errato.
- [x] L'applicazione deve mostrare un messaggio di errore in caso di inserimento data scadenza nel formato errata.
- [x] L'applicazione deve permettere di aggiungere uno stesso prodotto incrementando la quantità ma solo con stessa data di scadenza.
- [x] L'applicazione deve differenziare tra oggetti con lo stesso nome ma con data di scadenza diversa.
- [x] L'applicazione deve poter mostrare una tabella aggiornata di tutti i prodotti nel frigorifero.
- [x] L'applicazione deve poter mostrare un elenco di prodotti prossimi alla scadenza.
- [x] L'applicazione deve poter mostrare un elenco di prodotti in esaurimento (ne rimane solo 1).


## PIANIFICAZIONE E DESIGN DELL'ARCHITETTURA

- [x] L'applicazione deve poter leggere da una lista di prodotti in un file csv (prodotto,quantità,data_scadenza).
- [x] L'applicazione deve memorizzare ogni prodotto in un file JSON.
- [x] L'applicazione utilizza i colori per evidenziare i prodotti in scadenza nella tabella generale.
- [x] L'applicazione utilizza i colori per evidenziare i prodotti in esaurimento.
- [x] L'applicazione utilizza un menu principale per la selezione delle opzioni:
    >  **Menu principale**
    > - 1.Inserisci alimento
    > - 2.Visualizza tutti 
    > - 3.Alimenti in scadenza/esaurimento
    > - e.Esci
- [x] L'applicazione utilizza un sotto menu per l'opzione 1:
    > **INSERISCI ALIMENTO**
    > - 1.Inserisci da tastiera
    > - 2.Importa da file csv
    > - r.Torna indietro

## DEFINIZIONE DI STRUTTURE E CONVENZIONI

- [ ] I nomi delle classi devono essere PascalCase.
- [x] I nomi dei metodi devono essere PascalCase.
- [x] I nomi delle variabili devono essere camelCase.
- [x] I nomi delle costanti devono essere UPPERCASE.
- [x] I nomi dei file devono essere lowercase.
- [x] I nomi dei progetti devono essere PascalCase.
- [x] I nomi dei namespace devono essere PascalCase.


## SVILUPPO DEI COMPONENTI

- [x] Creare un progetto console per l'applicazione.
- [ ] Creare un progetto di test per i test unitari.

## TEST E DEBUGGING

- [ ] Scrivere test unitari per i componenti dell'applicazione.
- [ ] Eseguire il debugging per individuare e risolvere i bug.

## DOCUMENTAZIONE

Ora che abbiamo testato e risolto i bug dell'applicazione, dobbiamo documentare il codice e l'architettura.
In questo caso, documenteremo il codice e l'architettura dell'applicazione.
- [x] Documentare il codice e l'architettura dell'applicazione.
- [ ] Documentare i test unitari.
- [ ] Documentare la fase di Beta Testing.

- [ ] Documentare la fase di post Beta Testing.