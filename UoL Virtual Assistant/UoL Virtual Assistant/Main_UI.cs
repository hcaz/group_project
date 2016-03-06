using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UoL_Virtual_Assistant
{
    public partial class Main_UI : Form
    {
        //globally accessed values
        string Student_ID; //creates a string that will store the Student ID
        string Student_First_Name; //creates a string that will store the student first name
        string Student_Last_Name; //creates a string that will store the student last name
        string Student_Course; //creates a string that will store the course that the student is on
        string Universal_Theme_Value; //creates a string that will store the current theme value
        int R; int G; int B; //creates R,G,B values for themes
        string Preferred_Agent; //creates a string that stores the users preferred agent
        string UoL_Logo_Link; //creates a string that stores the users preferred website to launch when clicking on UoL branding
        int Open_Settings_Drawer = 0; //a value of 0 indicates that the drawer is shut
        int Open_Conversation_Window = 0; //a value of 0 indicates that the conversation window is hidden
        int User_Message_Counter = 0; //this will keep track of how many messages the user has sent so the chat interface can be resized accordingly

        public Main_UI()
        {
            Read_User_Data(); //read in the user data from the settings file
            if (Student_ID == null) //if no student ID is found
            {
                First_Run_UI FirstRun = new First_Run_UI(); //create a new instance of the First_Run_UI
                FirstRun.ShowDialog(); //show the new window and halt Main_UI until it is closed
                Read_User_Data(); //read in the user data from the settings file again (with new information this time)
            }

            InitializeComponent(); //initialize the component
            this.Width = 350; this.Height = 500; //resizes the UI to be it's default starting value
            UI_Theming(); //apply the theme to the UI
            Hide_Items(); //make sure certain items are hidden when the UI loads
            Tooltips_Generation(); //generates tooltips for certain items in the UI
        }

        public void Hide_Items()
        {
            Theme_Selection.SelectedIndex = Convert.ToInt32(Universal_Theme_Value); //applys the current selected theme to the combo box
            Preferred_Agent_Selection.SelectedIndex = Convert.ToInt32(Preferred_Agent); //applys the current selected agent to the combo box
            UoL_Logo_Link_Selection.SelectedIndex = Convert.ToInt32(UoL_Logo_Link); //applys the current selected link to the combo box


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

        public void Read_User_Data()
        {
            string Local_Name = Environment.UserName; //retrieves the PC's name and saves it to a string
            string Settings_Path = (@"C:\\Users\\" + Local_Name + "\\Documents\\UoL Assistant\\Settings.txt"); //creates a string for the settings path

            if (File.Exists(Settings_Path))
            {
                StreamReader ObjectStream = new StreamReader(Settings_Path); //accesses the file via the streamReader
                Student_ID = ObjectStream.ReadLine(); //reads the student ID and saves it to a string
                Student_Course = ObjectStream.ReadLine(); //reads the students course and saves it to a string
                Universal_Theme_Value = ObjectStream.ReadLine(); //reads the theme value and saves it to a string
                Preferred_Agent = ObjectStream.ReadLine(); //reads the preferred agent and saves it to a string
                UoL_Logo_Link = ObjectStream.ReadLine(); //reads the preferred type of link to be directed from the UoL branding and saves it to a string
                ObjectStream.Close(); //closes the streamReader
            }

            else
            {
                //do nothing as it should loop back over and go back to the first run UI
            }
        }

        public void UI_Theming()
        {

            switch (Universal_Theme_Value) //retrieve the Universal Theme Value
            {
                case "0": //if theme value is set to 0
                    R = 33; G = 150; B = 243; //set the R,G,B values to these
                    break;
                case "1": //if theme value is set to 1
                    R = 121; G = 85; B = 72; //set the R,G,B values to these
                    break;
                case "2": //if theme value is set to 2
                    R = 0; G = 188; B = 212; //set the R,G,B values to these
                    break;
                case "3": //if theme value is set to 3
                    R = 139; G = 195; B = 74; //set the R,G,B values to these
                    break;
                case "4": //if theme value is set to 4
                    R = 96; G = 125; B = 139; //set the R,G,B values to these
                    break;
                case "5": //if theme value is set to 5
                    R = 63; G = 81; B = 181; //set the R,G,B values to these
                    break;
                case "6": //if theme value is set to 6
                    this.BackgroundImage = Properties.Resources.JB; //set the background image to the following resource
                    R = 255; G = 255; B = 255; //set the R,G,B values to these
                    break;
                case "7": //if theme value is set to 7
                    R = 255; G = 87; B = 34; //set the R,G,B values to these
                    break;
                case "8": //if theme value is set to 8
                    R = 233; G = 30; B = 99; //set the R,G,B values to these
                    break;
                case "9": //if theme value is set to 9
                    R = 103; G = 58; B = 183; //set the R,G,B values to these
                    break;
                case "10": //if theme value is set to 10
                    R = 244; G = 67; B = 54; //set the R,G,B values to these
                    break;
                case "11": //if theme value is set to 11
                    R = 0; G = 150; B = 136; //set the R,G,B values to these
                    break;
                case "12": //if theme value is set to 12
                    R = 255; G = 255; B = 255; //set the R,G,B values to these
                    break;
            }

            if (Universal_Theme_Value != "6") //if the theme value is not set to a theme with a dedicated background image
            {
                this.BackgroundImage = null; //remove the background image
            }

                this.BackColor = Color.FromArgb(R, G, B); //set the colour of the background
        }

        private void Message_Input_TextChanged(object sender, EventArgs e)
        {
            if (Message_Input.Text.Length > 28) //if the number of characters in the message input field exceeds 28
            {
                Message_Input.ScrollBars = ScrollBars.Vertical; //make a vertical scroll bar visible
            }

            else //otherwise
            {
                Message_Input.ScrollBars = ScrollBars.None; //hide the vertical scroll bar
            }

        }

        private void UoL_Branding_Click(object sender, EventArgs e)
        {
            if (UoL_Logo_Link == "0") //if the logo link value is set to 0
            {
                System.Diagnostics.Process.Start("http://blackboard.lincoln.ac.uk"); //opens the users default browser and displays the page
            }

            if (UoL_Logo_Link == "1") //if the logo link value is set to 1
            {
                System.Diagnostics.Process.Start("http://www.lincoln.ac.uk/home/"); //opens the users default browser and displays the page
            }

            if (UoL_Logo_Link == "2") //if the logo link value is set to 2
            {
                System.Diagnostics.Process.Start("http://library.lincoln.ac.uk/"); //opens the users default browser and displays the page
            }

            if (UoL_Logo_Link == "3") //if the logo link value is set to 3
            {
                string Timetable_URL = ("http://timetables.lincoln.ac.uk/mytimetable/" + Student_ID + ".htm"); //create the URL for the users personal timetable
                System.Diagnostics.Process.Start(Timetable_URL); //opens the users default browser and displays the page
            }
        }

        private void Send_Message_Click(object sender, EventArgs e)
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
        } //THIS IS ONLY A PLACEHOLDER

        private async void Hamburger_Menu_Click(object sender, EventArgs e)
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
                    Student_ID_Title.Location = new Point(Student_ID_Title.Location.X - 11, Student_ID_Title.Location.Y); //move the student ID title so that it is on screen
                    Student_Name_Title.Location = new Point(Student_Name_Title.Location.X - 11, Student_Name_Title.Location.Y); //move the student name title so that it is on screen
                    Theme_Title.Location = new Point(Theme_Title.Location.X - 11, Theme_Title.Location.Y); //move the theme title so that it is on screen
                    Theme_Selection.Location = new Point(Theme_Selection.Location.X - 8, Theme_Selection.Location.Y); //move the theme selection menu so that it is on screen
                    Preferred_Agent_Title.Location = new Point(Preferred_Agent_Title.Location.X - 11, Preferred_Agent_Title.Location.Y); //move the preferred agent title so that it is on screen
                    Preferred_Agent_Selection.Location = new Point(Preferred_Agent_Selection.Location.X - 8, Preferred_Agent_Selection.Location.Y); //move the preferred agent selection menu so that it is on screen
                    UoL_Logo_Link_Title.Location = new Point(UoL_Logo_Link_Title.Location.X - 11, UoL_Logo_Link_Title.Location.Y); //move the logo link title so that it is on screen
                    UoL_Logo_Link_Selection.Location = new Point(UoL_Logo_Link_Selection.Location.X - 8, UoL_Logo_Link_Selection.Location.Y); //move the logo link selection menu so that it is on screen
                    Reset_Title.Location = new Point(Reset_Title.Location.X - 11, Reset_Title.Location.Y); //move the reset title so that it is on screen
                    Reset_Button.Location = new Point(Reset_Button.Location.X - 8, Reset_Button.Location.Y); //move the reset button so that it is on screen
                    About_Title.Location = new Point(About_Title.Location.X - 11, About_Title.Location.Y); //move the about title so that it is on screen
                    About_Content.Location = new Point(About_Content.Location.X - 11, About_Content.Location.Y); //move the about content so that it is on screen

                    if (Drawer_Steps == 3) //if the drawer steps are equal to 3
                    {
                        Hamburger_Menu.BackColor = Color.FromArgb(1, 38, 83); //change the background colour to blue
                    }
                }

                Hamburger_Menu.Enabled = true; //enable the button so it can be clicked again
                Open_Settings_Drawer = 1; //set the drawer status as open
            }

            else //otherwise
            {
                Hamburger_Menu.Enabled = false; //disable the button so it can't be clicked
                for (int Drawer_Steps = 0; Drawer_Steps <= 15; Drawer_Steps++) //establishes the number of individual steps the drawer needs to take
                {
                    await Task.Delay(5); //delay for 1/20 of a second
                    Settings_Drawer.Location = new Point(Settings_Drawer.Location.X + 10, Settings_Drawer.Location.Y); //move the drawer so that it is off screen
                    Settings_Title.Location = new Point(Settings_Title.Location.X + 11, Settings_Title.Location.Y); //move the settings title so that it is off screen
                    Course_Building.Location = new Point(Course_Building.Location.X + 11, Course_Building.Location.Y); //move the course building image so that it is off screen
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

                    if (Drawer_Steps == 12) //if the drawer steps are equal to 12
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
            switch (Theme_Selection.SelectedItem.ToString()) //retrieve the Universal Theme Value
            {
                case "Blue": //if theme value is set to blue
                    Universal_Theme_Value = "0"; //set the universal theme value to this
                    break;
                case "Brown": //if theme value is set to brown
                    Universal_Theme_Value = "1"; //set the universal theme value to this
                    break;
                case "Cyan": //if theme value is set to cyan
                    Universal_Theme_Value = "2"; //set the universal theme value to this
                    break;
                case "Green": //if theme value is set to green
                    Universal_Theme_Value = "3"; //set the universal theme value to this
                    break;
                case "Grey": //if theme value is set to grey
                    Universal_Theme_Value = "4"; //set the universal theme value to this
                    break;
                case "Indigo": //if theme value is set to indigo
                    Universal_Theme_Value = "5"; //set the universal theme value to this
                    break;
                case "Jbm8": //if theme value is set to jbm8
                    Universal_Theme_Value = "6"; //set the universal theme value to this
                    break;
                case "Orange": //if theme value is set to orange
                    Universal_Theme_Value = "7"; //set the universal theme value to this
                    break;
                case "Pink": //if theme value is set to pink
                    Universal_Theme_Value = "8"; //set the universal theme value to this
                    break;
                case "Purple": //if theme value is set to purple
                    Universal_Theme_Value = "9"; //set the universal theme value to this
                    break;
                case "Red": //if theme value is set to red
                    Universal_Theme_Value = "10"; //set the universal theme value to this
                    break;
                case "Teal": //if theme value is set to teal
                    Universal_Theme_Value = "11"; //set the universal theme value to this
                    break;
                case "White": //if theme value is set to white
                    Universal_Theme_Value = "12"; //set the universal theme value to this
                    break;
            }

            Save_Changes(); //save these changes to the settings file
            UI_Theming(); //rethemes the UI          
        }

        private void Preferred_Agent_Selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Preferred_Agent_Selection.SelectedItem.ToString()) //retrieve the preferred agent value
            {
                case "*None*": //if the preferred agent is set to none
                    Preferred_Agent = "0"; //set the preferred agent to 0
                    break;
                case "Bruce": //if the preferred agent is set to bruce
                    Preferred_Agent = "1";  //set the preferred agent to 1
                    break;
                case "Hal": //if the preferred agent is set to hal
                    Preferred_Agent = "2";  //set the preferred agent to 2
                    break;
                case "Jason": //if the preferred agent is set to jason
                    Preferred_Agent = "3";  //set the preferred agent to 3
                    break;
                case "Suzi": //if the preferred agent is set to suzie
                    Preferred_Agent = "4";  //set the preferred agent to 4
                    break;
            }

            Save_Changes(); //save the changes
        }

        private void UoL_Logo_Link_Selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (UoL_Logo_Link_Selection.SelectedItem.ToString()) //retrieve the UoL logo link value
            {
                case "Blackboard": //if logo link value selection is set to blackboard
                    UoL_Logo_Link = "0"; //set the logo link value to this
                    break;
                case "Homepage": //if logo link value selection is set to homepage
                    UoL_Logo_Link = "1"; //set the logo link value to this
                    break;
                case "Library": //if logo link value selection is set to library
                    UoL_Logo_Link = "2"; //set the logo link value to this
                    break;
                case "Timetable": //if logo link value selection is set to timetable
                    UoL_Logo_Link = "3"; //set the logo link value to this
                    break;
            }

            Save_Changes(); //save the changes
        }

        private void Save_Changes()
        {
            string Local_Name = Environment.UserName; //retrieves the PC's name and saves it to a string
            System.IO.Directory.CreateDirectory(@"C:\\Users\\" + Local_Name + "\\Documents\\UoL Assistant\\"); //create the new directory
            File.Create(@"C:\\Users\\" + Local_Name + "\\Documents\\UoL Assistant\\Settings.txt").Close(); //creates the local data file

            using (FileStream FileStream = new FileStream(@"C:\\Users\\" + Local_Name + "\\Documents\\UoL Assistant\\Settings.txt", FileMode.Open)) //uses the fileStream to open the settings file
            {
                using (TextWriter TextWriter = new StreamWriter(FileStream)) //uses the textWriter to save the content from the first run screen to the settings file
                {
                    TextWriter.WriteLine(Student_ID); //saves the users ID as the first line
                    TextWriter.WriteLine(Student_Course); //saves the users course as the second line
                    TextWriter.WriteLine(Universal_Theme_Value); //writes the current theme to the file
                    TextWriter.WriteLine(Preferred_Agent); //writes a 0 to the next line, this will represent the users preferred contact agent, 0 is default and there is no preferred agent
                    TextWriter.WriteLine(UoL_Logo_Link); //writes a 0 to the next line, this will represent the users choice of website for the UoL logo, 0 is default and represents Blackboard
                    TextWriter.Close(); //close the textWriter
                    FileStream.Close(); //close the fileStream
                }
            }
        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            DialogResult Reset_Confirmation = MessageBox.Show("If you choose to reset, all your personal settings will be lost and the application will restart. Are you sure you want to reset?", "", MessageBoxButtons.YesNo); //creates a new dialog box asking the user if they are sure they want to reset the application

            if (Reset_Confirmation == DialogResult.Yes) //if the user confirms their reset
            {
                string Local_Name = Environment.UserName; //retrieves the PC's name and saves it to a string
                File.Create(@"C:\\Users\\" + Local_Name + "\\Documents\\UoL Assistant\\Settings.txt").Close(); //creates the local data file again, overwriting what was there previously
                Application.Restart(); //restart the application
            }
        }
    }
}
