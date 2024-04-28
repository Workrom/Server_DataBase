namespace Server_DataBase
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ServerPanel = new Panel();
            Server_WritePanel = new Panel();
            Read_Button = new Button();
            Read_DataGridView = new DataGridView();
            Server_MainPanel = new Panel();
            Find_Button = new Button();
            Load_Button = new Button();
            HomeButton = new Button();
            ServerButton = new Button();
            HomePanel = new Panel();
            ExitButton = new Button();
            Button_Gif = new PictureBox();
            ServerPanel.SuspendLayout();
            Server_WritePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Read_DataGridView).BeginInit();
            Server_MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Button_Gif).BeginInit();
            SuspendLayout();
            // 
            // ServerPanel
            // 
            ServerPanel.BackColor = Color.Black;
            ServerPanel.Controls.Add(Server_WritePanel);
            ServerPanel.Controls.Add(Server_MainPanel);
            ServerPanel.Enabled = false;
            ServerPanel.Location = new Point(10, 50);
            ServerPanel.Margin = new Padding(3, 2, 3, 2);
            ServerPanel.Name = "ServerPanel";
            ServerPanel.Size = new Size(992, 439);
            ServerPanel.TabIndex = 0;
            ServerPanel.Visible = false;
            // 
            // Server_WritePanel
            // 
            Server_WritePanel.BorderStyle = BorderStyle.FixedSingle;
            Server_WritePanel.Controls.Add(Read_Button);
            Server_WritePanel.Controls.Add(Read_DataGridView);
            Server_WritePanel.Location = new Point(208, 3);
            Server_WritePanel.Margin = new Padding(3, 2, 3, 2);
            Server_WritePanel.Name = "Server_WritePanel";
            Server_WritePanel.Size = new Size(781, 434);
            Server_WritePanel.TabIndex = 4;
            // 
            // Read_Button
            // 
            Read_Button.Location = new Point(3, 330);
            Read_Button.Margin = new Padding(3, 2, 3, 2);
            Read_Button.Name = "Read_Button";
            Read_Button.Size = new Size(382, 22);
            Read_Button.TabIndex = 1;
            Read_Button.Text = "Read";
            Read_Button.UseVisualStyleBackColor = true;
            Read_Button.Click += Read_Button_Click;
            // 
            // Read_DataGridView
            // 
            Read_DataGridView.AllowUserToAddRows = false;
            Read_DataGridView.AllowUserToDeleteRows = false;
            Read_DataGridView.BackgroundColor = SystemColors.ActiveCaptionText;
            Read_DataGridView.BorderStyle = BorderStyle.Fixed3D;
            Read_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Read_DataGridView.Location = new Point(391, 2);
            Read_DataGridView.Margin = new Padding(3, 2, 3, 2);
            Read_DataGridView.Name = "Read_DataGridView";
            Read_DataGridView.ReadOnly = true;
            Read_DataGridView.RowHeadersWidth = 51;
            Read_DataGridView.RowTemplate.Height = 29;
            Read_DataGridView.ScrollBars = ScrollBars.Vertical;
            Read_DataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Read_DataGridView.Size = new Size(385, 428);
            Read_DataGridView.TabIndex = 0;
            // 
            // Server_MainPanel
            // 
            Server_MainPanel.BackColor = Color.FromArgb(48, 96, 130);
            Server_MainPanel.Controls.Add(Find_Button);
            Server_MainPanel.Controls.Add(Load_Button);
            Server_MainPanel.Location = new Point(3, 2);
            Server_MainPanel.Margin = new Padding(3, 2, 3, 2);
            Server_MainPanel.Name = "Server_MainPanel";
            Server_MainPanel.Size = new Size(199, 435);
            Server_MainPanel.TabIndex = 3;
            // 
            // Find_Button
            // 
            Find_Button.BackColor = Color.FromArgb(48, 96, 130);
            Find_Button.BackgroundImage = Properties.Resources.Find_Button_Off;
            Find_Button.BackgroundImageLayout = ImageLayout.Stretch;
            Find_Button.FlatAppearance.BorderColor = Color.FromArgb(48, 96, 130);
            Find_Button.FlatStyle = FlatStyle.Flat;
            Find_Button.ForeColor = Color.Black;
            Find_Button.Location = new Point(0, 214);
            Find_Button.Margin = new Padding(3, 2, 3, 2);
            Find_Button.Name = "Find_Button";
            Find_Button.Size = new Size(199, 76);
            Find_Button.TabIndex = 1;
            Find_Button.UseVisualStyleBackColor = false;
            // 
            // Load_Button
            // 
            Load_Button.BackgroundImage = Properties.Resources.Write_Button_Off;
            Load_Button.BackgroundImageLayout = ImageLayout.Stretch;
            Load_Button.FlatAppearance.BorderColor = Color.FromArgb(48, 96, 130);
            Load_Button.FlatStyle = FlatStyle.Flat;
            Load_Button.Location = new Point(0, 139);
            Load_Button.Margin = new Padding(3, 2, 3, 2);
            Load_Button.Name = "Load_Button";
            Load_Button.Size = new Size(199, 76);
            Load_Button.TabIndex = 0;
            Load_Button.UseVisualStyleBackColor = true;
            // 
            // HomeButton
            // 
            HomeButton.BackgroundImage = Properties.Resources.Home_Button_On;
            HomeButton.BackgroundImageLayout = ImageLayout.Stretch;
            HomeButton.FlatStyle = FlatStyle.Flat;
            HomeButton.Location = new Point(844, 11);
            HomeButton.Margin = new Padding(3, 2, 3, 2);
            HomeButton.Name = "HomeButton";
            HomeButton.Size = new Size(159, 40);
            HomeButton.TabIndex = 1;
            HomeButton.UseVisualStyleBackColor = true;
            HomeButton.Click += HomeButton_Click;
            // 
            // ServerButton
            // 
            ServerButton.BackgroundImage = Properties.Resources.Server_Button_On;
            ServerButton.BackgroundImageLayout = ImageLayout.Stretch;
            ServerButton.FlatStyle = FlatStyle.Flat;
            ServerButton.Location = new Point(686, 11);
            ServerButton.Margin = new Padding(3, 2, 3, 2);
            ServerButton.Name = "ServerButton";
            ServerButton.Size = new Size(159, 40);
            ServerButton.TabIndex = 2;
            ServerButton.UseVisualStyleBackColor = true;
            ServerButton.Click += ServerButton_Click;
            // 
            // HomePanel
            // 
            HomePanel.BackgroundImage = Properties.Resources.Home_Image;
            HomePanel.BackgroundImageLayout = ImageLayout.Stretch;
            HomePanel.Location = new Point(10, 50);
            HomePanel.Margin = new Padding(3, 2, 3, 2);
            HomePanel.Name = "HomePanel";
            HomePanel.Size = new Size(993, 439);
            HomePanel.TabIndex = 3;
            // 
            // ExitButton
            // 
            ExitButton.BackgroundImage = Properties.Resources.Exit_Button1;
            ExitButton.BackgroundImageLayout = ImageLayout.Stretch;
            ExitButton.FlatAppearance.BorderColor = Color.FromArgb(17, 17, 17);
            ExitButton.FlatStyle = FlatStyle.Flat;
            ExitButton.Location = new Point(10, 3);
            ExitButton.Margin = new Padding(3, 2, 3, 2);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(52, 44);
            ExitButton.TabIndex = 4;
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            ExitButton.MouseLeave += ExitButton_MouseLeave;
            // 
            // Button_Gif
            // 
            Button_Gif.Image = (Image)resources.GetObject("Button_Gif.Image");
            Button_Gif.Location = new Point(10, 3);
            Button_Gif.Margin = new Padding(3, 2, 3, 2);
            Button_Gif.Name = "Button_Gif";
            Button_Gif.Size = new Size(50, 43);
            Button_Gif.SizeMode = PictureBoxSizeMode.StretchImage;
            Button_Gif.TabIndex = 5;
            Button_Gif.TabStop = false;
            Button_Gif.Visible = false;
            Button_Gif.MouseEnter += Button_Gif_MouseEnter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 17, 17);
            ClientSize = new Size(1010, 500);
            ControlBox = false;
            Controls.Add(ServerButton);
            Controls.Add(HomeButton);
            Controls.Add(Button_Gif);
            Controls.Add(ExitButton);
            Controls.Add(ServerPanel);
            Controls.Add(HomePanel);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Server Manager";
            Load += Form1_Load;
            ServerPanel.ResumeLayout(false);
            Server_WritePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Read_DataGridView).EndInit();
            Server_MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Button_Gif).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel ServerPanel;
        private Panel Server_WritePanel;
        private Panel Server_MainPanel;
        private Button Find_Button;
        private Button Load_Button;
        private Button HomeButton;
        private Button ServerButton;
        private Panel HomePanel;
        private DataGridView Read_DataGridView;
        private Button ExitButton;
        private PictureBox Button_Gif;
        private Button Read_Button;
    }
}