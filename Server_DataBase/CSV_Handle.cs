
using Microsoft.VisualBasic.FileIO;
using System.Linq;
using System.Text;

namespace Server_DataBase
{
    //UDTR - User, Date, Time, Reason.
    struct UDTR
    {
        public string User { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Reason { get; set; }

    }
    internal class CSV_Handle
    {
        public List<UDTR> DataList { get; } = new List<UDTR>();
        private string UDTpath = "C:\\Users\\Workrom\\source\\repos\\Server_DataBase\\Server_DataBase\\UDT.csv";
        private string RNpath = "C:\\Users\\Workrom\\source\\repos\\Server_DataBase\\Server_DataBase\\RN.csv";


        public bool isLoaded(string user, string date, string time, string reason)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(date) ||
                string.IsNullOrWhiteSpace(time) || string.IsNullOrWhiteSpace(reason))
            {
                return false;
            }
            UDTR newData = new UDTR
            {
                User = user,
                Date = date,
                Time = time,
                Reason = reason
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

            using (StreamWriter stwUDT = new StreamWriter(UDTpath, true))
            using (StreamWriter stwRN = new StreamWriter(RNpath, true))
            {
                for (int i = 0; i < dataList.Count; i++)
                {
                    UDTR data = dataList[i];
                    stwUDT.WriteLine($"{data.User},{data.Date},{data.Time}");
                }
                for (int i = 0; i < dataList.Count; i++)
                {
                    UDTR data = dataList[i];
                    stwRN.WriteLine($"{data.Reason}");
                }
            }
        }

        public string Read()
        {

            //Прошла неделя а непомню что тут за что отвечает
            StringBuilder bruh = new StringBuilder();
            bruh.AppendLine("User, Date, Time, Reason");
            var UDTstr = File.ReadLines(UDTpath).Skip(1).Select(LINE => LINE.Split(',')).Select(LINES => new UDTR {User = LINES[0], Date = LINES[1], Time = LINES[2] });
            var RNstr = File.ReadLines(RNpath).Skip(1).Select(LINE => LINE.Split(',')).Select(LINES => new UDTR { Reason = LINES[0]});
            var UDTRNstr = UDTstr.Zip(RNstr, (x, y) => new UDTR {User = x.User, Date = x.Date, Time = x.Time, Reason = y.Reason}).ToList();
            foreach(var data in UDTRNstr)
            {
                bruh.Append($"{data.User}, {data.Date}, {data.Time}, {data.Reason}\n");
            }
            return bruh.ToString();
        }

    }
}
