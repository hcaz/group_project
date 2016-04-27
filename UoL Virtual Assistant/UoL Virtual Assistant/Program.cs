﻿using System;
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

            ScrapeData data = new ScrapeData();
            data.weatherData();

            Application.Run(new Main_UI());
        }
    }
}
