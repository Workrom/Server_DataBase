using System.Data;
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

        //          Form Main Controls             \\
        public Form1()
        {
            InitializeComponent();
            Datatable_ReadR = CSV.Read();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateComboBoxWithReasons();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void TogglePanel_Main(Panel panelToShow, Button buttonToShow, Panel panelToHide, Button buttonToHide)
        {
            buttonToShow.BackgroundImage = Properties.Resources.Server_Button_On;
            buttonToShow.FlatAppearance.BorderColor = Color.Black;
            panelToShow.Visible = true;
            panelToShow.Enabled = true;

            buttonToHide.BackgroundImage = Properties.Resources.Home_Button_Off;
            buttonToHide.FlatAppearance.BorderColor = Color.FromArgb(34, 32, 52);
            panelToHide.Visible = false;
            panelToHide.Enabled = false;
        }
        private void TogglePanel_Server(Panel panelToShow, Button buttonToShow, Panel panelToHide, Button buttonToHide)
        {
            buttonToShow.BackgroundImage = Properties.Resources.Write_Button_On;
            panelToShow.Visible = true;
            panelToShow.Enabled = true;

            buttonToHide.BackgroundImage = Properties.Resources.Find_Button_Off;
            panelToHide.Visible = false;
            panelToHide.Enabled = false;
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            //show-HomePanel and HomeButton
            //hide-ServerPanel and ServerButton
            TogglePanel_Main(HomePanel, HomeButton, ServerPanel, ServerButton);
        }

        private void ServerButton_Click(object sender, EventArgs e)
        {
            //show-ServerPanel and ServerButton
            //hide-HomePanel and HomeButton
            TogglePanel_Main(ServerPanel, ServerButton, HomePanel, HomeButton);
        }
        private void Write_Button_Click(object sender, EventArgs e)
        {
            //show-Server_WritePanel and Server_WRiteButton
            //hide-Server_SearchPanel and Find_Button
            TogglePanel_Server(Server_WritePanel, Write_Button, Server_SearchPanel, Find_Button);
        }
        private void Find_Button_Click(object sender, EventArgs e)
        {
            //show-Server_SearchPanel and Find_Button
            //hide-Server_WritePanel and Server_WRiteButton
            TogglePanel_Server(Server_SearchPanel, Find_Button, Server_WritePanel, Write_Button);
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
            DisplayDataInDataGridView();
        }
        //              Read tabpage                \\
        private void LoadInDGV()
        {
            if (Check_ForDataValidation())
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
        private bool Check_ForDataValidation()
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
        public void DisplayDataInDataGridView()
        {
            Read_DataGridView.AutoGenerateColumns = true;
            Read_DataGridView.DataSource = Datatable_ReadR;
        }
        public void PopulateComboBoxWithReasons()
        {
            //select reasons within the file and when the program opens load the reasons into a combobox
            var Reasons = Datatable_ReadR.AsEnumerable().Select(x => x.Field<string>("Reason")).Distinct();
            Write_ReasonCombobox.Items.Clear();
            foreach (var reason in Reasons)
            {
                Write_ReasonCombobox.Items.Add(reason);
            }
        }  
    }
}