namespace Task3;
using System.Text;
public class Test
{
    public static void Tests()
    {
        Console.OutputEncoding = Encoding.UTF8;
        int[] answers = {1, 50, 2 , 11 , 30, 1, 1};
        int result = 0;
        int parsed = 0;
        Console.WriteLine("Вводити значеня повинні бути цілі, якщо ви вводите інші значення зараховується 0 балів!!!!");
        Console.WriteLine("1: Професор ліг спати о 8 годині, а встав о 9 годині. Скільки годин проспав професор?");
        string? answer = Console.ReadLine();
        parsed = int.TryParse(answer, out parsed) ? parsed : 0;
        result += parsed == answers[0] ? 1 : 0;
        Console.WriteLine("2: На двох руках десять пальців. Скільки пальців на 10?");
        answer = Console.ReadLine();
        parsed = int.TryParse(answer, out parsed) ? parsed : 0;
        result += parsed == answers[1] ? 1 : 0;
        Console.WriteLine("3: Скільки цифр у дюжині? ");
        answer = Console.ReadLine();
        parsed = int.TryParse(answer, out parsed) ? parsed : 0;
        result += parsed == answers[2] ? 1 : 0;
        Console.WriteLine("4: Скільки потрібно зробити розпилів, щоб розпиляти колоду на 12 частин? ");
        answer = Console.ReadLine();
        parsed = int.TryParse(answer, out parsed) ? parsed : 0;
        result += parsed == answers[3] ? 1 : 0;
        Console.WriteLine("5: Лікар зробив три уколи в інтервалі 30 хвилин. Скільки часу він витратив?");
        answer = Console.ReadLine();
        parsed = int.TryParse(answer, out parsed) ? parsed : 0;
        result += parsed == answers[4] ? 1 : 0;
        Console.WriteLine("6: Скільки цифр 9 в інтервалі 1100? ");
        answer = Console.ReadLine();
        parsed = int.TryParse(answer, out parsed) ? parsed : 0;
        result += parsed == answers[5] ? 1 : 0;
        Console.WriteLine("7: Пастух мав 30 овець. Усі, окрім однієї, розбіглися. Скільки овець лишилося?");
        answer = Console.ReadLine();
        parsed = int.TryParse(answer, out parsed) ? parsed : 0;
        result += parsed == answers[6] ? 1 : 0;
        switch (result)
        {
            case 7:
                Console.WriteLine("Геній!");
                break;
            case 6:
                Console.WriteLine("Ерудит!");
                break;
            case 5:
                Console.WriteLine("Нормальний!");
                break;
            case 4:
                Console.WriteLine("Здібності середні!");
                break;
            case 3:
                Console.WriteLine("Здібності нижче середньго!");
                break;
            default:
                Console.WriteLine("Вам треба відпочити!");
                break;
        }
    }
}