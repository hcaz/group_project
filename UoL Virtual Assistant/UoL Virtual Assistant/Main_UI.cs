using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UoL_Virtual_Assistant
{
    public partial class Main_UI : Form
    {
        //globally accessed values should go below this
        string Student_ID = "12454434"; //**THIS SHOULD BE CHANGED TO REFLECT THE LOCALLY STORED VALUE** a value of 0 is default (no ID)
        string Student_First_Name = "Joseph"; //**THIS SHOULD BE CHANGED TO REFLECT THE LOCALLY STORED VALUE** a value of " " is default (no first name)
        string Student_Last_Name = "Potter"; //**THIS SHOULD BE CHANGED TO REFLECT THE LOCALLY STORED VALUE** a value of " " is default (no last name)
        string Student_Course = "Games Computing"; //**THIS SHOULD BE CHANGED TO REFLECT THE LOCALLY STORED VALUE** a value of " " is default (no course)

        int Universal_Theme_Value = 12; //**THIS SHOULD BE CHANGED TO REFLECT THE LOCALLY STORED VALUE** a value of 0 is default (white)
        int R = 0;
        int G = 0;
        int B = 0;

        int Preferred_Agent = 0; //**THIS SHOULD BE CHANGED TO REFLECT THE LOCALLY STORED VALUE** a value of 0 is default (no agent preference)
        int UoL_Logo_Link = 0; //**THIS SHOULD BE CHANGED TO REFLECT THE LOCALLY STORED VALUE** a value of 0 is default (UoL Homepage)

        int Open_Settings_Drawer = 0; //a value of 0 indicates that the drawer is shut
        int Open_Conversation_Window = 0; //a value of 0 indicates that the conversation window is hidden
        int User_Message_Counter = 0; //this will keep track of how many messages the user has sent so the chat interface can be resized accordingly


        //automated processes
        public Main_UI()
        {
            if (Student_ID == "0")
            {
                First_Run_UI FirstRun = new First_Run_UI(); //create a new instance of the First_Run_UI
                FirstRun.ShowDialog(); //show the new window
            }

            InitializeComponent(); //initialize the component
            this.Width = 350; this.Height = 500; //resizes the UI to be it's default starting value
            UI_Theming(); //apply the theme to the UI


            //StreamReader objstream = new StreamReader(@"tasks\task1.txt"); //locates task1 file
            //task1datePreview.Text = objstream.ReadLine(); //writes the creation date to the main screen
            //task1preview.Text = "1. " + objstream.ReadLine(); //writes a preview of the task title to the main screen
            //objstream.Close(); //closes the file, allows it to be used later



            Hide_Items(); //make sure certain items are hidden when the UI loads
            Tooltips_Generation(); //**THIS SHOULD BE ONE OF THE LAST THINGS TO RUN**
        }

        public void Hide_Items()
        {
            //hide items related to the settings drawer
            Settings_Drawer.Location = new Point(320, 0); //move the drawer so that it is off screen
            Settings_Title.Location = new Point(360, 12); //move the settings title so that it is off screen
            Course_Building.Location = new Point(352, 50); //move the course building image so that it is off screen

            //assigning and relocating Name and ID labels and assigning transparency values - this is witchcraft
            Student_ID_Title.Location = new Point(535, 101);
            Student_ID_Title.Text = Student_ID;
            Student_Name_Title.Location = new Point(535, 117);
            Student_Name_Title.Text = Student_First_Name + " " + Student_Last_Name;
            var NamePosition = this.PointToScreen(Student_Name_Title.Location);
            var IDPosition = this.PointToScreen(Student_ID_Title.Location);
            NamePosition = Course_Building.PointToClient(NamePosition);
            IDPosition = Course_Building.PointToClient(IDPosition);
            Student_Name_Title.Parent = Course_Building;
            Student_ID_Title.Parent = Course_Building;
            Student_Name_Title.Location = NamePosition;
            Student_ID_Title.Location = IDPosition;
            Student_Name_Title.BackColor = Color.Transparent;
            Student_ID_Title.BackColor = Color.Transparent;

            Theme_Title.Location = new Point(360, 157); //move the theme title so that it is off screen
            Theme_Selection.Location = new Point(395, 157); //move the theme selection box so that it is off screen
            Preferred_Agent_Title.Location = new Point(360, 186); //move the preferred agent title so that it is off screen
            Preferred_Agent_Selection.Location = new Point(395, 205); //move the preferred agent box so that it is off screen
            UoL_Logo_Link_Title.Location = new Point(360, 237); //move the UoL logo link title so that it is off screen
            UoL_Logo_Link_Selection.Location = new Point(395, 256); //move the UoL logo link selection so that it is off screen
            Reset_Title.Location = new Point(360, 285); //move the reset title so that it is off screen
            Reset_Button.Location = new Point(395, 285); //move the reset button so that it is off screen
            About_Title.Location = new Point(360, 314); //move the about title so that it is off screen
            About_Content.Location = new Point(365, 342); //move the about content so that it is off screen

            //hide items related to the conversation window
            Conversation_Window.Location = new Point(37, 410); //move the window so that it is off screen
        }

        public void Tooltips_Generation()
        {
            //generate tooltips
            ToolTip Tooltips = new ToolTip(); //creates a new tooltip
            Tooltips.SetToolTip(UoL_Branding, "Clicking on this will take you to the University of Lincoln website."); //assigns a tooltip description
        }


        public void UI_Theming()
        {

            if (Universal_Theme_Value == 0)
            {
                R = 33; G = 150; B = 243;
            }

            if (Universal_Theme_Value == 1)
            {
                R = 121; G = 85; B = 72;
            }

            if (Universal_Theme_Value == 2)
            {
                R = 0; G = 188; B = 212;
            }

            if (Universal_Theme_Value == 3)
            {
                R = 139; G = 195; B = 74;
            }

            if (Universal_Theme_Value == 4)
            {
                R = 96; G = 125; B = 139;
            }

            if (Universal_Theme_Value == 5)
            {
                R = 63; G = 81; B = 181;
            }

            if (Universal_Theme_Value == 6)
            {
                this.BackgroundImage = Properties.Resources.JB;
                MessageBox.Show("Ayyyy");
                R = 255; G = 255; B = 255;
            }

            if (Universal_Theme_Value == 7)
            {
                R = 255; G = 87; B = 34;
            }

            if (Universal_Theme_Value == 8)
            {
                R = 233; G = 30; B = 99;
            }

            if (Universal_Theme_Value == 9)
            {
                R = 103; G = 58; B = 183;
            }

            if (Universal_Theme_Value == 10)
            {
                R = 244; G = 67; B = 54;
            }

            if (Universal_Theme_Value == 11)
            {
                R = 0; G = 150; B = 136;
            }

            if (Universal_Theme_Value == 12)
            {
                R = 255; G = 255; B = 255;
            }

            this.BackColor = Color.FromArgb(R, G, B);
        }

        private void Message_Input_TextChanged(object sender, EventArgs e)
        {
            if (Message_Input.Text.Length > 28)
            {
                Message_Input.ScrollBars = ScrollBars.Vertical;
            }

            else
            {
                Message_Input.ScrollBars = ScrollBars.None;
            }

        }

        //user initiated events
        private void UoL_Branding_Click(object sender, EventArgs e) //when the UoL branding is clicked on...
        {
            if (UoL_Logo_Link == 0)
            {
                System.Diagnostics.Process.Start("http://blackboard.lincoln.ac.uk"); //opens the users default browser and displays the page
            }

            if (UoL_Logo_Link == 1)
            {
                System.Diagnostics.Process.Start("http://www.lincoln.ac.uk/home/"); //opens the users default browser and displays the page
            }

            if (UoL_Logo_Link == 2)
            {
                System.Diagnostics.Process.Start("http://library.lincoln.ac.uk/"); //opens the users default browser and displays the page
            }

            if (UoL_Logo_Link == 3)
            {
                string Timetable_URL = ("http://timetables.lincoln.ac.uk/mytimetable/" + Student_ID + ".htm");
                System.Diagnostics.Process.Start(Timetable_URL); //opens the users default browser and displays the page
            }
        }

        private void Send_Message_Click(object sender, EventArgs e) //when the send message button is clicked on...
        {
            string User_Message = (Message_Input.Text); //write the user message to a string

            User_Message_Counter++; //increase the user message counter by one
            Resize_Chat_Window();
            //bring up the conversation box with users submitted message
        }

        private async void Resize_Chat_Window()
        {
            if (Open_Conversation_Window == 0) //if the window status is set to hidden
            {
                Conversation_Window.Visible = true; //make the window visible
                Open_Conversation_Window = 1; //set the window status as open
                for (int Window_Steps = 0; Window_Steps <= 35; Window_Steps++) //establishes the number of individual steps the window needs to take
                {
                    await Task.Delay(1); //delay for 1/100 of a second
                    Conversation_Window.Location = new Point(Conversation_Window.Location.X, Conversation_Window.Location.Y - 10); //move the window so that it is on screen
                }
            }

            else
            {
                Open_Conversation_Window = 0; //set the window status as closed
                for (int Window_Steps = 0; Window_Steps <= 35; Window_Steps++) //establishes the number of individual steps the window needs to take
                {
                    await Task.Delay(1); //delay for 1/100 of a second
                    Conversation_Window.Location = new Point(Conversation_Window.Location.X, Conversation_Window.Location.Y + 10); //move the window so that it is off screen
                }

                Conversation_Window.Visible = false; //make the window invisible
                
            }
        }

        private async void Hamburger_Menu_Click(object sender, EventArgs e) //when the hamburger menu is clicked...
        {
            if(Open_Settings_Drawer == 0) //if the drawer status is set to closed
            {
                Settings_Drawer.Visible = true; //make the drawer visible
                Hamburger_Menu.Enabled = false; //disable the button so it can't be clicked
                for (int Drawer_Steps = 0; Drawer_Steps <= 15; Drawer_Steps++) //establishes the number of individual steps the drawer needs to take
                {
                    await Task.Delay(5); //delay for 1/20 of a second
                    Settings_Drawer.Location = new Point(Settings_Drawer.Location.X - 10, Settings_Drawer.Location.Y); //move the drawer so that it is on screen
                    Settings_Title.Location = new Point(Settings_Title.Location.X - 11, Settings_Title.Location.Y); //move the setting title so that it is on screen
                    Course_Building.Location = new Point(Course_Building.Location.X - 11, Course_Building.Location.Y); //move the course building image so that it is on screen
                    Student_ID_Title.Location = new Point(Student_ID_Title.Location.X - 11, Student_ID_Title.Location.Y);
                    Student_Name_Title.Location = new Point(Student_Name_Title.Location.X - 11, Student_Name_Title.Location.Y);
                    Theme_Title.Location = new Point(Theme_Title.Location.X - 11, Theme_Title.Location.Y);
                    Theme_Selection.Location = new Point(Theme_Selection.Location.X - 8, Theme_Selection.Location.Y);
                    Preferred_Agent_Title.Location = new Point(Preferred_Agent_Title.Location.X - 11, Preferred_Agent_Title.Location.Y);
                    Preferred_Agent_Selection.Location = new Point(Preferred_Agent_Selection.Location.X - 8, Preferred_Agent_Selection.Location.Y);
                    UoL_Logo_Link_Title.Location = new Point(UoL_Logo_Link_Title.Location.X - 11, UoL_Logo_Link_Title.Location.Y);
                    UoL_Logo_Link_Selection.Location = new Point(UoL_Logo_Link_Selection.Location.X - 8, UoL_Logo_Link_Selection.Location.Y);
                    Reset_Title.Location = new Point(Reset_Title.Location.X - 11, Reset_Title.Location.Y);
                    Reset_Button.Location = new Point(Reset_Button.Location.X - 8, Reset_Button.Location.Y);
                    About_Title.Location = new Point(About_Title.Location.X - 11, About_Title.Location.Y);
                    About_Content.Location = new Point(About_Content.Location.X - 11, About_Content.Location.Y);

                    if (Drawer_Steps == 3)
                    {
                        Hamburger_Menu.BackColor = Color.FromArgb(1, 38, 83); //change the background colour to blue
                    }
                }

                Hamburger_Menu.Enabled = true; //enable the button so it can be clicked again
                Open_Settings_Drawer = 1; //set the drawer status as open
            }

            else
            {
                Hamburger_Menu.Enabled = false; //disable the button so it can't be clicked
                for (int Drawer_Steps = 0; Drawer_Steps <= 15; Drawer_Steps++) //establishes the number of individual steps the drawer needs to take
                {
                    await Task.Delay(5); //delay for 1/20 of a second
                    Settings_Drawer.Location = new Point(Settings_Drawer.Location.X + 10, Settings_Drawer.Location.Y); //move the drawer so that it is off screen
                    Settings_Title.Location = new Point(Settings_Title.Location.X + 11, Settings_Title.Location.Y); //move the settings title so that it is off screen
                    Course_Building.Location = new Point(Course_Building.Location.X + 11, Course_Building.Location.Y); //move the course building image so that it is onff screen
                    Student_ID_Title.Location = new Point(Student_ID_Title.Location.X + 11, Student_ID_Title.Location.Y);
                    Student_Name_Title.Location = new Point(Student_Name_Title.Location.X + 11, Student_Name_Title.Location.Y);
                    Theme_Title.Location = new Point(Theme_Title.Location.X + 11, Theme_Title.Location.Y);
                    Theme_Selection.Location = new Point(Theme_Selection.Location.X + 8, Theme_Selection.Location.Y);
                    Preferred_Agent_Title.Location = new Point(Preferred_Agent_Title.Location.X + 11, Preferred_Agent_Title.Location.Y);
                    Preferred_Agent_Selection.Location = new Point(Preferred_Agent_Selection.Location.X + 8, Preferred_Agent_Selection.Location.Y);
                    UoL_Logo_Link_Title.Location = new Point(UoL_Logo_Link_Title.Location.X + 11, UoL_Logo_Link_Title.Location.Y);
                    UoL_Logo_Link_Selection.Location = new Point(UoL_Logo_Link_Selection.Location.X + 8, UoL_Logo_Link_Selection.Location.Y);
                    Reset_Title.Location = new Point(Reset_Title.Location.X + 11, Reset_Title.Location.Y);
                    Reset_Button.Location = new Point(Reset_Button.Location.X + 8, Reset_Button.Location.Y);
                    About_Title.Location = new Point(About_Title.Location.X + 11, About_Title.Location.Y);
                    About_Content.Location = new Point(About_Content.Location.X + 11, About_Content.Location.Y);

                    if (Drawer_Steps == 12)
                    {
                        Hamburger_Menu.BackColor = Color.Transparent; //change the background colour to transparent again
                    }
                }

                Hamburger_Menu.Enabled = true; //enable the button so it can be clicked again
                Settings_Drawer.Visible = false; //make the drawer invisible
                Open_Settings_Drawer = 0; //set the drawer status as closed
            }
                
        }

        private void Theme_Selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Theme_Selection.SelectedItem.ToString().Equals("Blue"))
            {
                Universal_Theme_Value = 0;
            }

            if (Theme_Selection.SelectedItem.ToString().Equals("Brown"))
            {
                Universal_Theme_Value = 1;
            }

            if (Theme_Selection.SelectedItem.ToString().Equals("Cyan"))
            {
                Universal_Theme_Value = 2;
            }

            if (Theme_Selection.SelectedItem.ToString().Equals("Green"))
            {
                Universal_Theme_Value = 3;
            }

            if (Theme_Selection.SelectedItem.ToString().Equals("Grey"))
            {
                Universal_Theme_Value = 4;
            }

            if (Theme_Selection.SelectedItem.ToString().Equals("Indigo"))
            {
                Universal_Theme_Value = 5;
            }

            if (Theme_Selection.SelectedItem.ToString().Equals("Jbm8"))
            {
                //something special
                Universal_Theme_Value = 6;
            }

            if (Theme_Selection.SelectedItem.ToString().Equals("Orange"))
            {
                Universal_Theme_Value = 7;
            }

            if (Theme_Selection.SelectedItem.ToString().Equals("Pink"))
            {
                Universal_Theme_Value = 8;
            }

            if (Theme_Selection.SelectedItem.ToString().Equals("Purple"))
            {
                Universal_Theme_Value = 9;
            }

            if (Theme_Selection.SelectedItem.ToString().Equals("Red"))
            {
                Universal_Theme_Value = 10;
            }

            if (Theme_Selection.SelectedItem.ToString().Equals("Teal"))
            {
                Universal_Theme_Value = 11;
            }

            if (Theme_Selection.SelectedItem.ToString().Equals("White"))
            {
                Universal_Theme_Value = 12;
            }

            //should save the theme selection to a file
            UI_Theming(); //rethemes the UI
        }

        private void UoL_Logo_Link_Selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UoL_Logo_Link_Selection.SelectedItem.ToString().Equals("Blackboard"))
            {
                UoL_Logo_Link = 0;
            }

            if (UoL_Logo_Link_Selection.SelectedItem.ToString().Equals("Homepage"))
            {
                UoL_Logo_Link = 1;
            }

            if (UoL_Logo_Link_Selection.SelectedItem.ToString().Equals("Library"))
            {
                UoL_Logo_Link = 2;
            }

            if (UoL_Logo_Link_Selection.SelectedItem.ToString().Equals("Timetable"))
            {
                UoL_Logo_Link = 3;
            }
        }
    }
}
