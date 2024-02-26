/*query per il metodo InizializzaApp()*/
CREATE TABLE utenti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
CREATE TABLE listaSpesa (id INTEGER PRIMARY KEY AUTOINCREMENT, alimento TEXT, quantita INTEGER CHECK (quantita > 0), id_utente INTEGER, FOREIGN KEY (id_utente) REFERENCES utenti(id));
CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT);
CREATE TABLE alimenti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, quantita INTEGER CHECK (quantita > 0), data_inserimento DATE, data_scadenza DATE, id_categoria INTEGER, FOREIGN KEY (id_categoria) REFERENCES categorie(id));

/*query per il metodo CreaFrigorifero()*/
INSERT INTO utenti (nome) VALUES ('Luca'), ('Sara'), ('Alex'), ('Emy'); 
INSERT INTO listaSpesa (alimento, quantita, id_utente) VALUES ('yogurt', 3, 2),
                                                              ('prosciutto cotto', 2, 1),
                                                              ('maionese', 1, 3),
                                                              ('insalata', 1, 1);
INSERT INTO categorie (nome) VALUES ('latticini'), ('carne'), ('pesce'), ('salumi'), ('verdure'), ('formaggi'), ('bevanda');
INSERT INTO alimenti (nome, quantita, data_inserimento, data_scadenza, id_categoria) VALUES ('pancetta', 2, '2024-02-10', '2024-03-05', 4),
                                                                                            ('actimel', 6, '2024-02-15', '2024-03-13', 1),
                                                                                            ('braciole', 5, '2024-02-21', '2024-02-28',2),
                                                                                            ('ace', 1, '2024-02-21', '2024-05-25', 7),
                                                                                            ('valeriana', 2, '2024-02-22', '2024-03-01', 5),
                                                                                            ('salame', 4, '2024-02-03', '2024-03-11', 4),
                                                                                            ('orata', 5, '2024-02-20', '2024-02-26', 3);

/*query per la visualizzazione di tutti gli alimenti nel frigo*/
SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id;

/*query per la visualizzazione alimenti scaduti*/
SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id WHERE DATE(data_scadenza) < DATE('now');

/*query per la visualizzazione alimenti in esaurimento*/
SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id WHERE quantita < 2;

/*query per la visualizzazione ordine per nome*/
SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id ORDER BY alimenti.nome;

/*query per la visualizzazione ordine per data di scadenza*/
SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id ORDER BY alimenti.data_scadenza;

/*query per la visualizzazione ordine per data di inserimento*/
SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id ORDER BY alimenti.data_inserimento;

/*query per la visualizzazione ordine per categoria*/
SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id ORDER BY categorie.nome;

/*query per la visualizzazione della lista della spesa*/
SELECT listaSpesa.id, listaSpesa.alimento, listaSpesa.quantita, utenti.nome FROM listaSpesa JOIN utenti ON listaSpesa.id_utente = utenti.id;

/*query per la visualizzazione delle categorie*/
SELECT * FROM categorie;

/*query per la visualizzazione degli utenti*/
SELECT * FROM utenti;

/*query per inserire un dato nella lista della spesa*/
INSERT INTO listaSpesa (alimento, quantita, id_utente) VALUES ('{nome}',{quantita}, (SELECT id FROM utenti WHERE nome = '{utente}'));

/*query per inserire un alimento del frigorifero*/
INSERT INTO alimenti (nome, quantita, data_inserimento, data_scadenza, id_categoria) VALUES ('{nome}',{quantita}, DATE('now'), '{dataScadenza}', (SELECT id FROM categorie WHERE nome = '{categoria}'));

/*query per la modifica dell'utente*/
UPDATE utenti SET nome = '{nome}' WHERE id = {idUtente};

/*query per la modifica della categoria*/
UPDATE categorie SET nome = '{nome}' WHERE id = {idCategoria};

/*query per la modifica degli alimenti*/
UPDATE alimenti SET nome = '{nome}', quantita = {quantita}, data_inserimento = DATE('now'), data_scadenza = '{dataScadenza}', id_Categoria = (SELECT id FROM categorie WHERE nome = '{categoria}') WHERE id = {idAlimento};

/*query per la modifica della lista della spesa*/
UPDATE listaSpesa SET alimento = '{alimento}', quantita = {quantita}, id_utente = (SELECT id FROM utenti WHERE nome = '{nomeUtente}') WHERE  id = {idLista};

/*query che elimina un record dagli alimenti*/
DELETE FROM alimenti WHERE id = {idAlimento};

/*query che elimina un record dalle categorie*/
DELETE FROM categorie WHERE id = {idCategorie};

/*query che elimina un record dalla lista della spesa*/
DELETE FROM listaSpesa WHERE id = {idLista};

/*query che elimina un record dagli utenti*/
DELETE FROM utenti WHERE id = {idUtente};