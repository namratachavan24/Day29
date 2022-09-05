using System;

namespace IndianStatesCensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            StateCensusAnalyser obj = new StateCensusAnalyser();
            obj.readCSV();
        }
    }
}