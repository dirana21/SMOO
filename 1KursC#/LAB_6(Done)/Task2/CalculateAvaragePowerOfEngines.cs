namespace Task2
{
    public class CalculateAvaragePowerOfEngines
    {
        
        
        public static void CalculateDiesel(Engine[] engine)
        {
            double totalPowerdiesel = 0;
            int dieseltCount = 0;
            foreach (var obj in engine)
            {
                if (obj is DieselEngine diesel)
                {
                    totalPowerdiesel += diesel.Power;
                    dieseltCount++;
                }
            }

            if (dieseltCount > 0)
            {
                double averagePowerdiesel = totalPowerdiesel / dieseltCount;
                Console.WriteLine($"Average power of all Diesel Engines: {averagePowerdiesel} kW");
            }
            else
            {
                Console.WriteLine("No Diesel Engines");
            }
        }
        
        public static void CalculateTubo(Engine[] engine)
        {
            double totalPowerturbo = 0;
            int turboCount = 0;
            foreach (var obj in engine)
            {
                if (obj is TurboEngine turbo)
                {
                    totalPowerturbo += turbo.Power;
                    turboCount++;
                }
            }

            if (turboCount > 0)
            {
                double averagePowerturbo = totalPowerturbo / turboCount;
                Console.WriteLine($"Average power of all Turbo Engines: {averagePowerturbo} kW");
            }
            else
            {
                Console.WriteLine("No Turbo Engines");
            }
        }
        
        public static void CalculateInternalCombustion(Engine[] engine)
        {
            double totalPoweOfInternalCombustionEngines = 0;
            int Count = 0;
            foreach (var obj in engine)
            {
                if (obj is InternalCombustionEngine internalCombustion)
                {
                    totalPoweOfInternalCombustionEngines += internalCombustion.Power;
                    Count++;
                }
            }

            if (Count > 0)
            {
                double averagePower = totalPoweOfInternalCombustionEngines / Count;
                Console.WriteLine($"Average power of all InternalCombustion Engines: {averagePower} kW");
            }
            else
            {
                Console.WriteLine("No InternalCombustion engines");
            }
        }
    }
}

