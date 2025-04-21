using System.Text;

namespace DataTypesAndMemoryManagement
{
    class Program
    {
        /// <summary> The main method, vill handle the menues for the program </summary>
        /// <param name="args"></param>
        static void Main()
        {
            #region Frågor och svar Övning 4

            /*
             1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion

                STACKEN:
                - Fungerar som en trave med tallrikar
                - Det som läggs till SENAST hamnar ÖVERST
                - Man kan bara nå det som ligger ÖVERST
                - Automatisk städning - grejer försvinner när metoden är klar
                - Lagrar enkla saker: int, bool, float, struct (värdetyper)

                Exempel:
                void Metod()
                {
                 int x = 5; // Hamnar på stacken
                } // x försvinner automatiskt här

                ============================================================

                HEAPEN:
                - Fungerar som ett stort förråd
                - Man kan nå allt OM man har "adressen" (referensen)
                - Saker ligger kvar tills Garbage Collector städar
                - Man behöver en "adress" (referens) för att komma åt sakerna
                - Lagrar större saker: class, string, List (referenstyper)

                Exempel:
                class Person {} // Klasser lagras på heapen
                Person p = new Person(); // p är en "adress" till objektet

             2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?

                    VALUE TYPES (värdetyper):
                     - Lagras på STACKEN (om de inte är i ett objekt)
                     - Kopieras när de tilldelas
                     - Exempel: int, double, bool, struct

                    Exempel:
                    int a = 10;
                    int b = a; // b får en KOPIA av 10
                    a = 20;    // b förblir 10

                    REFERENCE TYPES (referenstyper):
                    - Lagras på HEAPEN
                    - Variabeln är en "adress" till objektet
                    - Exempel: class, string, List

                    Exempel:
                    List<int> listaA = new List<int>();
                    List<int> listaB = listaA; // Båda pekar på SAMMA lista
                    listaA.Add(1); // Ändring syns i listaB också!

             3. Följande metoder genererar olika svar. Den första returnerar 3, den andra returnerar 4, varför?

                    FÖRSTA METODEN:
                    public int ReturnValue()
                    {
                    int x = new int();
                    x = 3;
                    int y = new int();
                    y = x
                    y = 4;
                    return x; // Returnerar 3
                    }

                    - Här används value types. y är en kopia av x, så när y ändras påverkar det inte x.

                    ANDRA METODEN:
                    public int ReturnValue2()
                    {
                    MyInt x = new MyInt();
                    x.MyValue = 3;
                    MyInt y = x;
                    y.MyValue = 4;
                    return x.MyValue; // Returnerar 4
                    }

                    - Här används reference types. y och x pekar på samma objekt på heapen, så en ändring via y syns också via x.

                    Sammanfattning:
                    Value types: KOPIERAS
                    Reference types: PEKAR
            */

            #endregion Frågor och svar Övning 4

            Console.OutputEncoding = Encoding.UTF8; //Sätter teckenkodningen till UTF-8 för att stödja specialtecken
            MainMenu(); //Anropar Main Menu metoden
        }

