class Biblioteca
{
    private List<Libro> libri = new();

    public void Aggiungi(Libro libro)
    {
        libri.Add(libro);
    }

    public void Stampa()
    {
        foreach (Libro libro in libri)
        {
            libro.Stampa();
        }
    }
}