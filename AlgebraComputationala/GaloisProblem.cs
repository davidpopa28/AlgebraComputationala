namespace AlgebraComputationala;

public class GaloisProblem : IAlgebraPatterns
{
    public string Name => "Problema 13: Grupul Galois (General)";
    public string Description => "Grupul Galois pentru ax^3 + bx^2 + cx + d = 0 (forma generala).";

    public void Solve()
    {
        Console.WriteLine("Analiza polinom: P(x) = a*x^3 + b*x^2 + c*x + d");

        Console.Write("a = "); double a = double.Parse(Console.ReadLine());
        
        if (Math.Abs(a) < 1e-9) 
        { 
            Console.WriteLine("Asta nu e ecuatie de gradul 3 (a=0)!"); 
            return; 
        }

        Console.Write("b = "); double b = double.Parse(Console.ReadLine());
        Console.Write("c = "); double c = double.Parse(Console.ReadLine());
        Console.Write("d = "); double d = double.Parse(Console.ReadLine());

        if (AreRadacinaRationala(a, b, c, d))
        {
            Console.WriteLine("\nPolinomul este REDUCTIBIL (are cel putin o radacina rationala).");
            Console.WriteLine("Grupul Galois este trivial (ordin 1) sau C2 (ordin 2), nu S3/A3.");

            return;
        }

        Console.WriteLine("\nPolinomul este IREDUCTIBIL peste Q.");

        double delta = (18 * a * b * c * d)
                     - (4 * Math.Pow(b, 3) * d)
                     + (Math.Pow(b, 2) * Math.Pow(c, 2))
                     - (4 * a * Math.Pow(c, 3))
                     - (27 * Math.Pow(a, 2) * Math.Pow(d, 2));

        Console.WriteLine($"Discriminantul (Delta) este: {delta}");

        if (Math.Abs(delta) < 1e-9)
        {
            Console.WriteLine("Delta = 0. Exista radacini multiple.");
        }
        else if (delta > 0)
        {
            if (EstePatratPerfect(delta))
            {
                Console.WriteLine("Delta > 0 si este Patrat Perfect -> Grupul Galois este A3 (Alternat, ordin 3).");
            }
            else
            {
                Console.WriteLine("Delta > 0 dar NU este Patrat Perfect -> Grupul Galois este S3 (Simetric, ordin 6).");
            }
        }
        else
        {
            Console.WriteLine("Delta < 0 -> Grupul Galois este S3 (Simetric, ordin 6).");
        }
    }

    private static bool EstePatratPerfect(double n)
    {
        if (n < 0)
        {
            return false;
        }

        double root = Math.Sqrt(n);

        return Math.Abs(root - Math.Round(root)) < 1e-5;
    }

    private static bool AreRadacinaRationala(double a, double b, double c, double d)
    {
        if (Math.Abs(d) < 1e-9)
        {
            return true;
        }

        int ia = (int)a;
        int id = (int)d;

        List<int> divizoriD = GetDivisors(id);
        List<int> divizoriA = GetDivisors(ia);

        foreach (int p in divizoriD)
        {
            foreach (int q in divizoriA)
            {
                double x1 = (double)p / q;
                double x2 = -(double)p / q;

                if (IsRoot(a, b, c, d, x1))
                {
                    return true;
                }

                if (IsRoot(a, b, c, d, x2))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool IsRoot(double a, double b, double c, double d, double x)
    {
        double val = a * Math.Pow(x, 3) + b * Math.Pow(x, 2) + c * x + d;
        
        return Math.Abs(val) < 1e-5;
    }

    private static List<int> GetDivisors(int n)
    {
        List<int> list = [];
        n = Math.Abs(n);

        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                list.Add(i);
            }
        }
        
        return list;
    }
}