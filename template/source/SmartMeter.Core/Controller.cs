using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utils;

namespace SmartMeter.Core
{
    public class Controller
    {
        private IDictionary<DateTime, string> _holidays;
        private List<Day> _measurements;
        private readonly string _inputFilePath;


        public Controller(string[] inputFileNames, string holidayFileName)
        {
            _inputFilePath = MyFile.GetFullFolderNameInApplicationTree("input");

            InitHolidays(holidayFileName);
            InitMeasurements(inputFileNames);
        }

        public int CountOfMeasurements => _measurements.Count;

        public string CreateMarkdownDump()
        {

            // SAMPLE:
            //
            //| Tables        | Are             | Cool  |
            //| ------------- |:---------------:| -----:|
            //| col 3 is      | right - aligned | $1600 |
            //| col 2 is      | centered        |   $12 |
            //| zebra stripes | are neat        |    $1 |

            throw new NotImplementedException();
        }

        private void InitHolidays(string holidayFileName)
        {
            _holidays = new Dictionary<DateTime, string>();

            throw new NotImplementedException();
        }


        private void InitMeasurements(string[] inputFileNames)
        {
            _measurements = new List<Day>();

            throw new NotImplementedException();
        }

    }
}
