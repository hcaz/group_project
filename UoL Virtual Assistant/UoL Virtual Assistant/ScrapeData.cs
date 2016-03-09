using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;

namespace UoL_Virtual_Assistant
{
    class ScrapeData
    {

        public string freePCData()
        {
            string win7DataUrl = "http://hls.me/win7clients.php";
            string thinDataUrl = "http://hls.me/thinclients.php";

            XmlDocument doc = new XmlDocument();
            doc.Load(win7DataUrl);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/workstations/win7Clients/win7Client");
            List<Computer> pcs = new List<Computer>();
            foreach (XmlNode node in nodes)
            {
                Computer pc = new Computer();
                pc.type = "Win7";
                pc.name = node.SelectSingleNode("machineName").InnerText;
                pc.status = node.SelectSingleNode("status").InnerText;
                pc.useage = node.SelectSingleNode("useage").InnerText;
                pc.building = node.SelectSingleNode("location").SelectSingleNode("building").InnerText;
                pc.floor = node.SelectSingleNode("location").SelectSingleNode("floor").InnerText;
                pc.room = node.SelectSingleNode("location").SelectSingleNode("room").InnerText;
                pc.block = node.SelectSingleNode("location").SelectSingleNode("block").InnerText;
                pcs.Add(pc);
            }

            XmlDocument doc2 = new XmlDocument();
            doc.Load(thinDataUrl);
            XmlNodeList nodes2 = doc.DocumentElement.SelectNodes("/workstations/thinClients/thinClient");
            foreach (XmlNode node in nodes2)
            {
                Computer pc = new Computer();
                pc.type = "Thin";
                pc.name = node.SelectSingleNode("machineName").InnerText;
                pc.status = node.SelectSingleNode("status").InnerText;
                pc.useage = node.SelectSingleNode("useage").InnerText;
                pc.building = node.SelectSingleNode("location").SelectSingleNode("building").InnerText;
                pc.floor = node.SelectSingleNode("location").SelectSingleNode("floor").InnerText;
                pc.room = node.SelectSingleNode("location").SelectSingleNode("room").InnerText;
                pc.block = node.SelectSingleNode("location").SelectSingleNode("block").InnerText;
                pcs.Add(pc);
            }

            return "Total PC's: " + pcs.Count;
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
}
