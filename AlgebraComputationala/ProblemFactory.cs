namespace AlgebraComputationala;

public class ProblemFactory
{
    public static IAlgebraPatterns GetProblem(string problemNumber)
    {
        return problemNumber switch
        {
            "5" => new GaussProblem(),
            "8" => new CodingTheoryProblem(),
            "13" => new GaloisProblem(),
            "14" => new EuclidProblem(),
            _ => throw new ArgumentException("Problema nu este disponibila."),
        };
    }
}
