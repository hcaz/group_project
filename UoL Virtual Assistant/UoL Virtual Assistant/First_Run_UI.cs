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
    public partial class First_Run_UI : Form
    {

        int Window_Expansion_Status = 0; //this means the window is in its default size

        public First_Run_UI()
        {
            InitializeComponent(); //initializes
            this.Width = 275; this.Height = 155; //resizes the UI to be it's default starting value
            Reveal_Content(); //switches to the reveal content class

            ID_Input.KeyDown += new KeyEventHandler(ID_Input_KeyDown); //create a new event handler for ID submission
        }

        private async void Reveal_Content()
        {
            Hi_Label.ForeColor = Color.FromArgb(255, 255, 255); //set the Hi_Label to white
            Instruction_Text.ForeColor = Color.FromArgb(255, 255, 255); //set the Instruction_Text to white

            for (int Colour = 305; Colour >= 55; Colour--)
            {
                await Task.Delay(1); //delay
                Hi_Label.ForeColor = Color.FromArgb(Colour - 50, Colour - 50, Colour - 50); //reduce the colour value of the label by 50 on each loop
            }

            for (int Colour = 305; Colour >= 55; Colour--)
            {
                await Task.Delay(1); //delay
                Instruction_Text.ForeColor = Color.FromArgb(Colour - 50, Colour - 50, Colour - 50); //reduce the colour value of the instructions by 50 on each loop
            }

            for (int Height = 145; Height <= 230; Height++)
            {
                this.Height = Height;
                this.CenterToScreen();
                await Task.Delay(1); //delay
            }

            Window_Expansion_Status = 1; //window is in stage two one
        }

        private async void ID_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(Window_Expansion_Status == 1)
                {
                    for (int Height = 230; Height <= 330; Height++)
                    {
                        this.Height = Height;
                        this.CenterToScreen();
                        await Task.Delay(1); //delay
                    }

                    Window_Expansion_Status = 2; //window is now in stage two
                }

                else
                {
                    //do nothing
                }
            }
        }

        private void Course_Selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Course_Selection_Resize();
        }

        private async void Course_Selection_Resize()
        {
            if(Window_Expansion_Status == 2)
            {
                for (int Height = 330; Height <= 400; Height++)
                {
                    this.Height = Height;
                    this.CenterToScreen();
                    await Task.Delay(1); //delay
                }

                Window_Expansion_Status = 3; //window is now in stage three
            }

        }

        private void Continue_Button_Click(object sender, EventArgs e)
        {
            string Local_Name = Environment.UserName;
            MessageBox.Show(Local_Name);

            System.IO.Directory.CreateDirectory(@"C:\\Users\\" + Local_Name + "\\Documents\\UoL Assistant\\"); //create the new directory
            File.Create(@"C:\\Users\\" + Local_Name + "\\Documents\\UoL Assistant\\Settings.txt").Close(); //creates the local data file

            using (FileStream fs = new FileStream(@"C:\\Users\\" + Local_Name + "\\Documents\\UoL Assistant\\Settings.txt", FileMode.Open)) //uses the fileStream to open the file via the path string
            {
                using (TextWriter tw = new StreamWriter(fs)) //uses the textWriter to add "0" to the newly created theme file, indicating default green theme.
                {
                    tw.WriteLine(ID_Input.Text);
                    tw.WriteLine(Course_Selection.SelectedItem.ToString());
                    tw.Close(); //close the textWriter
                    fs.Close(); //close the fileStream
                }
            }





            //do some saving of the information provided
            this.Close();
        }
    }
}
