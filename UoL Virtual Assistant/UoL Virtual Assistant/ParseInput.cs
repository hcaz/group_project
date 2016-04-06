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
        XmlDocument locationData = new XmlDocument();
        XmlNodeList staffNames;
        XmlNodeList questionWords;
        XmlNodeList greetingWords;
        XmlNodeList keyWords;
        XmlNodeList banks;
        XmlNodeList shops;
        XmlNodeList restaurants;
        XmlNodeList hotels;
        XmlNodeList gyms;
        XmlNodeList fastFood;
        XmlNodeList estateAgents;
        XmlNode ignoreWords;

        string[] punctuation = { "?", "!", "." };

        public void SplitInput(string input)
        {
            staffData.Load("../../staff.xml");
            keywordData.Load("../../keywordData.xml");
            locationData.Load("../../Locations.xml");
            staffNames = staffData.SelectNodes("STAFF");
            questionWords = keywordData.SelectNodes("KEYWORDS/QUESTIONS");
            greetingWords = keywordData.SelectNodes("KEYWORDS/GREETINGS");
            keyWords = keywordData.SelectNodes("KEYWORDS/MISC");
            banks = locationData.SelectNodes("LOCATIONS/BANKS");
            shops = locationData.SelectNodes("LOCATIONS/SHOPS");
            restaurants = locationData.SelectNodes("LOCATIONS/RESTAURANTS");
            hotels = locationData.SelectNodes("LOCATIONS/HOTELS");
            gyms = locationData.SelectNodes("LOCATIONS/GYMS");
            fastFood = locationData.SelectNodes("LOCATIONS/FASTFOOD");
            estateAgents = locationData.SelectNodes("LOCATIONS/ESTATEAGENTS");
            ignoreWords = keywordData.SelectSingleNode("KEYWORDS/IGNOREWORDS");



            input.ToLower();

            string regexPattern = @"(\? )|(\! )|(\. )|(\?)|(\!)|(\.)";
            string[] sentences = Regex.Split(input, regexPattern);
            string[] separatedWords = input.Split(' ');
            List<ContextObject> contextObjects = new List<ContextObject>();

            sentences = SentenceCleanup(sentences);


            contextObjects = AnalyseContext(sentences);
            

            string temp = " ";
            //Concatenates strings for DEBUG testing
            for (int i = 0; i < sentences.Length; i++)
            {
                //MessageBox.Show("Sentence: " + sentences[i] + "\n Characters: " + sentences[i].Length);
                temp = temp + "\n\n" + (i + 1) + ". " + sentences[i] + " " + contextObjects[i].debugString;
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

        List<ContextObject> AnalyseContext(string[] sentences)
        {
            List<ContextObject> contextList = new List<ContextObject>();
            string[] contexts = new string[sentences.Length];
            string[][] splitWords = new string[sentences.Length][];
            bool facultyFullNameFound = false;
            XmlNode partialMatchNode = null;
            int partialIndex = -1;

            for (int i = 0; i < splitWords.Length; i++)
            {
                splitWords[i] = Regex.Replace(sentences[i], "[?!.,-/]", "").Split(' ');
            }

            //MessageBox.Show(splitWords[1][0] + " " + splitWords[1][1]);

            for (int i = 0; i < sentences.Length; i++)
            {
                ContextObject contextObject = new ContextObject();
                facultyFullNameFound = false;
                for (int j = 0; j < questionWords[0].ChildNodes.Count; j++)
                {
                    //check against question words in array
                    if (sentences[i].ToLower().Contains(questionWords[0].ChildNodes[j].Name.ToLower()))
                    {
                        //contextObject.sentenceType = ContextObject.SentenceType.
                        switch (questionWords[0].ChildNodes[j].Name.ToLower())
                        {
                            case "where":
                                contextObject.sentenceType.Add(ContextObject.SentenceType.question_where);
                                break;
                            case "when":
                                contextObject.sentenceType.Add(ContextObject.SentenceType.question_when);
                                break;
                            case "who":
                                contextObject.sentenceType.Add(ContextObject.SentenceType.question_who);
                                break;
                            case "why":
                                contextObject.sentenceType.Add(ContextObject.SentenceType.question_why);
                                break;
                            case "what":
                                contextObject.sentenceType.Add(ContextObject.SentenceType.question_what);
                                break;
                            default:
                                break;
                        }
                        contexts[i] = contexts[i] + "[Question: " + questionWords[0].ChildNodes[j].Name.ToLower() + "]";
                    }
                    else if (sentences[i].ToLower().Contains("tell me about") || sentences[i].ToLower().Contains("tell me"))
                    {
                        contextObject.sentenceType.Add(ContextObject.SentenceType.tell_me_about);
                    }
                }
                for (int j = 0; j < greetingWords[0].ChildNodes.Count; j++)
                {
                    //check against greeting words in array
                    if (sentences[i].Contains(greetingWords[0].ChildNodes[j].Name.ToLower()))
                    {
                        contextObject.sentenceType.Add(ContextObject.SentenceType.greeting);
                        contexts[i] = contexts[i] + "[Greeting: " + greetingWords[0].ChildNodes[j].Name.ToLower() + "]";
                    }
                }


                for (int k = 0; k < staffNames[0].ChildNodes.Count; k++)
                {
                    if (!facultyFullNameFound)
                    {
                        string[] temp = staffNames[0].ChildNodes[k].ChildNodes[0].InnerText.ToLower().Split(' ');
                        //MessageBox.Show(temp.Length.ToString());


                        //check against staff names in the xml data file - any matching nodes can then be passed on to the output
                        //CHECKING FOR FULL NAME
                        for (int x = 0; x < splitWords[i].Length; x++)
                        {

                            //MessageBox.Show(splitWords[j][x].ToLower() + " " + temp[0] + " " + temp[1]);
                            if ((splitWords[i][x].ToLower() == temp[0]) && !ignoreWords.InnerText.ToLower().Contains(splitWords[i][x].ToLower()))
                            {
                                if (partialMatchNode == null && !facultyFullNameFound)
                                {
                                    partialMatchNode = staffNames[0].ChildNodes[k];
                                    partialIndex = i;
                                }
                                if (x + 1 < splitWords[i].Length && (splitWords[i][x + 1].ToLower() == temp[1]) && !ignoreWords.InnerText.ToLower().Contains(splitWords[i][x + 1].ToLower()))
                                {
                                    facultyFullNameFound = true;
                                    partialMatchNode = null;
                                    partialIndex = -1;
                                    //error checking for context, can cause issues otherwise
                                    if (contexts[i] != null)
                                    {
                                        //MessageBox.Show(contexts[j]);
                                        if (!contexts[i].ToLower().Contains(staffNames[0].ChildNodes[k].ChildNodes[0].InnerText.ToLower()) && !contexts[i].ToLower().Contains("name_faculty"))
                                        {
                                            contextObject.subType.Add(ContextObject.SubjectType.name_faculty);
                                            contextObject.subjectList.Add(staffNames[0].ChildNodes[k]);
                                            contexts[i] = contexts[i] + "[Name_Faculty: " + staffNames[0].ChildNodes[k].ChildNodes[0].InnerText + "]";
                                        }
                                    }
                                    else if (contexts[i] == null && !contexts[i].ToLower().Contains("name_faculty"))
                                    {
                                        contextObject.subType.Add(ContextObject.SubjectType.name_faculty);
                                        contextObject.subjectList.Add(staffNames[0].ChildNodes[k]);
                                        contexts[i] = contexts[i] + "[Name_Faculty: " + staffNames[0].ChildNodes[k].ChildNodes[0].InnerText + "]";
                                    }

                                    break;
                                }
                            }
                        }

                        if (facultyFullNameFound)
                        {
                            //MessageBox.Show(facultyFullNameFound + " " + temp[0] + " " + temp[1]);
                            facultyFullNameFound = true;
                            partialMatchNode = null;
                            partialIndex = -1;

                            break;
                        }
                        //MessageBox.Show(facultyFullNameFound + " " + partialIndex);
                        //if no FULL NAME match is found, use the partial match (if any)
                    }
                    else
                    {
                        break;
                    }
                }
                if (!facultyFullNameFound && partialMatchNode != null && partialIndex != -1)
                {
                    //MessageBox.Show(facultyFullNameFound + " " + partialMatchNode.InnerText);
                    //MessageBox.Show(facultyFullNameFound + " " + partialIndex);
                    contextObject.subType.Add(ContextObject.SubjectType.name_faculty);
                    contextObject.subjectList.Add(partialMatchNode);
                    contexts[partialIndex] = contexts[i] + "[PARTIAL_Name_Faculty: " + partialMatchNode.InnerText + "]";
                }

                facultyFullNameFound = true;
                partialMatchNode = null;
                partialIndex = -1;

                //more xml searching TODO

                //banks
                for (int j = 0; j < banks[0].ChildNodes.Count; j++)
                {
                    //check against banks words in array
                    if (sentences[i].Contains(banks[0].ChildNodes[j].ChildNodes[0].InnerText.ToLower()))
                    {
                        if (!contextObject.subjectList.Contains(banks[0].ChildNodes[j].ChildNodes[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.name_location);
                            contextObject.subjectList.Add(banks[0].ChildNodes[j].ChildNodes[0]);
                            contexts[i] = contexts[i] + "[Bank mentioned: " + banks[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                    else if (sentences[i].Contains("bank") || sentences[i].Contains("finance"))
                    {
                        if (!contextObject.subjectList.Contains(banks[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(banks[0]);
                        }
                    }
                }

                //shops
                for (int j = 0; j < shops[0].ChildNodes.Count; j++)
                {
                    //check against shops words in array
                    if (sentences[i].Contains(shops[0].ChildNodes[j].ChildNodes[0].InnerText.ToLower()))
                    {
                        if (!contextObject.subjectList.Contains(shops[0].ChildNodes[j].ChildNodes[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.name_location);
                            contextObject.subjectList.Add(shops[0].ChildNodes[j].ChildNodes[0]);
                            contexts[i] = contexts[i] + "[Shop mentioned: " + shops[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                    else if (sentences[i].Contains("shops") || sentences[i].Contains("shopping") || sentences[i].Contains("clothes") || sentences[i].Contains("shoes"))
                    {
                        if (!contextObject.subjectList.Contains(shops[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(shops[0]);
                        }
                    }
                }

                //restaurants
                for (int j = 0; j < restaurants[0].ChildNodes.Count; j++)
                {
                    //check against restaurants words in array
                    if (sentences[i].Contains(restaurants[0].ChildNodes[j].ChildNodes[0].InnerText.ToLower()))
                    {
                        if (!contextObject.subjectList.Contains(restaurants[0].ChildNodes[j].ChildNodes[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.name_location);
                            contextObject.subjectList.Add(restaurants[0].ChildNodes[j].ChildNodes[0]);
                            contexts[i] = contexts[i] + "[restaurants mentioned: " + restaurants[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                    else if (sentences[i].Contains("restaurant") || sentences[i].Contains("food") || sentences[i].Contains("eat out") || sentences[i].Contains("eat") || sentences[i].Contains("cafe"))
                    {
                        if (!contextObject.subjectList.Contains(restaurants[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(restaurants[0]);
                        }
                    }
                }

                //hotels
                for (int j = 0; j < hotels[0].ChildNodes.Count; j++)
                {
                    //check against hotels words in array
                    if (sentences[i].Contains(hotels[0].ChildNodes[j].ChildNodes[0].InnerText.ToLower()))
                    {
                        if (!contextObject.subjectList.Contains(hotels[0].ChildNodes[j].ChildNodes[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.name_location);
                            contextObject.subjectList.Add(hotels[0].ChildNodes[j].ChildNodes[0]);
                            //MessageBox.Show(hotels[0].ChildNodes[j].ChildNodes[0].InnerText);
                            contexts[i] = contexts[i] + "[hotel mentioned: " + hotels[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                    else if (sentences[i].Contains("hotel") || sentences[i].Contains("visit"))
                    {
                        if (!contextObject.subjectList.Contains(hotels[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(hotels[0]);
                        }
                    }
                }

                //gyms
                for (int j = 0; j < gyms[0].ChildNodes.Count; j++)
                {
                    //check against gyms words in array
                    if (sentences[i].Contains(gyms[0].ChildNodes[j].ChildNodes[0].InnerText.ToLower()))
                    {
                        if (!contextObject.subjectList.Contains(gyms[0].ChildNodes[j].ChildNodes[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.name_location);
                            contextObject.subjectList.Add(gyms[0].ChildNodes[j].ChildNodes[0]);
                            contexts[i] = contexts[i] + "[gyms mentioned: " + gyms[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                    else if (sentences[i].Contains("gym") || sentences[i].Contains("exercise") || sentences[i].Contains("running") || sentences[i].Contains("cycling") || sentences[i].Contains("in shape"))
                    {
                        if (!contextObject.subjectList.Contains(gyms[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(gyms[0]);
                        }
                    }
                }

                //fastFood
                for (int j = 0; j < fastFood[0].ChildNodes.Count; j++)
                {
                    //check against fastFood words in array
                    if (sentences[i].Contains(fastFood[0].ChildNodes[j].ChildNodes[0].InnerText.ToLower()))
                    {
                        if (!contextObject.subjectList.Contains(fastFood[0].ChildNodes[j].ChildNodes[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.name_location);
                            contextObject.subjectList.Add(fastFood[0].ChildNodes[j].ChildNodes[0]);
                            contexts[i] = contexts[i] + "[fastFood mentioned: " + fastFood[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                    else if (sentences[i].Contains("fast food") || sentences[i].Contains("maccies") || sentences[i].Contains("cheap food"))
                    {
                        if (!contextObject.subjectList.Contains(fastFood[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(fastFood[0]);
                        }
                    }
                }

                //estateAgents
                for (int j = 0; j < estateAgents[0].ChildNodes.Count; j++)
                {
                    //check against fastFood words in array
                    if (sentences[i].Contains(estateAgents[0].ChildNodes[j].ChildNodes[0].InnerText.ToLower()))
                    {
                        if (!contextObject.subjectList.Contains(estateAgents[0].ChildNodes[j]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.name_location);
                            contextObject.subjectList.Add(estateAgents[0].ChildNodes[j]);
                            contexts[i] = contexts[i] + "[estateAgents mentioned: " + estateAgents[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                    else if (sentences[i].Contains("estate") || sentences[i].Contains("agent") || sentences[i].Contains("accomodation") || sentences[i].Contains("housing") || sentences[i].Contains("hous"))
                    {
                        if (!contextObject.subjectList.Contains(estateAgents[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(estateAgents[0]);
                        }
                    }
                }

                //add context to list
                contextObject.ConstructDebugString();
                contextList.Add(contextObject);

            }

            return contextList;
        }
    }

    class ContextObject
    {
        public List<SentenceType> sentenceType = new List<SentenceType>();
        public List<SubjectType> subType = new List<SubjectType>();
        public List<XmlNode> subjectList = new List<XmlNode>();
        public string debugString = "";
        //
        public enum SubjectType { name_faculty, name_location, type_location };
        public enum SentenceType { greeting, statement, insult, question_where, question_why, question_when, question_what, question_who, tell_me_about};

        public ContextObject()
        {

        }

        public ContextObject(List<SentenceType> sentType, List<SubjectType> subType)
        {

        }

        public void ConstructDebugString()
        {
            for (int i = 0; i < sentenceType.Count; i++)
            {
                debugString = debugString + " [" + sentenceType[i] + "] ";
            }
            if (subType.Count > 0)
            {
                for (int i = 0; i < subType.Count; i++)
                {
                    if (subjectList[i].ParentNode.Name.ToLower() == "locations")
                    {
                        debugString = debugString + " [" + subType[i] + ": " + subjectList[i].Name + "] ";
                    }
                    else
                    {
                        debugString = debugString + " [" + subType[i] + ": " + subjectList[i].ChildNodes[0].InnerText + "] ";
                    }
                }
            }
        }
    }
}
