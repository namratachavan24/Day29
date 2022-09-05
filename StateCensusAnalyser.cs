using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyser
{
    public class StateCensusAnalyser
    {
        public void readCSV()
        {
            int count = 0;
            string path = @"C:\Users\HP\RFP.NET\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\Namrata.csv";
            string path2 = @"C:\Users\HP\RFP.NET\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\Namrata.csv";
            using (var reader2 = new StreamReader(path2))
            using (var csv2 = new CsvReader(reader2, System.Globalization.CultureInfo.InvariantCulture))
            {
                var record2 = csv2.GetRecords<CSVData2>().ToList();
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {

                    var record = csv.GetRecords<CSVData2>().ToList();
                    foreach (CSVData2 data2 in record2)
                    {
                        foreach (CSVData2 data in record)
                        {
                            if (data2.Population == data.Population)
                            {
                                Console.WriteLine(data.State);
                                Console.WriteLine(data.Population);
                                count++;
                            }
                        }
                    }
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Matched Data : " + (count - 2));


                }

            }
        }
    }
}
