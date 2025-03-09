namespace Task3
{
    internal class Program
    {
        public static int playerLifeForFirstRound = 0;
        public static int playerLifeForSecondRound = 0;
        public static int inputNumber = 0;
        public static int inputNumberForChoose = 0;
        public static int firstRound = 3;
        public static int secondRound = 2;
        public static int userScore = 0;
        public static int computerScore = 0;
        public static bool startGame = true;
        public static int winsCount = 0;

        public static void GuesMyNumber()
        {
            Random randomNumber = new Random();
            int firstDifficulty = 0;
            int secondDifficulty = 0;
            Console.WriteLine("\t ====First Round====");
            for (int i = 0; i < firstRound; i++)
            {
                if (userScore > 0)
                {
                    Console.WriteLine($"Now u have {userScore} score");
                }

                firstDifficulty = randomNumber.Next(1, 10);
                playerLifeForFirstRound += 5;
                Console.WriteLine($"\t==The {i + 1} battle has begun== \nEnter the number that you think the computer has guessed: ");
                while (playerLifeForFirstRound > 0)
                {
                    if (!startGame) Console.WriteLine($"Write a number again");
                    startGame = false;
                    while (true)
                    {
                        string userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out inputNumber)) break;
                        else Console.WriteLine("Error! Enter an integer!!!");
                    }

                    if (firstDifficulty == inputNumber)
                    {
                        Console.WriteLine("Congratulations! You are a choose right number!!!");
                        Console.WriteLine("Are you want continue to play again? 1 - Yes, 2 - No");
                        while (true)
                        {
                            string userInput = Console.ReadLine();
                            if (int.TryParse(userInput, out inputNumberForChoose)) break;
                            else Console.WriteLine("Error! Enter an integer!!!");
                        }

                        if (inputNumberForChoose == 2)
                        {
                            
                            userScore += playerLifeForFirstRound * 5;
                            Console.WriteLine($"Your score is: {userScore}!!");
                            Console.WriteLine($"Computer score is: {computerScore}!!");
                            if(computerScore > userScore) Console.WriteLine("Computer Win!!!");
                            else Console.WriteLine("U Win!!!");
                            return;
                        }

                        winsCount += 1;
                        break;
                    }
                    else
                    {
                        playerLifeForFirstRound -= 1;
                        Console.WriteLine($"Ohhh this is not the number that the computers thought, \n - 1 life, \nYou have left {playerLifeForFirstRound} life");
                        if (playerLifeForFirstRound > 1)
                        {
                            Console.WriteLine($"You have clue, if you want to use it: 1 - Yes, 2 - No \nBut if you choose yes, you'll lose 1 life directly");
                            while (true)
                            {
                                string userInput = Console.ReadLine();
                                if (int.TryParse(userInput, out inputNumberForChoose)) break;
                                else Console.WriteLine("Error! Enter an integer!!!");
                            }

                            if (inputNumberForChoose == 1)
                            {
                                playerLifeForFirstRound -= 1;
                                Console.WriteLine($"You have left {playerLifeForFirstRound} life");
                                if (inputNumber > firstDifficulty)
                                {
                                    Console.WriteLine($"The choosen number of computer is lesser ( < ) than {inputNumber}! So range of number are 1 - {inputNumber - 1} ");
                                }
                                else
                                {
                                    Console.WriteLine($"The choosen number of computer is greater ( > ) than {inputNumber}! So range of number are {inputNumber + 1} - 10");
                                }
                            }
                        }
                    }
                }

                if (playerLifeForFirstRound == 0)
                {
                    Console.WriteLine("Sorry but you are lose this round))");
                    computerScore += playerLifeForFirstRound * 5;
                }
            }

            if (winsCount == 3)
            {
                Console.WriteLine("\t ====Second Round====");
                for (int i = 0; i < secondRound; i++)
                {
                    if (userScore > 0)
                    {
                        Console.WriteLine($"Now u have {userScore} score");
                    }

                    secondDifficulty = randomNumber.Next(1, 10);
                    playerLifeForFirstRound += 23;
                    Console.WriteLine($"\t==The {i + 1} battle has begun== \nEnter the number that you think the computer has guessed: ");
                    while (playerLifeForFirstRound > 0)
                    {
                        if (!startGame) Console.WriteLine($"Write a number again");
                        startGame = false;
                        while (true)
                        {
                            string userInput = Console.ReadLine();
                            if (int.TryParse(userInput, out inputNumber)) break;
                            else Console.WriteLine("Error! Enter an integer!!!");
                        }

                        if (secondDifficulty == inputNumber)
                        {
                            Console.WriteLine("Congratulations! You are a choose right number!!!");
                            Console.WriteLine("Are you want continue to play again? 1 - Yes, 2 - No");
                            while (true)
                            {
                                string userInput = Console.ReadLine();
                                if (int.TryParse(userInput, out inputNumberForChoose)) break;
                                else Console.WriteLine("Error! Enter an integer!!!");
                            }

                            if (inputNumberForChoose == 2)
                            {
                                
                                userScore += playerLifeForSecondRound * 10;
                                Console.WriteLine($"Your score is: {userScore}!!");
                                Console.WriteLine($"Computer score is: {computerScore}!!");
                                if(computerScore > userScore) Console.WriteLine("Computer Win!!!");
                                else Console.WriteLine("U Win!!!");
                                return;
                            }

                            break;
                        }
                        else
                        {
                            playerLifeForSecondRound -= 1;
                            Console.WriteLine($"Ohhh this is not the number that the computers thought, \n - 1 life, \nYou have left {playerLifeForSecondRound} life");
                            if (playerLifeForSecondRound > 1)
                            {
                                Console.WriteLine($"You have clue, if you want to use it: 1 - Yes, 2 - No \nBut if you choose yes, you'll lose 1 life directly");
                                while (true)
                                {
                                    string userInput = Console.ReadLine();
                                    if (int.TryParse(userInput, out inputNumberForChoose)) break;
                                    else Console.WriteLine("Error! Enter an integer!!!");
                                }

                                if (inputNumberForChoose == 1)
                                {
                                    playerLifeForSecondRound -= 1;
                                    Console.WriteLine($"You have left {playerLifeForSecondRound} life");
                                    if (inputNumber > firstDifficulty)
                                    {
                                        Console.WriteLine($"The choosen number of computer is lesser ( < ) than {inputNumber}! So range of number are 1 - {inputNumber - 1} ");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"The choosen number of computer is greater ( > ) than {inputNumber}! So range of number are {inputNumber + 1} - 10");
                                    }
                                }
                            }
                        }
                    }

                    if (playerLifeForSecondRound == 0)
                    {
                        Console.WriteLine("Sorry but you are lose!!!");
                        computerScore += playerLifeForSecondRound * 10;
                    }
                }
            }

            Console.WriteLine($"Totaly u reach: {userScore}");
            Console.WriteLine($"Totaly computer reach : {computerScore}");
            if (computerScore > userScore)
            {
                Console.WriteLine("Computer Win!!!");
            }
            else
            {
                Console.WriteLine("U Win!!!");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\t     ==GUESS MY NUMBER==");
            GuesMyNumber();
        }
    }
}