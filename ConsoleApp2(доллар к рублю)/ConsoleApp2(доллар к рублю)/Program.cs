using System;
using System.Collections.Generic;

using System.Xml;

namespace ConsoleApp2_доллар_к_рублю_
{

    class Temping
    {
        public string Name { get; set; }
        public int Nominal { get; set; }
        public double Value { get; set; }
    }

    class Program
    {
     
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
               string nazvanie;
                try
                {
                    Console.WriteLine("введите название валюты");
                    nazvanie = Console.ReadLine();

                    List<Temping> temp = new List<Temping>();

                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load("http://www.cbr.ru/scripts/XML_daily.asp");

                    XmlElement xRoot = xDoc.DocumentElement;

                    foreach (XmlElement xnode in xRoot)
                    {
                        Temping temping = new Temping();

                        XmlNode attr = xnode.Attributes.GetNamedItem("Valute");

                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {

                            if (childnode.Name == "Name")

                                temping.Name = childnode.InnerText;


                            if (childnode.Name == "Nominal")

                                temping.Nominal = Int32.Parse(childnode.InnerText);


                            if (childnode.Name == "Value")

                                temping.Value = Double.Parse(childnode.InnerText);

                        }

                        temp.Add(temping);

                    }
                    foreach (Temping t in temp)

                        if (t.Name == nazvanie)
                            Console.WriteLine($" result :  {t.Nominal}рублей {t.Value} {t.Name}");
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка");
                    Console.ReadLine();
                    continue;

                }

                Console.ReadKey();

            }
        }
        
    }
}
