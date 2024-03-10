public class Date
{
    public int Anno { get; set; }
    public int Mese { get; set; }
    public int Giorno { get; set; }

    //costruttore
    public Date(int giorno, int mese, int anno)
    {
        if (anno > 1900 && anno < 2200)
        {
            Anno = anno;
        }
        switch (mese)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                if (giorno > 0 && giorno < 32)
                {
                    Giorno = giorno;
                }
                break;

            case 4:
            case 6:
            case 9:
            case 11:
                if (giorno > 0 && giorno < 31)
                {
                    Giorno = giorno;
                }
                break;

            case 2:
                if (anno % 4 == 0)  //bisestile
                {
                    if (giorno > 0 && giorno < 30)
                    {
                        Giorno = giorno;
                    }
                }
                else
                {
                    if (giorno > 0 && giorno < 29)
                    {
                        Giorno = giorno;
                    }
                }
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Override del metodo toString() per la stampa della data.
    /// </summary>
    /// <returns>La data formattata per essere stampata</returns>
    public override string ToString()
    {
        return $"{Giorno}/{Mese}/{Anno}";
    }

    /// <summary>
    /// Calcola da data di oggi 
    /// </summary>
    /// <returns></returns>
    public static Date Oggi()
    {
        Date oggi = new Date(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
        return oggi;
    }

    // public static Date AddGiorni(int giorni)     //TO DO 
    // {

    // }

    /// <summary>
    /// Confronto tra due oggetti di tipo data (data1 e data2). <br/>
    /// Valori restitiuti: <br/>
    /// -1 se data1 maggiore data2 <br/>
    /// 0 se data1 uguale data2 <br/>
    /// 1 se data 1 minore data2 <br/>
    /// 
    /// </summary>
    /// <param name="altraData">La data2 da confrontare</param>
    /// <returns></returns>
    public int ConfrontaData(Date altraData)
    {
        int res = 0;
        if (Anno < altraData.Anno)  //data1 < data2
        {
            res = 1;
        }
        else if (Anno > altraData.Anno) //data1 > data2
        {
            res = -1;
        }
        else if (Anno == altraData.Anno)
        {
            if (Mese < altraData.Mese)  //data1 < data2
            {
                res = 1;
            }
            else if (Mese > altraData.Mese) //data1 > data2
            {
                res = -1;
            }
            else if (Mese == altraData.Mese)
            {
                if (Giorno < altraData.Giorno)  //data1 < data2
                {
                    res = 1;
                }
                else if (Giorno > altraData.Giorno) //data1 > data2
                {
                    res = -1;
                }
                else    //data1 == data2
                {
                    res = 0;
                }
            }
        }
        return res;
    }

    /// <summary>
    /// Confronta due date data1 e data2 e verifica se sono uguali
    /// </summary>
    /// <param name="altraData">La data2 da confrontare</param>
    /// <returns>true se le date sono ugiali; false altrimenti</returns>
    public bool IsEquals(Date altraData)
    {
        bool uguale;
        if (ConfrontaData(altraData) == 0)
        {
            uguale = true;
        }
        else
        {
            uguale = false;
        }
        return uguale;
    }
}