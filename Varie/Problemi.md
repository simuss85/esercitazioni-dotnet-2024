# Problemi e soluzioni
<!-- TOC -->
[1. VSCode non riconosce l'autocompletamento (intelliCode).](#1-vscode-non-riconosce-lautocompletamento-intellicode)  
[2. Cancellare commit inviato per errore su github.](#2-cancellare-commit-inviato-per-errore-su-github)  
[3. Gestire i warning gialli da VSC.](#3-gestire-i-warning-gialli-da-VSC)  
[4. Nella shell non visualizzo i colori e le informazioni sul branch git MacOS.](#4-nella-shell-non-visualizzo-i-colori-e-le-informazioni-sul-branch-git-macos)  
[5. Modifica autocompletamento shell maiuscole/minuscole.](#5-modifica-autocompletamento-shell-maiuscoleminuscole)  
[6. Creato per errore un doppio autore con lo stesso account git](#6-creato-per-errore-un-doppio-autore-con-lo-stesso-account-git)  
[7. Aggiornare sqlite3 su MacOS con Brew](#7-aggiornare-sqlite3-su-macos-con-brew)

<!-- /TOC -->

## 1. VSCode non riconosce l'autocompletamento (intelliCode).  

Possibili soluzioni:
- Si sta utilizzando un estensione per la lingua che causa dei problemi.  
  Provare a disinstallare e installare di nuovo.
- C'è un problema nel file ***solution.sln***. Potrebbe capitare che il progetto attuale non sia stato aggiunto alla *solution*. Provare ad aggiungere il nuovo progetto nel modo seguente:
   1. Aprire il terminale nella root della *solution*.
   2. Verifica che nel file sia presente il nuovo progetto digitando:
  
  ```sh
     dotnet sln list
  ```
     3. Nel caso in cui il progetto non sia presente, aggiungerlo aggiungerlo digitando:

   ```sh
      dotnet sln add       #trascina qui la cartella del progetto oppure digita il nome del file.csproj
   ```

## 2. Cancellare commit inviato per errore su github.

Nel caso volessimo cancellare un commit gia inviato al server di github eseguiamo questa procedura:

1. Visualizza lo stato attuale di tutti i commit su di una riga con il comando seguente:

```sh
   git status --oneline --all
```
2. Eliminiamo l'ultimo commit (o gli n-ultimi), scegliendo l'opzione `--hard` nel caso volessimo ripristinare anche dal repository locale tutti i file, oppure `--soft` per mantenere i file modificati:

```sh
   git reset --soft[--hard] HEAD~1           #cancella l'ultimo commit
   git reset --soft[--hard] HEAD~3           #cancella ultimi 3 commit
   git reset --soft[--hard] HEAD^            #anche questo cancella ultimo commit
```
3. Controlliamo lo status dei commit come nel punto 1. e se siamo soddisfatti digitiamo:
```sh
   git push --force
```

## 3. Gestire i warning gialli da VSC.

1. Possibile riferimento null di una variabile **string**.
   
   esempio:
```c#
    // utilizza il carattere ? dopo il nome del tipo    
    string? input = Console.ReadLine();

    // utilizza il carattere ! dopo il nome del metodo
    string input = Console.ReadLine()!;
```
2. Disattivare qualsiasi tipo di warning e riabilitarlo.

   esempio:
```c#
    /* quando non utilizzo una variabile nel programma apre in warning
       quindi posso disabilitare momentaneamente i warning e all'occorrenza
    */ rittivarli anche subito dopo

    #pragma warning disable
    int numero; // variabile non utilizzata
    #pragma warning restore
```

## 4. Nella shell non visualizzo i colori e le informazioni sul branch git (MacOS).
[soluzione web](https://dev.to/devpato/customize-your-mac-terminal-vs-code-too-easy-2315)

Procedura:
1. La prima cosa da fare è aprire "Vai alla cartella" e digita: 

```sh 
    ~/.bash_profile 
```

   Nel caso non esista il file, andare nella directory '~/' e digitare il comando:

```sh
    nano ~/.bash_profile
```
In questo modo si crea il file da personalizzare e si apre automaticamente l'editor di modifica del file.

2. Adesso inseriamo la nostra personalizzazione per la bash copiando il codice seguente nell'editor:

```sh
    # Git Branch

    parse_git_branch() {
    git branch 2> /dev/null | sed -e '/^[^*]/d' -e 's/* \(.*\)/ (\1)/'
    }

    #export PS1="\u@\h \W\[\033[32m\]\$(parse_git_branch)\[\033[00m\] $ "

    # Folder Color

    export PS1="\[\033[36m\]\u\[\033[m\]@\[\033[32m\]\h:\[\033[33;1m\]\w\[\033[m\]\[\033[32m\]\$(parse_git_branch)\[\033[00m\]\n$ "
    export CLICOLOR=1
    export LSCOLORS=ExFxBxDxCxegedabagacad
    alias ls='ls -GFh'
```
Adesso abbiamo i colori e la visualizzazione del branch (main) nella bash.

3. Impostiamo VSCode per aprire di default la shell bash

## 5. Modifica autocompletamento shell maiuscole/minuscole.

Nella shell si può utilizzare l'autocompletamento con il tasto **tab** ma è *case sensitive*.  
Per utilizzare sia maiuscole che minuscole indifferentemente si deve creare il file '.inputrc':

1. Apri il terminale nella root '~/' e digita:

```sh
    echo "set completion-ignore-case On" >> ~/.inputrc
```

Riavvia il terminale.

## 6. Creato per errore un doppio autore con lo stesso account git:
Potrebbe capitare quando nella procedura di inizializzazione di github sul nuovo pc si esegue un accesso diverso da quello con token. Purtroppo non si possono modificare i commit passati quindi non risulterà alcun contributo da parte dell'autore doppio.  
Conviene quindi salvare ciò che ci serve, cancellare dal pc locale tutto il repository e procedere come segue.
Per prima cosa verifichiamo la versione di **gh** installata sul pc digitando il comando:
```sh
   gh version     #restituisce la versione corrente se installata
```
Nel caso non venisse visualizzata alcuna versione, probabilmente non è stata installata precedentemente. Su windows basta installare il file.exe. Su mac seguire la procedura seguente, dopo aver installato il pacchetto `brew` (vedi la guida):
```sh
   brew install gh   
```
Una volta installato **gh** eseguire l'accesso e seguire la procedura guidata, con il comando:
```sh
   gh auth login
```
Arrivati alla sezione token, andiamo su github per generare un nuovo token e copiamolo nel terminale quando richiesto.  
Adesso tutto dovrebbe essere corretto.

## 7. Aggiornare sqlite3 su MacOS con Brew:
Per prima cosa verifica se **sqlite3** è gia installato nel Mac eseguendo il comando seguente:
```sh
   sqlite3 --version    #restituisce la versione corrente se installata
```
Se vogliamo aggiornare alla nuova versione utilizzando il pacchetto `brew` digitiamo il comando seguente:
```sh
   brew install sqlite3
```
Una volta installato avremo una nuova versione di **sqlite3** nella folder `/usr/local/Cellar/sqlite/3.45.1/bin/sqlite3`.  
Adesso dobbiamo assegnare il nuovo percorso al PATH di sistema seguendo questi passaggi:
1. per prima cosa dobbiamo aprire il file di configurazione della shell in uso con *nano*:
```sh
   nano ~/.bash_profile
```
2. Alla fine del file inseriamo il codice seguente:
```sh
   #PATH di sistema per sqlite3 v.3.45.1
   export PATH="/usr/local/Cellar/sqlite/3.45.1/bin:$PATH"
```
3. Salva il file e chiudilo. Nell'editor nano, premi `Ctrl + X`, quindi conferma di voler salvare le modifiche premendo `invio`.
4. Per rendere effettive le modifiche digita:
```sh
   source ~/.bash_profile
```
5. Riavvia il terminale e verifica che il "PATH" sia aggiornato eseguendo il comando:
```sh
   echo $PATH
```