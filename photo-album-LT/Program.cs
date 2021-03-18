using ConsoleTables;
using System;
using System.Linq;

namespace photo_album_LT
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare variables
            string input;
            string[] inputArray;
            string albumID;
            string flag;
            JsonParser jp = new JsonParser();
            PrintHelper ph = new PrintHelper();

            // Display instructions for the user
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Enter the desired album ID (1-100).");
            Console.WriteLine("2. Enter a space and an 'i' vo numerically order the photos based on photo ID.");
            Console.WriteLine("3. Enter a space and a 't' to alphabetically order the photos information based on the title.");
            Console.WriteLine("   Example: Enter '49 t' to view album 49 in alphabetical order.");
            Console.WriteLine("4. Enter a 'Q' or 'q' to exit.");
            input = Console.ReadLine();
            int numSpaces = input.Count(c => c == ' ');

            // Continue looping through the program until the user enters a 'Q'
            while (input != "Q" && input != "q")
            {
                numSpaces = input.Count(c => c == ' ');

                // Ensure that only 1 space was entered by the user
                while (numSpaces != 1)
                {
                    Console.WriteLine("Please enter a single space between the album ID and the flag.");
                    input = Console.ReadLine();
                    numSpaces = input.Count(c => c == ' ');
                }

                inputArray = input.Split(" ");
                albumID = inputArray[0];
                flag = inputArray[1];

                // Ensure that the flag entered by the user is either an 'i' or a 't'
                while (flag != "i" && flag != "t")
                {
                    Console.WriteLine("Please enter an 'i' or a 't' depending on how you want to order the photos.");
                    flag = Console.ReadLine();
                }

                // Print the photo information in numerical order based on photo ID
                if (flag == "i")
                {
                    ConsoleTable table = ph.orderInfoByPhotoID(jp, albumID);
                    table.Write(Format.Minimal);
                }

                // Print the photo information in alphabetical order based on photo title
                else if (flag == "t")
                {
                    ConsoleTable table = ph.orderInfoByTitle(jp, albumID);
                    table.Write(Format.Minimal);
                }

                Console.WriteLine("Please enter your desired command:");
                input = Console.ReadLine();
            }
        }
    }
}
