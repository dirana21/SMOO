namespace Task2;

public class Calculate
{
    public static double CalculateS(double x)
    {
        double sum = 1;
        double term = x + 2;
        int n = 1;
        double accuracy = 1E-6;
        while (Math.Abs(term) >= accuracy)
        {
            sum += term;
            n++;
            term *= (x + 2) / n;
        }

        return Math.Exp(-2) * sum; // Math.Exp = e = 2,7482828415;
    }
}