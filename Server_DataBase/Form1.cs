using System.Data;

namespace Server_DataBase
{
    public partial class Form1 : Form
    {

        CSV_Handle CSV = new CSV_Handle();

        public Form1()
        {
            InitializeComponent();
            Read_DataGridView.RowHeadersVisible = false;
            Write_Timetxb.KeyPress += Write_Timetxb_KeyPress;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ill think of a better way later
            ServerPanel.Visible = false;
            ServerPanel.Enabled = false;
            HomeButton.BackgroundImage = Properties.Resources.Home_Button_On;
            ServerButton.BackgroundImage = Properties.Resources.Server_Button_Off;
            ServerButton.FlatAppearance.BorderColor = Color.FromArgb(34, 32, 52);
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            HomeButton.BackgroundImage = Properties.Resources.Home_Button_On;
            HomeButton.FlatAppearance.BorderColor = Color.Black;
            HomePanel.Visible = true;
            HomePanel.Enabled = true;

            ServerButton.BackgroundImage = Properties.Resources.Server_Button_Off;
            ServerButton.FlatAppearance.BorderColor = Color.FromArgb(34, 32, 52);
            ServerPanel.Visible = false;
            ServerPanel.Enabled = false;
        }

        private void ServerButton_Click(object sender, EventArgs e)
        {
            ServerButton.BackgroundImage = Properties.Resources.Server_Button_On;
            ServerButton.FlatAppearance.BorderColor = Color.Black;
            ServerPanel.Visible = true;
            ServerPanel.Enabled = true;

            HomeButton.BackgroundImage = Properties.Resources.Home_Button_Off;
            HomeButton.FlatAppearance.BorderColor = Color.FromArgb(34, 32, 52);
            HomePanel.Visible = false;
            HomePanel.Enabled = false;
            //ужас 
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void Read_Button_Click(object sender, EventArgs e)
        {
            DisplayDataInDataGridView();
        }

        public void DisplayDataInDataGridView()
        {
            string mergedData = CSV.Read();
            Read_DataGridView.AutoGenerateColumns = true;
            DataTable dataTable = ParseMergedStringToDataTable(mergedData);
            Read_DataGridView.DataSource = dataTable;
        }

        private DataTable ParseMergedStringToDataTable(string mergedData)
        {

            //again i think i can borrow CSV_Handle.write somehow but short on time
            DataTable dataTable = new DataTable();

            string[] columnHeaders = mergedData.Split('\n')[0].Split(',');
            foreach (string header in columnHeaders)
            {
                dataTable.Columns.Add(header.Trim());
            }

            string[] rows = mergedData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (string row in rows.Skip(1))
            {
                string[] rowData = row.Split(',');
                dataTable.Rows.Add(rowData);
            }

            return dataTable;
        }

        private void Write_Button_Click(object sender, EventArgs e)
        {
            Write_Button.BackgroundImage = Properties.Resources.Write_Button_On;
            Find_Button.BackgroundImage = Properties.Resources.Find_Button_Off;

            Server_WritePanel.Visible = true;
            Server_SearchPanel.Visible = false;
        }

        private void Find_Button_Click(object sender, EventArgs e)
        {
            Write_Button.BackgroundImage = Properties.Resources.Write_Button_Off;
            Find_Button.BackgroundImage = Properties.Resources.Find_Button_On;

            Server_WritePanel.Visible = false;
            Server_SearchPanel.Visible = true;
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
    }

}


