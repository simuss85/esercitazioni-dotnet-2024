# Problemi e soluzioni

1. VSCode non riconosce l'autocompletamento (intelliCode).  
2. Cancellare commit inviato per errore.
3. Gestire i warning gialli da VSC.
4. Su mac non visualizzo le informazioni sul branch ne i colori.
5. Modifica autocompletamento shell maiuscole/minuscole.

## 4. Su mac non visualizzo le informazioni sul branch ne i colori.
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

