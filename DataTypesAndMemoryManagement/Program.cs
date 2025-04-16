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

            List<string> theList = new List<string>();



            while (true)
            {


                Console.Clear();// Rensa konsolen

                Console.WriteLine("╔═════════════════════════════════════╗");
                Console.WriteLine("║          LIST EXAMINATION           ║");
                Console.WriteLine("╠═════════════════════════════════════╣");
                Console.WriteLine("║ Enter '+name' to add to list        ║");
                Console.WriteLine("║ Enter '-name' to remove from list   ║");
                Console.WriteLine("║ Enter 'exit' to return to main menu ║");
                Console.WriteLine("╚═════════════════════════════════════╝\n");



                var capacity = theList.Capacity;
                var count = theList.Count;

                // 
                Console.WriteLine($"Current list: [{string.Join(",", theList)}]");
                Console.WriteLine($"The list capacity: {capacity} | The list count: {count}\n");

                Console.WriteLine("Enter the command you want to use: ");
                string command = Console.ReadLine()!.Trim() ?? "";

                // Om användaren skriver "exit", gå tillbaka till huvudmenyn
                if (command.ToLower() == "exit")
                {
                    Console.WriteLine("Returning to main menu....");
                    Thread.Sleep(1250);
                    return;
                }

                // Om kommandot är tomt eller ogiltigt, ge ett felmeddelande
                if (string.IsNullOrEmpty(command) || command.Length < 2 || (command[0] != '+' && command[0] != '-'))
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Röd färg för att indikera ett fel
                    Console.WriteLine($"\n⛔ Invalid input. Please use '+' to add or '-' to remove.");
                    Console.ResetColor();
                    Console.WriteLine("\nPress any key to try again...");
                    Console.ReadKey(); // Vänta på användaren
                    continue; // Fortsätt till nästa iteration av loopen
                }

                // Hämta operationen (första tecknet) och värdet (resten av strängen)
                char operations = command[0];

                // Ta bort det första tecknet (operationen) och trimma värdet
                string value = command.Substring(1).Trim();

                switch (operations)
                {
                    case '+':
                        theList.Add(value);
                        Console.ForegroundColor = ConsoleColor.Green;// Grön färg för att indikera att något har lagts till
                        Console.WriteLine($"\n✓ Added '{value}' to the list | New capacity: {theList.Capacity}");
                        Console.ResetColor();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();  // Paus för att se resultatet
                        break;

                    case '-':
                        if (theList.Remove(value))
                        {
                            Console.ForegroundColor = ConsoleColor.Green; // Grön färg för att indikera att något har tagits bort
                            Console.WriteLine($"\n✓ Removed '{value}' from the list | Capacity: {theList.Capacity}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow; // Gul färg för att indikera att något inte hittades
                            Console.WriteLine($"\n⚠ '{value}' is not found in the list");
                        }
                        Console.ResetColor();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();  // Paus för att se resultatet
                        break;
                }
            }
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

