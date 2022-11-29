using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFiction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("press any key to start \n");
                Console.ReadKey(true);

                Story.showStory();

                Console.ReadKey(true);
            }
        }
    }
    public static void showStory()
    {
        ParseStory(story);
        ConsoleKeyInfo keyPress;

        for (int i = 0; i < pages.Count;)
        {
            Console.WriteLine(pages[i].plotText);
            Console.WriteLine();

            if (pages[i].isTitle == true) { i++; continue; }

            if (pages[i].isEnd == true) { break; }

            if (pages[i].choiceTextA != null)
                Console.WriteLine("A:" + pages[i].choiceTextA);

            if (pages[i].choiceTextB != null)
                Console.WriteLine("B:" + pages[i].choiceTextB);

            Console.WriteLine("\n Wrong input.. \n");

            keyPress = Console.ReadKey(true);

            if (keyPress.Key == ConsoleKey.A)
            {

                for (int j = 0; j < pages.Count; j++)
                {
                    if (pages[j] == pages[i].choiceA)
                    {
                        i = j;
                        break;
                    }
                }
            }
        }
    }
}
