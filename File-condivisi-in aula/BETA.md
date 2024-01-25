
# BETA TEST INDOVINA IL NUMERO SEGRETO

## OBIETTIVI

Testare il programma, segnalare eventuali bug, consigli e spunti sull'user experience.
- Eccezioni del try-catch
  prova bene tutte le eccezioni possibili:
  inserire stringhe invece che numeri, provare numeri troppo grossi ecc.

### BUG:
Controllare problema x che non sono riuscito a risolvere


### USER EXPERIENCE:
- Hai suggerimenti per migliorare l'esperienza dell'utente su questo programma?
- Come valuti l'usabilità e la chiarezza dei menu?
- I colori utilizzati nei messaggi all'utente sono leggibili?

## POST BETA TEST:

<details>
  <summary> Raccolta feedback </summary>
  <details>
    <summary> Feedback di Alex </summary>

>  **Eccezioni**

- [x] stringhe
- [ ] numeri maggiori o minori

>  **Bug**
- [ ] numeri maggiori o minori

>  **Miglioramenti**

- [x] esplicitare il range di numeri tra i quali indovinare
- [x] togliere True e False dai messaggi in console

  </details>
</details>


Priorità
1. Range 
2. Eccezioni
3. Bug Punteggio
## Tempistica di sviluppo

```mermaid
gantt
    title A Gantt Diagram
    dateFormat  YYYY-MM-DD
    section Section
    Range       :a1, 2024-01-24, 1d
    Eccezioni     :after a1, 2d
    section Another
    Bug Punteggio      :a2, 2024-01-24, 2d
    Refactor       :after a2, 4d

```
