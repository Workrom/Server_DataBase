using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Server_DataBase
{
    public partial class Server_Form : Form
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

        //          Form Main Controls             \\
        public Server_Form()
        {
            this.Icon = Properties.Resources.SM_Logo_OnB1;
            InitializeComponent();
            CSV.FilesExist();
            Datatable_ReadR = CSV.Read();
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
            if (Write_DataGridView.Rows.Count > 0)
            {
                CSV.Write(CSV.dataTable);
                Datatable_ReadR = CSV.Read();
            }
            else
            {
                MessageBox.Show("No data to write");
            }
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
        private async void TimeHandle(object? sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
                return;
            }
            if (textBox.Text.Length >= 5 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (char.IsDigit(e.KeyChar))
            {
                if (textBox.Text.Length == 2 && e.KeyChar != ':')
                {
                    textBox.Text += ":" + e.KeyChar;
                    textBox.SelectionStart = textBox.Text.Length;
                    e.Handled = true;
                }
                else if (textBox.Text.Length == 2 && e.KeyChar == ':')
                {
                    e.Handled = true;
                }
                else if (textBox.Text.Length == 3 && e.KeyChar == ':')
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == ':' && textBox.Text.Length == 5)
            {
                e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar))
            {
                //do not allow to type non valid time like 26:77 
                await Task.Delay(100);
                string[] parts = textBox.Text.Split(':');
                if (parts.Length == 2 && parts[0].Length == 2 && parts[1].Length == 2)
                {
                    //split into HH and mm and cool way to select non valid to valid time
                    int hours = Math.Min(int.Parse(parts[0]), 23);
                    int minutes = Math.Min(int.Parse(parts[1]), 59);
                    textBox.Text = $"{hours:D2}:{minutes:D2}";
                    textBox.SelectionStart = textBox.Text.Length;
                    e.Handled = true;
                }
            }
        }
        private async void Write_Timetxb_KeyPress(object sender, KeyPressEventArgs e)
        {
            TimeHandle(sender, e);
        }
        private async void Search_TimePickerFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            TimeHandle(sender, e);
        }
        private async void Search_TimePickerTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TimeHandle(sender, e);
        }
        //              Write tabpage               \\

        //              Read tabpage                \\
        private void Read_Button_Click(object sender, EventArgs e)
        {
            Days();
            DataTable sortedTable = CompareAndSort();
            Read_DataGridView.AutoGenerateColumns = true;
            Read_DataGridView.DataSource = sortedTable;
            Search_Dayslbl.Text = Read_DataGridView.RowCount.ToString();
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
        void Search_Exportbtn_Click(object sender, EventArgs e)
        {
            if (Read_DataGridView.RowCount > 0)
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        string folderPath = folderBrowserDialog.SelectedPath;
                        ExportData(folderPath);
                    }
                }
                MessageBox.Show("Exported!");
            }
            else
            {
                MessageBox.Show("Nothing to export");
            }
        }
        //              Read tabpage                \\
        private void ExportData(string folderPath)
        {
            foreach (DataGridViewRow row in Read_DataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    string dateValue = row.Cells["Date"].Value.ToString();
                    if (DateTime.TryParseExact(dateValue, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                    {
                        string fileName = Path.Combine(folderPath, $"{date.ToString("dd-MM-yyyy")}.txt");
                        using (StreamWriter writer = new StreamWriter(fileName, true))
                        {
                            List<string> rowData = new List<string>();
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                if (Read_DataGridView.Columns[i].Name != "Date")
                                {
                                    rowData.Add(row.Cells[i].Value.ToString());
                                }
                            }
                            writer.WriteLine(string.Join(", ", rowData));
                        }
                    }
                }
            }
        }
        private void LoadInDGV()
        {
            if (CheckForDataValidation())
            {
                string user = Write_Usertxb.Text;
                string date = Write_datetimepicker.Text;
                string time = Write_Timetxb.Text;
                string reason;
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
            foreach (var user in Users)
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
                row["Days S.U"] = daysSinceLastUpdate.ToString();
            }
        }
        private DataTable CompareAndSort()
        {
            List<DataRow> filteredRows = new List<DataRow>();
            foreach (DataRow row in Datatable_ReadR.Rows)
            {
                bool userMatch = Search_UserCombobox.SelectedIndex == 0 || row["User"].ToString() == Search_UserCombobox.SelectedItem.ToString();
                bool reasonMatch = Search_ReasonCombobox.SelectedIndex == 0 || row["Reason"].ToString() == Search_ReasonCombobox.SelectedItem.ToString();

                bool dateFieldsEmpty = !Search_Datechkbox.Checked ||
                       (Search_DatePickerFrom.Value == DateTime.MinValue &&
                        Search_DatePickerTo.Value == DateTime.MinValue);
                bool dateMatch = !Search_Datechkbox.Checked ||
                                 (dateFieldsEmpty ||
                                  (!string.IsNullOrWhiteSpace(row["Date"].ToString()) &&
                                   DateTime.TryParseExact(row["Date"].ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue) &&
                                   dateValue >= Search_DatePickerFrom.Value.Date && dateValue <= Search_DatePickerTo.Value.Date));

                bool timeFieldsEmpty = string.IsNullOrWhiteSpace(Search_TimePickerFrom.Text) || string.IsNullOrWhiteSpace(Search_TimePickerTo.Text);
                bool timeMatch = !Search_Timechkbox.Checked ||
                                 (timeFieldsEmpty ||
                                  (!string.IsNullOrWhiteSpace(row["Time"].ToString()) &&
                                   TimeSpan.TryParse(row["Time"].ToString(), out TimeSpan timeValue) &&
                                   TimeSpan.TryParse(Search_TimePickerFrom.Text, out TimeSpan timeFrom) &&
                                   TimeSpan.TryParse(Search_TimePickerTo.Text, out TimeSpan timeTo) &&
                                   timeValue >= timeFrom && timeValue <= timeTo));

                if (userMatch && reasonMatch && dateMatch && timeMatch)
                {
                    filteredRows.Add(row);
                }
            }
            if (Search_Datechkbox.Checked || Search_Timechkbox.Checked)
            {
                MergeSort(filteredRows, CompareRows);
            }
            DataTable sortedTable = Datatable_ReadR.Clone();
            foreach (var row in filteredRows)
            {
                sortedTable.ImportRow(row);
            }
            return sortedTable;
        }
        private int CompareRows(DataRow row1, DataRow row2)
        {
            if (Search_UserCombobox.SelectedIndex > 0)
            {
                int userComparison = string.Compare(row1["User"].ToString(), row2["User"].ToString(), StringComparison.OrdinalIgnoreCase);
                if (userComparison != 0)
                {
                    return userComparison;
                }
            }
            if (Search_ReasonCombobox.SelectedIndex > 0)
            {
                int reasonComparison = string.Compare(row1["Reason"].ToString(), row2["Reason"].ToString(), StringComparison.OrdinalIgnoreCase);
                if (reasonComparison != 0)
                {
                    return reasonComparison;
                }
            }
            if (Search_Datechkbox.Checked)
            {
                DateTime date1 = DateTime.Parse(row1["Date"].ToString());
                DateTime date2 = DateTime.Parse(row2["Date"].ToString());
                int dateComparison = date1.CompareTo(date2);
                if (dateComparison != 0)
                {
                    return dateComparison;
                }
            }
            if (Search_Timechkbox.Checked)
            {
                DateTime time1 = DateTime.Parse(row1["Time"].ToString());
                DateTime time2 = DateTime.Parse(row2["Time"].ToString());
                int timeComparison = time1.CompareTo(time2);
                if (timeComparison != 0)
                {
                    return timeComparison;
                }
            }
            return row1.Table.Rows.IndexOf(row1).CompareTo(row2.Table.Rows.IndexOf(row2));
        }
        private void MergeSort(List<DataRow> list, Comparison<DataRow> comparison)
        {
            if (list.Count <= 1)
            {
                return;
            }

            int middleIndex = list.Count / 2;
            List<DataRow> leftHalf = list.GetRange(0, middleIndex);
            List<DataRow> rightHalf = list.GetRange(middleIndex, list.Count - middleIndex);

            MergeSort(leftHalf, comparison);
            MergeSort(rightHalf, comparison);
            Merge(list, leftHalf, rightHalf, comparison);
        }

        private void Merge(List<DataRow> list, List<DataRow> left, List<DataRow> right, Comparison<DataRow> comparison)
        {
            int leftIndex = 0, rightIndex = 0, mergedIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (comparison(left[leftIndex], right[rightIndex]) <= 0)
                {
                    list[mergedIndex++] = left[leftIndex++];
                }
                else
                {
                    list[mergedIndex++] = right[rightIndex++];
                }
            }

            while (leftIndex < left.Count)
            {
                list[mergedIndex++] = left[leftIndex++];
            }

            while (rightIndex < right.Count)
            {
                list[mergedIndex++] = right[rightIndex++];
            }
        }

    }
}