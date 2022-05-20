using System;
using System.IO;
using System.Text;
using SpotifyAPI.Web; // For later

namespace AlbumBacklogManager.SongManagement
{
    static public class SongManager
    {
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
    public struct Song
    {
        public Song(string name, string artist, string album, float length, int priority)
        {
            // This looks really ugly to me but y'know it's w/e
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
        public float Length; // Consider using TimeSpan for this

        public int Priority{set{
            if (value < 0 || value > 3)
            {
                throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 0 and 3.");
            }}}

        public int LengthMinutes{get{
            return (int)(Math.Floor(Length/60f));
            }}

        public float LengthSeconds{get{
            return Length % 60f;
            }}

        public string LengthTotal{get{
            return LengthMinutes + ":" + LengthSeconds.ToString("00");
            }}
    }
}