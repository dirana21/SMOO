internal class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        float[] value = new float[lines.Length];
        for (int i = 0; i < value.Length; i++)
        {
            value[i] = int.Parse(lines[i]);
        }
        float fuel = value[0] /*1000*/, aToB = value[1] /*800*/, bToc = value[2] /*800*/, kg = value[3] /*1500*/;
        int consume = 0;
        if(kg < 500 && kg > 0) consume = 1;
        else if(kg < 1000 && kg >= 500) consume = 4;
        else if(kg < 1500 && kg >= 1000) consume = 7;
        else if(kg < 2000 && kg >= 1500) consume = 9;
        else
        {
            Console.WriteLine("Cannot proceed to fly!");
            Console.ReadLine();
            return;
        }
        // A to B
        for (int i = 0; i < fuel && i < aToB;)
        {
            if (fuel > consume)
            {
                fuel -= consume;
                aToB -= 1;
            }
            else
            {
                Console.WriteLine("If you fly you fall!! Dont go!");
                Console.ReadLine();
                return;
            }
        }
        // B to C
        bool canRefuel = true;
        if ((fuel / consume) == bToc)
        {
            for (int i = 0; i < fuel; i++)
            {
                if (fuel > consume)
                {
                    fuel -= consume;
                    bToc -= 1;
                }
            }
            Console.WriteLine("You are arrived to C");
            return;
        }
        else
        {
            canRefuel = false;
            Console.WriteLine($"Refuel for {bToc - fuel}");
            fuel += bToc - fuel;
        }
        for (int i = 0; i < fuel; i++)
        {
            if (fuel > consume)
            {
                fuel -= consume;
                bToc -= 1;
            }
            else
            {
                Console.WriteLine("If you fly you fall!! Dont go!");
                Console.ReadLine();
                return;
            }
        }
        Console.WriteLine("You are arrived to C");
    }
}