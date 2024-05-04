using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    internal class CSV_Handle
    {

        //UDTR - User Date Time Reason

        public List<UDTR> DataList { get; } = new List<UDTR>();
        private string UDTpath = "C:\\Users\\Workrom\\source\\repos\\Server_DataBase\\Server_DataBase\\UDT.csv";
        private string RNpath = "C:\\Users\\Workrom\\source\\repos\\Server_DataBase\\Server_DataBase\\RN.csv";

        public bool isLoaded(string user, string date, string time, string reason, int reasonID)
        {
            //probably a better way to do this but i am short on time
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(date) ||
                string.IsNullOrWhiteSpace(time) || string.IsNullOrWhiteSpace(reason) || reasonID <= 0)
            {
                return false;
            }

            UDTR newData = new UDTR
            {
                User = user,
                Date = date,
                Time = time,
                Reason = reason,
                ReasonID = reasonID
            };
            DataList.Add(newData);
            return true;
        }

        public void Write(List<UDTR> dataList)
        {
            if (dataList == null || dataList.Count == 0)
            {
                return;
            }
            var existingReasons = new Dictionary<string, int>();

            using (var reader = new StreamReader(RNpath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    existingReasons.Add(parts[1], int.Parse(parts[0]));
                }
            }
            using (StreamWriter stwUDT = new StreamWriter(UDTpath, true))
            using (StreamWriter stwRN = new StreamWriter(RNpath, true))
            {
                for (int i = 0; i < dataList.Count; i++)
                {
                    UDTR data = dataList[i];
                    stwUDT.WriteLine($"{data.User},{data.Date},{data.Time},{data.ReasonID}");

                    if (!existingReasons.ContainsKey(data.Reason.ToLower()))
                    {
                        //create a new id if thereason is new || if the reason like this already exists take the same id
                        //(probably use regex for this one we`ll see)
                        int newReasonID = existingReasons.Count + 1;
                        existingReasons.Add(data.Reason.ToLower(), newReasonID);
                        stwRN.WriteLine($"{newReasonID},{data.Reason}");
                    }
                }
            }
        }

        public string Read()
        {
            StringBuilder bruh = new StringBuilder();
            bruh.AppendLine("User, Date, Time, Reason, ReasonID");

            var UDTstr = File.ReadLines(UDTpath).Skip(1).Select(LINE => LINE.Split(',')).Select(LINES => new UDTR { User = LINES[0], Date = LINES[1], Time = LINES[2], ReasonID = int.Parse(LINES[3]) });
            var reasons = File.ReadLines(RNpath).Skip(1).Select(line => line.Split(',')).ToDictionary(parts => int.Parse(parts[0]), parts => parts[1]);

            foreach (var data in UDTstr)
            {
                //COmpare if dictionary with reason_id`s correspond to UDT id`s || if yes thatn we take the reason with that id
                string reason = reasons.ContainsKey(data.ReasonID) ? reasons[data.ReasonID] : "Unknown";
                bruh.Append($"{data.User}, {data.Date}, {data.Time}, {reason}\n");
            }
            return bruh.ToString();
        }
    }
}
