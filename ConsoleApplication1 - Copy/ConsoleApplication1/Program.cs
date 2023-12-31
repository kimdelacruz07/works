﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleKeyInfo cki;
            string sXML = "";
            Console.WriteLine("XML string Validation in C#\r");
            Console.WriteLine("------------------------\n");

            Console.WriteLine("Enter the XML string, and then press Enter...");
            sXML = Console.ReadLine();

            bool result = DetermineXml1(sXML);

            Console.WriteLine("\nResult: " + result);

            Console.Write("\n\nPress any key to close the console app...\n");
            Console.ReadKey();

            
        }


        public static bool DetermineXml(string xml)
        {
            bool isValidXML = false;
            bool isContinue = false;
            bool isClosingTag = false;
            List<string> listOpeningTag = new List<string>();
            string sTag = "";
            try
            {
                if (String.IsNullOrEmpty(xml))
                {
                    return isValidXML;
                }

                for (int i = 0; i < xml.Length; i++)
                {
                    if (xml[i] == '<')
                    {
                        isContinue = true;
                        int iXMLIndex = i + 1;

                        if (xml[iXMLIndex] == '/')
                        {
                            isClosingTag = true;
                            iXMLIndex++;
                        }

                        do
                        {
                            switch (xml[iXMLIndex])
                            {
                                case '>':
                                    if (isClosingTag)
                                    {
                                        isClosingTag = false;
                                        if (listOpeningTag[listOpeningTag.Count - 1] == sTag)
                                        {
                                            listOpeningTag.RemoveAt(listOpeningTag.Count - 1);
                                        }
                                        else
                                        {
                                            isContinue = false; //stop do while
                                            i = xml.Length; //stop for loop
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        listOpeningTag.Add(sTag);
                                    }
                                    sTag = "";
                                    i = iXMLIndex;
                                    isContinue = false;
                                    break;

                                default:
                                    sTag += xml[iXMLIndex];
                                    break;
                            }

                            iXMLIndex++;
                        } while (isContinue && iXMLIndex < xml.Length);
                    }
                }

                if (listOpeningTag.Count == 0)
                {
                    isValidXML = true;
                }

                return isValidXML;
            }
            catch (Exception ex)
            {
                Console.Write("\n\nERROR: "+ ex.Message + "\n");
                return false;
            }
        }


        public static bool DetermineXml1(string xml)
        {
            Stack<string> tagStack = new Stack<string>();
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
                    }
                    else
                    {
                        tagStack.Push(sTag);
                        listOpeningTag.Add(sTag);
                    }
                }
            }

            return listOpeningTag.Count == 0;
        }
    }
}
