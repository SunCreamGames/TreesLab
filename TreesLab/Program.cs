using System;
using System.IO;
using System.Collections;

namespace TreesLab
{
    class Program
    {
        
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("C:\\Users\\Богдан\\Desktop\\text.txt");
            string problem = Console.ReadLine();
            string s = "notNullString";
            Hashtable table = new Hashtable();
            Tree tree = new Tree(table);
            Tree.Node pointer = tree.Top;
            while (s != "")
            {
                s = Console.ReadLine();
                s = s.Replace("=", " ");
                s = s.Replace(";", " ");
                string[] parts = s.Split(new char [' '], StringSplitOptions.RemoveEmptyEntries);
                Tree.Node setter = pointer.AddNode(1, "=");
                setter.AddNode(0, parts[0]);
                setter.AddNode(0, parts[1]);
                pointer = pointer.AddNode(99, "");
            }

            reader.Close();
   
        }
    }
}
