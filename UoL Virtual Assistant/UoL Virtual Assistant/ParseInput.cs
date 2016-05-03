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
        XmlNodeList greetingQuestions;
        XmlNodeList questionWords;
        XmlNodeList greetingWords;
        XmlNodeList farewells;
        XmlNodeList affirmatives;
        XmlNodeList negatives;
        XmlNodeList thanks;
        XmlNodeList workstations;
        XmlNodeList weather;
        XmlNodeList keyWords;
        XmlNodeList banks;
        XmlNodeList shops;
        XmlNodeList restaurants;
        XmlNodeList hotels;
        XmlNodeList gyms;
        XmlNodeList fastFood;
        XmlNodeList estateAgents;
        XmlNodeList insults;
        XmlNode ignoreWords;

        string[] punctuation = { "?", "!", "." };

        public void SplitInput(string input)
        {
            staffData.Load("../../staff.xml");
            keywordData.Load("../../keywordData.xml");
            locationData.Load("../../Locations.xml");
            staffNames = staffData.SelectNodes("STAFF");
            questionWords = keywordData.SelectNodes("KEYWORDS/QUESTIONS");
            greetingQuestions = keywordData.SelectNodes("KEYWORDS/GREETINGS_QUESTIONS");
            greetingWords = keywordData.SelectNodes("KEYWORDS/GREETINGS");
            farewells = keywordData.SelectNodes("KEYWORDS/FAREWELLS");
            affirmatives = keywordData.SelectNodes("KEYWORDS/CONFIRMATIONS");
            negatives = keywordData.SelectNodes("KEYWORDS/NEGATIVE_RESPONSES");
            thanks = keywordData.SelectNodes("KEYWORDS/THANK_YOUS");
            workstations = keywordData.SelectNodes("KEYWORDS/FREE_PCS");
            weather = keywordData.SelectNodes("KEYWORDS/WEATHER_QUERY");
            keyWords = keywordData.SelectNodes("KEYWORDS/MISC");
            banks = locationData.SelectNodes("LOCATIONS/BANKS");
            shops = locationData.SelectNodes("LOCATIONS/SHOPS");
            restaurants = locationData.SelectNodes("LOCATIONS/RESTAURANTS");
            hotels = locationData.SelectNodes("LOCATIONS/HOTELS");
            gyms = locationData.SelectNodes("LOCATIONS/GYMS");
            fastFood = locationData.SelectNodes("LOCATIONS/FASTFOOD");
            estateAgents = locationData.SelectNodes("LOCATIONS/ESTATEAGENTS");
            ignoreWords = keywordData.SelectSingleNode("KEYWORDS/IGNOREWORDS");
            insults = keywordData.SelectNodes("KEYWORDS/INSULTS");
            
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

        public List<ContextObject> SplitInputReturn(string input)
        {
            staffData.Load("../../staff.xml");
            keywordData.Load("../../keywordData.xml");
            locationData.Load("../../Locations.xml");
            staffNames = staffData.SelectNodes("STAFF");
            questionWords = keywordData.SelectNodes("KEYWORDS/QUESTIONS");
            greetingQuestions = keywordData.SelectNodes("KEYWORDS/GREETINGS_QUESTIONS");
            greetingWords = keywordData.SelectNodes("KEYWORDS/GREETINGS");
            farewells = keywordData.SelectNodes("KEYWORDS/FAREWELLS");
            affirmatives = keywordData.SelectNodes("KEYWORDS/CONFIRMATIONS");
            thanks = keywordData.SelectNodes("KEYWORDS/THANK_YOUS");
            negatives = keywordData.SelectNodes("KEYWORDS/NEGATIVE_RESPONSES");
            workstations = keywordData.SelectNodes("KEYWORDS/FREE_PCS");
            weather = keywordData.SelectNodes("KEYWORDS/WEATHER_QUERY");
            keyWords = keywordData.SelectNodes("KEYWORDS/MISC");
            banks = locationData.SelectNodes("LOCATIONS/BANKS");
            shops = locationData.SelectNodes("LOCATIONS/SHOPS");
            restaurants = locationData.SelectNodes("LOCATIONS/RESTAURANTS");
            hotels = locationData.SelectNodes("LOCATIONS/HOTELS");
            gyms = locationData.SelectNodes("LOCATIONS/GYMS");
            fastFood = locationData.SelectNodes("LOCATIONS/FASTFOOD");
            estateAgents = locationData.SelectNodes("LOCATIONS/ESTATEAGENTS");
            ignoreWords = keywordData.SelectSingleNode("KEYWORDS/IGNOREWORDS");
            insults = keywordData.SelectNodes("KEYWORDS/INSULTS");

            string regexPattern = @"(\? )|(\! )|(\. )|(\?)|(\!)|(\.)";
            string[] sentences = Regex.Split(input, regexPattern);
            string[] separatedWords = input.Split(' ');
            List<ContextObject> contextObjects = new List<ContextObject>();

            sentences = SentenceCleanup(sentences);

            contextObjects = AnalyseContext(sentences);

            return contextObjects;
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
                        if (!contextObject.sentenceType.Contains(ContextObject.SentenceType.tell_me_about))
                        {
                            contextObject.sentenceType.Add(ContextObject.SentenceType.tell_me_about);
                        }
                    }
                }

                for (int j = 0; j < greetingWords[0].ChildNodes.Count; j++)
                {
                    //check against greeting words in array
                    if (sentences[i].ToLower().Contains(greetingWords[0].ChildNodes[j].Name.ToLower()))
                    {
                        if (!contextObject.sentenceType.Contains(ContextObject.SentenceType.greeting))
                        {
                            contextObject.sentenceType.Add(ContextObject.SentenceType.greeting);
                            contexts[i] = contexts[i] + "[Greeting: " + greetingWords[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                }

                for (int j = 0; j < greetingQuestions[0].ChildNodes.Count; j++)
                {
                    //check against greeting words in array
                    if (sentences[i].ToLower().Contains(greetingQuestions[0].ChildNodes[j].InnerText.ToLower()))
                    {
                        if (!contextObject.sentenceType.Contains(ContextObject.SentenceType.greeting_question))
                        {
                            contextObject.sentenceType.Add(ContextObject.SentenceType.greeting_question);
                            contexts[i] = contexts[i] + "[Greeting_Question: " + greetingQuestions[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                }

                //farewells
                for (int j = 0; j < farewells[0].ChildNodes.Count; j++)
                {
                    //check against farewell words in array
                    if (sentences[i].ToLower().Contains(farewells[0].ChildNodes[j].InnerText.ToLower()))
                    {
                        if (!contextObject.sentenceType.Contains(ContextObject.SentenceType.farewell))
                        {
                            contextObject.sentenceType.Add(ContextObject.SentenceType.farewell);
                            contexts[i] = contexts[i] + "[Farewell: " + farewells[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                }

                //affirmatives
                for (int j = 0; j < affirmatives[0].ChildNodes.Count; j++)
                {
                    //check against affirmative words in array
                    if (sentences[i].ToLower().Contains(affirmatives[0].ChildNodes[j].InnerText.ToLower()))
                    {
                        if (!contextObject.sentenceType.Contains(ContextObject.SentenceType.affirmative))
                        {
                            contextObject.sentenceType.Add(ContextObject.SentenceType.affirmative);
                            contexts[i] = contexts[i] + "[Affirmative: " + affirmatives[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                }

                //negatives
                for (int j = 0; j < negatives[0].ChildNodes.Count; j++)
                {
                    //check against negative words in array
                    if (sentences[i].ToLower().Contains(negatives[0].ChildNodes[j].InnerText.ToLower()))
                    {
                        if (!contextObject.sentenceType.Contains(ContextObject.SentenceType.negative))
                        {
                            contextObject.sentenceType.Add(ContextObject.SentenceType.negative);
                            contexts[i] = contexts[i] + "[Negative: " + negatives[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                }

                //thanks
                for (int j = 0; j < thanks[0].ChildNodes.Count; j++)
                {
                    //check against thanks words in array
                    if (sentences[i].ToLower().Contains(thanks[0].ChildNodes[j].InnerText.ToLower()))
                    {
                        if (!contextObject.sentenceType.Contains(ContextObject.SentenceType.thank_you))
                        {
                            contextObject.sentenceType.Add(ContextObject.SentenceType.thank_you);
                            contexts[i] = contexts[i] + "[Thank_you: " + thanks[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                }

                //free_pcs
                for (int j = 0; j < workstations[0].ChildNodes.Count; j++)
                {
                    //check against free_pcs words in array
                    if (sentences[i].ToLower().Contains(workstations[0].ChildNodes[j].InnerText.ToLower()))
                    {
                        if (!contextObject.sentenceType.Contains(ContextObject.SentenceType.workstation))
                        {
                            contextObject.sentenceType.Add(ContextObject.SentenceType.workstation);
                            contexts[i] = contexts[i] + "[Workstation: " + workstations[0].ChildNodes[j].Name.ToLower() + "]";
                        }
                    }
                }

                //weather
                for (int j = 0; j < weather[0].ChildNodes.Count; j++)
                {
                    //check against weather words in array
                    if (sentences[i].ToLower().Contains(weather[0].ChildNodes[j].InnerText.ToLower()))
                    {
                        if (!contextObject.sentenceType.Contains(ContextObject.SentenceType.weather))
                        {
                            contextObject.sentenceType.Add(ContextObject.SentenceType.weather);
                            contexts[i] = contexts[i] + "[Weather: " + weather[0].ChildNodes[j].Name.ToLower() + "]";
                        }
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
                                            Main_UI.currentObject = staffNames[0].ChildNodes[k];
                                        }
                                    }
                                    else if (contexts[i] == null && !contexts[i].ToLower().Contains("name_faculty"))
                                    {
                                        contextObject.subType.Add(ContextObject.SubjectType.name_faculty);
                                        contextObject.subjectList.Add(staffNames[0].ChildNodes[k]);
                                        contexts[i] = contexts[i] + "[Name_Faculty: " + staffNames[0].ChildNodes[k].ChildNodes[0].InnerText + "]";
                                        Main_UI.currentObject = staffNames[0].ChildNodes[k];
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
                    if (!contextObject.subjectList.Contains(partialMatchNode))
                    {
                        //MessageBox.Show(facultyFullNameFound + " " + partialMatchNode.InnerText);
                        //MessageBox.Show(facultyFullNameFound + " " + partialIndex);
                        contextObject.subType.Add(ContextObject.SubjectType.partial_name_faculty);
                        contextObject.subjectList.Add(partialMatchNode);
                        contexts[partialIndex] = contexts[i] + "[PARTIAL_Name_Faculty: " + partialMatchNode.InnerText + "]";
                        Main_UI.currentObject = partialMatchNode;
                    }
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
                            Main_UI.currentObject = banks[0].ChildNodes[j];
                            Main_UI.location = "namedbank";
                        }
                    }
                    else if (sentences[i].Contains("bank") || sentences[i].Contains("finance"))
                    {
                        if (!contextObject.subjectList.Contains(banks[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(banks[0]);
                            Main_UI.location = "bank";
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
                            Main_UI.currentObject = shops[0].ChildNodes[j];
                            Main_UI.location = "namedshop";
                        }
                    }
                    else if (sentences[i].Contains("shops") || sentences[i].Contains("shopping") || sentences[i].Contains("clothes") || sentences[i].Contains("shoes"))
                    {
                        if (!contextObject.subjectList.Contains(shops[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(shops[0]);
                            Main_UI.location = "shop";
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
                            Main_UI.currentObject = restaurants[0].ChildNodes[j];
                            Main_UI.location = "namedresturant";
                        }
                    }
                    else if (sentences[i].Contains("restaurant") || sentences[i].Contains("food") || sentences[i].Contains("eat out") || sentences[i].Contains("eat") || sentences[i].Contains("cafe"))
                    {
                        if (!contextObject.subjectList.Contains(restaurants[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(restaurants[0]);
                            Main_UI.location = "resturant";
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
                            Main_UI.currentObject = hotels[0].ChildNodes[j];
                            Main_UI.location = "namedhotel";
                        }
                    }
                    else if (sentences[i].Contains("hotel") || sentences[i].Contains("visit"))
                    {
                        if (!contextObject.subjectList.Contains(hotels[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(hotels[0]);
                            Main_UI.location = "hotel";
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
                            Main_UI.currentObject = gyms[0].ChildNodes[j];
                            Main_UI.location = "namedgym";
                        }
                    }
                    else if (sentences[i].Contains("gym") || sentences[i].Contains("exercise") || sentences[i].Contains("running") || sentences[i].Contains("cycling") || sentences[i].Contains("in shape"))
                    {
                        if (!contextObject.subjectList.Contains(gyms[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(gyms[0]);
                            Main_UI.location = "gym";
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
                            Main_UI.currentObject = fastFood[0].ChildNodes[j];
                            Main_UI.location = "namedfastfood";
                        }
                    }
                    else if (sentences[i].Contains("fast food") || sentences[i].Contains("maccies") || sentences[i].Contains("cheap food"))
                    {
                        if (!contextObject.subjectList.Contains(fastFood[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(fastFood[0]);
                            Main_UI.location = "fastfood";
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
                            Main_UI.currentObject = estateAgents[0].ChildNodes[j];
                            Main_UI.location = "namedestate";
                        }
                    }
                    else if (sentences[i].Contains("estate") || sentences[i].Contains("agent") || sentences[i].Contains("accomodation") || sentences[i].Contains("housing") || sentences[i].Contains("hous"))
                    {
                        if (!contextObject.subjectList.Contains(estateAgents[0]))
                        {
                            contextObject.subType.Add(ContextObject.SubjectType.type_location);
                            contextObject.subjectList.Add(estateAgents[0]);
                            Main_UI.location = "estate";
                        }
                    }
                }

                //insults
                for (int j = 0; j < insults[0].ChildNodes.Count; j++)
                {
                    //check against fastFood words in array
                    if (sentences[i].Contains(insults[0].ChildNodes[j].Name.ToLower()))
                    {
                        if (!contextObject.subjectList.Contains(insults[0].ChildNodes[j]))
                        {
                            contextObject.sentenceType.Add(ContextObject.SentenceType.insult);
                            contexts[i] = contexts[i] + "[INSULT: " + insults[0].ChildNodes[j].Name.ToLower() + "]";
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
        public enum SubjectType { partial_name_faculty, name_faculty, name_location, type_location };
        public enum SentenceType { greeting, farewell, affirmative, negative, thank_you, workstation, weather, greeting_question, statement, insult, question_where, question_why, question_when, question_what, question_who, tell_me_about};

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
