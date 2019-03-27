namespace CurvedCS
{
    partial class FrontForm
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
            this.Title = new System.Windows.Forms.Label();
            this.SelectCurve = new System.Windows.Forms.Button();
            this.CurveID = new System.Windows.Forms.Label();
            this.numberSegments = new System.Windows.Forms.Label();
            this.fromZ = new System.Windows.Forms.Label();
            this.toZ = new System.Windows.Forms.Label();
            this.signature = new System.Windows.Forms.Label();
            this.showLinks = new System.Windows.Forms.CheckBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.sheet_drop_down = new System.Windows.Forms.ComboBox();
            this.sheet = new System.Windows.Forms.Label();
            this.detailLevel = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.visualStyle = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.scale = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.name = new System.Windows.Forms.Label();
            this.secName = new System.Windows.Forms.TextBox();
            this.showAnnotations = new System.Windows.Forms.CheckBox();
            this.NumericSegments = new System.Windows.Forms.TextBox();
            this.fromZ_Input = new System.Windows.Forms.TextBox();
            this.toZInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Futura Hv BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Title.Location = new System.Drawing.Point(99, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(171, 19);
            this.Title.TabIndex = 0;
            this.Title.Text = "Curved Cross Section";
            this.Title.Click += new System.EventHandler(this.label1_Click);
            // 
            // SelectCurve
            // 
            this.SelectCurve.Location = new System.Drawing.Point(26, 41);
            this.SelectCurve.Name = "SelectCurve";
            this.SelectCurve.Size = new System.Drawing.Size(136, 55);
            this.SelectCurve.TabIndex = 1;
            this.SelectCurve.Text = "Select Model Curve";
            this.SelectCurve.UseVisualStyleBackColor = true;
            this.SelectCurve.Click += new System.EventHandler(this.SelectCurve_Click);
            // 
            // CurveID
            // 
            this.CurveID.AutoSize = true;
            this.CurveID.Location = new System.Drawing.Point(207, 62);
            this.CurveID.Name = "CurveID";
            this.CurveID.Size = new System.Drawing.Size(89, 13);
            this.CurveID.TabIndex = 2;
            this.CurveID.Text = "Nothing Selected";
            // 
            // numberSegments
            // 
            this.numberSegments.AutoSize = true;
            this.numberSegments.Location = new System.Drawing.Point(42, 134);
            this.numberSegments.Name = "numberSegments";
            this.numberSegments.Size = new System.Drawing.Size(104, 13);
            this.numberSegments.TabIndex = 4;
            this.numberSegments.Text = "Number of segments";
            // 
            // fromZ
            // 
            this.fromZ.AutoSize = true;
            this.fromZ.Location = new System.Drawing.Point(42, 166);
            this.fromZ.Name = "fromZ";
            this.fromZ.Size = new System.Drawing.Size(57, 13);
            this.fromZ.TabIndex = 6;
            this.fromZ.Text = "From Z (m)";
            // 
            // toZ
            // 
            this.toZ.AutoSize = true;
            this.toZ.Location = new System.Drawing.Point(42, 198);
            this.toZ.Name = "toZ";
            this.toZ.Size = new System.Drawing.Size(47, 13);
            this.toZ.TabIndex = 8;
            this.toZ.Text = "To Z (m)";
            // 
            // signature
            // 
            this.signature.AutoSize = true;
            this.signature.Font = new System.Drawing.Font("Futura Hv BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signature.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.signature.Location = new System.Drawing.Point(128, 562);
            this.signature.Name = "signature";
            this.signature.Size = new System.Drawing.Size(190, 18);
            this.signature.TabIndex = 9;
            this.signature.Text = "by Pablo  Alvarez  - 2019";
            // 
            // showLinks
            // 
            this.showLinks.AutoSize = true;
            this.showLinks.Location = new System.Drawing.Point(102, 393);
            this.showLinks.Name = "showLinks";
            this.showLinks.Size = new System.Drawing.Size(109, 17);
            this.showLinks.TabIndex = 10;
            this.showLinks.Text = "Show Linked files";
            this.showLinks.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(176, 490);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(136, 55);
            this.Cancel.TabIndex = 11;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(12, 490);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(136, 55);
            this.OK.TabIndex = 12;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // sheet_drop_down
            // 
            this.sheet_drop_down.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sheet_drop_down.FormattingEnabled = true;
            this.sheet_drop_down.Location = new System.Drawing.Point(102, 244);
            this.sheet_drop_down.Name = "sheet_drop_down";
            this.sheet_drop_down.Size = new System.Drawing.Size(194, 21);
            this.sheet_drop_down.TabIndex = 13;
            this.sheet_drop_down.SelectedIndexChanged += new System.EventHandler(this.sheet_drop_down_SelectedIndexChanged);
            // 
            // sheet
            // 
            this.sheet.AutoSize = true;
            this.sheet.Location = new System.Drawing.Point(54, 247);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(35, 13);
            this.sheet.TabIndex = 14;
            this.sheet.Text = "Sheet";
            // 
            // detailLevel
            // 
            this.detailLevel.AutoSize = true;
            this.detailLevel.Location = new System.Drawing.Point(26, 274);
            this.detailLevel.Name = "detailLevel";
            this.detailLevel.Size = new System.Drawing.Size(63, 13);
            this.detailLevel.TabIndex = 16;
            this.detailLevel.Text = "Detail Level";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Coarse",
            "Medium",
            "Fine"});
            this.comboBox2.Location = new System.Drawing.Point(102, 271);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(194, 21);
            this.comboBox2.TabIndex = 15;
            // 
            // visualStyle
            // 
            this.visualStyle.AutoSize = true;
            this.visualStyle.Location = new System.Drawing.Point(26, 301);
            this.visualStyle.Name = "visualStyle";
            this.visualStyle.Size = new System.Drawing.Size(61, 13);
            this.visualStyle.TabIndex = 18;
            this.visualStyle.Text = "Visual Style";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Wireframe",
            "Hidden Line",
            "Shaded",
            "Consistent Colours",
            "Realistic"});
            this.comboBox3.Location = new System.Drawing.Point(102, 298);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(194, 21);
            this.comboBox3.TabIndex = 17;
            // 
            // scale
            // 
            this.scale.AutoSize = true;
            this.scale.Location = new System.Drawing.Point(40, 328);
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(34, 13);
            this.scale.TabIndex = 19;
            this.scale.Text = "Scale";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(103, 325);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown4.TabIndex = 20;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(42, 358);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(35, 13);
            this.name.TabIndex = 21;
            this.name.Text = "Name";
            // 
            // secName
            // 
            this.secName.Location = new System.Drawing.Point(103, 355);
            this.secName.Name = "secName";
            this.secName.Size = new System.Drawing.Size(193, 20);
            this.secName.TabIndex = 22;
            // 
            // showAnnotations
            // 
            this.showAnnotations.AutoSize = true;
            this.showAnnotations.Location = new System.Drawing.Point(102, 427);
            this.showAnnotations.Name = "showAnnotations";
            this.showAnnotations.Size = new System.Drawing.Size(112, 17);
            this.showAnnotations.TabIndex = 23;
            this.showAnnotations.Text = "Show Annotations";
            this.showAnnotations.UseVisualStyleBackColor = true;
            // 
            // NumericSegments
            // 
            this.NumericSegments.Location = new System.Drawing.Point(176, 131);
            this.NumericSegments.Name = "NumericSegments";
            this.NumericSegments.Size = new System.Drawing.Size(120, 20);
            this.NumericSegments.TabIndex = 24;
            // 
            // fromZ_Input
            // 
            this.fromZ_Input.Location = new System.Drawing.Point(176, 163);
            this.fromZ_Input.Name = "fromZ_Input";
            this.fromZ_Input.Size = new System.Drawing.Size(120, 20);
            this.fromZ_Input.TabIndex = 25;
            // 
            // toZInput
            // 
            this.toZInput.Location = new System.Drawing.Point(176, 191);
            this.toZInput.Name = "toZInput";
            this.toZInput.Size = new System.Drawing.Size(120, 20);
            this.toZInput.TabIndex = 26;
            // 
            // FrontForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(330, 589);
            this.Controls.Add(this.toZInput);
            this.Controls.Add(this.fromZ_Input);
            this.Controls.Add(this.NumericSegments);
            this.Controls.Add(this.showAnnotations);
            this.Controls.Add(this.secName);
            this.Controls.Add(this.name);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.scale);
            this.Controls.Add(this.visualStyle);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.detailLevel);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.sheet_drop_down);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.showLinks);
            this.Controls.Add(this.signature);
            this.Controls.Add(this.toZ);
            this.Controls.Add(this.fromZ);
            this.Controls.Add(this.numberSegments);
            this.Controls.Add(this.CurveID);
            this.Controls.Add(this.SelectCurve);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrontForm";
            this.Text = "Curved Cross Section";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button SelectCurve;
        private System.Windows.Forms.Label CurveID;
        private System.Windows.Forms.Label numberSegments;
        private System.Windows.Forms.Label fromZ;
        private System.Windows.Forms.Label toZ;
        private System.Windows.Forms.Label signature;
        private System.Windows.Forms.CheckBox showLinks;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.ComboBox sheet_drop_down;
        private System.Windows.Forms.Label sheet;
        private System.Windows.Forms.Label detailLevel;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label visualStyle;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label scale;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.TextBox secName;
        private System.Windows.Forms.CheckBox showAnnotations;
        private System.Windows.Forms.TextBox NumericSegments;
        private System.Windows.Forms.TextBox fromZ_Input;
        private System.Windows.Forms.TextBox toZInput;
    }
}