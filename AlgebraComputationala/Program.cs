namespace AlgebraComputationala;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Algebra Computationala (Design Patterns Edition) ===");
            Console.WriteLine("5. Gauss");
            Console.WriteLine("8. Teoria Codurilor");
            Console.WriteLine("13. Galois");
            Console.WriteLine("14. Euclid");
            Console.WriteLine("0. Iesire");

            Console.Write("\nSelectie: ");
            string opt = Console.ReadLine();

            if (String.IsNullOrEmpty(opt) || opt == "0")
            {
                break;
            }

            IAlgebraPatterns problem = ProblemFactory.GetProblem(opt);

            if (problem != null)
            {
                Console.WriteLine($"\n--- Rulare: {problem.Name} ---");
                Console.WriteLine($"Info: {problem.Description}\n");

                try
                {
                    problem.Solve();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Eroare in executie: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Optiune invalida.");
            }

            Console.WriteLine("\nApasa orice tasta pentru a continua...");
            Console.ReadKey();
        }
    }
}
