namespace AlgebraComputationala;

public class CodingTheoryProblem : IAlgebraPatterns
{
    public string Name => "Problema 8: Teoria Codurilor";

    public string Description => "(din Teoria codurilor) Fiind dat un cod în (Fq)\r\nn , afisati parametrii codului (n, M, d, s, t,\r\nρ). \r\n";

    public void Solve()
    {
        Console.WriteLine("Vom lucra in corpul F_2 (binar) pentru simplicitate.");
        Console.Write("Numar linii (k - lungime mesaj): ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Numar coloane (n - lungime cod): ");
        int n = int.Parse(Console.ReadLine());

        int[,] G = CitesteMatriceBinara(k, n);

        long M = (long)Math.Pow(2, k);
        int d = CalculeazaDistantaMinima(G, k, n);

        int t = (d - 1) / 2;

        Console.WriteLine($"\nParametrii codului:");
        Console.WriteLine($"n (lungime) = {n}");
        Console.WriteLine($"k (dimensiune) = {k}");
        Console.WriteLine($"M (nr cuvinte) = {M}");
        Console.WriteLine($"d (distanta min) = {d}");
        Console.WriteLine($"t (capacitate corectie) = {t}");
    }

    private static int CalculeazaDistantaMinima(int[,] G, int k, int n)
    {
        int minWeight = n;
        int combinatii = (int)Math.Pow(2, k);

        for (int i = 1; i < combinatii; i++)
        {
            int[] cuvant = new int[n];

            for (int row = 0; row < k; row++)
            {
                if (((i >> row) & 1) == 1)
                {
                    for (int col = 0; col < n; col++)
                    {
                        cuvant[col] = (cuvant[col] + G[row, col]) % 2;
                    }
                }
            }

            int weight = cuvant.Count(bit => bit == 1);

            if (weight < minWeight)
            {
                minWeight = weight;
            }
        }

        return minWeight;
    }

    private static int[,] CitesteMatriceBinara(int rows, int cols)
    {
        Console.WriteLine("Introduceti elementele matrici G (doar 0 si 1):");
        int[,] m = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            var line = Console.ReadLine().Split(' ');

            for (int j = 0; j < cols; j++)
            {
                m[i, j] = int.Parse(line[j]);
            }
        }

        return m;
    }
}
