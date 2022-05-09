using System;
using System.IO;
using System.Text;

namespace AlbumBacklogManager
{
    class Program
    {
        public struct Song
        {
            public Song(string name, string artist, string album, float length, int priority)
            {
                Name = name;
                Artist = artist;
                Album = album;
                Length = length;
                Priority = priority;
            }

            // Nullable strings is a band-aid fix for the egregious amount of
            // possible null reference warnings I'm getting for using Console.Readline()
            public string? Name;
            public string? Artist;
            public string? Album;
            public float Length;
            public int Priority;

            public int LengthMinutes {get {
                return (int) (Math.Floor(Length/60f));
            }}

            public float LengthSeconds {get {
                return Length%60;
            }}

            public string LengthTotal {get {
                return LengthMinutes + ":" + LengthSeconds.ToString("00");
            }}
        }

        static public void Main()
        {
            Song newSong = PromptNewSong();
            Console.WriteLine(newSong.LengthTotal);
            PromptExit();
        }

        static public void PromptExit()
        {
            // This is such a tiny thing but for some reason
            // having these two lines in Main() always annoys me

            Console.Write("\nPress Enter to exit.");
            Console.ReadLine();
        }

        static public Song PromptNewSong()
        {
            // Probably won't prove super useful as time goes on
            // Good for testing
            
            Song s = new Song();

            Console.Write("Name of song: ");
            s.Name = Console.ReadLine();

            Console.Write("Name of artist: ");
            s.Artist = Console.ReadLine();

            Console.Write("Name of album: ");
            s.Album = Console.ReadLine();

            Console.Write("Length of song (seconds): ");
            s.Length = int.Parse(Console.ReadLine());

            Console.Write("Priority Level (0 - 3): ");
            s.Priority = int.Parse(Console.ReadLine());

            return s;
        }
    }
}