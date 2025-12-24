namespace AlgebraComputationala;

public class GaloisProblem : IAlgebraPatterns
{
    public string Name => "Problema 13: Grupul Galois";

    public string Description => "Determinati grupul Galois asociat unui polinom de gradul 3 sau 4. \r\n";

    public void Solve()
    {
        Console.WriteLine("Analizam polinomul de forma: x^3 + px + q = 0");
        Console.Write("Introduceti p: ");
        double p = double.Parse(Console.ReadLine());
        Console.Write("Introduceti q: ");
        double q = double.Parse(Console.ReadLine());

        double delta = -4 * Math.Pow(p, 3) - 27 * Math.Pow(q, 2);
        Console.WriteLine($"\nDiscriminantul este: {delta}");

        if (delta == 0)
        {
            Console.WriteLine("Discriminantul e 0 -> Radacini multiple. Grupul e trivial sau mai mic.");
        }
        else if (delta > 0)
        {
            double sqrt = Math.Sqrt(delta);
            bool isSquare = Math.Abs(Math.Floor(sqrt) - sqrt) < 1e-9;

            if (isSquare)
            {
                Console.WriteLine("Delta este patrat perfect. Grupul Galois este A3 (Grupul Alternat, ordin 3).");
            }
            else
            {
                Console.WriteLine("Delta NU este patrat perfect. Grupul Galois este S3 (Grupul Simetric, ordin 6).");
            }
        }
        else
        {
            Console.WriteLine("Delta < 0. Exista radacini complexe. Grupul Galois este S3.");
        }
    }
}
