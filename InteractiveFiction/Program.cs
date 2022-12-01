using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveFiction
{

    class Program
    {
        static void Main()
        {
            Story.showStory();

            Console.ReadKey(true);
        }
    }

    public class PageNode
    {
        public string plotText;
        public string choiceTextA;
        public string choiceTextB;

        public bool isTitle;
        public bool isEnd;

        public PageNode choiceA;
        public PageNode choiceB;
    }

    public class Story
    {

        public static string[] story = new string[]
        {
                //Title Page | page:0
                "The Forest Part 1"+
                ";" +
                ";" +
                ";1" +
                ";1",
                //-----------------------------------------------------------------------------------------------
                //1st intro | Page:1
                "- You've awaken on the ground of a dark forest. There are two set paths. Which one do you choose?" +
                ";Left." +
                ";Right." +
                ";2" +
                ";3", 
                //A: Left path | Page:2
                "You've taken the path to your left.\nAs you walk, you see an abandoned house.\nMovement is heard farther down the path." +
                ";Go into the house?" +
                ";Continue down the path." +
                ";4" +
                ";5", 
                //-----------------------------------------------------------------------------------------------
                //B: Right path | Page:3
                "You've taken the path to your right. As you walk you notice a strange, dark figure farther into the forest.\nDo you investigate?" +
                ";No, continue on the path." +
                ";Investigate." +
                ";6" +
                ";7", 
                //-----------------------------------------------------------------------------------------------
                // house / A: enter house | Page:4
                "You approach the house. \nAs you enter you notice strange carvings on the wall. \nAs you examine the carvings, a bright light shines through the window." +
                ";Walk outisde to investigate." +
                ";Hide?." +
                ";8" +
                ";9", 
                // path / B: contine down path | page:5
                "You continue down the path. \nThe movement is getting louder, but a bright light begins to protrude throughout the woods. " +
                ";Investigate light" +
                ";Investigate movement." +
                ";10" +
                ";11",
                //-----------------------------------------------------------------------------------------------
                // right path / A: continue path | page:6
                "As you continue down the dark path, you hear talking in the distance." +
                ";Investigate talking." +
                ";Continue down the path." +
                ";12" +
                ";13",
                // right path / B: figure | page:7
                "You walk closer to the figure but it vanishes in thin air. \nYou investigate and notice a strange wooden carving on the ground where they vanished. \nAs you pick up the object you hear a blood curdling scream farther down the path." +
                ";Break the object." +
                ";Investigate scream." +
                ";14" +
                ";15",
                //-----------------------------------------------------------------------------------------------
                // house / A: walk outside | Page:8
                " * It's your friend, he's breathing heavily as he tells you the sun hasn't come up in 14 hours. \n As he begins to finish, a loud hum from outside deafens your ears. \n \n Everything goes black as you awaken on the ground a dark forest.\n \n There are two set paths..." +
                ";" +
                ";" +
                ";" +
                ";",
                // house / B: hide | Page:9
                " * Hiding under a table, you hear a familiar voice. \n   You go to leave your hiding place until a loud hum from outside deafens your ears.\n \n  Everything goes black as you awaken on the ground of a dark forest.\n \n  There are two set paths..." +
                ";" +
                ";" +
                ";" +
                ";",
                // path / A: light | page:10
                " * A strange obilisk sits upon the center of a barren field. \n Surrounding the obilisk are hooded figures, chanting an unintelligable phrase as more and more light protrudes from the object. \n You shakingly walk towards the group until a tall, dark figure appears. \n He begins to reach into his robe until a loud hum from the object deafens your ears. \n \n Everything goes black as you awaken on the ground of a dark forest.\n \n There are two set paths...  " +
                ";" +
                ";" +
                ";" +
                ";",
                // path / B: movement | page:11
                " * It's your friend. You yell to him but he doesn't respond. \n As you catch up to him, you put your hand on his shoulder, he slowly turns his head to reveal his eyes and mouth have been stitched closed. \n You scream and fall backwards. \n As you shakingly try to get up and help him, a loud hum from outside deafens your ears.\n \n Everything goes black as you awaken on the ground of a dark forest.\n \n There are two set paths..." +
                ";" +
                ";" +
                ";" +
                ";",
                //-----------------------------------------------------------------------------------------------
                // right path A: talking | page:12
                " *You see a group of tall dark figures humming in unicen. \n You yell for help as they all slowly turn to face you. \n Their faces are pale with no distict features that could resemble a human being. \n You turn to run but feel a sharp pain in your abdomen. \n You look down to see you are bleeding profusely. \n \n You fall to the ground as everything fades to black. \n \n You awaken on the ground of a dark forest. \n \n There are two set paths..."+
                ";" +
                ";" +
                ";" +
                ";",
                // right path B: path | page:13
                " *You continue down the path. It seems you have been walking for hours. \n  The Moon is full and hasn't moved. \n  You finally pass out from exhaustion. \n \n You begin to open your eyes and awaken on the ground of a dark forest. \n \n There are two set paths..." +
                ";" +
                ";" +
                ";" +
                ";",
                // right path A: break obj | page:14
                " *As you're breaking the object, a familiar voice yells 'NO!' and then screams in agony. \n  You look over to see the mangled, contourted body of your friend. \n  You scream and begin to vomit to the point of passing out. \n \n  You fall to the ground as everything goes black. \n \n  You finally awaken on the ground of a dark forest. \n \n  There are two set paths..." +
                ";" +
                ";" +
                ";" +
                ";",
                // right path B: scream | page:15
                " *You run to investigate the scream. In the distance you see a tall, lanky, pale figure. \n You begin to slowly approach as turns its head in your direction. \n It lets out a deafening scream as it sprints in your direction on all fours. \n It raises its arm to slash as everything goes black. \n \n You finally awaken on the ground of a dark forest. \n \n There are two set paths..." +
                ";" +
                ";" +
                ";" +
                ";",
        };

        static Dictionary<int, PageNode> pages = new Dictionary<int, PageNode>(); // so nothings static 

        public static PageNode ParseStory(string[] storyData)
        {
            //story text and choices
            for (int i = 0; i < storyData.Length; i++)
            {
                string pageSource = storyData[i];
                PageNode pageNode = new PageNode();
                string[] storySplit = pageSource.Split(';');

                if (i == 0)
                    pageNode.isTitle = true;

                else
                    pageNode.isTitle = false;

                pageNode.plotText = storySplit[0];
                pageNode.choiceTextA = storySplit[1];
                pageNode.choiceTextB = storySplit[2];

                pages.Add(i, pageNode);
            }

            //choices/destination. links pages together
            for (int j = 0; j < storyData.Length; j++)
            {
                string pageSource = storyData[j];
                string[] storySplit = pageSource.Split(';');
                PageNode pageNode = pages[j];

                //ignore if no numbers in string[] to parse
                try
                {
                    int A = int.Parse(storySplit[3]);
                    pageNode.choiceA = pages[A];
                }
                catch (FormatException)
                {
                    pageNode.choiceA = null;
                    pageNode.isEnd = true;

                }

                try
                {
                    int B = int.Parse(storySplit[4]);
                    pageNode.choiceB = pages[B];
                }
                catch (FormatException)
                {
                    pageNode.choiceB = null;
                    pageNode.isEnd = true;

                }
            }

            return pages[0];
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n > ...Awaiting Decision... \n");
                Console.ResetColor();

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

                if (keyPress.Key == ConsoleKey.B)
                {
                    for (int j = 0; j < pages.Count; j++)
                    {
                        if (pages[j] == pages[i].choiceB)
                        {
                            i = j;
                            break;
                        }
                    }
                }

                Console.WriteLine("_______________________________________________________________________________\n");
            }
        }

    }
}
