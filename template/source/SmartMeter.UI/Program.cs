using SmartMeter.Core;
using System;
using System.IO;
using System.Text;
using Utils;

namespace SmartMeter.UI
{
    class Program
    {
        private static readonly string[] inputFiles = new string[] {
                "2019_01.csv",
                "2019_02.csv",
                "2019_03.csv",
                "2019_04.csv",
                "2019_05.csv",
                "2019_06.csv",
                "2019_07.csv",
                "2019_08.csv",
                "2019_09.csv",
            };

        static void Main()
        {
            Console.WriteLine("SmartMeter - Analyser");

            Controller ctrl = new Controller(inputFiles, "holidays.csv");
            Console.WriteLine();
            Console.WriteLine($"Imported measurements for {ctrl.CountOfMeasurements} days");
            Console.WriteLine();

            string markdown = ctrl.CreateMarkdownDump();
            Console.WriteLine("Markdown:");
            Console.WriteLine("=========");
            Console.WriteLine();
            Console.WriteLine(markdown);


            File.WriteAllText(
                Path.Combine(
                    MyFile.GetFullFolderNameInApplicationTree("output"),
                    $"measurements_{DateTime.Now.ToString("yyyyddMM_HHmmss")}.md"),
                markdown,
                Encoding.UTF8);
        }
    }
}
