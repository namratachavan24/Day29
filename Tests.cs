using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.Constructor_for_different_CSV;

namespace IndianStatesCensusAnalyserTest
{
    [TestClass]
    public class Tests
           
        static string indiaStateCensusData = @"C:\Users\HP\RFP.NET\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensusData.csv";
        static string wrongIndiaStateCensusData = @"C:\Users\HP\RFP.NET\IndianStatesCensusAnalyser\IndianStatesCensusAnalyserWrongIndiaStateCensusData.csv";
        static string indiaStateCensusDataText = @"C:\Users\HP\RFP.NET\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensusDAta.txt";
        static string delimiterIndiaStateCensusData = @"C:\Users\HP\RFP.NET\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\DelimiterIndiaStateCensusData.csv";

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
      
        [TestInitialize]
        public void TestInitialize()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }     
        // Test Case 1.1      
        [TestMethod]
        public void GivenIndianCensusDataFile_WhenReturnShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indiaStateCensusData, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
       // test case 1.2
    
        [TestMethod]
        public void GivenWrongIndianCensusDataFile_WhenReadedShouldReturnCustomException()
        {            
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaStateCensusData, indianStateCensusHeaders));           
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.etype);
        }    
        // test case 1.3
       
        [TestMethod]
        public void GivenWrongIndianCensusDataType_WhenReadedShouldReturnCustomException()
        {       
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indiaStateCensusDataText, indianStateCensusHeaders));           
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, customException.etype);
        }
        // test case 1.4
        
        [TestMethod]
        public void GivenIncorrectDelimiterForCensusData_WhenReadedShouldReturnCustomException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndiaStateCensusData, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.etype);
        }
        // test case 1.5
       
        [TestMethod]
        public void GivenIncorrectHeaderForCensusData_WhenReadedShouldReturnCustomException()
        {
        var customException = Assert.ThrowsException<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndiaStateCensusData, indianStateCensusHeaders));
        Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.etype);
        }
    }
}