        /// <summary> Examines the datastructure List </summary>
        static void ExamineList()
        {
            #region Frågor och svar ExamineList()

            /*

             1. Skriv klart implementationen av ExamineList-metoden så att undersökningen blir genomförbar
                - Gjord längre ner

             2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
                - Så fort första elementet läggs till i listan så blir kapaciteten 4, den ökar sen när man lägger till 5e,9e,17e elementet osv
                  (Kapacitet 4 → 8 → 16 osv..)

             3. Med hur mycket ökar kapaciteten?
                - Kapaciteten börjar från början med 4 när ett element läggs till (.NET inplemenation) som sedan ökar med det dubbla
                  (4 → 8 → 16 osv..)

             4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
                - Den ökar inte en och en för att minska minnesallokeringar

             5. Minskar kapaciteten när element tas bort ur listan?
                - Nej. Kapaciteten förblir oförändrad för att undvika onödiga minnesomallokeringar – en prestandaoptimering i .NET.

             6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
                - Det är fördelaktigt att använda en en egendefinerad array, när man vet i förväg vilken storlek den ska ha och arrayen inte kommer att ändras.
            */

            #endregion Frågor och svar ExamineList()

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

                Console.WriteLine("=============== LIST EXAMINATION ===============\n");
                Console.WriteLine("         Enter '+name' to add to list             ");
                Console.WriteLine("         Enter '-name' to remove from list        ");
                Console.WriteLine("       Enter 'exit' to return to main menu      \n");
                Console.WriteLine("==================================================\n");
                var capacity = theList.Capacity;
                var count = theList.Count;

                // Visa listan och dess kapacitet och antal element
                Console.WriteLine($"Current list: [{string.Join(",", theList)}]");
                Console.WriteLine($"The list capacity: {capacity} | The list count: {count}\n");

                string command = GetUserInput("Enter the command you want to use: ");

                // Om användaren skriver "exit", gå tillbaka till huvudmenyn
                if (CheckForExit(command)) return;

                // Om kommandot är tomt eller ogiltigt, ge ett felmeddelande
                if (string.IsNullOrEmpty(command) || command.Length < 2 || (command[0] != '+' && command[0] != '-'))
                {
                    DisplayError("Invalid input. Please use '+' to add or '-' to remove.");
                    PauseExecution();
                    continue;
                }

                // Hämta operationen (första tecknet) och värdet (resten av strängen)
                char operation = command[0];

                // Ta bort det första tecknet (operationen) och trimma värdet
                string value = command.Substring(1).Trim();

                switch (operation)
                {
                    case '+':
                        theList.Add(value);
                        DisplaySuccess($"Added '{value}' to the list | New capacity: {theList.Capacity}");
                        PauseExecution();
                        break;

                    case '-':
                        if (theList.Remove(value))
                        {
                            DisplaySuccess($"Removed '{value}' from the list | Capacity: {theList.Capacity}");
                        }
                        else
                        {
                            DisplayWarning($"'{value}' is not found in the list");
                        }
                        PauseExecution();
                        break;
                }
            }
        }

        /// <summary> Examines the datastructure Queue </summary>
        static void ExamineQueue()
        {
            #region ICA Queue List FIFO

            /*
                HÄNDELSE	                LISTA (FRÄMST → SIST)	     FÖRKLARING
                ======================================================================================
                a. ICA öppnar       	    [ ]	                         Tom lista
                b. Kalle kommer 	        [Kalle]	                     Kalle hamnar FRÄMST
                c. Greta kommer	            [Kalle, Greta]	             Greta hamnar SIST
                d. Expedering	            [Greta]	                     Kalle (FRÄMST) lämnar, Greta blir först
                e. Stina ställer sig	    [Greta, Stina]	             Stina SIST
                f. Expedering	            [Stina]	                     Greta (FRÄMST) lämnar, Stina blir först
                g. Olle ställer sig	        [Stina, Olle]	             Olle sist
                =======================================================================================

                KÖNS NYCKELPRINCIPER:
                1. Enqueue (ställa sig i kön) → Hamnar SIST i kön
                2. Dequeue (expedieras) → Alltid den FRÄMSTA går
                3. Först in (Kalle) → Först ut (när han når kassan)
             */

            #endregion ICA Queue List FIFO

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> theQueueInICA = new Queue<string>();

            while (true)
            {
                Console.Clear();// Rensa konsolen
                Console.WriteLine("=============== ICA Queue Simulator (FIFO) ===============\n");
                Console.WriteLine("     Type 'add name' to add a person to the queue       ");
                Console.WriteLine("     Type 'next' to serve the first person in queue     ");
                Console.WriteLine("     Type 'exit' when you're done to return to main menu");
                Console.WriteLine("==========================================================\n");

                var count = theQueueInICA.Count;

                if (count == 0)
                {
                    Console.WriteLine($"Current queue: [{string.Join(", ", theQueueInICA)}]");
                }
                else
                {
                    Console.WriteLine("=== Current persons in queue ===");

                    foreach (var person in theQueueInICA)
                    {
                        Console.WriteLine($"- {person}");
                    }
                    Console.WriteLine($"Current queue count: {count}\n");
                }
                string input = GetUserInput("Add a person to join the queue: ");

                if (CheckForExit(input)) return;

                if (input.StartsWith("add "))
                {
                    if (input.Length <= 4) // "add" är 3 tecken + 1 mellanslag = 4
                    {
                        DisplayError("Please enter a name after 'add'.");
                    }
                    else
                    {
                        string name = input.Substring(4).Trim();
                        theQueueInICA.Enqueue(name);
                        DisplaySuccess($"'{name}' has joined the queue.");
                    }
                    PauseExecution();
                }
                else if (input.Equals("next"))
                {
                    if (theQueueInICA.Count > 0)
                    {
                        DisplaySuccess($"{theQueueInICA.Dequeue()} was served!");
                    }
                    else
                    {
                        DisplayError("No one is in the queue.");
                    }
                    PauseExecution();
                }
                else
                {
                    DisplayWarning("Unknown command. Try 'add name' or 'next'.");
                    PauseExecution();
                }
            }
        }

