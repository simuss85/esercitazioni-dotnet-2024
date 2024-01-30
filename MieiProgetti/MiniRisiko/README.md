# PROGETTO MINI-RISIKO

### Descrizone del gioco:
Gioco *stile Risiko* versione super semplificata, con la mappa costituita da 8 continenti (piu i due poli). L'obiettivo finale è quello di conquistare tutti i continenti utilizzando il lancio di due dadi. Il gioco prevede anche una *modalità rischio*, attivabile solo 1 volta per giocatore.

#### Regole
>**Lanciando i dadi**: ottenendo il punteggio maggiore contro l'avversario si vince 1 continente a scelta sulla mappa.

>**Pari o dispari:** viene lanciato un dado a 36 facce. Ogni utente mette in palio 1 continente in suo possesso, in caso di vittoria se ne ottengono 2 (1 in palio e 1 a scelta). A turno ogni giocatore chiede all'altro la predizione e poi lancia il dado. Il primo che sbaglia nel corso di un turno, perde.  

>**Numero esatto:** viene lanciato un dado a 50 facce. Ogni utente mette in palio 2 continenti in suo possesso, in caso di vittoria se ne ottengono 3 (2 in palio e 1 a scelta). A turno viene chiesto ad un giocatore la predizione del numero e poi viene lanciato il dado. Chi si avvicina di più al numero segreto vince. In caso di parità si ripete fino al decretamento del vincitore.
Nel caso uno dei due utenti non sia in possesso di 2 continenti, l'opzione non è selezionabile.




### DEFINIZIONE DEI REQUISITI E ANALISI:

- [x] L'applicazione permette di insiere il nome utente e fargli scegliere un colore per le sue armate.
- [x] L'applicazione deve creare di volta in volta la mappa dei continenti di tipo testuale e colorata, aggiornata ad ogni turno di gioco.  
- [x] Il gioco prevede l'utilizzo di due dadi a 6 facce per turno.
- [x] Una volta per gioco un utente può decidere se scommettere anche su "Pari o dispari" oppure "Numero esatto".
- [x] Possibilità di giocare sia contro il pc che contro un altro utente umano.  
- [x] Possibilità di salvare la partita e riprenderla successivamente utilizzando file.txt.
- [x] Possibilità di visualizzare ad ogni turno la situazione attuale della mappa mediante una combinazione di tasti "ctrl"+"m".




### PIANIFICAZIONE E DESIGN DELL'ARCHITETTURA
- [x] Menu di selezione iniziale con 5 opzioni:   
    >1.gioca contro pc,  
    >2.gioca contro giocatore 2  
    >3.riprendi ultima partita  
    >4.Regole di gioco  
    >5.exit. 

- [x] Menu di selezione colore:
    >r.Rosso  
    >b.Blu  
    >n.Nero  
    >g.Giallo  
    >v.Verde  

- [x] Menu di gioco giocatore con 3 opzioni:  
    >1.lancia i dadi  
    >2.rischia  
    >s. salva il gioco  
    >(ctrl+M visualizza mappa)

- [x] Menu modalità rischio:  
    >1.Scommetti su pari o dispari (costo 1 continente)  
    >2.Scommetti sul numero esatto (costo 2 continenti)  
    >r.Ritorna alla schermata precedente

- [x] Menu pari o dispari:
    >1.Pari  
    >2.Dispari

- [x] Menu numero esatto: 
    >inserisci il numero

- [x] Mappa dei continenti:  
    >   MAPPA DEL MONDO  
    >|AMERICA|ASIA|EUROPA|SUD AMERICA|AFRICA|OCEANIA|POLO SUD|POLO NORD|

- [x] Richiesta input per l'inserimento nome/i
- [x] Richiesta input per l'inserimento del numero esatto (da 1 a 50)



### Test e Debugging