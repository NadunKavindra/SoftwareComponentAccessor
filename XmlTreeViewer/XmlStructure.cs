using System;
using System.Xml;

namespace XmlTreeViewer
{
    public class XmlStructure
    {
        //Method 01
        public static void PrintNode(XmlNode node, string indent)
        {
            Console.Write(indent);
            Console.Write(node.Name);

            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    Console.Write(" {0}=\"{1}\"", attr.Name, attr.Value);
                }
            }

            Console.WriteLine();

            if (node.HasChildNodes)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    PrintNode(child, indent + "  ");
                }
            }
        }


        //Method 02
        public static void DisplayNode(XmlNode node, int indent)
        {
            Console.Write(new string(' ', indent));
            Console.Write(node.Name);

            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                Console.Write(" [");
                foreach (XmlAttribute attr in node.Attributes)
                {
                    Console.Write($"{attr.Name}={attr.Value}");
                }
                Console.Write("]");
            }

            if (node.HasChildNodes)
            {
                Console.WriteLine();
                foreach (XmlNode child in node.ChildNodes)
                {
                    DisplayNode(child, indent + 2);
                }
            }
            else
            {
                Console.Write(": ");
                Console.Write(node.InnerText);
                Console.WriteLine();
            }
        }


        public static void Print(XmlNode xmlNode, string prefix = "", bool isLast = true)
        {
            Console.Write(prefix);

            if (isLast)
            {
                Console.Write("└─");
                prefix += "  ";
            }
            else
            {
                Console.Write("├─");
                prefix += "│ ";
            }

            Console.WriteLine(xmlNode.Name);

            XmlNodeList children = xmlNode.ChildNodes;
            for (int i = 0; i < children.Count; i++)
            {
                Print(children[i], prefix, i == children.Count - 1);
            }
        }

        //Print xml in prettier way
        public static void PrintXml(XmlDocument xmlDoc)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\n";
            settings.NewLineHandling = NewLineHandling.Replace;

            using (XmlWriter writer = XmlWriter.Create(Console.Out, settings))
            {
                xmlDoc.WriteTo(writer);
            }
        }
    }
}
