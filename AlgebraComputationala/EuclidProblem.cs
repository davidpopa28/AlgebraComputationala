namespace AlgebraComputationala;

public class EuclidProblem : IAlgebraPatterns
{
    public string Name => "Problema 14: Algoritmul lui Euclid";

    public string Description => "Folosind algoritmul lui Euclid calculati cmmdc (d) pentru doua numere naturale date\r\n(a,b), scrieti o combinatie liniara a celor trei (a,b,d), afisati fractia continua asociata lui\r\na/b. \r\n";

    public void Solve()
    {
        Console.Write("Introduceti a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Introduceti b: ");
        int b = int.Parse(Console.ReadLine());

        int d = EuclidExtins(a, b, out int x, out int y);

        Console.WriteLine($"\nCMMDC({a}, {b}) = {d}");
        Console.WriteLine($"Combinatia liniara: {d} = ({x}) * {a} + ({y}) * {b}");

        var fractie = CalculFractieContinua(a, b);
        Console.WriteLine($"Fractia continua: [{string.Join(", ", fractie)}]");
    }

    private static int EuclidExtins(int a, int b, out int x, out int y)
    {
        if (b == 0) 
        { 
            x = 1; 
            y = 0; 
            
            return a; 
        }

        int d = EuclidExtins(b, a % b, out int x1, out int y1);
        x = y1;
        y = x1 - (a / b) * y1;

        return d;
    }

    private static List<int> CalculFractieContinua(int num, int numitor)
    {
        List<int> coef = [];
        
        while (numitor != 0)
        {
            coef.Add(num / numitor);
            int r = num % numitor;
            num = numitor; numitor = r;
        }

        return coef;
    }
}
