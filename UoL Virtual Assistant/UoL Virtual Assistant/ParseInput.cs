using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace UoL_Virtual_Assistant
{
    class ParseInput
    {

        XmlDocument staffData = new XmlDocument();
        XmlDocument keywordData = new XmlDocument();
        XmlNodeList staffNames;
        XmlNodeList questionWords;
        XmlNodeList greetingWords;
        XmlNodeList keyWords;
        XmlNode ignoreWords;

        string[] punctuation = { "?", "!", "." };

        public void SplitInput(string input)
        {
            staffData.Load("../../staff.xml");
            keywordData.Load("../../keywordData.xml");
            staffNames = staffData.SelectNodes("STAFF");
            questionWords = keywordData.SelectNodes("KEYWORDS/QUESTIONS");
            greetingWords = keywordData.SelectNodes("KEYWORDS/GREETINGS");
            keyWords = keywordData.SelectNodes("KEYWORDS/MISC");
            ignoreWords = keywordData.SelectSingleNode("KEYWORDS/IGNOREWORDS");

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
                temp = temp + "\n\n" + (i + 1) + ". " + sentences[i] + " " + contexts[i];
            }

            MessageBox.Show("Question Sentence Split:" + "\n" + temp + "\n\n\n[" + sentences.Length + " sentences detected from input]");   //DEBUG MESSAGEBOX, displays the separated sentences and amount (-1 to account for the way it splits 'em).

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
            string[][] splitWords = new string[sentences.Length][];

            for (int i = 0; i < splitWords.Length; i++)
            {
                splitWords[i] = Regex.Replace(sentences[i], "[?!.,-/]", "").Split(' ');
            }

            //MessageBox.Show(splitWords[1][0] + " " + splitWords[1][1]);

            for (int i = 0; i < sentences.Length; i++)
            {
                for (int j = 0; j < questionWords[0].ChildNodes.Count; j++)
                {
                    //check against question words in array
                    if (sentences[i].Contains(questionWords[0].ChildNodes[j].Name.ToLower()))
                    {
                        contexts[i] = contexts[i] + "[Question: " + questionWords[0].ChildNodes[j].Name.ToLower() + "]";
                    }
                }
                for (int j = 0; j < greetingWords[0].ChildNodes.Count; j++)
                {
                    //check against greeting words in array
                    if (sentences[i].Contains(greetingWords[0].ChildNodes[j].Name.ToLower()))
                    {
                        contexts[i] = contexts[i] + "[Greeting: " + greetingWords[0].ChildNodes[j].Name.ToLower() + "]";
                    }
                }
                for (int j = 0; j < sentences.Length; j++)
                {
                    for (int k = 0; k < staffNames[0].ChildNodes.Count; k++)
                    {
                        string[] temp = staffNames[0].ChildNodes[k].ChildNodes[0].InnerText.ToLower().Split(' ');
                        //MessageBox.Show(temp.Length.ToString());
                        

                        //check against staff names in the xml data file - any matching nodes can then be passed on to the output
                        for (int x = 0; x < splitWords[j].Length; x++)
                        {
                            //MessageBox.Show(splitWords[j][x].ToLower() + " " + temp[0] + " " + temp[1]);
                            if ((splitWords[j][x].ToLower() == temp[0] || splitWords[j][x].ToLower() == temp[1]) && !ignoreWords.InnerText.ToLower().Contains(splitWords[j][x].ToLower()))
                            {
                               
                                //error checking for context, can cause issues otherwise
                                if (contexts[j] != null)
                                {
                                    //MessageBox.Show(contexts[j]);
                                    if (!contexts[j].ToLower().Contains(staffNames[0].ChildNodes[k].ChildNodes[0].InnerText.ToLower()))
                                    {
                                        contexts[j] = contexts[j] + "[Name_Faculty: " + staffNames[0].ChildNodes[k].ChildNodes[0].InnerText + "]";
                                    }
                                }
                                else
                                {
                                    contexts[j] = contexts[j] + "[Name_Faculty: " + staffNames[0].ChildNodes[k].ChildNodes[0].InnerText + "]";
                                }
                            }
                        }
                    }
                }
            }
            return contexts;
        }
    }
}
