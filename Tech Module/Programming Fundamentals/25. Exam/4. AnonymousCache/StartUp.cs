namespace AnonymousCache
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class AnonymousCache
    {
        public static void Main()
        {
            Dictionary<string, List<DataSet>> cacheDict = new Dictionary<string, List<DataSet>>();

            Dictionary<string, List<DataSet>> dataDict = new Dictionary<string, List<DataSet>>();

            string input = Console.ReadLine();

            while (input != "thetinggoesskrra")
            {
                string[] currentInputData = input.Split(new[] { ' ', '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries);

                if (currentInputData.Length == 1)
                {

                    if (!cacheDict.ContainsKey(currentInputData[0]) && !dataDict.ContainsKey(currentInputData[0]))
                    {
                        dataDict[currentInputData[0]] = new List<DataSet>();
                    }
                    else if (cacheDict.ContainsKey(currentInputData[0]) && !dataDict.ContainsKey(currentInputData[0]))
                    {
                        dataDict[currentInputData[0]] = new List<DataSet>();

                        List<DataSet> keysAndSizesToAdd = cacheDict[currentInputData[0]];

                        foreach (DataSet keyAndSize in keysAndSizesToAdd)
                        {
                            dataDict[currentInputData[0]].Add(keyAndSize);
                        }
                    }
                                      
                    input = Console.ReadLine();
                    continue;
                }

                string currentDataSetName = currentInputData[2];
                string currentDataKey = currentInputData[0];
                long currentDataSize = long.Parse(currentInputData[1]);

                if (dataDict.ContainsKey(currentDataSetName))
                {
                    DataSet currentDataSet = new DataSet()
                    {
                        Key = currentDataKey,
                        Size = currentDataSize
                    };

                    dataDict[currentDataSetName].Add(currentDataSet);
                }
                else
                {
                    if (!cacheDict.ContainsKey(currentDataSetName))
                    {
                        cacheDict[currentDataSetName] = new List<DataSet>();
                    }

                    DataSet currentDataSet = new DataSet()
                    {
                        Key = currentDataKey,
                        Size = currentDataSize
                    };

                    cacheDict[currentDataSetName].Add(currentDataSet);
                }

                input = Console.ReadLine();
            }

            Dictionary<string, List<DataSet>> dataSetToPrint = dataDict
                .OrderByDescending(x => x.Value.Sum(y => y.Size))
                .Take(1)
                .ToDictionary(x => x.Key, x => x.Value);

            if (dataSetToPrint.Count > 0)
            {
                Console.WriteLine($"Data Set: {dataSetToPrint.First().Key}, Total Size: {dataSetToPrint.First().Value.Sum(x => x.Size)}");
                foreach (var key in dataSetToPrint.First().Value)
                {
                    Console.WriteLine($"$.{key.Key}");
                }
            }
        }
    }

    public class DataSet
    {
        public string Key { get; set; }
        public long Size { get; set; }
    }
}