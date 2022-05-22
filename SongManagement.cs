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
            s.AlbumName = Console.ReadLine();

            Console.Write("Length of song (seconds): ");
            s.Length = int.Parse(Console.ReadLine());

            return s;
        }
    }
    public struct Song
    {
        public Song(string name, string artist, string albumName, float length)
        {
            // This looks really ugly to me but y'know it's w/e
            Name = name;
            Artist = artist;
            AlbumName = albumName;
            Length = length;
        }

        // Nullable strings is a band-aid fix for the egregious amount of
        // possible null reference warnings I'm getting for using Console.Readline()
        public string? Name;
        public string? Artist;
        public string? AlbumName;
        public float Length; // Consider using TimeSpan for this

        // Make a property to return an Album from AlbumName

        public int LengthMinutes{get{
            return (int)(Math.Floor(Length/60f));
            }}

        public float LengthSeconds{get{
            return Length%60f;
            }}

        public string LengthTotal{get{
            return LengthMinutes + ":" + LengthSeconds.ToString("00");
            }}
    }
    public struct Album
    {
        public Album(string name, float length, Song[] songList)
        {
            Name = name;
            Length = length;
            SongList = songList;
        }

        public string? Name;
        public float Length;
        public Song[] SongList;

        public int Priority{set{
            if (value < 1 || value > 3) throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 1 and 3.");
            }}

        public int LengthMinutes{get{
            return (int)(Math.Floor(Length/60f));
            }}

        public float LengthSeconds{get{
            return Length%60f;
            }}

        public string LengthTotal{get{
            return LengthMinutes + ":" + LengthSeconds.ToString("00");
            }}
    }
}