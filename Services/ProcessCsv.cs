using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ep1.Models;

namespace ep1.Services
{
    public class ProcessCsv
    {
        public static void StartProcess(Dictionary<long, Research> placeList)
        {
            using (var reader = new StreamReader(@"./Data/OD_2017.csv"))
            {
                var firstLine = reader.ReadLine();
                var firstLineValues = firstLine.Split(',');
                Dictionary<string, int> columnIndexes = new Dictionary<string, int>();
                for (int i = 0; i < firstLineValues.Count(); i++)
                {
                    if (VerifyHeader(firstLineValues, i))
                    {
                        columnIndexes.Add(firstLineValues[i], i);
                    }
                }
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    ProcessCsv.Process(columnIndexes, values, placeList);

                }
            }
        }
        private static void Process(Dictionary<string, int> columnIndexes, string[] values, Dictionary<long, Research> placeList)
        {
            long converted = Convert.ToInt64(values[columnIndexes["CO_O_X"]] + values[columnIndexes["CO_O_Y"]]);
            if (converted != 0)
            {
                PopulateResearch(values[columnIndexes["ID_PESS"]],
                    values[columnIndexes["CO_O_X"]],
                    values[columnIndexes["CO_O_Y"]],
                    converted,
                    placeList);
            }
            converted = Convert.ToInt64(values[columnIndexes["CO_D_X"]] + values[columnIndexes["CO_D_Y"]]);
            if (converted != 0)
            {
                PopulateResearch(values[columnIndexes["ID_PESS"]],
                    values[columnIndexes["CO_D_X"]],
                    values[columnIndexes["CO_D_Y"]],
                    converted,
                    placeList);
            }
            converted = Convert.ToInt64(values[columnIndexes["CO_O_X"]] + values[columnIndexes["CO_O_Y"]]);
            if (converted != 0)
            {
                PopulateResearch(values[columnIndexes["ID_PESS"]],
                    values[columnIndexes["CO_O_X"]],
                    values[columnIndexes["CO_O_Y"]],
                    converted,
                    placeList);
            }
            converted = Convert.ToInt64(values[columnIndexes["CO_ESC_X"]] + values[columnIndexes["CO_ESC_Y"]]);
            if (converted != 0)
            {
                PopulateResearch(values[columnIndexes["ID_PESS"]],
                    values[columnIndexes["CO_ESC_X"]],
                    values[columnIndexes["CO_ESC_Y"]],
                    converted,
                    placeList);
            }
            converted = Convert.ToInt64(values[columnIndexes["CO_T1_X"]] + values[columnIndexes["CO_T1_Y"]]);
            if (converted != 0)
            {
                PopulateResearch(values[columnIndexes["ID_PESS"]],
                    values[columnIndexes["CO_T1_X"]],
                    values[columnIndexes["CO_T1_Y"]],
                    converted,
                    placeList);
            }
            converted = Convert.ToInt64(values[columnIndexes["CO_T2_X"]] + values[columnIndexes["CO_T2_Y"]]);
            if (converted != 0)
            {
                PopulateResearch(values[columnIndexes["ID_PESS"]],
                    values[columnIndexes["CO_T2_X"]],
                    values[columnIndexes["CO_T2_Y"]],
                    converted,
                    placeList);
            }
            converted = Convert.ToInt64(values[columnIndexes["CO_T3_X"]] + values[columnIndexes["CO_T3_Y"]]);
            if (converted != 0)
            {
                PopulateResearch(values[columnIndexes["ID_PESS"]],
                    values[columnIndexes["CO_T3_X"]],
                    values[columnIndexes["CO_T3_Y"]],
                    converted,
                    placeList);
            }
            converted = Convert.ToInt64(values[columnIndexes["CO_TR1_X"]] + values[columnIndexes["CO_TR1_Y"]]);
            if (converted != 0)
            {
                PopulateResearch(values[columnIndexes["ID_PESS"]],
                    values[columnIndexes["CO_TR1_X"]],
                    values[columnIndexes["CO_TR1_Y"]],
                    converted,
                    placeList);
            }
            converted = Convert.ToInt64(values[columnIndexes["CO_TR2_X"]] + values[columnIndexes["CO_TR2_Y"]]);
            if (converted != 0)
            {
                PopulateResearch(values[columnIndexes["ID_PESS"]],
                    values[columnIndexes["CO_TR2_X"]],
                    values[columnIndexes["CO_TR2_Y"]],
                    converted,
                    placeList);
            }
        }

        private static void PopulateResearch(string id, string coodX, string coodY, long converted, Dictionary<long, Research> placeList)
        {
            if (!placeList.ContainsKey(converted))
            {
                Research research = new Research();
                research.CoodX = coodX;
                research.CoodY = coodY;
                research.Users = new HashSet<ulong>();
                research.Users.Add(Convert.ToUInt64(id));
                placeList.Add(Convert.ToInt64(coodX + coodY), research);
            }
            else
            {
                placeList[converted].Users.Add(Convert.ToUInt64(id));
            }
        }

        private static bool VerifyHeader(string[] firstLineValues, int i)
        {
            if (firstLineValues[i].Equals("ID_PESS") || firstLineValues[i].Equals("CO_O_X") ||
                firstLineValues[i].Equals("CO_O_Y") || firstLineValues[i].Equals("CO_D_X") ||
                firstLineValues[i].Equals("CO_D_Y") || firstLineValues[i].Equals("CO_DOM_X") ||
                firstLineValues[i].Equals("CO_DOM_Y") || firstLineValues[i].Equals("CO_ESC_X") ||
                firstLineValues[i].Equals("CO_ESC_Y") || firstLineValues[i].Equals("CO_T1_X") ||
                firstLineValues[i].Equals("CO_T1_Y") || firstLineValues[i].Equals("CO_T2_X") ||
                firstLineValues[i].Equals("CO_T2_Y") || firstLineValues[i].Equals("CO_T3_X") ||
                firstLineValues[i].Equals("CO_T3_Y") || firstLineValues[i].Equals("CO_TR1_X") ||
                firstLineValues[i].Equals("CO_TR1_Y") || firstLineValues[i].Equals("CO_TR2_X") ||
                firstLineValues[i].Equals("CO_TR2_Y")) return true;
            return false;
        }
    }
}