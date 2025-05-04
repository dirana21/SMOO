namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var register = new Register();
            register.Add(new Airplane("An-225 Mriya", 640000, 80000));  
            register.Add(new Airplane("Airbus A320", 73500, 27000));     
            register.Add(new Airplane("Cessna 172", 1111, 180));         
            register.Add(new Helicopter("Apache AH-64", 7250, 1500));    
            register.Add(new Helicopter("Sikorsky CH-53", 13600, 2700)); 
            register.Add(new Balloon("Hot Air Balloon", 400));        
            register.Add(new Balloon("Lunar Balloon", 500));          
            register.Add(new FlyingCarpet("Aladdin's Carpet", 500));  
            register.Add(new FlyingCarpet("Modern Carpet X1", 1200)); 
            register.Add(new HangGlider("Xtreme 2000", 45));           
            register.Add(new HangGlider("Nimbus Glider", 50));         
            register.Add(new HangGlider("SkyRider 3", 48)); 
            
            register.PrintAll();
            
            Console.WriteLine("\tCopying first 2 devices...");

            var newRegister = register.CopyFirstNDevices(2);
            newRegister.PrintAll();
            register.PrintDeviceWithNoEngine();
            
            register.SortingDeviceByTheWeight();
            Console.WriteLine("After sorting by weight:");
            register.PrintAll();
            
            register.SortingDeviceByTheName();
            Console.WriteLine("After sorting by name:");
            register.PrintAll();
        }
    }
}

 