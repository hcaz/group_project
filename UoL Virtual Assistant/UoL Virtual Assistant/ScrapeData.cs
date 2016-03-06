using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml;
using System.IO;

namespace UoL_Virtual_Assistant
{
    class ScrapeData
    {

        public string freePCData()
        {
            string win7 = "http://findapc.web01.lincoln.ac.uk/datafiles/win7clients.aspx";
            string thin = "http://findapc.web01.lincoln.ac.uk/datafiles/thinclients.aspx";
            using (var client = new HttpClient())
            {
                string responseString = client.GetStringAsync(win7).ToString();

                StringBuilder output = new StringBuilder();

                using (XmlReader reader = XmlReader.Create(new StringReader(responseString)))
                {
                    reader.ReadToFollowing("book");
                    reader.MoveToFirstAttribute();
                    string genre = reader.Value;
                    output.AppendLine("The genre value: " + genre);

                    reader.ReadToFollowing("title");
                    output.AppendLine("Content of the title element: " + reader.ReadElementContentAsString());
                }

                return output.ToString();
            }
        }

    }
}
