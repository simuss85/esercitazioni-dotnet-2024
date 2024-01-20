# Mini guida ai comandi Markdown

indice:
1. Link alle pagine web.  
2. Invio a capo del testo.  
3. Usare il grassetto e il corsivo.  
4. Nascondere il codice (collapse).
5. Cambiare colore del font.
6. Inserire i **link** come una descrizione.


## 1. Guide dal web

<details>
    <summary>link di rifertimento</summary>

- [guida semplice](https://www.ionos.it/digitalguide/siti-web/programmazione-del-sito-web/markdown/)<br>
- [altra guida semplice](http://elearning.lngs.infn.it/help.php?file=advanced_markdown.html)<br>  
- [guida html.it](https://www.html.it/articoli/markdown-guida-al-linguaggio)<br> 
- [guida adobe avanzata](https://experienceleague.adobe.com/docs/contributor/contributor-guide/writing-essentials/markdown.html?lang=it)<br>
- [altra guida avanzata](https://daringfireball.net/projects/markdown/syntax)
- [collapse del testo](https://gist.github.com/pierrejoubert73/902cc94d79424356a8d20be2b382e1ab)<br>
- [cambiare il colore](https://www.puntoinformaticofree.it/markdown_tutorial/markdown-9/markdown-15/)<br>

</details>

## 2. Invio a capo del testo.
Non si può utilizzare il tasto 'Enter' per andare a capo di una riga.  
Si deve utilizzare il 'doppio spazio' da tastiera oppure il tag \<br>

## 3. Usare il grassetto e il corsivo. 
Inserire prima e dopo la parola/frase da modificare:  
Utilizzare il carattere '\*' oppure '\_' per il *corsivo*.  
Utilizzare il carattere '\*\*' oppure '\_\_' per il **grassetto**.   
Utilizzare il carattere '\*\*\*' oppure '\_\_\_' per il ***corsivo-grassetto***.

esempio

```md
Una parola in *corsivo*, oppure _corsivo_
un'altra in **grasseto**, oppure __grassetto__
un'altra in ***corsivo grassetto***, oppure ___corsivo grassetto___

```

## 4. Nascondere il codice (collapse).

```md
<details>
    <summary> titolo </summary>
    Contenuto  
</details>
```

<details>
    <summary> esempio </summary>

 ```c#
    Console.WriteLine("Ciao");
 ```
</details>

## 5. Cambiare il colore del font
Utilizzare il tag html '*font color*' e il colore scelto.

esempio

```md
Una parola di colore <font color="red">rosso</font>
```

## 6. Inserire i link come una descrizione
Utilizzare la sintassi \[descrizione\](link)

esempio

```md
il link normale è https://www.puntoinformaticofree.it/markdown_tutorial/
il link con descrizione è [descrizione](https://www.puntoinformaticofree.it/markdown_tutorial/)
```