
class Program
{
    // stampa matrice 2x2:
    static void Main(string[] args)
    {
        int[][] matrice = {[ 1, 2, 3], [ 4, 5, 6]};
        Console.WriteLine("");
        
        for (int i = 0; i < matrice.Length; i++)
        {
            for (int j = 0; j < matrice[i].Length; j++)
            {
                Console.Write($"{matrice[i][j]} ");
                
            }
            Console.WriteLine("");
        }
        
    }

}