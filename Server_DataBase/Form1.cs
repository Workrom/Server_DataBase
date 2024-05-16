using System;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Server_DataBase
{
    public partial class Form1 : Form
    {
        //... Make the Form movable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        //...


        CSV_Handle CSV = new CSV_Handle();
        public DataTable Datatable_ReadR;
        public List<UDTR_list> udtr_listR;

        //          Form Main Controls             \\
        public Form1()
        {
            InitializeComponent();
            Datatable_ReadR = CSV.Read();
            CSV.ListLoad();
            udtr_listR = CSV.UDTR_list;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateComboBoxes();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            //show-HomePanel and HomeButton
            //hide-ServerPanel and ServerButton
            HomeButton.BackgroundImage = Properties.Resources.Home_Button_On;
            ServerButton.BackgroundImage = Properties.Resources.Server_Button_Off;
            HomeButton.FlatAppearance.BorderColor = Color.Black;
            ServerButton.FlatAppearance.BorderColor = Color.FromArgb(34, 32, 52);
            HomePanel.Visible = true;
            ServerPanel.Visible = false;
        }

        private void ServerButton_Click(object sender, EventArgs e)
        {
            //show-ServerPanel and ServerButton
            //hide-HomePanel and HomeButton
            HomeButton.BackgroundImage = Properties.Resources.Home_Button_Off;
            ServerButton.BackgroundImage = Properties.Resources.Server_Button_On;
            ServerButton.FlatAppearance.BorderColor = Color.Black;
            HomeButton.FlatAppearance.BorderColor = Color.FromArgb(34, 32, 52);
            HomePanel.Visible = false;
            ServerPanel.Visible = true;
        }
        private void Write_Button_Click(object sender, EventArgs e)
        {
            //show-Server_WritePanel and Server_WRiteButton
            //hide-Server_SearchPanel and Find_Button
            Write_Button.BackgroundImage = Properties.Resources.Write_Button_On;
            Find_Button.BackgroundImage = Properties.Resources.Find_Button_Off;
            Server_WritePanel.Visible = true;
            Server_SearchPanel.Visible = false;
        }
        private void Find_Button_Click(object sender, EventArgs e)
        {
            //show-Server_SearchPanel and Find_Button
            //hide-Server_WritePanel and Server_WRiteButton
            Write_Button.BackgroundImage = Properties.Resources.Write_Button_Off;
            Find_Button.BackgroundImage = Properties.Resources.Find_Button_On;
            Server_WritePanel.Visible = false;
            Server_SearchPanel.Visible = true;
        }
        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Visible = false;
            Button_Gif.Visible = true;
        }

        private void Button_Gif_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.Visible = true;
            Button_Gif.Visible = false;
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //          Form Main Controls             \\

        //              Write tabpage               \\
        private void Write_LoadBut_Click(object sender, EventArgs e)
        {
            LoadInDGV();
        }
        private void WriteBut_Click(object sender, EventArgs e)
        {
            CSV.Write(CSV.dataTable);
        }
        private void Write_ClearBut_Click(object sender, EventArgs e)
        {
            if (Write_DataGridView.Rows.Count > 0)
            {
                Write_DataGridView.Rows.RemoveAt(Write_DataGridView.Rows.Count - 1);
            }
        }
        private void Write_ClearAllBut_Click(object sender, EventArgs e)
        {
            Write_DataGridView.Rows.Clear();
        }

        private void Write_ExisRNbtn_CheckedChanged(object sender, EventArgs e)
        {
            Write_ReasonCombobox.Enabled = true;
            Write_Reasontxb.Enabled = false;
        }

        private void Write_OtherRNbtn_CheckedChanged(object sender, EventArgs e)
        {
            Write_ReasonCombobox.Enabled = false;
            Write_Reasontxb.Enabled = true;
        }
        private async void Write_Timetxb_KeyPress(object? sender, KeyPressEventArgs e)
        {
            //why error handle when error cannot happend :) (probably not true but still i tried)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
                return;
            }
            if (Write_Timetxb.Text.Length >= 5 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (char.IsDigit(e.KeyChar))
            {
                if (Write_Timetxb.Text.Length == 2 && e.KeyChar != ':')
                {
                    Write_Timetxb.Text += ":" + e.KeyChar;
                    Write_Timetxb.SelectionStart = Write_Timetxb.Text.Length;
                    e.Handled = true;
                }
                else if (Write_Timetxb.Text.Length == 2 && e.KeyChar == ':')
                {
                    e.Handled = true;
                }
                else if (Write_Timetxb.Text.Length == 3 && e.KeyChar == ':')
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == ':' && Write_Timetxb.Text.Length == 5)
            {
                e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar))
            {
                //do not allow to type non valid time like 26:77 
                await Task.Delay(100);
                string[] parts = Write_Timetxb.Text.Split(':');
                if (parts.Length == 2 && parts[0].Length == 2 && parts[1].Length == 2)
                {
                    //split into HH and mm and cool way to select non valid to valid time
                    int hours = Math.Min(int.Parse(parts[0]), 23);
                    int minutes = Math.Min(int.Parse(parts[1]), 59);
                    Write_Timetxb.Text = $"{hours:D2}:{minutes:D2}";
                    Write_Timetxb.SelectionStart = Write_Timetxb.Text.Length;
                    e.Handled = true;
                }
            }
        }
        //              Write tabpage               \\

        //              Read tabpage                \\
        private void Read_Button_Click(object sender, EventArgs e)
        {
            List <UDTR_list> Sorted_list = CompareAndSort();
            Read_DataGridView.AutoGenerateColumns = true;
            Read_DataGridView.DataSource = Sorted_list;
           //Days();
        }
        private void Search_Clearbtn_Click(object sender, EventArgs e)
        {
            if (Read_DataGridView.Rows.Count > 0)
            {
                Read_DataGridView.Rows.RemoveAt(Read_DataGridView.Rows.Count - 1);
            }
            Search_Dayslbl.Text = Read_DataGridView.RowCount.ToString();
        }
        private void Search_ClearAllbtn_Click(object sender, EventArgs e)
        {
            Read_DataGridView.DataSource = null;
            Read_DataGridView.Rows.Clear();
            Search_Dayslbl.Text = Read_DataGridView.RowCount.ToString();
        }
        private void Search_Datechkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Search_Datechkbox.Checked)
            {
                Search_DatePickerFrom.Enabled = true;
                Search_DatePickerTo.Enabled = true;
            }
            else
            {
                Search_DatePickerFrom.Enabled = false;
                Search_DatePickerTo.Enabled = false;
            }
        }

        private void Search_Timechkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Search_Timechkbox.Checked)
            {
                Search_TimePickerFrom.Enabled = true;
                Search_TimePickerTo.Enabled = true;
            }
            else
            {
                Search_TimePickerFrom.Enabled = false;
                Search_TimePickerTo.Enabled = false;
            }
        }
        //              Read tabpage                \\
        private void LoadInDGV()
        {
            if (CheckForDataValidation())
            {
                string user = Write_Usertxb.Text;
                string date = Write_datetimepicker.Text;
                string time = Write_Timetxb.Text;
                string reason = "";
                if (Write_ReasonCombobox.Enabled == true)
                {
                    reason = Write_ReasonCombobox.Text;
                }
                else
                {
                    reason = Write_Reasontxb.Text;
                }
                Write_DataGridView.AutoGenerateColumns = true;
                Write_DataGridView.DataSource = CSV.Load(user, date, time, reason);
            }
        }
        private bool CheckForDataValidation()
        {
            //So check for if the textbox is empty 
            //if it is dont load it in dgv
            //if it isn`nt then everything is correct
            //i moved this method and improved it from Load() in CSV_Handle
            Dictionary<string, string> controlNameMapp = new Dictionary<string, string>
            {
            { "Write_Usertxb", "User text" },
            { "Write_datetimepicker", "Date" },
            { "Write_Timetxb", "Time" },
            { "Write_ReasonCombobox", "Reason text" },
            { "Write_Reasontxb", "Reason text" }
            };
            foreach (var textfield in controlNameMapp)
            {
                Control control = Controls.Find(textfield.Key, true).FirstOrDefault();
                if (control != null && control.Enabled && string.IsNullOrWhiteSpace(control.Text))
                {
                    MessageBox.Show($"The {textfield.Value} is empty.");
                    return false;
                }
            }
            return true;
        }

        //goind to change this btw
        private void DisplayDataInDataGridView()
        {
            Read_DataGridView.AutoGenerateColumns = true;
            Read_DataGridView.DataSource = Datatable_ReadR;
        }
        private void PopulateComboBoxes()
        {
            //select reasons within the file and when the program opens load the reasons into a combobox
            var Reasons = Datatable_ReadR.AsEnumerable().Select(x => x.Field<string>("Reason")).Distinct();
            var Users = Datatable_ReadR.AsEnumerable().Select(x => x.Field<string>("User")).Distinct();
            Write_ReasonCombobox.Items.Clear();
            Search_ReasonCombobox.Items.Clear();
            Search_UserCombobox.Items.Clear();

            Search_ReasonCombobox.Items.Add("All");
            Search_UserCombobox.Items.Add("All");

            Search_ReasonCombobox.SelectedIndex = 0;
            Search_UserCombobox.SelectedIndex = 0;
            foreach (var reason in Reasons)
            {
                Write_ReasonCombobox.Items.Add(reason);
                Search_ReasonCombobox.Items.Add(reason);
            }
            foreach(var user in Users)
            {
                Search_UserCombobox.Items.Add(user);
            }
        }
        private void Days()
        {
            DateTime currentDate = DateTime.Today;
            foreach (DataRow row in Datatable_ReadR.Rows)
            {
                DateTime lastUpdateDate = Convert.ToDateTime(row["Date"]);
                TimeSpan timeSinceLastUpdate = currentDate - lastUpdateDate;
                int daysSinceLastUpdate = (int)timeSinceLastUpdate.TotalDays;
                row["Days last"] = daysSinceLastUpdate.ToString();
            }
            int totalCountOfUpdates = Datatable_ReadR.Rows.Count;
            Search_Dayslbl.Text = $"{totalCountOfUpdates}";
        }
        private List<UDTR_list> CompareAndSort()
        {
            Comparison<UDTR_list> comparison = null;

            if (Search_UserCombobox.SelectedIndex == 0 && Search_ReasonCombobox.SelectedIndex == 0
                && !Search_Datechkbox.Checked && !Search_Timechkbox.Checked)
            {
                comparison = (x, y) => 0;
            }
            else
            {
                comparison = (x, y) =>
                {
                    int result = 0;
                    if (Search_UserCombobox.SelectedIndex > 0)
                    {
                        int userComparison = string.Compare(x.User.ToString(), y.User.ToString(), StringComparison.OrdinalIgnoreCase);
                        if (userComparison != 0)
                        {
                            result = userComparison;
                        }
                    }
                    if (Search_ReasonCombobox.SelectedIndex > 0)
                    {
                        int reasonComparison = string.Compare(x.Reason.ToString(), y.Reason.ToString(), StringComparison.OrdinalIgnoreCase);
                        if (reasonComparison != 0)
                        {
                            result = reasonComparison;
                        }
                    }
                    if (Search_Datechkbox.Checked)
                    {
                        DateTime dateX = DateTime.ParseExact(x.Date.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                        DateTime dateY = DateTime.ParseExact(y.Date.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                        int dateComparison = DateTime.Compare(dateX, dateY);
                        if (dateComparison != 0)
                        {
                            return dateComparison;
                        }
                    }
                    if (Search_Timechkbox.Checked)
                    {
                        DateTime timeX = DateTime.ParseExact(x.Time.ToString(), "HH:mm", CultureInfo.InvariantCulture);
                        DateTime timeY = DateTime.ParseExact(y.Time.ToString(), "HH:mm", CultureInfo.InvariantCulture);
                        int timeComparison = DateTime.Compare(timeX, timeY);
                        if (timeComparison != 0)
                        {
                            return timeComparison;
                        }
                    }
                    return result;
                };
                }
            List<UDTR_list> S_list = Sort(udtr_listR, comparison);
            return S_list;
        }
        private static List<T> Sort<T>(List<T> list, Comparison<T> comparison)
        {
            if (list == null || list.Count <= 1)
            {
                return list;
            }

            List<T> sortedList = MergeSortInternal(list, comparison);
            list.Clear();
            list.AddRange(sortedList);
            return sortedList;
        }

        private static List<T> MergeSortInternal<T>(List<T> list, Comparison<T> comparison)
        {
            if (list.Count <= 1)
            {
                return list;
            }
            int middleIndex = list.Count / 2;
            List<T> leftHalf = list.GetRange(0, middleIndex);
            List<T> rightHalf = list.GetRange(middleIndex, list.Count - middleIndex);

            leftHalf = MergeSortInternal(leftHalf, comparison);
            rightHalf = MergeSortInternal(rightHalf, comparison);

            return Merge(leftHalf, rightHalf, comparison);
        }

        private static List<T> Merge<T>(List<T> left, List<T> right, Comparison<T> comparison)
        {
            List<T> merged = new List<T>();
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (comparison(left[leftIndex], right[rightIndex]) <= 0)
                {
                    merged.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    merged.Add(right[rightIndex]);
                    rightIndex++;
                }
            }
            while (leftIndex < left.Count)
            {
                merged.Add(left[leftIndex]);
                leftIndex++;
            }
            while (rightIndex < right.Count)
            {
                merged.Add(right[rightIndex]);
                rightIndex++;
            }
            return merged;
        }
    }
}