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
            //PI.SplitInput("hello! Do you know where I can find Bruce Hargrave? He's my bae. I like to shoot hoops with my bois!?!????.....??!?!?!?!?....!?!.?!?!?");

            ScrapeData data = new ScrapeData();
            //data.freePCData();
            //MessageBox.Show("There are " + data.totalPcs + " pc's in total and " + data.freePcs + " of them are free.\n(Thats " + data.freePcsWin7 + " free win7 pc's and " + data.freePcsThin + " free thin clients.)");

            Application.Run(new Main_UI());
        }
    }
}
