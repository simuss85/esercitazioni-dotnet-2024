# Corso di programmazione dotNet 2024

<small>Lezioni seguite  ✔️. Lezioni perse in ❌.
</small>  

<!-- ***************   08 gen 2024   ******************** -->
<details>
    <summary><h2>08 gen 2024 ✔️</h2></summary>

Breve introduzione al corso, presentazione dei colleghi. Raccolta del materiale su github. 

Argomenti:
- Installare l'ambiente di lavoro sul pc (VSCode, Git, SDK.net, estensioni VSCode).
- Registrazione su ***github.com*** e prime basi sul versionamento del codice.
- Primi comandi da terminale: git e dotnet.
- Creazione token gitub.
- Creazione prima app da console dotnet.
- Creazione ambiente di lavoro e creazione primo repository.
- Creazione primo file README.md e breve introduzione al Markdown.

### Info
> Password pc 'aula'. Password admin '!Aula'.  
> Estensioni VSCode: C# Dev Kit, Intellicode for C#, C# Snippets, Italiano pack.

### Note
Domande da fare per i colloqui aziendali:
>1. *Utilizzate JS per il vostro tipo di lavoro?*
>2. *QUale hub utilizzate per il versionamento?*
>3. *Utilizzate BootStrap o TailWind?*
>4. *Utilizzate DB relazionali o a documenti (MongoDB)*

### Note
- Primi comandi **git** utilizzati:

```sh
    $ git                        # lista di comandi
    $ git --version              # versione installata
    $ git auth login             # per accedere a git
    $ git init                   # inizializza il repository
    $ git log                    # visualizza lista dei commit
    $ git status                 # viualizza lo stato del repository
    $ git add                    # aggiunge i file allo stage
    $ git commit -m "mess"       # esegue il commit 
    
```
- Primi comandi **dotnet** utilizzati:

```sh
    $ dotnet --version           # versione installata
    $ dotnet new                 # visualizza opzioni di creazione nuovo progetto
    $ dotnet new console         # creo nuovo progetto di app console (da terminale)
    $ dotnet new webapp          # creo nuovo progetto di app web (sito web)
    
```
</details>

<!-- ***************   09 gen 2024   ******************** -->
<details>
    <summary><h2>09 gen 2024 ✔️</h2></summary>

Argomenti:
- ....
- ....
- ....

### Info
> .... 
> .... 
> .... 

### Note
- attenzione a ........
Possibile soluzione 1:

```c#
    // codice di esempio 1
```

- attenzione a ........
Possibile soluzione 2:

```c#
    // codice di esempio 2
```

</details>

<!-- ***************   10 gen 2024   ******************** -->
## 10 gen 2024 ❌

> [!WARNING]  
> Lezione annullata!!!

<!-- ***************   11 gen 2024   ******************** -->
<details>
    <summary><h2>11 gen 2024 ✔️</h2></summary>

Argomenti:
- ....
- ....
- ....

### Info
> .... 
> .... 
> .... 

### Note
- attenzione a ........
Possibile soluzione 1:

```c#
    // codice di esempio 1
```

- attenzione a ........
Possibile soluzione 2:

```c#
    // codice di esempio 2
```

</details>

<!-- ***************   12 gen 2024   ******************** -->
<details>
    <summary><h2>12 gen 2024 ✔️</h2></summary>

Argomenti:
- ....
- ....
- ....

### Info
> .... 
> .... 
> .... 

### Note
- attenzione a ........
Possibile soluzione 1:

```c#
    // codice di esempio 1
```

- attenzione a ........
Possibile soluzione 2:

```c#
    // codice di esempio 2
```

</details>

<!-- ***************   15 gen 2024   ******************** -->
<details>
    <summary><h2>15 gen 2024 ✔️</h2></summary>

Argomenti:
- ....
- ....
- ....

### Info
> .... 
> .... 
> .... 

### Note
- attenzione a ........
Possibile soluzione 1:

```c#
    // codice di esempio 1
```

- attenzione a ........
Possibile soluzione 2:

```c#
    // codice di esempio 2
```

</details>

<!-- ***************   16 gen 2024   ******************** -->
<details>
    <summary><h2>16 gen 2024 ✔️</h2></summary>

Argomenti:
- ....
- ....
- ....

### Info
> .... 
> .... 
> .... 

### Note
- attenzione a ........
Possibile soluzione 1:

```c#
    // codice di esempio 1
```

- attenzione a ........
Possibile soluzione 2:

```c#
    // codice di esempio 2
```

