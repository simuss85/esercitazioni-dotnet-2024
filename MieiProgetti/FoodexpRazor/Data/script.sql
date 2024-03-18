INSERT INTO Utenti (Nome, Password) VALUES ('Simone','12345678'), ('Emy','pongo89'), ('Alex','maria99'); 


INSERT INTO Categorie (Nome) VALUES ('latticini'), ('salumi'), ('frutta'), ('verdura'), ('formaggi'), ('carne'), ('pesce'), ('bevande');

INSERT INTO Alimenti (Nome, Quantita, DataScadenza, DataInserimento, CategoriaId, Immagine) VALUES ('prosciutto cotto', 2, '2024-02-10', '2024-03-05', 4, '~/img/p-cotto.jpg'),
                                                                                            ('actimel', 6, '2024-02-15', '2024-03-13', 1, '~/img/actimel.jpg'),
                                                                                            ('braciole', 5, '2024-02-21', '2024-02-28',2, '~/img/fridge.jpg'),
                                                                                            ('ace', 1, '2024-02-21', '2024-05-25', 7, '~/img/fridge.jpg'),
                                                                                            ('insalata', 2, '2024-02-22', '2024-03-01', 5, '~/img/insalata.jpg'),
                                                                                            ('yogurt fragola', 4, '2024-02-03', '2024-03-11', 4, '~/img/yogurt-fragola.jpg'),
                                                                                            ('orata', 5, '2024-02-20', '2024-02-26', 3, '~/img/fridge.jpg');

INSERT INTO ListaSpesa (Alimento, Quantita, CategoriaId, UtenteId) VALUES ('latte', 3, 1, 2),
                                                              ('prosciutto cotto', 2, 2, 1),
                                                              ('parmigiano', 1, 5, 3),
                                                              ('valeriana', 1, 4, 2);