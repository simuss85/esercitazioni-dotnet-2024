# Mini guida ai comandi Markdown

## 1. Guide dal web

<details>
    <summary>link</summary>

- https://www.ionos.it/digitalguide/siti-web/programmazione-del-sito-web/markdown/<br>
- https://www.html.it/articoli/markdown-guida-al-linguaggio<br> 
- https://experienceleague.adobe.com/docs/contributor/contributor-guide/writing-essentials/markdown.html?lang=it<br>
- http://elearning.lngs.infn.it/help.php?file=advanced_markdown.html<br>  
- https://gist.github.com/pierrejoubert73/902cc94d79424356a8d20be2b382e1ab<br>

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

## 4. Nascondere il codice nel file file.md (collapse)

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