using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UoL_Virtual_Assistant
{
    class ParseInput
    {

        string[] questionWords = { "where", "who", "when", "how", "why" };
        string[] greetingWords = { "hello", "hi", "howdy", "hey", "heya" };
        string[] punctuation = { "?", "!", "." };

        public void SplitInput(string input)
        {
            input.ToLower();

            string regexPattern = @"(\? )|(\! )|(\. )|(\?)|(\!)|(\.)";
            string[] sentences = Regex.Split(input, regexPattern);
            string[] separatedWords = input.Split(' ');
            
            sentences = SentenceCleanup(sentences);

            string[] contexts = AnalyseContext(sentences);

            string temp = " ";
            //Concatenates strings for DEBUG testing
            for (int i = 0; i < sentences.Length; i++)
            {
                //MessageBox.Show("Sentence: " + sentences[i] + "\n Characters: " + sentences[i].Length);
                temp = temp + "\n" + i + ". " + sentences[i] + " [" + contexts[i] + "]";
            }

            MessageBox.Show("Question Sentence Split:" + "\n" + temp + "\n\n[" + sentences.Length + " sentences detected from input]");   //DEBUG MESSAGEBOX, displays the separated sentences and amount (-1 to account for the way it splits 'em).

        }

        string[] SentenceCleanup(string[] sentences)
        {
            //Reincorperates punctuation into the sentences
            for (int i = 0; i < sentences.Length; i++)
            {
                if ((sentences[i].Contains("?") || sentences[i].Contains("!") || sentences[i].Contains(".")) && i > 0)
                {
                    List<string> tempList = new List<string>(sentences);
                    tempList[i - 1] = tempList[i - 1] + tempList[i];
                    tempList.RemoveAt(i);
                    sentences = tempList.ToArray();
                    //MessageBox.Show("LOL");
                }
            }

            //Removes sentences that are just space
            for (int i = 0; i < sentences.Length; i++)
            {
                if (sentences[i] == "" || sentences[i] == " " || sentences[i] == "?" || sentences[i] == "!" || sentences[i] == "." || sentences[i] == ". " || sentences[i] == "? " || sentences[i] == "! " || sentences[i] == "." + "" || sentences[i] == "?" + "" || sentences[i] == "!" + "" || sentences[i] == "" + "." || sentences[i] == "" + "?" || sentences[i] == "" + "!")
                {
                    List<string> tempList = new List<string>(sentences);
                    tempList.RemoveAt(i);
                    sentences = tempList.ToArray();
                    i -= 1;
                }
            }

            return sentences;
        }

        string[] AnalyseContext(string[] sentences)
        {
            string[] contexts = new string[sentences.Length];

            for (int i = 0; i < sentences.Length; i++)
            {
                for (int j = 0; j < questionWords.Length; j++)
                {
                    if (sentences[i].Contains(questionWords[j]))
                    {
                        contexts[i] = "Question: " + questionWords[j];
                    }
                }
                for (int j = 0; j < greetingWords.Length; j++)
                {
                    if (sentences[i].Contains(greetingWords[j]))
                    {
                        contexts[i] = "Greeting: " + greetingWords[j];
                    }
                }
            }

            return contexts;
        }

    }
}
