# Problemi e soluzioni
<!-- TOC -->
[1. VSCode non riconosce l'autocompletamento (intelliCode).](#1-vscode-non-riconosce-lautocompletamento-intellicode)  
[2. Cancellare commit inviato per errore.](#2-cancellare-commit-inviato-per-errore)  
[3. Gestire i warning gialli da VSC.](#3-gestire-i-warning-gialli-da-VSC)  
[4. Nella shell non visualizzo i colori e le informazioni sul branch git MacOS.](#4-nella-shell-non-visualizzo-i-colori-e-le-informazioni-sul-branch-git-macos)  
[5. Modifica autocompletamento shell maiuscole/minuscole.](#5-modifica-autocompletamento-shell-maiuscoleminuscole)  

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
      dotnet sln add "trascina qui la cartella del progetto oppure digita il nome del file.csproj"
   ```

## 2. Cancellare commit inviato per errore.

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

