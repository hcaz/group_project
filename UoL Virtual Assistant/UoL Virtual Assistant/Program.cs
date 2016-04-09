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
            //PI.SplitInput("Hey Amr! Do you know where I can find somewhere to eat? Also, how are you?. Also fuck you! Also, tell me about your day.?!????.....??!?!?!?!?....!?!.?!?!?");

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