        /// <summary> Examines the datastructure Stack </summary>
        static void ExamineStack()
        {
            #region ICA Queue Stack FILO - ORÄTTVIS KÖHANTERING!

            /*

            HÄNDELSE           STACK (ÖVERST → UNDERST)      FÖRKLARING
            ===========================================================================
            a. ICA öppnar      [ ]                           Tom stack
            b. Kalle kommer    [Kalle]                       Kalle hamnar UNDERST
            c. Greta kommer    [Greta, Kalle]                Greta hamnar ÖVERST
            d. Expediering     [Kalle]                       Greta (ÖVERST) går först
            e. Stina kommer    [Stina, Kalle]                Stina hamnar ÖVERST
            f. Expediering     [Kalle]                       Stina (ÖVERST) går först
            g. Olle kommer     [Olle, Kalle]                 Olle hamnar ÖVERST
            ===========================================================================

            STACK-PRINCIPER I AKTION:
            • Push() = Någon ställer sig i "kön" (läggs ÖVERST)
            - tex. stack.Push("Greta") → [Greta, Kalle]

            • Pop() = Någon expedieras (alltid den ÖVERSTA)
            - tex. stack.Pop() → Tar bort "Greta"

            PROBLEM SOM KÖSYSTEM:
            • Kalle (först in) blir kvar längst ner i stacken
            • Olle (senast in) skulle bli nästa att serveras!
            • Orättvis ordning - inte som en riktig kö.
            */

            #endregion ICA Queue Stack FILO - ORÄTTVIS KÖHANTERING!

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack<string> theIcaStack = new Stack<string>();
            Stack<string> theReversedText = new Stack<string>();

            while (true)
            {
                Console.Clear();// Rensa konsolen
                Console.WriteLine("========== STACK EXAMINATION MENU ===========\n");
                Console.WriteLine("     1. ICA Stack Simulator (Unrealistic)");
                Console.WriteLine("     2. Reverse Text ");
                Console.WriteLine("     3. Return to Main Menu");
                Console.WriteLine("=============================================\n");

                string option = GetUserInput("Select an option (1-3): ");

                if (option == "1")
                {
                    while (true)
                    {
                        Console.Clear();// Rensa konsolen
                        Console.WriteLine("============ ICA Stack Simulator (UNREALISTIC) ============\n");
                        Console.WriteLine("     Type 'push name' to add a person to join the stack");
                        Console.WriteLine("     Type 'pop' to serve the LAST person in the stack  ");
                        Console.WriteLine("     Type 'exit' when you're done to return to main menu");
                        Console.WriteLine("===========================================================\n");

                        Console.WriteLine("\nCurrent stack (LAST person to join is FIRST to leave):");
                        Console.WriteLine("BOTTOM ← " + string.Join(" ← ", theIcaStack.Reverse()) + " ← TOP"); //Här visas stacken med den senaste personen som är TOP

                        Console.WriteLine($"Current stack count: {theIcaStack.Count}\n");

                        string input = GetUserInput("What do you want to do? ");

                        if (CheckForExit(input)) return;

                        if (input.StartsWith("push "))
                        {
                            if (input.Length <= 5)
                            {
                                DisplayError("Please enter a name after 'push'.");
                            }
                            else
                            {
                                string name = input.Substring(5).Trim();
                                theIcaStack.Push(name);
                                DisplaySuccess($"⏫ {name} joined the stack! (Now at TOP)");
                            }
                            PauseExecution();
                        }
                        else if (input.Equals("pop"))
                        {
                            if (theIcaStack.Count > 0)
                            {
                                DisplaySuccess($"⏬ {theIcaStack.Pop()} was served! (Removed from TOP)");
                            }
                            else
                            {
                                DisplayError("No one is in the queue.");
                            }
                            PauseExecution();
                        }
                        else
                        {
                            DisplayWarning("Unknown command. Try 'push name' or 'pop'.");
                            PauseExecution();
                        }
                    }
                }
                else if (option == "2")
                {
                    Console.Clear();
                    Console.WriteLine("========== REVERSE TEXT ==========\n");
                    Console.WriteLine("     Enter a string to reverse    ");
                    Console.WriteLine("==================================\n");

                    string textToReverse = GetUserInput("Enter text to reverse: ");

                    Stack<char> reveresedChars = new Stack<char>();

                    foreach (char c in textToReverse)
                    {
                        reveresedChars.Push(c);
                    }

                    string reversedText = "";

                    while (reveresedChars.Count > 0)
                    {
                        reversedText += reveresedChars.Pop();
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\nOriginal: {textToReverse}");
                    DisplaySuccess($"Reversed: {reversedText}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ResetColor();
                    PauseExecution();
                }
                else if (option == "3")
                {
                    ReturnToMainMenu();
                }
                else
                {
                    DisplayError($"Invalid option. Please choose between 1-3.");
                    PauseExecution();
                }
            }
        }

        static void CheckParanthesis()
        {
            #region Frågor och svar CheckParanthesis()
            /*1. Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en välformad
                 sträng på papper. Du ska använda dig av någon eller några av de datastrukturer vi
                 precis gått igenom. Vilken datastruktur använder du?
                 - Jag använder en stack för att lösa detta problem eftersom:

                 En stack följer FILO-principen (First In, Last Out) vilket passar perfekt för matchning av parenteser.
                 När vi träffar på en öppnande parentes, lägger vi den på stacken.
                 När vi träffar på en stängande parentes, kontrollerar vi om den matchar den senaste öppnande parentesen (toppen av stacken).

              2. Implementera funktionaliteten i metoden CheckParentheses.
                 Låt programmet läsa in en sträng från användaren och returnera ett svar som reflekterar huruvidasträngen är välformad eller ej.
                 - Gjord längre ner
            */
            # endregion Frågor och svar CheckParanthesis()

            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.Clear();
            Console.WriteLine("=========== PARENTHESIS VALIDITY CHECK ===========");
            Console.WriteLine("    Enter a string to check for valid paranthesis");
            Console.WriteLine("     Type 'exit' to return to main menu           ");
            Console.WriteLine("==================================================\n");

            while (true)
            {
                string input = GetUserInput("Enter a string to check: ");

                if (CheckForExit(input)) return;
                // Validera inmatningen
                if (string.IsNullOrWhiteSpace(input))
                {
                    DisplayError("Invalid input: Empty string.");
                    continue;
                }

                if (!input.Any(c => "(){}[]<>".Contains(c)))
                {
                    DisplayWarning("Invalid input: The string must contain at least one parenthesis.");
                    continue;
                }

                // Validera paranteserna och se om de stämmer
                Stack<char> parenthesesStack = new Stack<char>();
                Dictionary<char, char> brackets = new Dictionary<char, char>
                {
                     {'(', ')'},
                     {'{', '}'},
                     {'[', ']'},
                     {'<', '>'}
                };

                bool isValid = true;
                foreach (char c in input)
                {
                    if (!brackets.ContainsKey(c))
                    {
                        parenthesesStack.Push(brackets[c]);
                    }
                    else if (brackets.ContainsValue(c))
                    {
                        if (parenthesesStack.Count == 0 || c != parenthesesStack.Pop())
                        {
                            isValid = false;
                            break;
                        }
                    }
                }

                isValid = isValid && parenthesesStack.Count == 0;

                // Visa resultat
                if (isValid)
                {
                    DisplaySuccess($"The string '{input}' has valid parenthesis.");
                }
                else
                {
                    DisplayError($"The string '{input}' has invalid parenthesis.");
                }

                PauseExecution();
            }
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
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

                string input = GetUserInput("Please enter your choice (1-4, 0 to exit): ");

                if (CheckForExit(input)) continue;

                // TRY-BLOCK - Här börjar exceptionhanteringen
                try
                {
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
                            DisplayError($"Invalid option: '{input}' | Choose between 1-4 or 0 to exit");
                            PauseExecution();
                            break;
                    }
                }
                catch (Exception ex)  // CATCH-BLOCK - Här hamnar alla exceptions

                {
                    DisplayError($"Operation failed: {ex.Message}");
                }
            }
        }

        #region UI HELPERS

        static void DisplaySuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✓ {message}");
            Console.ResetColor();
        }

        static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n⛔ {message}");
            Console.ResetColor();
        }

        static void DisplayWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n⚠ {message}");
            Console.ResetColor();
        }

        static void PauseExecution(string message = "\nPress <Enter> to continue...")
        {
            Console.WriteLine(message);
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                // Vänta tills Enter trycks
            }
        }

        static void ReturnToMainMenu()
        {
            Console.WriteLine("Returning to main menu....");
            Thread.Sleep(1250);
        }

        static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()?.Trim() ?? "";
        }

        static bool CheckForExit(string input)
        {
            if (input?.ToLower() != "exit")
            {
                return false;
            }

            ReturnToMainMenu();
            return true;
        }

        #endregion UI HELPERS
    }
}