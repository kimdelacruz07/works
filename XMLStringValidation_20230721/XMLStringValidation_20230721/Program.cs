using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLStringValidation_20230721
{
    class Program
    {
        static void Main(string[] args)
        {
            string sXML = "";
            Console.WriteLine("XML string Validation in C#\r");
            Console.WriteLine("\nSample Cases:\n");
            string sXML1 = "<Design><Code>hello world</Code></Design>";
            string sXML2 = "<Design><Code>hello world</Code></Design><People>";
            string sXML3 = "<People><Design><Code>hello world</People></Code></Design>";
            string sXML4 = "<People age=”1”>hello world</People>";
            string sXML5 = "<Design><Code>hello > world </Code></Design>";
            string sXML6 = "<Design><Code>hello < world </Code></Design>";
            string sXML7 = "<People age=”1”>hello world</People age=”1”>";
            string sXML8 = "<People age=”1”>hello world</People age=”1”>";


            Console.WriteLine(String.Format("XML String 1 [{0}]: {1}", sXML1, DetermineXml(sXML1)));
            Console.WriteLine(String.Format("XML String 2 [{0}]: {1}", sXML2, DetermineXml(sXML2)));
            Console.WriteLine(String.Format("XML String 3 [{0}]: {1}", sXML3, DetermineXml(sXML3)));
            Console.WriteLine(String.Format("XML String 4 [{0}]: {1}", sXML4, DetermineXml(sXML4)));
            Console.WriteLine(String.Format("XML String 5 [{0}]: {1}", sXML5, DetermineXml(sXML5)));
            Console.WriteLine(String.Format("XML String 6 [{0}]: {1}", sXML6, DetermineXml(sXML6)));
            Console.WriteLine(String.Format("XML String 7 [{0}]: {1}", sXML7, DetermineXml(sXML7)));

            Console.WriteLine("------------------------\n");

            Console.WriteLine("Enter the XML string, and then press Enter...");
            sXML = Console.ReadLine();

            bool result = DetermineXml(sXML);

            Console.WriteLine("\nResult: " + result);

            Console.Write("\n\nPress any key to close the console app...\n");
            Console.ReadKey();
        }

        public static bool DetermineXml(string xml)
        {
            List<string> listOpeningTag = new List<string>();

            for (int i = 0; i < xml.Length; i++)
            {
                if (xml[i] == '<')
                {
                    int iClosingBracketIndex = xml.IndexOf('>', i + 1);

                    if (iClosingBracketIndex == -1)
                        return false;

                    string sTag = xml.Substring(i + 1, iClosingBracketIndex - i - 1).Trim();
                    i = iClosingBracketIndex;

                    if (sTag.Length == 0)
                        return false;

                    if (sTag[0] == '/')
                    {
                        if (listOpeningTag.Count == 0)
                            return false;

                        string sOpeningTag = listOpeningTag[listOpeningTag.Count - 1];
                        if (!sOpeningTag.Equals(sTag.Substring(1)))
                            return false;
                        else
                            listOpeningTag.RemoveAt(listOpeningTag.Count - 1);
                    }
                    else
                    {
                        listOpeningTag.Add(sTag);
                    }
                }
            }

            return listOpeningTag.Count == 0;
        }
    }
}
