using System;
using System.Collections.Generic;
using System.Diagnostics;
using SysJson = System.Text.Json;
using NsJson = Newtonsoft.Json;
using System.Linq;

namespace SerializationWithSystemTextJson
{
    class Program
    {
        public static int SysJsonSerializeTimer(List<Note> noteList)
        {
            Stopwatch sw;
            sw = Stopwatch.StartNew();
            SysJson.JsonSerializer.Serialize(noteList);
            sw.Stop();
            return (int)sw.ElapsedMilliseconds;
        }

        public static int NsJsonSerializeTimer(List<Note> noteList)
        {
            Stopwatch sw;
            sw = Stopwatch.StartNew();
            NsJson.JsonConvert.SerializeObject(noteList);
            sw.Stop();
            return (int)sw.ElapsedMilliseconds;
        }

        static void Main(string[] args)
        {
            // Press key to begin 
            Console.WriteLine("Please enter the number of objects to serialize:");
            int input = int.Parse(Console.ReadLine());

            // Build Note objects
            Console.WriteLine($"Creating {input} objects...");

            List<Note> notesList = new List<Note>();

            for (int i = 1; i <= input; i++)
            {
                Note createdNote = new Note(i, $"Note {i}", $"This is the text for Note {i}");
                notesList.Add(createdNote);
            }


            // Begin serialization
            Console.WriteLine($"{input} Note objects have been created.{Environment.NewLine}Please press any key to begin serialization to string.");
            Console.ReadKey();

            int[] sysJsonTimings = new int[10];
            int[] nsJsonTimings = new int[10];

            for (int x = 0; x < 10; x++)
            {
                sysJsonTimings[x] = SysJsonSerializeTimer(notesList);
                nsJsonTimings[x] = NsJsonSerializeTimer(notesList);
            }

            // Display table
            Console.WriteLine("Serialization complete. Please press any key to display timings table.");
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("{0,-15}{1,-25}{2,-25}", "ITERATION", "SYSTEM.TEXT.JSON (ms)", "NEWTONSOFT.JSON (ms)");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0,-15}{1,-25}{2,-25}", i + 1, sysJsonTimings[i], nsJsonTimings[i]);
            }
            Console.WriteLine();
            Console.WriteLine("{0,-15}{1,-25}{2,-25}", "AVG", sysJsonTimings.Average(), nsJsonTimings.Average());

            Console.ReadKey();
        }
    }
}
