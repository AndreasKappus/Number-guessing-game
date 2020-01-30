using System;

namespace NumberGuesser
{
    class Program
    {
       
        
        static void Main(string[] args)
        {
            AppInfo(); // output le game info

            Greet();

            NumberGuesser();

        }

        static void NumberGuesser()
        {

            // would rather keep variable declarations outside of loops
            string prompt;
            int guess = 0;
            int correctNum;
            string numInput;

            do
            {
                Random rand = new Random();
                correctNum = rand.Next(1, 10);

                Console.WriteLine("Guess a number between 1 and 10!");


                while (guess != correctNum)
                {
                    numInput = Console.ReadLine();

                    if (!int.TryParse(numInput, out guess))
                    {
                        PrintMessage(ConsoleColor.Red, "Please enter an actual number and stop trying to break my program!!!");
                        continue;
                    }

                    guess = int.Parse(numInput);

                    if (guess != correctNum)
                    {
                        SaucyHint(guess, correctNum);
                        //PrintMessage(ConsoleColor.Red, "ehnt! Wrong answer, please try again!");
                    }
                }

                // output if successful
                PrintMessage(ConsoleColor.Green, "DING! correct answer!");

                // play again prompt
                Console.WriteLine("Fancy another game? [Y or N)");
                prompt = Console.ReadLine().ToUpper();

            } while (prompt != "N");
        }

        static void AppInfo()
        {
            string appName = "Number Guesser";
            string version = "1.0";
            string author = "Andreas Kappus";

            // changing text colour
            Console.ForegroundColor = ConsoleColor.Cyan;
            

            // "{}" acts as placeholders for variables, shame uni didn't teach me that
            Console.WriteLine("{0}: Version {1}, created by {2}", appName, version, author);

            // resets text colour
            Console.ResetColor();

           
        }

        static void Greet()
        {
            // date time to change message greeting based on current time
            DateTime time = DateTime.Now;
            string morning = "Guten Morgen";
            string noon = "Guten Tag";
            string evening = "Guten Abend";
            string wtf = "bloody hell get some sleep! anyway hello ";
            
            

            // input for user's name
            Console.WriteLine("Enter name below");
            string input = Console.ReadLine();


            if (time.Hour < 12 && time.Hour >= 5) 
            {
                
            }
            else if(time.Hour >= 12 && time.Hour < 17)
            {
                GreetMessage(noon, input);
            }
            else if(time.Hour >= 17 && time.Hour <= 22)
            {
                GreetMessage(evening, input);
            }
            else
            {
                GreetMessage(wtf, input);
            }

        }


        // just makes error handling and output alot easier
        static void PrintMessage(ConsoleColor colour, string message)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void GreetMessage(string time, string name)
        {
            Console.WriteLine("{0} {1}, let's play a cheeky number guessing game!", time, name);
        }

       static void Hint(int guess, int correctNum)
        {
            if(guess < correctNum)
            {
                PrintMessage(ConsoleColor.White, "Go higher!");
            }
            else
            {
                PrintMessage(ConsoleColor.White, "Go lower!");
            }

        }

        
        static void SaucyHint(int guess, int correctNum)
        {
            if(guess >= correctNum - 1 && guess <= correctNum + 1)
            {
                PrintMessage(ConsoleColor.DarkRed, "Thot!");
            }
            else if(guess >= correctNum - 3 && guess <= correctNum + 3)
            {
                PrintMessage(ConsoleColor.Yellow, "Getting warmer!");
            }
            else
            {
                PrintMessage(ConsoleColor.DarkCyan, "Getting colder...");
            }
        }
    }
}
