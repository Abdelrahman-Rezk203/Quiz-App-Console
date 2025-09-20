namespace Project_C__Basic_Console
{
    internal class Program
    {
        public static void AskUserToStartQuiz()
        {
            bool flag;
            int userChoice;
            do
            {
                Console.WriteLine("Attemped Quiz ?");
                Console.WriteLine("Choose 1.(Yes) or 2.(No)");
                flag = int.TryParse(Console.ReadLine(), out userChoice);
            } while (!flag || !(userChoice == 1 || userChoice == 2));
            if (userChoice == 1)
            {
                Console.WriteLine("Great! Let's start the quiz 🎯");
            }
            else
            {
                Console.WriteLine("Quiz canceled. See you next time! 👋");
                return;
            }

        }
        public static int StartQuiz(string[] Questions, string[,] MultipleChoise, int[] CorrectAnswer)
        {
            int scoure = 0;
            for (int i = 0; i < Questions.Length; i++)
            {
                //Display Question
                Console.WriteLine($"{i + 1}- {Questions[i]}");
                for (int j = 0; j < 4; j++)
                {
                    //Display MultipleChoise
                    Console.WriteLine($"{j + 1}- {MultipleChoise[i, j]}");
                }
                //Answer Is Correct ?
                if (CheckAnswerIsCorrectOrNot(ReadAnswerFromUser(), CorrectAnswer[i]))
                    scoure += 10;
                Console.WriteLine("--------------------------------------------------------------");
            }
            return scoure;
        }
        public static int ReadAnswerFromUser()
        {
            bool flag;
            int YourAnswer;
            do
            {     // Read User Answer
                Console.WriteLine(" Answer must be between 1 to 4");
                Console.Write("You Answer : ");
                flag = int.TryParse(Console.ReadLine(), out YourAnswer);
            } while (!flag || !(YourAnswer >= 1 && YourAnswer <= 4));
            return YourAnswer;
        }
        public static bool CheckAnswerIsCorrectOrNot(int YourAnswer, int CorrectAnswer)
        {
            //if (YourAnswer - 1 == CorrectAnsewer)   /* -1 because user enters 1 to 4 , array index is Zero based */
            //    return true;
            //else
            //    return false;

            return YourAnswer - 1 == CorrectAnswer;
        }
        public static int ShowResultAndReturnScore(int scoure, int Questions)
        {
            if (scoure == Questions * 10)
                Console.WriteLine("Excellent");
            else if (scoure > (Questions * 10) / 2)
                Console.WriteLine("Good, You Must More Studying");
            else
                Console.WriteLine("Sorry , Can't Pass This Action");

            return scoure;
        }
        public static void DisplayCorrectAnswers(string[] Questions, int[] CorrectAnswers, string[,] MultipleChoise)
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"{Questions[i]}\n✅Correct Answer: {MultipleChoise[i, CorrectAnswers[i]]}\n");
            }

        }
        static void Main(string[] args)
        {
            string[] Questions =
            {
                "How many planets are there in the Solar System?",
                "Which programming language was developed by Microsoft for the .NET platform?",
                "Who won the first FIFA World Cup?",
                "Where was the 2022 FIFA World Cup held?",
                "How many players are there on a football team on the field?"
            };
            string[,] MultipleChoise =
            {
                {"7","8","9","6"},
                {"Python","C#","C++","Java"},
                {"Brazil", "Uruguay", "Italy", "Argentina"},
                {"Russia", "Qatar", "USA", "France"},
                {"10","12","11","13"},
            };
            int[] CorrectAnswer = { 1, 1, 1, 1, 2 };

            AskUserToStartQuiz();
            int score = StartQuiz(Questions, MultipleChoise, CorrectAnswer);

            Console.Clear();

            Console.WriteLine($"Your Scoure: {ShowResultAndReturnScore(score, Questions.Length)}\n");

            //Display Correct Answers
            DisplayCorrectAnswers(Questions, CorrectAnswer, MultipleChoise);

           

        }
    }
}
