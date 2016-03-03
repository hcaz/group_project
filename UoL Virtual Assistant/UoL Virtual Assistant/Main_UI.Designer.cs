namespace UoL_Virtual_Assistant
{
    partial class Main_UI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Message_Input = new System.Windows.Forms.TextBox();
            this.Settings_Title = new System.Windows.Forms.Label();
            this.Theme_Title = new System.Windows.Forms.Label();
            this.Theme_Selection = new System.Windows.Forms.ComboBox();
            this.Reset_Title = new System.Windows.Forms.Label();
            this.About_Title = new System.Windows.Forms.Label();
            this.About_Content = new System.Windows.Forms.TextBox();
            this.Preferred_Agent_Title = new System.Windows.Forms.Label();
            this.Preferred_Agent_Selection = new System.Windows.Forms.ComboBox();
            this.UoL_Logo_Link_Title = new System.Windows.Forms.Label();
            this.UoL_Logo_Link_Selection = new System.Windows.Forms.ComboBox();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.Student_Name_Title = new System.Windows.Forms.Label();
            this.Student_ID_Title = new System.Windows.Forms.Label();
            this.Hamburger_Menu = new System.Windows.Forms.Button();
            this.Course_Building = new System.Windows.Forms.PictureBox();
            this.Settings_Drawer = new System.Windows.Forms.PictureBox();
            this.Send_Message = new System.Windows.Forms.Button();
            this.Message_Input_Area = new System.Windows.Forms.PictureBox();
            this.Conversation_Window = new System.Windows.Forms.PictureBox();
            this.UoL_Branding = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Course_Building)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Settings_Drawer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Message_Input_Area)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Conversation_Window)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoL_Branding)).BeginInit();
            this.SuspendLayout();
            // 
            // Message_Input
            // 
            this.Message_Input.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Message_Input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Message_Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message_Input.Location = new System.Drawing.Point(307, 406);
            this.Message_Input.MaxLength = 500;
            this.Message_Input.Multiline = true;
            this.Message_Input.Name = "Message_Input";
            this.Message_Input.Size = new System.Drawing.Size(222, 38);
            this.Message_Input.TabIndex = 3;
            this.Message_Input.TextChanged += new System.EventHandler(this.Message_Input_TextChanged);
            // 
            // Settings_Title
            // 
            this.Settings_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Settings_Title.AutoSize = true;
            this.Settings_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(38)))), ((int)(((byte)(83)))));
            this.Settings_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Settings_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.Settings_Title.Location = new System.Drawing.Point(724, 12);
            this.Settings_Title.Name = "Settings_Title";
            this.Settings_Title.Size = new System.Drawing.Size(90, 25);
            this.Settings_Title.TabIndex = 9;
            this.Settings_Title.Text = "Settings";
            // 
            // Theme_Title
            // 
            this.Theme_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Theme_Title.AutoSize = true;
            this.Theme_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(38)))), ((int)(((byte)(83)))));
            this.Theme_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Theme_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.Theme_Title.Location = new System.Drawing.Point(724, 157);
            this.Theme_Title.Name = "Theme_Title";
            this.Theme_Title.Size = new System.Drawing.Size(62, 20);
            this.Theme_Title.TabIndex = 11;
            this.Theme_Title.Text = "Theme:";
            // 
            // Theme_Selection
            // 
            this.Theme_Selection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Theme_Selection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(28)))), ((int)(((byte)(59)))));
            this.Theme_Selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Theme_Selection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Theme_Selection.ForeColor = System.Drawing.SystemColors.Control;
            this.Theme_Selection.FormattingEnabled = true;
            this.Theme_Selection.Items.AddRange(new object[] {
            "Blue",
            "Brown",
            "Cyan",
            "Green",
            "Grey",
            "Indigo",
            "Jbm8",
            "Orange",
            "Pink",
            "Purple",
            "Red",
            "Teal",
            "White"});
            this.Theme_Selection.Location = new System.Drawing.Point(804, 157);
            this.Theme_Selection.Name = "Theme_Selection";
            this.Theme_Selection.Size = new System.Drawing.Size(58, 21);
            this.Theme_Selection.Sorted = true;
            this.Theme_Selection.TabIndex = 12;
            this.Theme_Selection.SelectedIndexChanged += new System.EventHandler(this.Theme_Selection_SelectedIndexChanged);
            // 
            // Reset_Title
            // 
            this.Reset_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Reset_Title.AutoSize = true;
            this.Reset_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(38)))), ((int)(((byte)(83)))));
            this.Reset_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.Reset_Title.Location = new System.Drawing.Point(724, 285);
            this.Reset_Title.Name = "Reset_Title";
            this.Reset_Title.Size = new System.Drawing.Size(56, 20);
            this.Reset_Title.TabIndex = 13;
            this.Reset_Title.Text = "Reset:";
            // 
            // About_Title
            // 
            this.About_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.About_Title.AutoSize = true;
            this.About_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(38)))), ((int)(((byte)(83)))));
            this.About_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.About_Title.Location = new System.Drawing.Point(724, 314);
            this.About_Title.Name = "About_Title";
            this.About_Title.Size = new System.Drawing.Size(68, 25);
            this.About_Title.TabIndex = 14;
            this.About_Title.Text = "About";
            // 
            // About_Content
            // 
            this.About_Content.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.About_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(38)))), ((int)(((byte)(83)))));
            this.About_Content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.About_Content.ForeColor = System.Drawing.SystemColors.Control;
            this.About_Content.Location = new System.Drawing.Point(728, 342);
            this.About_Content.Multiline = true;
            this.About_Content.Name = "About_Content";
            this.About_Content.Size = new System.Drawing.Size(134, 102);
            this.About_Content.TabIndex = 15;
            this.About_Content.Text = "Developed by Lukas Annear, Zachary Claret-Scott, Jack Duffy, Jason Gill, Joseph P" +
    "otter, Paulo Salles and Daniel Wilson at the University of Lincoln in 2016.";
            // 
            // Preferred_Agent_Title
            // 
            this.Preferred_Agent_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Preferred_Agent_Title.AutoSize = true;
            this.Preferred_Agent_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(38)))), ((int)(((byte)(83)))));
            this.Preferred_Agent_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Preferred_Agent_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.Preferred_Agent_Title.Location = new System.Drawing.Point(724, 186);
            this.Preferred_Agent_Title.Name = "Preferred_Agent_Title";
            this.Preferred_Agent_Title.Size = new System.Drawing.Size(75, 40);
            this.Preferred_Agent_Title.TabIndex = 16;
            this.Preferred_Agent_Title.Text = "Preferred\r\nAgent:";
            // 
            // Preferred_Agent_Selection
            // 
            this.Preferred_Agent_Selection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Preferred_Agent_Selection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(28)))), ((int)(((byte)(59)))));
            this.Preferred_Agent_Selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Preferred_Agent_Selection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Preferred_Agent_Selection.ForeColor = System.Drawing.SystemColors.Control;
            this.Preferred_Agent_Selection.FormattingEnabled = true;
            this.Preferred_Agent_Selection.Items.AddRange(new object[] {
            "Bruce",
            "Hal",
            "Jason",
            "Suzi"});
            this.Preferred_Agent_Selection.Location = new System.Drawing.Point(804, 205);
            this.Preferred_Agent_Selection.Name = "Preferred_Agent_Selection";
            this.Preferred_Agent_Selection.Size = new System.Drawing.Size(58, 21);
            this.Preferred_Agent_Selection.Sorted = true;
            this.Preferred_Agent_Selection.TabIndex = 17;
            // 
            // UoL_Logo_Link_Title
            // 
            this.UoL_Logo_Link_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UoL_Logo_Link_Title.AutoSize = true;
            this.UoL_Logo_Link_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(38)))), ((int)(((byte)(83)))));
            this.UoL_Logo_Link_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UoL_Logo_Link_Title.ForeColor = System.Drawing.SystemColors.Control;
            this.UoL_Logo_Link_Title.Location = new System.Drawing.Point(724, 237);
            this.UoL_Logo_Link_Title.Name = "UoL_Logo_Link_Title";
            this.UoL_Logo_Link_Title.Size = new System.Drawing.Size(79, 40);
            this.UoL_Logo_Link_Title.TabIndex = 18;
            this.UoL_Logo_Link_Title.Text = "UoL Logo\r\nLink:";
            // 
            // UoL_Logo_Link_Selection
            // 
            this.UoL_Logo_Link_Selection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UoL_Logo_Link_Selection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(28)))), ((int)(((byte)(59)))));
            this.UoL_Logo_Link_Selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UoL_Logo_Link_Selection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UoL_Logo_Link_Selection.ForeColor = System.Drawing.SystemColors.Control;
            this.UoL_Logo_Link_Selection.FormattingEnabled = true;
            this.UoL_Logo_Link_Selection.Items.AddRange(new object[] {
            "Blackboard",
            "Homepage",
            "Library",
            "Timetable"});
            this.UoL_Logo_Link_Selection.Location = new System.Drawing.Point(804, 256);
            this.UoL_Logo_Link_Selection.Name = "UoL_Logo_Link_Selection";
            this.UoL_Logo_Link_Selection.Size = new System.Drawing.Size(58, 21);
            this.UoL_Logo_Link_Selection.Sorted = true;
            this.UoL_Logo_Link_Selection.TabIndex = 19;
            this.UoL_Logo_Link_Selection.SelectedIndexChanged += new System.EventHandler(this.UoL_Logo_Link_Selection_SelectedIndexChanged);
            // 
            // Reset_Button
            // 
            this.Reset_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Reset_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(28)))), ((int)(((byte)(59)))));
            this.Reset_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reset_Button.ForeColor = System.Drawing.SystemColors.Control;
            this.Reset_Button.Location = new System.Drawing.Point(807, 283);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(58, 23);
            this.Reset_Button.TabIndex = 20;
            this.Reset_Button.Text = "Reset";
            this.Reset_Button.UseVisualStyleBackColor = false;
            // 
            // Student_Name_Title
            // 
            this.Student_Name_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Student_Name_Title.AutoSize = true;
            this.Student_Name_Title.BackColor = System.Drawing.Color.Black;
            this.Student_Name_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Student_Name_Title.ForeColor = System.Drawing.Color.White;
            this.Student_Name_Title.Location = new System.Drawing.Point(725, 117);
            this.Student_Name_Title.Name = "Student_Name_Title";
            this.Student_Name_Title.Size = new System.Drawing.Size(86, 20);
            this.Student_Name_Title.TabIndex = 21;
            this.Student_Name_Title.Text = "John Doe";
            // 
            // Student_ID_Title
            // 
            this.Student_ID_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Student_ID_Title.AutoSize = true;
            this.Student_ID_Title.BackColor = System.Drawing.Color.Black;
            this.Student_ID_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Student_ID_Title.ForeColor = System.Drawing.Color.White;
            this.Student_ID_Title.Location = new System.Drawing.Point(725, 101);
            this.Student_ID_Title.Name = "Student_ID_Title";
            this.Student_ID_Title.Size = new System.Drawing.Size(72, 16);
            this.Student_ID_Title.TabIndex = 22;
            this.Student_ID_Title.Text = "12345678";
            // 
            // Hamburger_Menu
            // 
            this.Hamburger_Menu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Hamburger_Menu.BackColor = System.Drawing.Color.Transparent;
            this.Hamburger_Menu.BackgroundImage = global::UoL_Virtual_Assistant.Properties.Resources.Hamburger__for_light_themes_;
            this.Hamburger_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Hamburger_Menu.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Hamburger_Menu.FlatAppearance.BorderSize = 0;
            this.Hamburger_Menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Hamburger_Menu.Location = new System.Drawing.Point(836, 12);
            this.Hamburger_Menu.Name = "Hamburger_Menu";
            this.Hamburger_Menu.Size = new System.Drawing.Size(26, 26);
            this.Hamburger_Menu.TabIndex = 4;
            this.Hamburger_Menu.UseVisualStyleBackColor = false;
            this.Hamburger_Menu.Click += new System.EventHandler(this.Hamburger_Menu_Click);
            // 
            // Course_Building
            // 
            this.Course_Building.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Course_Building.BackgroundImage = global::UoL_Virtual_Assistant.Properties.Resources.MHT_Building__blurred_;
            this.Course_Building.Location = new System.Drawing.Point(716, 50);
            this.Course_Building.Name = "Course_Building";
            this.Course_Building.Size = new System.Drawing.Size(160, 90);
            this.Course_Building.TabIndex = 10;
            this.Course_Building.TabStop = false;
            // 
            // Settings_Drawer
            // 
            this.Settings_Drawer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Settings_Drawer.BackColor = System.Drawing.Color.Transparent;
            this.Settings_Drawer.BackgroundImage = global::UoL_Virtual_Assistant.Properties.Resources.Settings_Drawer;
            this.Settings_Drawer.Location = new System.Drawing.Point(699, 0);
            this.Settings_Drawer.MaximumSize = new System.Drawing.Size(200, 615);
            this.Settings_Drawer.MinimumSize = new System.Drawing.Size(185, 465);
            this.Settings_Drawer.Name = "Settings_Drawer";
            this.Settings_Drawer.Size = new System.Drawing.Size(200, 615);
            this.Settings_Drawer.TabIndex = 7;
            this.Settings_Drawer.TabStop = false;
            this.Settings_Drawer.Visible = false;
            // 
            // Send_Message
            // 
            this.Send_Message.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Send_Message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Send_Message.BackgroundImage = global::UoL_Virtual_Assistant.Properties.Resources.Send_Icon__for_light_themes_;
            this.Send_Message.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Send_Message.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Send_Message.FlatAppearance.BorderSize = 0;
            this.Send_Message.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Send_Message.Location = new System.Drawing.Point(528, 406);
            this.Send_Message.Name = "Send_Message";
            this.Send_Message.Size = new System.Drawing.Size(42, 38);
            this.Send_Message.TabIndex = 2;
            this.Send_Message.UseVisualStyleBackColor = false;
            this.Send_Message.Click += new System.EventHandler(this.Send_Message_Click);
            // 
            // Message_Input_Area
            // 
            this.Message_Input_Area.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Message_Input_Area.BackColor = System.Drawing.Color.Transparent;
            this.Message_Input_Area.BackgroundImage = global::UoL_Virtual_Assistant.Properties.Resources.Message_Input_Area__for_light_themes_;
            this.Message_Input_Area.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Message_Input_Area.Location = new System.Drawing.Point(289, 405);
            this.Message_Input_Area.Name = "Message_Input_Area";
            this.Message_Input_Area.Size = new System.Drawing.Size(310, 63);
            this.Message_Input_Area.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Message_Input_Area.TabIndex = 1;
            this.Message_Input_Area.TabStop = false;
            // 
            // Conversation_Window
            // 
            this.Conversation_Window.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Conversation_Window.BackColor = System.Drawing.Color.Transparent;
            this.Conversation_Window.BackgroundImage = global::UoL_Virtual_Assistant.Properties.Resources.Conversation_Area__for_light_themes_;
            this.Conversation_Window.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Conversation_Window.Location = new System.Drawing.Point(307, 410);
            this.Conversation_Window.Name = "Conversation_Window";
            this.Conversation_Window.Size = new System.Drawing.Size(263, 362);
            this.Conversation_Window.TabIndex = 8;
            this.Conversation_Window.TabStop = false;
            // 
            // UoL_Branding
            // 
            this.UoL_Branding.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UoL_Branding.BackColor = System.Drawing.Color.Transparent;
            this.UoL_Branding.BackgroundImage = global::UoL_Virtual_Assistant.Properties.Resources.UoL_Branding__for_light_themes_;
            this.UoL_Branding.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.UoL_Branding.Cursor = System.Windows.Forms.Cursors.Default;
            this.UoL_Branding.Location = new System.Drawing.Point(347, 80);
            this.UoL_Branding.Name = "UoL_Branding";
            this.UoL_Branding.Size = new System.Drawing.Size(180, 180);
            this.UoL_Branding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.UoL_Branding.TabIndex = 0;
            this.UoL_Branding.TabStop = false;
            this.UoL_Branding.Click += new System.EventHandler(this.UoL_Branding_Click);
            // 
            // Main_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(874, 461);
            this.Controls.Add(this.Student_ID_Title);
            this.Controls.Add(this.Student_Name_Title);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.Hamburger_Menu);
            this.Controls.Add(this.Settings_Title);
            this.Controls.Add(this.UoL_Logo_Link_Selection);
            this.Controls.Add(this.UoL_Logo_Link_Title);
            this.Controls.Add(this.Preferred_Agent_Selection);
            this.Controls.Add(this.Preferred_Agent_Title);
            this.Controls.Add(this.About_Content);
            this.Controls.Add(this.About_Title);
            this.Controls.Add(this.Reset_Title);
            this.Controls.Add(this.Theme_Selection);
            this.Controls.Add(this.Theme_Title);
            this.Controls.Add(this.Course_Building);
            this.Controls.Add(this.Settings_Drawer);
            this.Controls.Add(this.Message_Input);
            this.Controls.Add(this.Send_Message);
            this.Controls.Add(this.Message_Input_Area);
            this.Controls.Add(this.Conversation_Window);
            this.Controls.Add(this.UoL_Branding);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 650);
            this.MinimumSize = new System.Drawing.Size(350, 500);
            this.Name = "Main_UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UoL Assistant";
            ((System.ComponentModel.ISupportInitialize)(this.Course_Building)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Settings_Drawer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Message_Input_Area)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Conversation_Window)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UoL_Branding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox UoL_Branding;
        private System.Windows.Forms.PictureBox Message_Input_Area;
        private System.Windows.Forms.Button Send_Message;
        private System.Windows.Forms.TextBox Message_Input;
        private System.Windows.Forms.Button Hamburger_Menu;
        private System.Windows.Forms.PictureBox Settings_Drawer;
        private System.Windows.Forms.PictureBox Conversation_Window;
        private System.Windows.Forms.Label Settings_Title;
        private System.Windows.Forms.PictureBox Course_Building;
        private System.Windows.Forms.Label Theme_Title;
        private System.Windows.Forms.ComboBox Theme_Selection;
        private System.Windows.Forms.Label Reset_Title;
        private System.Windows.Forms.Label About_Title;
        private System.Windows.Forms.TextBox About_Content;
        private System.Windows.Forms.Label Preferred_Agent_Title;
        private System.Windows.Forms.ComboBox Preferred_Agent_Selection;
        private System.Windows.Forms.Label UoL_Logo_Link_Title;
        private System.Windows.Forms.ComboBox UoL_Logo_Link_Selection;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.Label Student_Name_Title;
        private System.Windows.Forms.Label Student_ID_Title;
    }
}

