## BETA-TEST DEL CODICE

### Segnalazione dei bug:

1. Dopo aver selezionato la modalità, devo inserire i tentativi da utilizzare.
 ```sh
    Scegli il numero di tentativi
    $ 78                                                              //se qua scrivo lettere la gestisce
    Puoi fare un massimo di 6 tentativi in modalità normale
    Scegli il numero di tentativi                                   //ma qua no
    $ hk6
    Unhandled exception. System.FormatException
  ```
  Oppure.
  ```sh
    Scegli il numero di tentativi (max 3).
    $ g
    Devi inserire un numero valido.       
    Scegli il numero di tentativi (max 3).
    $ 5
    Puoi fare un massimo di 3 tentativi in modalità facile
    Scegli il numero di tentativi
    $ g
    Unhandled exception. System.FormatException
  ```

### Suggerimenti:

1. Inserire un controllo sul range dei numeri da indovinare.
 ```sh
    Inizia il gioco. Indovina il numero tra 1 e 10
    Hai 3 tentativi
    $ 999999        // inserisco un numero fuori dal range 1 e 10
    . . . 
    Mi dispiace, hai ancora 2 tentativi
    Suggerimento. Il numero segreto è più basso!   
    $ -121          // inserisco un numero fuori dal range 1 e 10
    Suggerimento. Il numero segreto è più alto!
 ```
