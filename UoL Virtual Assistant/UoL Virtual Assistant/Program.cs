using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UoL_Virtual_Assistant
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application!
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //ParseInput testing, comment out when not testing
            //ParseInput PI = new ParseInput();
            //PI.SplitInput("hello Amr! Do you know where I can find Bruce? He's my bae. I like to shoot hoops with my bois!?!????.....??!?!?!?!?....!?!.?!?!?");

            //ScrapeData data = new ScrapeData();
            //data.libraryOpening();
            //if(data.libraryDeskOpenNow == true)
            //{
            //    MessageBox.Show(data.libraryDeskOpen);
            //}

            Application.Run(new Main_UI());
        }
    }
}
