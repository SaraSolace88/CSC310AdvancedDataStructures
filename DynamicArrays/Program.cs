using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DynamicArrays
{
    internal class Program
    {
        static string dataFile = Path.Combine("ExtraCreditDataSet.csv");

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            List<Contact> usContacts = new List<Contact>();

            using (StreamReader sReader = File.OpenText(dataFile))
            {
                string currString;
                while ((currString = sReader.ReadLine()) != null)
                {
                    Contact newContact = new Contact(currString.Split(','));
                    usContacts.Add(newContact);
                }
            }

            usContacts.Sort();

            for (int printCounter = 1; printCounter * 1000 - 1 < usContacts.Count; printCounter++)
            {
                usContacts[printCounter * 1000 - 1].Print();
            }

            sw.Stop();

            Console.WriteLine($"Elapsed time: {sw.Elapsed}");
        }
    }
}