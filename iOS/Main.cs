using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;
using System.Xml;
using Foundation;
using System.IO;
using UIKit;

namespace YouRun.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            string XMLFILE = "/Users/russgomez/Desktop/YouRunXML.txt";

			// Clear all the text in the text file 
			File.WriteAllText(XMLFILE, "");

			System.IO.StreamWriter file = new System.IO.StreamWriter(XMLFILE);

			XmlReader Reader = XmlReader.Create("/Users/russgomez/Desktop/map (1).osm");

			while (!Reader.EOF)
			{
				// Reads the next node in the file
				Reader.Read();

                // Write the name of the node to the text file
                file.WriteLine("Node: = " + Reader.Name);

                // Read all the attributes of the node in the xml file, and
                // write them to the text file
				while (Reader.MoveToNextAttribute())
				{
                    file.WriteLine(" {0} = {1}", Reader.Name, Reader.Value);
				}

				// Move the reader back to the element node.
				Reader.MoveToElement();
			}

            /* This Part Runs the Main Program (I believe) */

            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");

   
		}
   


    }
}
