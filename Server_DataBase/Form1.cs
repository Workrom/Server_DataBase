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

        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
    }
}


