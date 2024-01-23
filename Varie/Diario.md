# Corso di programmazione dotNet 2024

<small>Lezioni seguite  ✔️. Lezioni perse in ❌.
</small>  

<!-- ***************   08 gen 2024   ******************** -->
<details>
    <summary><h2>08 gen 2024 ✔️</h2></summary>
  
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
<details>
    <summary><h2>10 gen 2024 ❌</h2></summay>

> [!WARNING]  
> Lezione annullata!!!

</details>

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
<details>
    <summary><h2>22 gen 2024 ❌</h2></summay>

> [!WARNING]  
> Lezione annullata!!!

</details>

<!-- ***************   23 gen 2024   ******************** -->
<details open>
    <summary><h2>23 gen 2024 ✔️</h2></summary>

Argomenti:
- Verifica del programma svolto nella lezione precedente
- ....
- ....

### Info
> Potrei implementare i colori nel codice
> Programmino per insegnare la matematica ai bambini e ai DSA
> .... 

### Note 
- Controlla l'input del numero quando seleziono il numero di tentativi
Possibile soluzione: 

```c#
    // da verificare
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

</details>

<!-- ***************   24 gen 2024   ******************** -->
<details>
    <summary><h2>24 gen 2024 </h2></summary>

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

<!-- ***************   25 gen 2024   ******************** -->
<details>
    <summary><h2>25 gen 2024 </h2></summary>

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

<!-- ***************   26 gen 2024   ******************** -->
<details>
    <summary><h2>26 gen 2024 </h2></summary>

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