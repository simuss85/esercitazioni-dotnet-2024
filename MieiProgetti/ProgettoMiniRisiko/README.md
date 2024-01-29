# PROGETTO GIOCO DI DADI

### Descrizone del gioco:
Gioco *stile Risiko* versione super semplificata, con la mappa costituita dai soli 7 continenti (piu i due poli) senza la suddivisione delle varie nazioni. L'obiettivo finale è quello di conquistare tutti i continenti lanciando i dadi e ottenendo il punteggio maggiore contro l'avversario.  
Il gioco prevede anche una modalità rischio, attivabile solo 1 volta per giocatore, che prevede di scommettere sui numeri usciti dopo il lancio dei dadi se pari o dispari, oppure il numero esatto. Come posta in gioco si utilizzano i continenti in proprio possesso. Chi indovina vince quelle messe in palio dall'avversario.



### Specifiche generali:

- [x] Creazione di una mappa visulizzabile da console colorata con colori scelti dall'utente.  
- [x] Il gioco prevede l'utilizzo di due dadi per turno, il numero piu alto decreta la vittoria e la scelta del continente.  
- [x] 1 volta per gioco un utente può decidere se scommettere anche su "Pari o dispari" oppure "Numero esatto".
- [x] Pari o dispari: viene lanciato un dado a 36 facce. Ogni utente mette in palio 1 continente in suo possesso, in caso di vittoria se ne ottengono 2 (1 in palio e 1 a scelta). A turno ogni giocatore chiede all'altro la predizione e poi lancia il dado. Il primo che sbaglia nel corso di un turno, perde.
- [x] Numero esatto: viene lanciato un dado a 50 facce. Ogni utente mette in palio 2 continenti in suo possesso, in caso di vittoria se ne ottengono 3 (2 in palio e 1 a scelta). A turno viene chiesto ad un giocatore la predizione del numero e poi viene lanciato il dado. Chi si avvicina di più al numero segreto vince. In caso di parità si ripete fino al decretamento del vincitore.
Nel caso uno dei due utenti non sia in possesso di 2 continenti, l'opzione non è selezionabile.
- [x] Possibilità di giocare sia contro il pc che contro un altro utente umano.  
- [x] Possibilità di salvare la partita e riprenderla successivamente utilizzando file.txt.
- [x] Possibilità di visualizzare ad ogni turno la situazione attuale della mappa mediante una combinazione di tasti "ctrl"+"m".




### Interazione con l'utente e Design dell'Architettura:
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
    >2.scommetti su pari o dispari  
    >3.scommetti sul numero esatto  
    >s. salva il gioco  
    >(ctrl+M visualizza mappa)

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