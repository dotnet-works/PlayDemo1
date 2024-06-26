using Microsoft.Playwright;
using PlayDemo1.Drivers.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PlayDemo1.Steps
{
    [Binding]
    public sealed class TableSteps1
    {
        public TableSteps1()
        {
            
        }

        [When(@"some data table1")]
        public void stepTable1(Table tbl)
        {
            var header = tbl.Header.Count;
            var rows =tbl.Rows.Count;            
            Console.WriteLine($"Header Count: {header}");
            Console.WriteLine($"Row Count: {rows}");
        }

        [When(@"creating instance of this table1")]
        public void stepTableInstance(Table tbl)
        {
            TableDataInstance tableDat = tbl.CreateInstance<TableDataInstance>();

            Console.WriteLine($"First: {tableDat.FirstName} Last: {tableDat.LastName} Age: {tableDat.Age}");
        }

        [When(@"creating instance of this table2")]
        public void stepTableInstance2(Table tbl)
        {
            var tableDat = tbl.CreateSet<TableDataInstance>();
            foreach(var row in tableDat)
            {
                
                Console.WriteLine($"First: {row.FirstName} Last: {row.LastName} Age: {row.Age}");
            }
            
        }

        [When("create a dictionary of table data1")]
        public void createDict1(Table dictTable)
        {
             Dictionary<string, string> _dataDictionary = new Dictionary<string, string>();

            foreach (var row in dictTable.Rows)
            {
                var key = row["Key"];
                var value = row["Value"];
                _dataDictionary.Add(key, value);
            }
            Console.WriteLine(_dataDictionary["FirstName"]);
            Console.WriteLine(_dataDictionary["LastName"]);
            Console.WriteLine(_dataDictionary["Age"]);

        }





    }
}