using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace UoL_Virtual_Assistant
{
    class ScrapeData
    {
        public List<Computer> pcs = new List<Computer>();
        public int totalPcs = 0;
        public int freePcs = 0;
        public int freePcsWin7 = 0;
        public int freePcsThin = 0;
        public bool libraryOpenNow = false;
        public bool libraryDeskOpenNow = false;
        public string libraryOpen = "";
        public string libraryDeskOpen = "";
        public List<Day> days = new List<Day>();

        public bool freePCData()
        {
            string win7DataUrl = "http://hls.me/win7clients.php";
            string thinDataUrl = "http://hls.me/thinclients.php";

            XmlDocument doc = new XmlDocument();
            doc.Load(win7DataUrl);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/workstations/win7Clients/win7Client");

            foreach (XmlNode node in nodes)
            {
                Computer pc = new Computer();
                pc.type = "Win7";
                pc.name = "lol";
                pc.status = node.SelectSingleNode("status").InnerText;
                pc.useage = node.SelectSingleNode("useage").InnerText;
                pc.building = node.SelectSingleNode("location").SelectSingleNode("building").InnerText;
                pc.floor = node.SelectSingleNode("location").SelectSingleNode("floor").InnerText;
                pc.room = node.SelectSingleNode("location").SelectSingleNode("room").InnerText;
                pc.block = node.SelectSingleNode("location").SelectSingleNode("block").InnerText;
                pcs.Add(pc);
                if (pc.status == "FREE" || pc.status == "OFF")
                {
                    this.freePcs++;
                    this.freePcsWin7++;
                }
            }

            XmlDocument doc2 = new XmlDocument();
            doc.Load(thinDataUrl);
            XmlNodeList nodes2 = doc.DocumentElement.SelectNodes("/workstations/thinClients/thinClient");
            foreach (XmlNode node in nodes2)
            {
                Computer pc = new Computer();
                pc.type = "Thin";
                pc.name = "lol";
                pc.status = node.SelectSingleNode("status").InnerText;
                pc.useage = node.SelectSingleNode("useage").InnerText;
                pc.building = node.SelectSingleNode("location").SelectSingleNode("building").InnerText;
                pc.floor = node.SelectSingleNode("location").SelectSingleNode("floor").InnerText;
                pc.room = node.SelectSingleNode("location").SelectSingleNode("room").InnerText;
                pc.block = node.SelectSingleNode("location").SelectSingleNode("block").InnerText;
                pcs.Add(pc);
                if (pc.status == "FREE" || pc.status == "OFF")
                {
                    this.freePcs++;
                    this.freePcsThin++;
                }
            }

            this.totalPcs = pcs.Count;
            return true;
        }

        public bool libraryOpening()
        {
            string url = "https://api3.libcal.com/api_hours_today.php?iid=1718&lid=604&format=xml&context=object";

            XmlDocument doc = new XmlDocument();
            doc.Load(url);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/libcal/locations/location");

            foreach (XmlNode node in nodes)
            {
                if (node.SelectSingleNode("lid").InnerText == "604")
                {
                    this.libraryOpenNow = Boolean.Parse(node.SelectSingleNode("times").SelectSingleNode("currently_open").InnerText);
                    this.libraryOpen = Regex.Replace(node.SelectSingleNode("rendered").InnerText, @"<[^>]+>|&nbsp", "").Replace("&ndash;", "-").Trim();
                }
                else
                {
                    this.libraryDeskOpenNow = Boolean.Parse(node.SelectSingleNode("times").SelectSingleNode("currently_open").InnerText);
                    this.libraryDeskOpen = Regex.Replace(node.SelectSingleNode("rendered").InnerText, @"<[^>]+>|&nbsp;", "").Replace("&ndash;", "-").Trim();
                }
            }

            return true;
        }

        public bool weatherData()
        {
            string weatherAPI = "http://datapoint.metoffice.gov.uk/public/data/val/wxfcs/all/xml/3469?res=daily&key=8ec9c40f-71f5-4bb5-ba02-60e0c1d3d777";
            XmlDocument doc = new XmlDocument();
            doc.Load(weatherAPI);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/SiteRep/DV/Location/Period");

            foreach (XmlNode node in nodes)
            {
                Day day = new Day();
                XmlNode daytime = node.SelectNodes("Rep")[0];
                XmlNode nighttime = node.SelectNodes("Rep")[1];
                day.FDm = daytime.Attributes["Dm"].Value;
                day.FNm = nighttime.Attributes["Nm"].Value;
                day.Dm = daytime.Attributes["Dm"].Value;
                day.Nm = nighttime.Attributes["Nm"].Value;
                day.V = daytime.Attributes["V"].Value;
                day.D = nighttime.Attributes["D"].Value;
                day.S = daytime.Attributes["S"].Value;
                days.Add(day);
            }

            return true;
        }
    }

    class Computer
    {
        public string type;
        public string name;
        public string status;
        public string useage;
        public string building;
        public string floor;
        public string room;
        public string block;
    }

    class Day
    {
        public string FDm;//" units="C">Feels Like Day Maximum Temperature</Param>
        public string FNm;//" units="C">Feels Like Night Minimum Temperature</Param>
        public string Dm;//" units="C">Day Maximum Temperature</Param>
        public string Nm;//" units="C">Night Minimum Temperature</Param>
        public string V;//" units= "" > Visibility </ Param >
        public string D;//" units= "compass" > Wind Direction</Param>
        public string S;//" units= "mph" > Wind Speed</Param>
    }
}
