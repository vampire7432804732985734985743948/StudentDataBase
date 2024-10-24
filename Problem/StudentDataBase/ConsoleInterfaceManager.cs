using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem.StudentDataBase
{
    internal static class ConsoleInterfaceManager
    {
        public static void DrawColoredText<T>(T article, ConsoleColor color)
        {
            if (article != null)
            {
                Console.WriteLine(article.ToString(), Console.ForegroundColor = color);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("Data were corrupted", ConsoleColor.Green);
            }
        }
    }
}
