using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    abstract class Messeges
    {
        public static string HELP_MESSAGE = "Hi, this is an application made by Sahakyan Hovhannes" +
                             "with Visual Studio 2015. All Rights Reserved!" +
                             "\n" +
                             "This calculator was made to help you to count big values" +
                             "and with many operations. You are free to print \"+\"" +
                             ", \"-\", \"*\", \"/\", \"(\", \")\".\n" + "\n" +
                             "If any problem accures you are free to messege me on" +
                             "syanhovhannes@gmail.com" + "\n" +
                             "Example: (5 + 6.26) / (2 * 9) + (0 - 2)" + 
                             "Note: minus numbers are written like (0 - 5).";
        public static string ABOUT_MESSAGE = "This application is made by Sahakyan Hovhannes" +
                                             "on 26th of July 2017." +
                                             "\nAll Rights Reserved!" +
                                             "\nThe programm was made on C#/.Net on Visual Studio 2015" +
                                             "\nGreat thank to my parents and teachers.";
    }
}
