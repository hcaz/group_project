﻿using System;
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
        public string studentFirstname = "student";
        public string studentNumber = "number";

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
            this.studentFirstname = Main_UI.Student_First_Name;
            this.studentNumber = Main_UI.Student_ID;
            if (Main_UI.AI_Message_Counter == 0)
            {
                if ((DateTime.Now.TimeOfDay > new TimeSpan(17, 55, 0)))
                {
                    lookupMessage("filler", "greetingsEnd");
                }
                else
                {
                    lookupMessage("filler", "greetings");
                }
                return;
            }

            if (Main_UI.AI_Message_Counter == 24)
            {
                lookupMessage("filler", "farewells");
                return;
            }

            else
            {
                //Generate_Message();
                return;
            }
        }

        public void lookupMessage(string context, string message)
        {
            agent = this.agent.ToUpper();
            context = context.ToUpper();
            message = message.ToUpper();

            Random rnd = new Random();
            string url = "../../resources/files/messages.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/MESSAGES/" + context + "/" + message + "/"+ agent + "/MESSAGE");
            if (nodes.Count == 0)
            {
                nodes = doc.DocumentElement.SelectNodes("/MESSAGES/" + context + "/" + message + "/DEFAULT/MESSAGE");
            }
            int random = rnd.Next(0, nodes.Count);
            string output = nodes[random].InnerText;

            output = output.Replace("$studentFirstName", this.studentFirstname);
            output = output.Replace("$studentID", this.studentNumber);

            Main_UI.Latest_AI_Message = output;
        }
    }
}