﻿namespace Server_DataBase
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
            Server_MainPanel = new Panel();
            Find_Button = new Button();
            Write_Button = new Button();
            Server_WritePanel = new Panel();
            Write_OtherRNbtn = new RadioButton();
            Write_ExisRNbtn = new RadioButton();
            Write_Timetxb = new TextBox();
            Write_datetimepicker = new DateTimePicker();
            Write_TimeLabel = new Label();
            Write_DateLabel = new Label();
            Write_ReasonCombobox = new ComboBox();
            Write_Reasontxb = new TextBox();
            Write_Usertxb = new TextBox();
            Write_ReasonLabel = new Label();
            Write_UserLabel = new Label();
            Write_LoadBut = new Button();
            WriteBut = new Button();
            Write_ClearBut = new Button();
            Write_ClearAllBut = new Button();
            Write_DataGridView = new DataGridView();
            Server_SearchPanel = new Panel();
            Read_Button = new Button();
            Read_DataGridView = new DataGridView();
            HomeButton = new Button();
            ServerButton = new Button();
            HomePanel = new Panel();
            ExitButton = new Button();
            Button_Gif = new PictureBox();
            ServerPanel.SuspendLayout();
            Server_MainPanel.SuspendLayout();
            Server_WritePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Write_DataGridView).BeginInit();
            Server_SearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Read_DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Button_Gif).BeginInit();
            SuspendLayout();
            // 
            // ServerPanel
            // 
            ServerPanel.BackColor = Color.Black;
            ServerPanel.Controls.Add(Server_MainPanel);
            ServerPanel.Controls.Add(Server_WritePanel);
            ServerPanel.Controls.Add(Server_SearchPanel);
            ServerPanel.Enabled = false;
            ServerPanel.Location = new Point(10, 50);
            ServerPanel.Margin = new Padding(3, 2, 3, 2);
            ServerPanel.Name = "ServerPanel";
            ServerPanel.Size = new Size(992, 439);
            ServerPanel.TabIndex = 0;
            ServerPanel.Visible = false;
            // 
            // Server_MainPanel
            // 
            Server_MainPanel.BackColor = Color.FromArgb(48, 96, 130);
            Server_MainPanel.Controls.Add(Find_Button);
            Server_MainPanel.Controls.Add(Write_Button);
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
            Find_Button.Click += Find_Button_Click;
            // 
            // Write_Button
            // 
            Write_Button.BackgroundImage = Properties.Resources.Write_Button_Off;
            Write_Button.BackgroundImageLayout = ImageLayout.Stretch;
            Write_Button.FlatAppearance.BorderColor = Color.FromArgb(48, 96, 130);
            Write_Button.FlatStyle = FlatStyle.Flat;
            Write_Button.Location = new Point(0, 139);
            Write_Button.Margin = new Padding(3, 2, 3, 2);
            Write_Button.Name = "Write_Button";
            Write_Button.Size = new Size(199, 76);
            Write_Button.TabIndex = 0;
            Write_Button.UseVisualStyleBackColor = true;
            Write_Button.Click += Write_Button_Click;
            // 
            // Server_WritePanel
            // 
            Server_WritePanel.BorderStyle = BorderStyle.FixedSingle;
            Server_WritePanel.Controls.Add(Write_OtherRNbtn);
            Server_WritePanel.Controls.Add(Write_ExisRNbtn);
            Server_WritePanel.Controls.Add(Write_Timetxb);
            Server_WritePanel.Controls.Add(Write_datetimepicker);
            Server_WritePanel.Controls.Add(Write_TimeLabel);
            Server_WritePanel.Controls.Add(Write_DateLabel);
            Server_WritePanel.Controls.Add(Write_ReasonCombobox);
            Server_WritePanel.Controls.Add(Write_Reasontxb);
            Server_WritePanel.Controls.Add(Write_Usertxb);
            Server_WritePanel.Controls.Add(Write_ReasonLabel);
            Server_WritePanel.Controls.Add(Write_UserLabel);
            Server_WritePanel.Controls.Add(Write_LoadBut);
            Server_WritePanel.Controls.Add(WriteBut);
            Server_WritePanel.Controls.Add(Write_ClearBut);
            Server_WritePanel.Controls.Add(Write_ClearAllBut);
            Server_WritePanel.Controls.Add(Write_DataGridView);
            Server_WritePanel.Location = new Point(208, 3);
            Server_WritePanel.Name = "Server_WritePanel";
            Server_WritePanel.Size = new Size(777, 430);
            Server_WritePanel.TabIndex = 2;
            // 
            // Write_OtherRNbtn
            // 
            Write_OtherRNbtn.AutoSize = true;
            Write_OtherRNbtn.Location = new Point(198, 74);
            Write_OtherRNbtn.Name = "Write_OtherRNbtn";
            Write_OtherRNbtn.Size = new Size(14, 13);
            Write_OtherRNbtn.TabIndex = 16;
            Write_OtherRNbtn.UseVisualStyleBackColor = true;
            Write_OtherRNbtn.CheckedChanged += Write_OtherRNbtn_CheckedChanged;
            // 
            // Write_ExisRNbtn
            // 
            Write_ExisRNbtn.AutoSize = true;
            Write_ExisRNbtn.Checked = true;
            Write_ExisRNbtn.Location = new Point(198, 45);
            Write_ExisRNbtn.Name = "Write_ExisRNbtn";
            Write_ExisRNbtn.Size = new Size(14, 13);
            Write_ExisRNbtn.TabIndex = 15;
            Write_ExisRNbtn.TabStop = true;
            Write_ExisRNbtn.UseVisualStyleBackColor = true;
            Write_ExisRNbtn.CheckedChanged += Write_ExisRNbtn_CheckedChanged;
            // 
            // Write_Timetxb
            // 
            Write_Timetxb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Write_Timetxb.Location = new Point(218, 161);
            Write_Timetxb.Name = "Write_Timetxb";
            Write_Timetxb.PlaceholderText = "00:00";
            Write_Timetxb.Size = new Size(129, 23);
            Write_Timetxb.TabIndex = 14;
            Write_Timetxb.TextAlign = HorizontalAlignment.Center;
            Write_Timetxb.KeyPress += Write_Timetxb_KeyPress;
            // 
            // Write_datetimepicker
            // 
            Write_datetimepicker.Format = DateTimePickerFormat.Short;
            Write_datetimepicker.Location = new Point(13, 162);
            Write_datetimepicker.Name = "Write_datetimepicker";
            Write_datetimepicker.Size = new Size(116, 23);
            Write_datetimepicker.TabIndex = 13;
            // 
            // Write_TimeLabel
            // 
            Write_TimeLabel.AutoSize = true;
            Write_TimeLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Write_TimeLabel.ForeColor = Color.ForestGreen;
            Write_TimeLabel.Location = new Point(257, 137);
            Write_TimeLabel.Name = "Write_TimeLabel";
            Write_TimeLabel.Size = new Size(46, 21);
            Write_TimeLabel.TabIndex = 12;
            Write_TimeLabel.Text = "Time";
            // 
            // Write_DateLabel
            // 
            Write_DateLabel.AutoSize = true;
            Write_DateLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Write_DateLabel.ForeColor = Color.ForestGreen;
            Write_DateLabel.Location = new Point(45, 137);
            Write_DateLabel.Name = "Write_DateLabel";
            Write_DateLabel.Size = new Size(44, 21);
            Write_DateLabel.TabIndex = 11;
            Write_DateLabel.Text = "Date";
            // 
            // Write_ReasonCombobox
            // 
            Write_ReasonCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            Write_ReasonCombobox.FormattingEnabled = true;
            Write_ReasonCombobox.Location = new Point(218, 41);
            Write_ReasonCombobox.Name = "Write_ReasonCombobox";
            Write_ReasonCombobox.Size = new Size(129, 23);
            Write_ReasonCombobox.TabIndex = 10;
            // 
            // Write_Reasontxb
            // 
            Write_Reasontxb.Enabled = false;
            Write_Reasontxb.Location = new Point(218, 70);
            Write_Reasontxb.Name = "Write_Reasontxb";
            Write_Reasontxb.PlaceholderText = "Other option";
            Write_Reasontxb.Size = new Size(129, 23);
            Write_Reasontxb.TabIndex = 9;
            Write_Reasontxb.Tag = "";
            // 
            // Write_Usertxb
            // 
            Write_Usertxb.Location = new Point(13, 41);
            Write_Usertxb.Name = "Write_Usertxb";
            Write_Usertxb.PlaceholderText = "Username";
            Write_Usertxb.Size = new Size(116, 23);
            Write_Usertxb.TabIndex = 8;
            // 
            // Write_ReasonLabel
            // 
            Write_ReasonLabel.AutoSize = true;
            Write_ReasonLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Write_ReasonLabel.ForeColor = Color.ForestGreen;
            Write_ReasonLabel.Location = new Point(249, 17);
            Write_ReasonLabel.Name = "Write_ReasonLabel";
            Write_ReasonLabel.Size = new Size(63, 21);
            Write_ReasonLabel.TabIndex = 7;
            Write_ReasonLabel.Text = "Reason";
            // 
            // Write_UserLabel
            // 
            Write_UserLabel.AutoSize = true;
            Write_UserLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Write_UserLabel.ForeColor = Color.ForestGreen;
            Write_UserLabel.Location = new Point(42, 17);
            Write_UserLabel.Name = "Write_UserLabel";
            Write_UserLabel.Size = new Size(43, 21);
            Write_UserLabel.TabIndex = 6;
            Write_UserLabel.Text = "User";
            // 
            // Write_LoadBut
            // 
            Write_LoadBut.BackColor = Color.DarkGreen;
            Write_LoadBut.Cursor = Cursors.Hand;
            Write_LoadBut.FlatAppearance.BorderColor = Color.DarkGreen;
            Write_LoadBut.FlatAppearance.MouseOverBackColor = Color.DarkSlateGray;
            Write_LoadBut.FlatStyle = FlatStyle.Flat;
            Write_LoadBut.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Write_LoadBut.ForeColor = Color.White;
            Write_LoadBut.Location = new Point(98, 299);
            Write_LoadBut.Name = "Write_LoadBut";
            Write_LoadBut.Size = new Size(200, 27);
            Write_LoadBut.TabIndex = 5;
            Write_LoadBut.Text = "Load";
            Write_LoadBut.UseVisualStyleBackColor = false;
            Write_LoadBut.Click += Write_LoadBut_Click;
            // 
            // WriteBut
            // 
            WriteBut.BackColor = Color.DarkGreen;
            WriteBut.Cursor = Cursors.Hand;
            WriteBut.FlatAppearance.BorderColor = Color.DarkGreen;
            WriteBut.FlatAppearance.MouseOverBackColor = Color.DarkSlateGray;
            WriteBut.FlatStyle = FlatStyle.Flat;
            WriteBut.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            WriteBut.ForeColor = Color.White;
            WriteBut.Location = new Point(98, 332);
            WriteBut.Name = "WriteBut";
            WriteBut.Size = new Size(200, 27);
            WriteBut.TabIndex = 4;
            WriteBut.Text = "Write";
            WriteBut.UseVisualStyleBackColor = false;
            WriteBut.Click += WriteBut_Click;
            // 
            // Write_ClearBut
            // 
            Write_ClearBut.BackColor = Color.DarkGreen;
            Write_ClearBut.Cursor = Cursors.Hand;
            Write_ClearBut.FlatAppearance.BorderColor = Color.DarkGreen;
            Write_ClearBut.FlatAppearance.MouseOverBackColor = Color.DarkSlateGray;
            Write_ClearBut.FlatStyle = FlatStyle.Flat;
            Write_ClearBut.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Write_ClearBut.ForeColor = Color.White;
            Write_ClearBut.Location = new Point(98, 365);
            Write_ClearBut.Name = "Write_ClearBut";
            Write_ClearBut.Size = new Size(200, 27);
            Write_ClearBut.TabIndex = 3;
            Write_ClearBut.Text = "Clear";
            Write_ClearBut.UseVisualStyleBackColor = false;
            Write_ClearBut.Click += Write_ClearBut_Click;
            // 
            // Write_ClearAllBut
            // 
            Write_ClearAllBut.BackColor = Color.DarkGreen;
            Write_ClearAllBut.Cursor = Cursors.Hand;
            Write_ClearAllBut.FlatAppearance.BorderColor = Color.DarkGreen;
            Write_ClearAllBut.FlatAppearance.MouseOverBackColor = Color.DarkSlateGray;
            Write_ClearAllBut.FlatStyle = FlatStyle.Flat;
            Write_ClearAllBut.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Write_ClearAllBut.ForeColor = Color.White;
            Write_ClearAllBut.Location = new Point(98, 398);
            Write_ClearAllBut.Name = "Write_ClearAllBut";
            Write_ClearAllBut.Size = new Size(200, 27);
            Write_ClearAllBut.TabIndex = 2;
            Write_ClearAllBut.Text = "Clear all";
            Write_ClearAllBut.UseVisualStyleBackColor = false;
            Write_ClearAllBut.Click += Write_ClearAllBut_Click;
            // 
            // Write_DataGridView
            // 
            Write_DataGridView.AllowUserToAddRows = false;
            Write_DataGridView.AllowUserToDeleteRows = false;
            Write_DataGridView.BackgroundColor = SystemColors.ActiveCaptionText;
            Write_DataGridView.BorderStyle = BorderStyle.Fixed3D;
            Write_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Write_DataGridView.GridColor = SystemColors.GradientActiveCaption;
            Write_DataGridView.Location = new Point(392, 3);
            Write_DataGridView.Margin = new Padding(3, 2, 3, 2);
            Write_DataGridView.Name = "Write_DataGridView";
            Write_DataGridView.ReadOnly = true;
            Write_DataGridView.RowHeadersVisible = false;
            Write_DataGridView.RowHeadersWidth = 51;
            Write_DataGridView.RowTemplate.Height = 29;
            Write_DataGridView.ScrollBars = ScrollBars.Vertical;
            Write_DataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Write_DataGridView.Size = new Size(385, 428);
            Write_DataGridView.TabIndex = 1;
            // 
            // Server_SearchPanel
            // 
            Server_SearchPanel.BorderStyle = BorderStyle.FixedSingle;
            Server_SearchPanel.Controls.Add(Read_Button);
            Server_SearchPanel.Controls.Add(Read_DataGridView);
            Server_SearchPanel.Location = new Point(208, 3);
            Server_SearchPanel.Margin = new Padding(3, 2, 3, 2);
            Server_SearchPanel.Name = "Server_SearchPanel";
            Server_SearchPanel.Size = new Size(781, 434);
            Server_SearchPanel.TabIndex = 4;
            // 
            // Read_Button
            // 
            Read_Button.Location = new Point(3, 330);
            Read_Button.Margin = new Padding(3, 2, 3, 2);
            Read_Button.Name = "Read_Button";
            Read_Button.Size = new Size(344, 22);
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
            Read_DataGridView.GridColor = SystemColors.GradientActiveCaption;
            Read_DataGridView.Location = new Point(373, 2);
            Read_DataGridView.Margin = new Padding(3, 2, 3, 2);
            Read_DataGridView.Name = "Read_DataGridView";
            Read_DataGridView.ReadOnly = true;
            Read_DataGridView.RowHeadersVisible = false;
            Read_DataGridView.RowHeadersWidth = 51;
            Read_DataGridView.RowTemplate.Height = 29;
            Read_DataGridView.ScrollBars = ScrollBars.Vertical;
            Read_DataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Read_DataGridView.Size = new Size(403, 428);
            Read_DataGridView.TabIndex = 0;
            // 
            // HomeButton
            // 
            HomeButton.BackgroundImage = Properties.Resources.Home_Button_On;
            HomeButton.BackgroundImageLayout = ImageLayout.Stretch;
            HomeButton.FlatStyle = FlatStyle.Flat;
            HomeButton.Location = new Point(844, 10);
            HomeButton.Margin = new Padding(3, 2, 3, 2);
            HomeButton.Name = "HomeButton";
            HomeButton.Size = new Size(159, 40);
            HomeButton.TabIndex = 1;
            HomeButton.UseVisualStyleBackColor = true;
            HomeButton.Click += HomeButton_Click;
            // 
            // ServerButton
            // 
            ServerButton.BackgroundImage = Properties.Resources.Server_Button_Off;
            ServerButton.BackgroundImageLayout = ImageLayout.Stretch;
            ServerButton.FlatAppearance.BorderColor = Color.FromArgb(34, 32, 52);
            ServerButton.FlatStyle = FlatStyle.Flat;
            ServerButton.Location = new Point(686, 10);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load;
            ServerPanel.ResumeLayout(false);
            Server_MainPanel.ResumeLayout(false);
            Server_WritePanel.ResumeLayout(false);
            Server_WritePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Write_DataGridView).EndInit();
            Server_SearchPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Read_DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)Button_Gif).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel ServerPanel;
        private Panel Server_SearchPanel;
        private Panel Server_MainPanel;
        private Button Find_Button;
        private Button Write_Button;
        private Button HomeButton;
        private Button ServerButton;
        private Panel HomePanel;
        private DataGridView Read_DataGridView;
        private Button ExitButton;
        private PictureBox Button_Gif;
        private Button Read_Button;
        private Panel Server_WritePanel;
        private DataGridView Write_DataGridView;
        private Button Write_ClearAllBut;
        private Button Write_LoadBut;
        private Button WriteBut;
        private Button Write_ClearBut;
        private Label Write_UserLabel;
        private DateTimePicker Write_datetimepicker;
        private Label Write_TimeLabel;
        private Label Write_DateLabel;
        private ComboBox Write_ReasonCombobox;
        private TextBox Write_Reasontxb;
        private TextBox Write_Usertxb;
        private Label Write_ReasonLabel;
        private TextBox Write_Timetxb;
        private RadioButton Write_OtherRNbtn;
        private RadioButton Write_ExisRNbtn;
    }
}