using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees_Task_A
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            AVLTree<text> textWords = new AVLTree<text>();           
            const int MAX_FILE_LINES = 50000;
            string[] AllLines = new string[MAX_FILE_LINES];
            //reads from bin/DEBUG subdirectory of project directory
            AllLines = File.ReadAllLines("textFile.txt");
            string[] preTree = new string[MAX_FILE_LINES];

            foreach (string line in AllLines)
            {
                //split words using space , . ?
                string[] words = line.Split(' ', ',', '.', '?', ';', ':', '!');
                foreach (string word in words)
                {   
                    text texts = new text(word.ToLower());
                    if (word != "" && preTree.Contains(word.ToLower()) == false)//textWords.Contains(word) == false)
                    {
                        preTree[++i] = word.ToLower();
                        if (textWords.Contains(texts) == false)
                        {
                            textWords.InsertItem(texts);
                        }
                    }
                    else
                    {
                        texts.increase();
                    }
                }
            }

            string printer = "";
            textWords.InOrder(ref printer);
            Console.WriteLine(printer);
            Console.WriteLine("Height of Tree = " + textWords.Height());
            Console.WriteLine("Number of Unique Words = " + textWords.Count());
            Console.ReadKey();

        }
    }
}
