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


            StringBuilder sb = new StringBuilder();

            sb.AppendLine("| Date | Measurement | Holiday |");
            sb.AppendLine("| ------------- |:---------------:| -----:|");

            foreach (var measurement in _measurements)
            {
                sb.AppendLine(measurement.GetMarkDownRow());
            }

            return sb.ToString();
        }

        private void InitHolidays(string holidayFileName)
        {
            _holidays = new Dictionary<DateTime, string>();

            string[] lines = File.ReadAllLines(Path.Combine(_inputFilePath, holidayFileName), Encoding.UTF8);

            foreach (string line in lines)
            {
                string[] data = line.Split(';');
                DateTime date;

                if (data != null &&
                    data.Length == 2 &&
                    DateTime.TryParse(data[1], out date))
                {
                    string holidayName = data[0];
                    _holidays.Add(date, holidayName);
                }
            }
        }


        private void InitMeasurements(string[] inputFileNames)
        {
            _measurements = new List<Day>();

            foreach (string inputFileName in inputFileNames)
            {
                Dictionary<DateTime, double> dailyMeasurements = new Dictionary<DateTime, double>();
                
                string[] lines = File.ReadAllLines(Path.Combine(_inputFilePath, inputFileName), Encoding.UTF8);
                foreach (string line in lines)
                {
                    string[] data = line.Split(';');
                    DateTime timestamp;
                    double measurement;

                    if (data != null &&
                        data.Length == 2 &&
                        DateTime.TryParse(data[0], out timestamp) &&
                        Double.TryParse(data[1], out measurement))
                    {
                        if (dailyMeasurements.ContainsKey(timestamp.Date))
                        {
                            dailyMeasurements[timestamp.Date] += measurement;
                        }
                        else
                        {
                            dailyMeasurements[timestamp.Date] = measurement;
                        }
                    }
                }

                foreach (KeyValuePair<DateTime, double> entry in dailyMeasurements)
                {
                    if (_holidays.ContainsKey(entry.Key))
                    {
                        _measurements.Add(
                            new Holiday(entry.Key,
                            entry.Value,
                            _holidays[entry.Key]));
                    }
                    else
                    {
                        _measurements.Add(
                            new Day(entry.Key,
                            entry.Value));
                    }
                }
            }

        }
    }
}
