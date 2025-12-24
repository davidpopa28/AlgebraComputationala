namespace AlgebraComputationala;

public class GaussProblem : IAlgebraPatterns
{
    public string Name => "Problema 5: Metoda lui Gauss";

    public string Description => "Calculati rangul unei matrici prin metoda lui Gauss. Calculati inversa unei matrici prin\r\nmetoda lui Gauss";

    public void Solve()
    {
        Console.Write("Dimensiune n: ");
        int n = int.Parse(Console.ReadLine());
        double[,] matrix = CitesteMatrice(n);

        int rang = CalculeazaRang(ClonaMatrice(matrix, n), n);
        Console.WriteLine($"Rang: {rang}");

        if (rang == n)
        {
            var inv = CalculeazaInversa(matrix, n);
            AfiseazaMatrice(inv, n);
        }
        else
        {
            Console.WriteLine("Matricea nu este inversabila.");
        }
    }

    static int CalculeazaRang(double[,] a, int n)
    {
        int rang = 0;

        for (int j = 0; j < n; j++)
        {
            int pivotRow = rang;

            while (pivotRow < n && Math.Abs(a[pivotRow, j]) < 1e-9)
            {
                pivotRow++;
            }

            if (pivotRow < n)
            {
                for (int k = 0; k < n; k++)
                {
                    (a[pivotRow, k], a[rang, k]) = (a[rang, k], a[pivotRow, k]);
                }

                for (int i = rang + 1; i < n; i++)
                {
                    double factor = a[i, j] / a[rang, j];

                    for (int k = j; k < n; k++)
                    {
                        a[i, k] -= factor * a[rang, k];
                    }
                }

                rang++;
            }
        }

        return rang;
    }

    static double[,] CalculeazaInversa(double[,] a, int n)
    {
        double[,] extinsa = new double[n, 2 * n];
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                extinsa[i, j] = a[i, j];
            }

            extinsa[i, n + i] = 1;
        }

        for (int i = 0; i < n; i++)
        {
            int pivot = i;

            for (int j = i + 1; j < n; j++)
            {
                if (Math.Abs(extinsa[j, i]) > Math.Abs(extinsa[pivot, i])) pivot = j;
            }

            for (int k = 0; k < 2 * n; k++)
            {
                (extinsa[pivot, k], extinsa[i, k]) = (extinsa[i, k], extinsa[pivot, k]);
            }

            double div = extinsa[i, i];

            for (int k = 0; k < 2 * n; k++)
            {
                extinsa[i, k] /= div;
            }

            for (int j = 0; j < n; j++)
            {
                if (i != j)
                {
                    double mult = extinsa[j, i];
                    for (int k = 0; k < 2 * n; k++) extinsa[j, k] -= mult * extinsa[i, k];
                }
            }
        }

        double[,] inv = new double[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {

                inv[i, j] = extinsa[i, n + j];
            }
        }

        return inv;
    }

    static double[,] CitesteMatrice(int n)
    {
        double[,] m = new double[n, n];
        Console.WriteLine($"Introduceti elementele matrici ({n}x{n}):");

        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split([' '], StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < n; j++)
            {
                if (j < line.Length) m[i, j] = double.Parse(line[j]);
            }
        }

        return m;
    }

    static void AfiseazaMatrice(double[,] m, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{m[i, j]:0.00}\t");
            }

            Console.WriteLine();
        }
    }

    static double[,] ClonaMatrice(double[,] src, int n)
    {
        double[,] dest = new double[n, n];
        Array.Copy(src, dest, src.Length);

        return dest;
    }
}
