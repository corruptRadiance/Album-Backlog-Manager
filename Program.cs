using System;
using System.IO;
using System.Text;

namespace StructTesting
{
    class Program
    {
        struct Song
        {
            public string Name;
            public double Length;

            public double LengthMinutes {get {
                return Math.Floor(Length/60);
            }}

            public double LengthSeconds {get {
                return Length%60;
            }}

            // Old shitty way of doing minutes
            // public (int,int) InMinutes()
            // {
            //     // First array element is length/60
            //     // Second array element is remainder

            //     int minutes = Length/60;
            //     int seconds = Length%60;

            //     return (minutes,seconds);
            // }
        }

        static public void Main()
        {
            Song songExample = new Song();

            Console.WriteLine("Length of song in seconds: ");
            songExample.Length = double.Parse(Console.ReadLine());

            Console.WriteLine("Song Length: " + songExample.LengthMinutes + ":" + songExample.LengthSeconds.ToString("00"));

            Console.ReadLine();
        }
    }
}