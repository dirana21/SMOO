namespace Task3
{
    internal class Program
    {
        public static int playerLife = 0;
        public static int inputNumber = 0;
        public static int inputNumberForChoose = 0;
        public static int userScore = 0;
        public static int computerScore = 0;
        public static bool startGame = true;
        public static int winsCount = 0;
        public static bool ifPlayerWantContinue = true;
        public static int CheckIfInt()
        {
            int result = 0;
            while (true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out result)) break;
                else Console.WriteLine("Error! Enter an integer!!!");
            }
            return result;
        }
        public static void HowManyScore()
        {
            if (userScore > 0)
            {
                Console.WriteLine($"Now u have {userScore} score");
            }
        }
        public static void WhoWon()
        {
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
        public static void loseRound(int life, int score)
        {
            if (life == 0)
            {
                Console.WriteLine("Sorry but you are lose this round))");
                computerScore += score * 5;
            }
        }
        public static void ContinueRoundOrNo(int life)
        {
            Console.WriteLine("Are you want continue to play again? 1 - Yes, 2 - No");
            inputNumberForChoose = CheckIfInt();
            if (inputNumberForChoose == 2)
            {
                userScore += life * 5;
                Console.WriteLine($"Your score is: {userScore}!!");
                Console.WriteLine($"Computer score is: {computerScore}!!");
                if(computerScore > userScore) Console.WriteLine("Computer Win!!!");
                else Console.WriteLine("U Win!!!");
                ifPlayerWantContinue = false;
            }
        }
        public static void RightChoice(int life)
        {
            Console.WriteLine("Congratulations! You are a choose right number!!!");
            ContinueRoundOrNo(life);
            if(!ifPlayerWantContinue) return;
            winsCount += 1;
            userScore += life * 5;
        }
        public static void Clue(int dif)
        {
            if (inputNumberForChoose == 1)
            {
                playerLife -= 1;
                Console.WriteLine($"You have left {playerLife} life");
                if (inputNumber > dif)
                {
                    Console.WriteLine($"The choosen number of computer is lesser ( < ) than {inputNumber}! So range of number are 1 - {inputNumber - 1} ");
                }
                else
                {
                    Console.WriteLine($"The choosen number of computer is greater ( > ) than {inputNumber}! So range of number are {inputNumber + 1} - 10");
                }
            }
        }
        public static void WrongChoice(int dif)
        {
            playerLife -= 1;
            Console.WriteLine($"Ohhh this is not the number that the computers thought, \n - 1 life, \nYou have left {playerLife} life");
            if (playerLife > 1)
            {
                Console.WriteLine($"You have clue, if you want to use it: 1 - Yes, 2 - No \nBut if you choose yes, you'll lose 1 life directly");
                inputNumberForChoose = CheckIfInt();
                Clue(dif);

            }
        }
        public static void Round(int whichRound)
        {
            Random randomNumber = new Random();
            int difficulty = 0;
            Console.WriteLine($"\t ===={whichRound} Round====");
            for (int i = 0; i < (whichRound == 1 ? 3 : 2); i++)
            {
                HowManyScore();
                difficulty = whichRound == 1 ? randomNumber.Next(1, 10) : randomNumber.Next(10, 100);
                playerLife =  whichRound == 1 ? 5 : 23;
                int score = playerLife;
                Console.WriteLine($"\t==The {i + 1} battle has begun== \nEnter the number that you think the computer has guessed between 1-10: ");
                while (playerLife > 0 && ifPlayerWantContinue)
                {
                    if (!startGame) Console.WriteLine($"Write a number again");
                    startGame = false;
                    inputNumber = CheckIfInt();
                    if (difficulty == inputNumber)
                    {
                        RightChoice(playerLife);
                        break;
                    }
                    else
                    {
                        WrongChoice(difficulty);
                    }
                    
                    loseRound(playerLife, score);
                }
                
            }
        }
        public static void GuesMyNumber()
        {
            int round = 1;
            Round(1);
            if (winsCount == 3)
            {
                Round(2);
            }
            WhoWon();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\t     ==GUESS MY NUMBER==");
            GuesMyNumber();
        }
    }
}