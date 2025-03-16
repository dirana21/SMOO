namespace Task1
{
    /*Для заданої умови скласти консольний додаток, для тестування якого створити декілька текстових файлів з даними для відлагодження коду.
    Уведення даних виконувати або з файлу, або з клавіатури або заповнити значеннями випадкових чисел (вибирає користувач).

    12. Знайти третій додатній та останній від’ємний елементи масиву. Замінити знак елементів, що розташовані між шуканими елементами, на протилежний.*/
    internal class Program
    {
        public static void Formula(int n)
        {
            int[]? array = (n switch
            {
                1 => FileInput.InputByFile(),
                2 => UserInput.InputByUser(),
                3 => RandomInput.InputByRandom(),
                _ => null
            })!;
            if (array == null)
            {
                Console.WriteLine("Wrong input, so no formula for you BROAH! MUHAHAHAHA");
                return;
            }
            PrintArray.ShowNotSortedArray(array);
            PrintArray.ShowSortedArray(MathOperation.Task(array));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option: 1 - input are takes by txt file, 2 - input by your self, 3 - input by random number");
            Formula(ChekerForInteger.CheckIfInt());
        }
    }
}