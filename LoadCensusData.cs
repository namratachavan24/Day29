using CensusAnalyzer_Day29;

using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CensusAnalyzer_Day29.POCO;
using System.Globalization;
using CensusAnalyzer_Day29.CustomException;


namespace  IndianStatesCensusAnalyser
{
    public class LoadCensusData
    {
        List<IndianStateCensusData> indianStateCensusDatas;
        public int LoadCensusDataIntoList(string filepath)
        {
            try
            {
                using (StreamReader reader = File.OpenText(filepath))

                using (CsvReader csvreader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    indianStateCensusDatas = csvreader.GetRecords<IndianStateCensusData>().ToList();
                }
                return indianStateCensusDatas.Count;



            }
            catch (Exception ex)
            {
                throw new CecsusAnalyzerException("WrongHeader", "WrongFileType");
            }

            return indianStateCensusDatas.Count;
        }

    }
}
