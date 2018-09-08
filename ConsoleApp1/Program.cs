using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Tachocline;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Tweetomator();

            Console.ReadKey();
        }

        public static void Tweetomator()
        {
            var text = File.ReadAllText("LoremIpsum.txt");
            text = Regex.Replace(text, @"\s+", " ");
            var maxLength = 140;

            var corteMolhado = text.Split(maxLength, c => !char.IsPunctuation(c) /*&& !char.IsWhiteSpace(c)*/);
            foreach (var tweet in corteMolhado)
            {
                Console.Write("\"");
                Console.Write(tweet);
                Console.WriteLine("\"");
                Console.WriteLine();
            }
        }

        public static void Blocker()
        {
            var text = new String('*', 500);
            var blocks = text.Split(280, c => !char.IsPunctuation(c));
            Console.WriteLine(blocks.Sum(block => block.Length));
        }
    }
}
