using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UoL_Virtual_Assistant
{
    class Output
    {
        Random Randomiser = new Random(); //creates a randomiser item

        public void Generate_AI_Response()
        {
            if (Main_UI.AI_Message_Counter == 0)
            {
                Generate_Greeting();
                return;
            }

            if (Main_UI.AI_Message_Counter == 24)
            {
                Generate_Goodbye();
                return;
            }

            else
            {
                Generate_Message();
                return;
            }
        }

        public void Generate_Greeting()
        {
            if ((DateTime.Now.TimeOfDay > new TimeSpan(17, 55, 0)))
            {
                switch (Main_UI.Connected_Agent)
                {
                    case 0: //bruce
                        Main_UI.Latest_AI_Message = "Hi " + Main_UI.Student_First_Name + ". We're just about to leave for the day. If it's a quick question I can answer it now, otherwise you can contact us again the next working day or leave the question with the out of hours service.";
                        break;
                    case 1: //hal
                        break;
                    case 2: //jason
                        break;
                    case 3: //suzie
                        break;
                }
            }

            else
            {
                int Greeting_Option = Randomiser.Next(0, 4);
                switch (Main_UI.Connected_Agent)
                {
                    case 0: //bruce
                        switch (Greeting_Option)
                        {
                            case 0:
                                Main_UI.Latest_AI_Message = "Hi, I'm Bruce Hargrave and I'll be dealing with your query today. What would you like me to do for you?";
                                break;
                            case 1:
                                Main_UI.Latest_AI_Message = "Hi " + Main_UI.Student_First_Name + ". What would you like me to do for you today?";
                                break;
                            case 2:
                                Main_UI.Latest_AI_Message = "Hi, I'm Bruce. What can I do for you today?";
                                break;
                            case 3:
                                Main_UI.Latest_AI_Message = "Hi " + Main_UI.Student_First_Name + ". How can I help?";
                                break;
                            case 4:
                                Main_UI.Latest_AI_Message = "Hi, I'm Bruce Hargrave. How can I help you today?";
                                break;
                        }
                        break;
                    case 1: //hal
                        switch (Greeting_Option)
                        {
                            case 0:
                                Main_UI.Latest_AI_Message = "Hello, " + Main_UI.Student_First_Name + ". What is your query?";
                                break;
                            case 1:
                                Main_UI.Latest_AI_Message = "Hello, " + Main_UI.Student_First_Name + ". What is your query today?";
                                break;
                            case 2:
                                Main_UI.Latest_AI_Message = "Hello, " + Main_UI.Student_First_Name + ". How can I assist you?";
                                break;
                            case 3:
                                Main_UI.Latest_AI_Message = "Hello, " + Main_UI.Student_First_Name + ". How can I help you today?";
                                break;
                            case 4:
                                Main_UI.Latest_AI_Message = "Hello, " + Main_UI.Student_First_Name + ". What task can I perform for you today?";
                                break;
                        }
                        break;
                    case 2: //jason
                        switch (Greeting_Option)
                        {
                            case 0:
                                Main_UI.Latest_AI_Message = "Hi! I'm Jason Bradbury. What can I do for you? :)";
                                break;
                            case 1:
                                Main_UI.Latest_AI_Message = "Hi! What can I do for you today? :)";
                                break;
                            case 2:
                                Main_UI.Latest_AI_Message = "Hi " + Main_UI.Student_First_Name + ", I'm Jason! What can I do for you today? ;)";
                                break;
                            case 3:
                                Main_UI.Latest_AI_Message = "Hi " + Main_UI.Student_First_Name + ", I'm Jason Bradbury! What will I be doing for you today? :)";
                                break;
                            case 4:
                                Main_UI.Latest_AI_Message = "Hi I'm Jason! What would you like me do for you today?? :)";
                                break;
                        }
                        break;
                    case 3: //suzie
                        switch (Greeting_Option)
                        {
                            case 0:
                                Main_UI.Latest_AI_Message = "Hi " + Main_UI.Student_First_Name + ", I'm Suzi :3 How can I help you today?";
                                break;
                            case 1:
                                Main_UI.Latest_AI_Message = "Hi " + Main_UI.Student_First_Name + ", I'm Suzi :3 What can I do for you?";
                                break;
                            case 2:
                                Main_UI.Latest_AI_Message = "Hi " + Main_UI.Student_First_Name + ", I'm Suzi :3 What can I do to help you today?";
                                break;
                            case 3:
                                Main_UI.Latest_AI_Message = "Hi " + Main_UI.Student_First_Name + ", I'm Suzi! How can I help? :)";
                                break;
                            case 4:
                                Main_UI.Latest_AI_Message = "Hi " + Main_UI.Student_First_Name + ", I'm Suzi. How can I help you out today? :3";
                                break;
                        }
                        break;
                }
            }
        }        

        public void Generate_Message()
        {
            Main_UI.Latest_AI_Message = "dasfghjkhtgrsdfdfxgjhdxfgmhthgrdfbdfctedwascffvbbgnghgjytrewwhfgcghvbn";
        }

        public void Generate_Goodbye()
        {

        }
    }
}
