using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace Server_DataBase
{
    struct UDTR
    {
        public string User { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Reason { get; set; }
        public int ReasonID { get; set; }
    }
    public struct UDTR_list
    {
        public string User { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Reason { get; set; }
    }
    internal class CSV_Handle
    {

        //UDTR - User Date Time Reason
        public List<UDTR_list> UDTR_list = new List<UDTR_list>();
        public DataTable dataTable = new DataTable();
        private string UDTpath = "C:\\Users\\Workrom\\source\\repos\\Server_DataBase\\Server_DataBase\\UDT.csv";
        private string RNpath = "C:\\Users\\Workrom\\source\\repos\\Server_DataBase\\Server_DataBase\\RN.csv";

        public void ListLoad()
        {


            foreach(DataRow row in dataTable.Rows)
            {
                UDTR_list udtr_list = new UDTR_list();
                udtr_list.User = row["User"].ToString();
                udtr_list.Date = row["Date"].ToString();
                udtr_list.Time = row["Time"].ToString();
                udtr_list.Reason = row["Reason"].ToString();
                UDTR_list.Add(udtr_list);
            }
        }
        public DataTable Load(string user, string date, string time, string reason)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                dataTable = InitializeDataTable();
            }

            // Add a new row with the provided data
            DataRow newRow = dataTable.NewRow();
            newRow["User"] = user;
            newRow["Date"] = date;
            newRow["Time"] = time;
            newRow["Reason"] = reason;
            dataTable.Rows.Add(newRow);

            return dataTable;
        }

        public void Write(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return;
            }

            var existingReasons = new Dictionary<string, int>();

            using (var reader = new StreamReader(RNpath))
            {
                //skip header row
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    existingReasons.Add(parts[1].Trim().ToLower(), int.Parse(parts[0]));
                }
            }

            using (StreamWriter stwUDT = new StreamWriter(UDTpath, true))
            using (StreamWriter stwRN = new StreamWriter(RNpath, true))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string user = row["User"].ToString();
                    string date = row["Date"].ToString();
                    string time = row["Time"].ToString();

                    //so i check reasons by ToLower() which is dumb
                    //and it will be smarter to use Regex

                    //so i just found out how hard it is to match 2 string via treshold
                    //no thx i will rely on user input
                    string reason = row["Reason"].ToString().Trim().ToLower();

                    stwUDT.WriteLine($"{user},{date},{time},{existingReasons[reason]}");

                    if (!existingReasons.ContainsKey(reason))
                    {
                        // Create a new ID if the reason is new
                        int newReasonID = existingReasons.Count + 1;
                        existingReasons.Add(reason, newReasonID);
                        stwRN.WriteLine($"{newReasonID},{reason}");
                    }
                }
            }
        }
        private DataTable InitializeDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("User", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Time", typeof(string));
            dt.Columns.Add("Reason", typeof(string));
            return dt;
        }
        public DataTable Read()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("User");
            dataTable.Columns.Add("Date");
            dataTable.Columns.Add("Time");
            dataTable.Columns.Add("Reason");
            dataTable.Columns.Add("Days last", typeof(string));

            DateTime currentDate = DateTime.Today;

            var UDTstr = File.ReadLines(UDTpath).Skip(1).Select(LINE => LINE.Split(',')).Select(LINES => new UDTR { User = LINES[0], Date = LINES[1], Time = LINES[2], ReasonID = int.Parse(LINES[3]) });
            var reasons = File.ReadLines(RNpath).Skip(1).Select(line => line.Split(',')).ToDictionary(parts => int.Parse(parts[0]), parts => parts[1]);
            foreach (var data in UDTstr)
            {
                string reason = reasons.ContainsKey(data.ReasonID) ? reasons[data.ReasonID] : "Unknown";
                dataTable.Rows.Add(data.User, data.Date, data.Time, reason, currentDate);
            }
            return dataTable;
        }
    }
}
