namespace Task2
{
    /*Створити консольний додаток для виконання дій з масивами відповідно до індивідуального завдання
     (номер завдання дорівнює числу, яке отримане за формулою (Д+М+В)%30 Д – день вашого народження, 
     М – числовий номер місяця вашого народження, В – порядковий номер у журналі групи. 
     Створюючи проєкт самостійно вибрати «тип» багатовимірного масиву (прямокутний чи ступінчатий), 
     але водночас уміти замінити код роботи зі ступінчатим масивом на роботу з прямокутним та навпаки. 
     Запропонувати користувачу вибрати спосіб отримання початкових значень елементів масиву (діалог з користувачем, 
     зчитати з файлу даних, згенерувати значення елементів). таким чином (04+05+12)%30=21
     
     21. Написати програму, яка будує матрицю А розмірності n×n з компонентами, які визначають за формулою: 
     aij= sin(i+j)*x, i,j=1..n, 
     x – довільна дійсна величина. 
     Потім у кожному рядку А замінити найбільший елемент абсолютною величиною діагонального елемента, а від’ємні елементи замінити їх кубами. 
     Далі розташувати елементи кожного рядка в порядку зростання.
     */
    

    internal class Program
    {
        public static void Formula()
        {
            int choose = ChekerForCorrectInput.CheckIfInteger();
            double[][]? array = (choose switch
            {
                1 => ChooseOption.ChooseRandomInput(),
                2 => ChooseOption.ChooseFileInput(),
                _ => null
            })!;
            if (array == null)
            {
                Console.WriteLine("Wrong input, so no formula for you BROAH! MUHAHAHAHA");
                return;
            }
            Console.WriteLine("This is not sorted Array \n");
            PrintArray.PrintDoubleArray(array);
            Console.WriteLine("\nThis is sorted Array \n");
            PrintArray.PrintDoubleArray(MathOperation.Task(array));
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(FileSystem.DialogueFile());
            Formula();
        }
    }
}