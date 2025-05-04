namespace Task2
{
    public class Register
    {
        private Device[] devices;
        private int count;

        public Register()
        {
            this.devices = new Device[100];
            count = 0;
        }

        public void AddDevice(Device device)
        {
            if (count < devices.Length)
            {
                devices[count++] = device;
            }
            else
            {
                Console.WriteLine("Register is full!");
            }
        }

        public void PrintAllDevices()
        {
            Console.WriteLine("All Devices:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(devices[i]);
                Console.WriteLine("---------------------");
            }
        }

        public void PrintDevicesWithEngine()
        {
            Console.WriteLine("Devices with Engine:");
            for (int i = 0; i < count; i++)
            {
                if (devices[i] is IEngine)
                {
                    Console.WriteLine(devices[i]);
                    Console.WriteLine("---------------------");
                }
            }
        }

        public void PrintDeviceWithNoEngine()
        {
            Console.WriteLine("Devices without Engine:");
            for (int i = 0; i < count; i++)
            {
                if (!(devices[i] is IEngine))
                {
                    Console.WriteLine(devices[i]);
                    Console.WriteLine("---------------------");
                }
            }
        }

        public void SortingDeviceByTheName()
        {
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (string.Compare(devices[i].Name, devices[j].Name) > 0)
                    {
                        Swap(i, j);
                    }   
                }
            }
        }
        
        public void SortingDeviceByTheWeight()
        {
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (devices[i].Weight > devices[j].Weight)
                    {
                        Swap(i, j);
                    }
                }
            }
        }
        private void Swap(int i, int j)
        {
            Device temp = devices[i];
            devices[i] = devices[j];
            devices[j] = temp;
        }
        
        public void PrintAll()
        {
            Console.WriteLine("All devices:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(devices[i]);
                Console.WriteLine();
            }
        }
        
        public void Add(Device device)
        {
            if (count < devices.Length)
            {
                devices[count++] = device;
            }
        }
        
        public Register CopyFirstNDevices(int n)
        {
            Register newRegister = new Register();
            for (int i = 0; i < n && i < count; i++)
            {
                Device clonedDevice = (Device)devices[i].Clone();
                newRegister.Add(clonedDevice);
            }
            return newRegister;
        }
    }   
}