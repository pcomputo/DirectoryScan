using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace searchingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            string[] file = Directory.GetFiles(@"directory_to_be_checked", "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".xml", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".config", StringComparison.OrdinalIgnoreCase)).ToArray();
            Console.WriteLine("Files");
            foreach (string name in file) {
                Console.WriteLine(name);

            }
            foreach(string name in file){
                 Console.WriteLine("Now scanning" +name);

                 StreamReader s = new StreamReader(name);
                 
                 string currentLine ="";
                 string search = "String_want_to_search";   
                 bool found = false;
                do{
                   currentLine=s.ReadLine();
                    if(currentLine !=null){
                       found=currentLine.Contains(search);
                    }
                 
                }while(currentLine!=null & !found);

                if (found) {
                    Console.WriteLine("Found in file" +name);
                    i++;
                    using(StreamWriter writer= new StreamWriter(@"C:\file.txt",true)){
                        writer.WriteLine(name);
                    }
                    
                }
            } Console.WriteLine("Total number of files with that string are" + i);
            Console.ReadKey();
        }
    }
}
