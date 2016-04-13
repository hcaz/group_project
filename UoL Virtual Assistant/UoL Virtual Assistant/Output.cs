using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace UoL_Virtual_Assistant
{
    class Output
    {
        Random Randomiser = new Random(); //creates a randomiser item
        public string agent = "default";

        public void Generate_AI_Response()
        {
            switch (Main_UI.Connected_Agent)
            {
                case 0: //bruce
                    this.agent = "bruce";
                    break;
                case 1: //hal
                    this.agent = "hal";
                    break;
                case 2: //jason
                    this.agent = "jason";
                    break;
                case 3: //suzie
                    this.agent = "suzie";
                    break;
            }
            if (Main_UI.AI_Message_Counter == 0)
            {
                if ((Main_UI.currentTime > new TimeSpan(17, 55, 0)))
                {
                    Main_UI.Latest_AI_Message = lookupMessage("filler", "greetingEnd");
                }
                else
                {
                    Main_UI.Latest_AI_Message = @"Welcome to UOL Live chat!
==================
" + lookupMessage("filler", "greeting");
                }
                return;
            }

            if (Main_UI.AI_Message_Counter == 24)
            {
                Main_UI.Latest_AI_Message = lookupMessage("filler", "farewell");
                return;
            }

            else
            {
                ParseInput PI = new ParseInput();
                List<ContextObject> sentences = PI.SplitInputReturn(Main_UI.Latest_User_Message.ToLower());
                string output = "";
                foreach (ContextObject currentSentance in sentences)
                {
                    if (currentSentance.sentenceType.Contains(ContextObject.SentenceType.farewell))
                    {
                        output = output + " - " + lookupMessage("filler", "farewell");
                    }
                    else if (currentSentance.sentenceType.Contains(ContextObject.SentenceType.greeting))
                    {
                        output = output + " - " + lookupMessage("filler", "greeting");
                    }
                    else if (currentSentance.sentenceType.Contains(ContextObject.SentenceType.greeting_question))
                    {
                        output = output + " - " + lookupMessage("filler", "greeting_question");
                    }
                    else if (currentSentance.sentenceType.Contains(ContextObject.SentenceType.insult))
                    {
                        output = output + " - " + lookupMessage("filler", "rude_insult");
                    }
                    else if (currentSentance.sentenceType.Contains(ContextObject.SentenceType.question_who))
                    {
                        if (currentSentance.subType.Contains(ContextObject.SubjectType.name_faculty))
                        {
                            output = output + " - " + lookupMessage("filler", "name_faculty");
                        }
                        else
                        if (currentSentance.subType.Contains(ContextObject.SubjectType.partial_name_faculty))
                        {
                            output = output + " - " + lookupMessage("filler", "partial_name_faculty");
                        }
                        else
                        {
                            output = output + " - " + lookupMessage("filler", "error_name_faculty");
                        }
                    }
                    else if (currentSentance.sentenceType.Contains(ContextObject.SentenceType.statement))
                    {
                    }
                    else if (currentSentance.sentenceType.Contains(ContextObject.SentenceType.workstation))
                    {
                        output = output + " - " + lookupMessage("filler", "workstation");
                    }
                    else if (currentSentance.sentenceType.Contains(ContextObject.SentenceType.thank_you))
                    {
                        output = output + " - " + lookupMessage("filler", "thanks");
                    }
                    else
                    {
                        output = output + " - " + lookupMessage("filler", "error");
                    }
                }
                Main_UI.Latest_AI_Message = output.Trim().TrimStart('-');
                return;
            }
        }

        public string lookupMessage(string context, string message)
        {
            agent = this.agent.ToUpper();
            context = context.ToUpper();
            message = message.ToUpper();

            Random rnd = new Random();
            string url = "../../resources/files/messages.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/MESSAGES/" + context + "/" + message + "/" + agent + "/MESSAGE");
            if (nodes.Count == 0)
            {
                nodes = doc.DocumentElement.SelectNodes("/MESSAGES/" + context + "/" + message + "/DEFAULT/MESSAGE");
            }
            if (nodes.Count == 0)
            {
                nodes = doc.DocumentElement.SelectNodes("/MESSAGES/FILLER/" + message + "/" + agent + "/MESSAGE");
            }
            if (nodes.Count == 0)
            {
                nodes = doc.DocumentElement.SelectNodes("/MESSAGES/FILLER/" + message + "/DEFAULT/MESSAGE");
            }
            if (nodes.Count == 0)
            {
                nodes = doc.DocumentElement.SelectNodes("/MESSAGES/FILLER/ERROR/" + agent + "/MESSAGE");
            }
            if (nodes.Count == 0)
            {
                nodes = doc.DocumentElement.SelectNodes("/MESSAGES/FILLER/ERROR/DEFAULT/MESSAGE");
            }
            int random = rnd.Next(0, nodes.Count);
            string output = nodes[random].InnerText;

            output = output.Replace("$studentFirstName", Main_UI.Student_First_Name);
            output = output.Replace("$studentID", Main_UI.Student_ID);

            if (message == "NAME_FACULTY")
            {
                output = output.Replace("$firstName", Main_UI.currentObject.ChildNodes[0].InnerText);
                output = output.Replace("$email", Main_UI.currentObject.ChildNodes[4].InnerText);
                output = output.Replace("$phone", Main_UI.currentObject.ChildNodes[5].InnerText);
            }
            if (message == "PARTIAL_NAME_FACULTY")
            {
                output = output.Replace("$fullName", Main_UI.currentObject.ChildNodes[0].InnerText);
            }
            if (message == "WORKSTATION")
            {
                ScrapeData data = new ScrapeData();
                data.freePCData();
                data.libraryOpening();
                output = output.Replace("$freePCS", data.freePcs.ToString());
                output = output.Replace("$times", data.libraryOpen.ToString());
                output = output.Replace("$deskTimes", data.libraryDeskOpen.ToString());
            }

            return output;
        }
    }
}