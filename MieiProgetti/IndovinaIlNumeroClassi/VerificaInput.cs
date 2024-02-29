public class VerificaInput : ControlloInput
{
    /// <summary>
    /// Verifica il corretto inserimento del nome giocatore. <br/>
    /// - non deve superare i 18 caratteri
    /// </summary>
    /// <param name="input">L'input inserito dall'utente</param>
    public void MaxNome(string input)
    {
        base.Stringa(input);
        if (input.Length > 18)
        {
            Console.WriteLine("Non puoi inserire più di 18 caratteri");
            PremiUnTasto();
            Valido = false;
        }
    }
}