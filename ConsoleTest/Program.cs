using HttpClientNet;
using System;
using System.Xml;
using UseNewtonSoft;
using XmlTreeViewer;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********** Printing Tree structure of XML document ************");
            Console.WriteLine("           (Created Software component)     \n\n");
            XmlDocument doc = new XmlDocument();
            doc.Load("C:/Users/Nadun/Downloads/books.xml"); // Replace with the actual path to your XML file          
            XmlStructure.Print(doc.DocumentElement);


            Console.WriteLine("\n\n\n*********** Converting Json string in to xml document ************");
            Console.WriteLine("           (Created Software component)     \n\n");
            var json = "{\"firstName\": \"John\",\"lastName\": \"Doe\",\"age\": 30,\"address\": {\"street\": \"123 Main St\",\"city\": \"Anytown\",\"state\": \"CA\",\"zip\": \"12345\"},\"phoneNumbers\": [{\"type\": \"home\",\"number\": \"555-555-1234\"},{\"type\": \"work\",\"number\": \"555-555-5678\"}]}";
            var xmlDocument = JsonToXmlConverter.Convert(json);
            XmlStructure.PrintXml(xmlDocument);



            //Use NewtonSoft.Json Software component 
            ReadJsonData.ReadUrlJsonData();
            
            //Use HttpClient Software component 
            HeadDetails.GetHeadRequest();
            Console.ReadLine();

        }
 
    }


}
