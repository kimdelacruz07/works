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

                        string openingTag = listOpeningTag[listOpeningTag.Count - 1];
                        if (!openingTag.Equals(sTag.Substring(1)))
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
