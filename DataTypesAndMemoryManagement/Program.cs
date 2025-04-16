using System.Runtime.ExceptionServices;
using System.Text;

namespace DataTypesAndMemoryManagement
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; //Sätter teckenkodningen till UTF-8 för att stödja specialtecken
            MainMenu(); //Anropar Main Menu metoden
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

        static void MainMenu()
        {
            string errorMessage = "";

            while (true)
            {
                Console.Clear();
                DisplayMenu();

                // Visa felmeddelande under menyn om det finns
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n⛔ {errorMessage}");
                    Console.ResetColor();
                    errorMessage = "";
                }

                Console.Write("\nPlease enter your choice (1-4, 0 to exit): ");

                // TRY-BLOCK - Här börjar exceptionhanteringen
                try
                {
                    string input = Console.ReadLine()?.Trim() ?? "";

                    if (string.IsNullOrEmpty(input))
                    {
                        errorMessage = "Please enter valid input! (number)";
                        continue;
                    }

                    // CATCH-BLOCK - Här hamnar alla exceptions
                    switch (input)
                    {
                        case "0":
                            Environment.Exit(0);
                            break;
                        case "1":
                            ExamineList();
                            break;
                        case "2":
                            ExamineQueue();
                            break;
                        case "3":
                            ExamineStack();
                            break;
                        case "4":
                            CheckParanthesis();
                            break;
                        default:
                            errorMessage = $"Invalid option: '{input}' | Choose between 1-4 or 0 to exit";
                            break;
                    }
                }
                catch (Exception ex)  // Detta är där "catchen" hamnar
                {
                    errorMessage = $"Operation failed: {ex.Message}";
                }
            }
        }

        static void DisplayMenu()
        {
            Console.Title = "DataTypes and Memory Management";
            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("║     DATA STRUCTURE EXPLORER      ║");
            Console.WriteLine("╠══════════════════════════════════╣");
            Console.WriteLine("║ 1. Examine List                  ║");
            Console.WriteLine("║ 2. Examine Queue                 ║");
            Console.WriteLine("║ 3. Examine Stack                 ║");
            Console.WriteLine("║ 4. Check Parenthesis Validity    ║");
            Console.WriteLine("║ 0. Exit                          ║");
            Console.WriteLine("╚══════════════════════════════════╝");
        }
    }

}

