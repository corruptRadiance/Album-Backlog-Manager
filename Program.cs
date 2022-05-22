using System;
using System.IO;
using System.Text;
using AlbumBacklogManager.SongManagement;

namespace AlbumBacklogManager
{
    class Program
    {
        // Acceptable responses for Y/N prompts
        static public string[] Responses = new string[]{"y", "yes"};

        static public void Main()
        {
            // This needs to get wrapped in a loop probably

            // Prompt and store user input 
            string input;
            Console.Write("Would you like to add a new song? (Y/N): ");
            input = Console.ReadLine().ToLower();

            // Check if user input is within acceptable "true" responses
            foreach(string i in Responses)
            {
                // If so, prompt user further
                if(input.Contains(i))
                {
                    Song s = SongManager.PromptNewSong();
                }
            }

            // Prompt user to exit app when finished
            PromptExit();
        }

        static public void PromptExit()
        {
            // This is such a tiny thing but for some reason
            // having these two lines in Main() always annoys me

            Console.Write("\nPress Enter to exit.");
            Console.ReadLine();
        }
    }
}