namespace Task2
{
    public class ShowEngines
    {
        public static void Show(Engine[] engine)
        {
            foreach (var obj in engine)
            {
                obj.Display();
            }
        }
    }
}

