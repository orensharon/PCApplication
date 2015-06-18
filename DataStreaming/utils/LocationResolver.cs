using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.Threading.Tasks;

namespace DataStreaming.utils
{
    public class LocationResolver
    {

        private const string API_KEY = "AIzaSyAVqThMg4ADW84pGKx2m4kyxZc9fYVZ6iY";

        public static void ReverseGeoLoc(double? longitude, double? latitude, out string location)
        {

            string Address_formatted = "";
            string Address_country = "";
            string Address_street = "";
            string Address_city = "";


            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load("http://maps.googleapis.com/maps/api/geocode/xml?latlng=" + latitude + "," + longitude + "&key=" + API_KEY);
                XmlNode element = doc.SelectSingleNode("//GeocodeResponse/status");

                if (!element.InnerText.Equals("ZERO_RESULTS"))
                {
                    element = doc.SelectSingleNode("//GeocodeResponse/result/formatted_address");

                    Address_formatted = element.InnerText;
                    string longname = "";
                    string shortname = "";
                    string typename = "";

                    XmlNodeList xnList = doc.SelectNodes("//GeocodeResponse/result/address_component");
                    foreach (XmlNode xn in xnList)
                    {
                        try
                        {
                            longname = xn["long_name"].InnerText;
                            shortname = xn["short_name"].InnerText;
                            typename = xn["type"].InnerText;

                            switch (typename)
                            {
                                //Add whatever you are looking for below
                                case "country":
                                    {
                                        Address_country = longname;
                                        break;
                                    }

                                case "route":
                                    {
                                        Address_street = longname;
                                        break;
                                    }

                                case "locality":
                                    {
                                        Address_city = longname;
                                        break;
                                    }

                                default:
                                    break;
                            }
                        }

                        catch (Exception e)
                        {}


                    }
                }

            }
            catch (Exception ex)
            { }

            location = ((!Address_street.Equals("")) ? Address_street + ", " : "") +
                  ((!Address_city.Equals("")) ? Address_city + ", " : "") + ((!Address_country.Equals("")) ? Address_country : "");
        }

    }


}