</details>

<!-- ***************   17 gen 2024   ******************** -->
<details>
    <summary><h2>17 gen 2024 ✔️</h2></summary>

Argomenti:
- ....
- ....
- ....

### Info
> .... 
> .... 
> .... 

### Note
- attenzione a ........
Possibile soluzione 1:

```c#
    // codice di esempio 1
```

- attenzione a ........
Possibile soluzione 2:

```c#
    // codice di esempio 2
```

    Argomenti:  
- Fizz Buzz

</details>


<!-- ***************   18 gen 2024   ******************** -->
<details>
    <summary><h2>18 gen 2024 ✔️</h2></summary>

Argomenti:
- Creazione prima calcolatrice.
- Utilizzare le etichette nel codice per il comando "goto"
- Gestire le lingue 'CurrentCulture'
- Gestire il punto o la virgola in inserimento double
- Gestire l'output dei decimali 
- Bitwise operator
- Programma che genera un numero random e chiede di indovinare il numero

### Info
>Utilizziamo il costrutto switch.  
>Verifichiamo l'input inserito, deve essere di tipo intero.  
>Controlla che lo zero non sia inserito nella divisione.  
>Prova le due versioni.  
>Utilizza i double.

### Note
- attenzione a come si scrive il numero double (virgola o punto).
Possibile soluzione:

```c#
    double a = double.Parse(Console.ReadLine()!.Replace(".",","));
```

- nascondere il tasto premuto da console

```c#
    // inserisci senza che si vede il tasto sullo schermo
    ConsoleKeyInfo key = Console.ReadKey(true);
    string selezione = key.keyChar.ToString();
```
</details>

<!-- ***************   19 gen 2024   ******************** -->
<details>
    <summary><h2>19 gen 2024 ✔️</h2></summary>

Argomenti:
- Indovina il numero con i suggerimenti e 10 tentativi.  
- Implementare e aggiungere altri suggerimenti.
- Implementare un sistema a punteggi con possibilità di creare un nuovo gioco.

### Info
> Indicare se il numero è più basso/alto.  
> Indicare se il numero è pari o dispari.  
> La somma delle cifre è.  
> Il numero inizia con.  
> Inserisci il Thread.Sleep per simulare che sta pensando.  
> Inserisci un ciclo per poter avviare un nuovo gioco.  
> Inserimento di un contatore per i punti.  

### Note
- Utilizza il % e la / per isolare le cifre del numero:
```c#
    primaCifra = x / 10;
    resto = x % 10; // rimane 1 cifra
```
- Utilizza **case** nello switch senza i **break**:
```c#
    ......
    case 7:               // suggerimento se piu alto o piu basso
    case 6:               // per tre volte
    case 5:               // di fila 
    case 3:               // e per il 
    case 2:               // resto dei
    case 1:               // tentativi rimasti

    if (input < x)
    ......
```
- Somma delle cifre di un numero:
```c#
    resto = x;
    while (resto > 0)
    {
        somma += resto % 10;
        resto /= 10;
    }
```
</details>

<!-- ***************   22 gen 2024   ******************** -->
## 22 gen 2024 ❌

> [!WARNING]  
> Lezione annullata!!!

<!-- ***************   23 gen 2024   ******************** -->
<details>
    <summary><h2>23 gen 2024 ✔️</h2></summary>

Argomenti:
- Verifica del programma svolto nella lezione precedente
- Gestione degli **errori** e delle **eccezioni**
- Applicare la gestione degli errori ai nostri programmi. 
- Modificata la calcolatrice n.55 con la gestione try-cath.   


### Gestione degli errori e delle eccezioni.  
Try-catch-finally e try-catch-trow-finally. Try-catch-finally di solito usato per la gestione dei database.  
Differenziare gli errori per il programmatore e quelli per l'utente, quindi con la gestione di essi semplifico l'usabilità dei programmi.  

### Info
> Potrei implementare i colori nel codice.  
> Programmino per insegnare la matematica ai bambini e ai DSA.  
> Modifica il Diario, inserisci una batteria con il % che indica il livello del corso.  

### Note 
- Controlla l'input del numero quando seleziono il numero di tentativi. I caratteri non devono essere ammessi.    
Possibile soluzione: 

```c#
    ............
    case "d":
    InputD:
        Console.WriteLine("Scegli il numero di tentativi (max 10).");
        input = Console.ReadLine()!;
        
        try     // gestione errore carattere inserito al posto di un int
        {
            maxTentativi = int.Parse(input);                
        }
        catch 
        {
            Console.WriteLine("Devi inserire un numero valido.");
            goto InputD;   
        }
    ............
```

