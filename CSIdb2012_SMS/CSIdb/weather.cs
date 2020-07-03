using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
namespace CSIdb
{
    class weather
    {
 public weather()
        {
           
        }
        private string city;
        private int temp;
        public string xmlContent;

        public int CheckWeather(string setCity, out string details)
        {
            WeatherAPI DataAPI = new WeatherAPI(setCity);
            temp = DataAPI.GetTemp(out details);
            xmlContent = DataAPI.xmlContent;
            return temp;
        }

        public string City { get; set; } // { get => temp; set => city = value; } // get => city; set => city = value; };
        public float Temp { get; set; }//{ get => temp; set => temp = value; }
        public float TempMax { get; set; }// { get => tempMax; set => tempMax = value; }
        public float TempMin { get; set; }// { get => tempMin; set => tempMin = value; }
    }
    class WeatherAPI
    {
        public string xmlContent;
        public WeatherAPI(string city)
        {
            SetCurrentURL(city);
           
            xmlDocument = GetXML(CurrentURL);
        }

        public int GetTemp(out string details)
        {
            int tempF, tempFeelsLikeF;
            details = "";

          //  XmlNodeList x = xmlDocument.SelectNodes("//temperature");
            XmlNode temp_node = xmlDocument.SelectSingleNode("//temperature");
            XmlAttribute temp_value = temp_node.Attributes["value"];
            string temp_string = temp_value.Value;

         //   tempF = float.Parse(temp_string);
            tempF = (int)((1.8f * float.Parse(temp_string) + 32.0f) + 0.5); // F

            temp_node = xmlDocument.SelectSingleNode("//feels_like");
            XmlAttribute desc = temp_node.Attributes["value"];
            temp_string = temp_value.Value;

            tempFeelsLikeF = (int)((1.8f * float.Parse(temp_string) + 32.0f) + 0.5); // F
            details = "Feels Like:" + tempFeelsLikeF.ToString() + "\u00B0F";

            temp_node = xmlDocument.SelectSingleNode("//humidity");
             desc = temp_node.Attributes["value"];
            details +=  "   Humidity: " + desc.Value + "%";

            temp_node = xmlDocument.SelectSingleNode("//weather");
            desc = temp_node.Attributes["value"];
            details += "   Weather: " + desc.Value;
    

            return tempF;
        }

        private const string APIKEY = "527d00d17ada54f64944d1c747604e6c"; // "79a1cb34e7b50fcdc445ec7e6692bad7";
        private string CurrentURL;
        private XmlDocument xmlDocument;

        private void SetCurrentURL(string location)
        {
            CurrentURL = "http://api.openweathermap.org/data/2.5/weather?q=" 
                + location + "&mode=xml&units=metric&APPID=" + APIKEY;
        }

        private XmlDocument GetXML(string CurrentURL)
        {
            using (WebClient client = new WebClient())
            {
                 xmlContent = client.DownloadString(CurrentURL);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlContent);
                return xmlDocument;
            }
        }
    }
}

