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
    public partial class Timetable_UI : Form
    {
        public Timetable_UI()
        {
            InitializeComponent();            
        }

        public void Timetable_URL(string Student_ID)
        {
            string Timetable_URL = ("http://timetables.lincoln.ac.uk/mytimetable/" + Student_ID + ".htm");
            Timetable_Web.Navigate(new Uri(Timetable_URL));

            Timetable_Web.Height = 1000;
        }
    }
}