- Potrei utilizzare un bool di debug per il controllo del codice  
Possibile soluzione:

```c#
    // all'inizio del programma
    bool debug = false;
    
    // quando mi serve utilizzarlo
    if (debug)
    {
        // esegui l'azione da controllare
    }
```

- Verificare il max numero possibile per int o per indice array.  
Codice:

```c#
    // visualizza il max numero per int
    int max = int.MaxValue;

    // visualizzare il max indice per un array
    int maxArray = Array.MaxLength

```

</details>

<!-- ***************   24 gen 2024   ******************** -->
<details>
    <summary><h2>24 gen 2024 ✔️</h2></summary>

Argomenti:
- Finire le modifiche della gestione errori (lezione precedente).  
- Introduzione al beta-test
- Eseguire beta-test del programma del collega.
- Eseguire il post-beta testing.


### Info
> Creazione file README.md per la gestione dei BETA-TEST.  
> Consiglio di utilizzare Jira Software o Trello.

### Note
- Eseguire la radice N-esima di un numero negativo con la funzione **Math.Pow(double, double)**. Con esponente pari la radic di un numero negativo nonesiste, mentre con esponente dispari si e corrisponde alla radice del numero positivo e poi cambiata di segno.  
Esempio: radice 3a di 8 = 2; radice 3a di -8 = -2.  
Possibile soluzione 1:

```c#
    static void Main(string[] args)
    {
        double expRad = 3;
        double exp = 1.0 / expRand;
        double n = -8;
        int segno = 1;
        if (n < 0)
        {
            if (expRad % 2 == 0)
            {
                Console.WriteLine("Operazione impossibile");
                return;
            }
            else
            {
                segno = -1;
                n *= segno;
            }
        }
        double risultato = Math.Pow(n, exp);
        n *= segno;
        risultato *= segno;
        Console.WriteLine($"Radice {expRad} di {n} = {risultato}");
        
    }
```

</details>

<!-- ***************   25 gen 2024   ******************** -->
<details>
    <summary><h2>25 gen 2024 ✔️</h2></summary>

Argomenti:
- Creazione documentazione beta-test e post beta-test.
- Introduzione ai grafici [**Mermaid**](https://jojozhuang.github.io/tutorial/mermaid-cheat-sheet/).
- Persistenza dei dati con la gestione dei file, txt, csv, JSON.
- Accenno ai database: DB relazionali, DB non relazionali, Entity Framework.
- Accenno alle *Lambda Function*.

### Info
> Installata estenzione "Github Markdown Preview" per visualizzare i file .md in modo corretto.

### Note
- Utilizza il metodo Array.Copy
esempio

```c#
    .......
    string[] lines = File.ReadAllLines(path);
    string[] righe = new string[lines.Length];
    
    Array.Copy(lines, righe, lines.Length);
    .......
```

- Utilizzo funzione Lambda
esempio

```c#
    .......
    if (!lines.Any(line => line.StartsWith("a"))) // funzione lambda
    {
        Console.WriteLine("Nessun nome trovato");
    }
    .......
    // versione con funzione classica
    .......
    if (!lines.Any(Prova))
    {
        Console.WriteLine("Nessun nome trovato");
    }
    // funzione 
    static bool Prova(string s)
    {
        return s.StartsWith("a");
    }
```
</details>

<!-- ***************   26 gen 2024   ******************** -->
<details open>
    <summary><h2>26 gen 2024 ✔️</h2></summary>

Argomenti:
- Utilizzo, creazione, gestione dei *file*.
- Implementa la gestione dei file nel gioco *indovina il numero THE GAME*.

### Info
> Salva il punteggio ad ogni sessione di gioco in modo cumulativo.
> .... 
> .... 

### Note 
- Verificare se un giocatore è gia nel file

Possibile soluzione :

```c#
    //mi copio il file su un array di string   
    string[] listaGiocatori = File.ReadAllLines(path);
    // verifico se è un nuovo giocatore
    if (!listaGiocatori.Any(linea => linea.StartsWith(nomeGiocatore)))
    .....
```
### Note per il Mac
- Utilizza "OpenCore Legacy Patcher" per installare i MacOS più recenti non supportti di default.
- Se si usa *Brew* per cancellare la cache di installazione che si riempie facilmente.
Possibile soluzione 1:

```sh
    brew clean cache --prune=all     
```
</details>