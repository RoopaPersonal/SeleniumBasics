using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Data;
using System.IO;
using ExcelDataReader;

namespace SeleniumBasics.TestDataAccess.Before
{
    class Common
    {
        //Creating the collection we will use to store data 
        private static List<DataCollection> dataCollection = new List<DataCollection>();

        //Populating stream data into the "dataCollection" collection 
        public static void PopulateInCollection(string Credentials)
        {
            DataTable table = ExcelToDataTable(Credentials);

            //Iterate through the columns and rows 
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    DataCollection dtTable = new DataCollection()
                    {
                        RowNumber = row,
                        ColumnName = table.Columns[col].ColumnName,
                        ColumnValue = table.Rows[row - 1][col].ToString()
                    };

                    //Add detaile per row 
                    dataCollection.Add(dtTable);
                }
            }
        }

        public static DataTable ExcelToDataTable(String Credentials)
        {
            //Open system file amd returns it as a stream 
            using (FileStream stream = File.Open(Credentials, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    //Get all the Tables 
                    DataTableCollection table = result.Tables;

                    //Store it in DataTable 
                    DataTable resultTable = table["Sheet1"];

                    return resultTable;
                }
            }
        }

        public static string ReadData(int rowNumber, string ColumnName)
        {
            try
            {
                //Retrieving Data using LINQ 
                string data = (from colData in dataCollection
                               where colData.ColumnName == ColumnName && colData.RowNumber == rowNumber
                               select colData.ColumnValue).SingleOrDefault();

                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public class DataCollection
        {
            public int RowNumber { get; internal set; }
            public string ColumnName { get; internal set; }
            public string ColumnValue { get; internal set; }
        }

    }

    
}
