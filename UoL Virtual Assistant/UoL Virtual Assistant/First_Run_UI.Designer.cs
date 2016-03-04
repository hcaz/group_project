namespace UoL_Virtual_Assistant
{
    partial class First_Run_UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(First_Run_UI));
            this.Hi_Label = new System.Windows.Forms.Label();
            this.Instruction_Text = new System.Windows.Forms.Label();
            this.ID_Input_Area = new System.Windows.Forms.PictureBox();
            this.Student_ID_Instruction = new System.Windows.Forms.Label();
            this.Course_Instruction = new System.Windows.Forms.Label();
            this.Course_Input_Area = new System.Windows.Forms.PictureBox();
            this.Continue_Button = new System.Windows.Forms.Button();
            this.ID_Input = new System.Windows.Forms.TextBox();
            this.Course_Selection = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ID_Input_Area)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Course_Input_Area)).BeginInit();
            this.SuspendLayout();
            // 
            // Hi_Label
            // 
            this.Hi_Label.AutoSize = true;
            this.Hi_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hi_Label.Location = new System.Drawing.Point(122, 23);
            this.Hi_Label.Name = "Hi_Label";
            this.Hi_Label.Size = new System.Drawing.Size(40, 31);
            this.Hi_Label.TabIndex = 0;
            this.Hi_Label.Text = "Hi";
            // 
            // Instruction_Text
            // 
            this.Instruction_Text.AutoSize = true;
            this.Instruction_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Instruction_Text.Location = new System.Drawing.Point(15, 54);
            this.Instruction_Text.Name = "Instruction_Text";
            this.Instruction_Text.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Instruction_Text.Size = new System.Drawing.Size(254, 72);
            this.Instruction_Text.TabIndex = 1;
            this.Instruction_Text.Text = "Before we get started we \r\nneed to get some information\r\nabout you!";
            this.Instruction_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ID_Input_Area
            // 
            this.ID_Input_Area.BackgroundImage = global::UoL_Virtual_Assistant.Properties.Resources.Message_Input_Area__for_light_themes_;
            this.ID_Input_Area.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ID_Input_Area.Location = new System.Drawing.Point(17, 177);
            this.ID_Input_Area.Name = "ID_Input_Area";
            this.ID_Input_Area.Size = new System.Drawing.Size(250, 50);
            this.ID_Input_Area.TabIndex = 2;
            this.ID_Input_Area.TabStop = false;
            // 
            // Student_ID_Instruction
            // 
            this.Student_ID_Instruction.AutoSize = true;
            this.Student_ID_Instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Student_ID_Instruction.Location = new System.Drawing.Point(92, 150);
            this.Student_ID_Instruction.Name = "Student_ID_Instruction";
            this.Student_ID_Instruction.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Student_ID_Instruction.Size = new System.Drawing.Size(101, 24);
            this.Student_ID_Instruction.TabIndex = 3;
            this.Student_ID_Instruction.Text = "Student ID:";
            this.Student_ID_Instruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Course_Instruction
            // 
            this.Course_Instruction.AutoSize = true;
            this.Course_Instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Course_Instruction.Location = new System.Drawing.Point(84, 241);
            this.Course_Instruction.Name = "Course_Instruction";
            this.Course_Instruction.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Course_Instruction.Size = new System.Drawing.Size(116, 24);
            this.Course_Instruction.TabIndex = 5;
            this.Course_Instruction.Text = "Course Title:";
            this.Course_Instruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Course_Input_Area
            // 
            this.Course_Input_Area.BackgroundImage = global::UoL_Virtual_Assistant.Properties.Resources.Message_Input_Area__for_light_themes_;
            this.Course_Input_Area.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Course_Input_Area.Location = new System.Drawing.Point(17, 275);
            this.Course_Input_Area.Name = "Course_Input_Area";
            this.Course_Input_Area.Size = new System.Drawing.Size(250, 30);
            this.Course_Input_Area.TabIndex = 4;
            this.Course_Input_Area.TabStop = false;
            // 
            // Continue_Button
            // 
            this.Continue_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Continue_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Continue_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Continue_Button.Location = new System.Drawing.Point(89, 340);
            this.Continue_Button.Name = "Continue_Button";
            this.Continue_Button.Size = new System.Drawing.Size(108, 37);
            this.Continue_Button.TabIndex = 3;
            this.Continue_Button.Text = "Continue";
            this.Continue_Button.UseVisualStyleBackColor = false;
            this.Continue_Button.Click += new System.EventHandler(this.Continue_Button_Click);
            // 
            // ID_Input
            // 
            this.ID_Input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ID_Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_Input.Location = new System.Drawing.Point(31, 183);
            this.ID_Input.Name = "ID_Input";
            this.ID_Input.Size = new System.Drawing.Size(224, 24);
            this.ID_Input.TabIndex = 1;
            this.ID_Input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Course_Selection
            // 
            this.Course_Selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Course_Selection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Course_Selection.FormattingEnabled = true;
            this.Course_Selection.Items.AddRange(new object[] {
            "Accountancy and Finance - BA (Hons)",
            "Advertising and Marketing - BA (Hons)",
            "Animal Behaviour and Welfare - BSc (Hons)",
            "Animal Behaviour and Welfare - MBio",
            "Animation - BA (Hons)",
            "Architecture - BA (Hons)",
            "Audio Production - BA (Hons)",
            "Bachelor of Architecture with Honours - BArch (Hons)",
            "Banking and Finance - (MFin)",
            "Banking and Finance - BSc (Hons)",
            "Biochemistry - BSc (Hons)",
            "Biochemistry - MBio",
            "Biology - BSc (Hons)",
            "Biology - MBio",
            "Biomedical Science - BSc (Hons)",
            "Biomedical Science - MBio",
            "Bioveterinary Science - BSc (Hons)",
            "Bioveterinary Science - MBio",
            "Business and Enterprise Development - BA (Hons)",
            "Business and Finance - BA (Hons)",
            "Business and Management - BA (Hons)",
            "Business and Marketing - BA (Hons)",
            "Business Economics - BA (Hons)",
            "Business Management - BA (Hons)",
            "Business Studies - BA (Hons)",
            "Chemistry - BSc (Hons)",
            "Chemistry - MChem",
            "Computer Science - BSc (Hons)",
            "Computer Science - MComp",
            "Conservation of Cultural Heritage - BA (Hons)",
            "Creative Advertising - BA (Hons)",
            "Criminology - BA (Hons)",
            "Criminology and Social Policy - BA (Hons)",
            "Criminology and Sociology - BA (Hons)",
            "Dance - BA (Hons)",
            "Design for Exhibition and Museums - BA (Hons)",
            "Drama - BA (Hons)",
            "Drama and English - BA (Hons)",
            "Economics - BSc (Hons)",
            "Economics and Finance - (MEcon)",
            "Economics and Finance - BSc (Hons)",
            "Electrical Engineering (Control Systems) - BEng (Hons)",
            "Electrical Engineering (Control Systems) - MEng (Hons)",
            "Electrical Engineering (Electronics) - BEng (Hons)",
            "Electrical Engineering (Electronics) - MEng (Hons)",
            "Electrical Engineering (Power and Energy) - BEng (Hons)",
            "Electrical Engineering (Power and Energy) - MEng (Hons)",
            "Engineering Management - BSc (Hons)",
            "English - BA (Hons)",
            "English and History - BA (Hons)",
            "English and Journalism - BA (Hons)",
            "Events Management - BSc (Hons)",
            "Fashion - BA (Hons)",
            "Film and Television - BA (Hons)",
            "Fine Art - BA (Hons)",
            "Food Manufacture (Operations Management) - BSc (Hons)",
            "Food Manufacture (Operations Management) - FdSc",
            "Food Manufacture (Quality Assurance and Technical Management) - BSc (Hons)",
            "Food Manufacture (Quality Assurance and Technical Management) - FdSc",
            "Forensic Chemistry - BSc (Hons)",
            "Forensic Chemistry - MChem",
            "Forensic Science - BSc (Hons)",
            "Games Computing - BSc (Hons)",
            "Games Computing - MComp",
            "Graphic Design - BA (Hons)",
            "Health and Social Care - BSc (Hons)",
            "History - BA (Hons)",
            "Illustration - BA (Hons)",
            "Interactive Design - BA (Hons)",
            "Interior Architecture and Design - BA (Hons)",
            "International Business Management - BA (Hons)",
            "International Relations - BA (Hons)",
            "International Relations and Politics - BA (Hons)",
            "International Relations and Social Policy - BA (Hons)",
            "International Tourism Management - BA (Hons)",
            "Journalism - BA (Hons)",
            "Journalism (Investigative) - BA (Hons)",
            "Journalism and Public Relations - BA (Hons)",
            "Law - LLB (Hons)",
            "Law and Criminology - LLB (Hons)",
            "Logistics Management (Open) - BSc (Hons)",
            "Marketing - BA (Hons)",
            "Mathematics - BSc (Hons)",
            "Mathematics - MMath",
            "Mathematics and Computer Science - BSc (Hons)",
            "Mathematics and Physics - BSc (Hons)",
            "Mathematics and Physics - MMath",
            "Mechanical Engineering - BEng (Hons)",
            "Mechanical Engineering - MEng (Hons)",
            "Mechanical Engineering (Control Systems) - BEng (Hons)",
            "Mechanical Engineering (Control Systems) - MEng (Hons)",
            "Mechanical Engineering (Power and Energy) - BEng (Hons)",
            "Mechanical Engineering (Power and Energy) - MEng (Hons)",
            "Media Production - BA (Hons)",
            "Media Studies - BA (Hons)",
            "Music - BA (Hons)",
            "Nursing - BSc (Hons)",
            "Nursing (Mental Health) - BSc (Hons)",
            "Pharmaceutical Science - BSc (Hons)",
            "Pharmacy - MPharm",
            "Photography - BA (Hons)",
            "Physical Activity and Health Development - BSc (Hons)",
            "Physical Education and Sport - BSc (Hons)",
            "Physics - BSc (Hons)",
            "Physics - MPhys",
            "Politics - BA (Hons)",
            "Politics and Social Policy - BA (Hons)",
            "Politics and Sociology - BA (Hons)",
            "Practice Certificate in Non-Medical Prescribing - UG Credit",
            "Product Design - BA (Hons)",
            "Professional Practice - BSc (Hons)",
            "Psychology - BSc (Hons)",
            "Psychology with Clinical Psychology - BSc (Hons)",
            "Psychology with Forensic Psychology - BSc (Hons)",
            "Public Relations - BA (Hons)",
            "Social Policy - BA (Hons)",
            "Social Policy and Sociology - BA (Hons)",
            "Social Work - BSc (Hons)",
            "Sociology - BA (Hons)",
            "Sport and Exercise Science - BSc (Hons)",
            "Sport Development and Coaching - BSc (Hons)",
            "Strength and Conditioning in Sport - BSc (Hons)",
            "Zoology - BSc (Hons)",
            "Zoology - MBio"});
            this.Course_Selection.Location = new System.Drawing.Point(31, 276);
            this.Course_Selection.Name = "Course_Selection";
            this.Course_Selection.Size = new System.Drawing.Size(224, 21);
            this.Course_Selection.TabIndex = 2;
            this.Course_Selection.SelectedIndexChanged += new System.EventHandler(this.Course_Selection_SelectedIndexChanged);
            // 
            // First_Run_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(285, 400);
            this.Controls.Add(this.Course_Selection);
            this.Controls.Add(this.ID_Input);
            this.Controls.Add(this.Continue_Button);
            this.Controls.Add(this.Course_Instruction);
            this.Controls.Add(this.Course_Input_Area);
            this.Controls.Add(this.Student_ID_Instruction);
            this.Controls.Add(this.ID_Input_Area);
            this.Controls.Add(this.Instruction_Text);
            this.Controls.Add(this.Hi_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(285, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(275, 155);
            this.Name = "First_Run_UI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.ID_Input_Area)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Course_Input_Area)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Hi_Label;
        private System.Windows.Forms.Label Instruction_Text;
        private System.Windows.Forms.PictureBox ID_Input_Area;
        private System.Windows.Forms.Label Student_ID_Instruction;
        private System.Windows.Forms.Label Course_Instruction;
        private System.Windows.Forms.PictureBox Course_Input_Area;
        private System.Windows.Forms.Button Continue_Button;
        private System.Windows.Forms.TextBox ID_Input;
        private System.Windows.Forms.ComboBox Course_Selection;
    }
}