namespace Task2
{
    public class ChooseOption
    {
        public static double[][] ChooseUserInput()
        {
            double[][] array = Input.InputByUser();
            return array;
        }
        public static double[][] ChooseRandomInput()
        {
            double[][] array = Input.InputByRandom();
            return array;
        }
        public static double[][] ChooseFileInput()
        {
            double[][] array = FileSystem.InputByFile();
            return array;
        }
    }
}

