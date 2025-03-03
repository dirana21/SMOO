internal class Program
{
    static void Main(string[] args)
    {
        //1 Task
        const float PI = 3.14159265358979323846f;
        float c = 0;
        Console.WriteLine("Введите значение x: ");
        float x = float.TryParse(Console.ReadLine(), out float resultX) ? resultX : 3.251f;
        Console.WriteLine("Введите значение y: ");
        float y = float.TryParse(Console.ReadLine(), out float resultY) ? resultY : 0.325f;
        Console.WriteLine("Введите значение z: ");
        float z = float.TryParse(Console.ReadLine(), out float resultZ) ? resultZ : 1E-4f;
        c = (float)(float.Pow(2, float.Pow(y,x)) + float.Pow(float.Pow(3,x),y) - (y*(Math.Atan(z) - PI/6)) / float.Abs(x) + (1 / float.Pow(y,2) + 1));
        Console.WriteLine($"The result of that is: {c}");
    }
}