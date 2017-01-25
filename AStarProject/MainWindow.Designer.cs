namespace AStarProject
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInitTiles = new System.Windows.Forms.Button();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.nudColums = new System.Windows.Forms.NumericUpDown();
            this.btnClearPath = new System.Windows.Forms.Button();
            this.btnClearField = new System.Windows.Forms.Button();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.chbAllowDiagonal = new System.Windows.Forms.CheckBox();
            this.Generate = new System.Windows.Forms.Button();
            this.txtSeed = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.asGrid1 = new AStarProject.asGrid();
            this.chbInstant = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColums)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.chbInstant);
            this.panel1.Controls.Add(this.btnInitTiles);
            this.panel1.Controls.Add(this.nudRows);
            this.panel1.Controls.Add(this.nudColums);
            this.panel1.Controls.Add(this.btnClearPath);
            this.panel1.Controls.Add(this.btnClearField);
            this.panel1.Controls.Add(this.cbxType);
            this.panel1.Controls.Add(this.chbAllowDiagonal);
            this.panel1.Controls.Add(this.Generate);
            this.panel1.Controls.Add(this.txtSeed);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1010, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 850);
            this.panel1.TabIndex = 1;
            // 
            // btnInitTiles
            // 
            this.btnInitTiles.Location = new System.Drawing.Point(13, 177);
            this.btnInitTiles.Name = "btnInitTiles";
            this.btnInitTiles.Size = new System.Drawing.Size(155, 23);
            this.btnInitTiles.TabIndex = 9;
            this.btnInitTiles.Text = "Init Tiles";
            this.btnInitTiles.UseVisualStyleBackColor = true;
            this.btnInitTiles.Click += new System.EventHandler(this.btnInitTiles_Click);
            // 
            // nudRows
            // 
            this.nudRows.Location = new System.Drawing.Point(94, 151);
            this.nudRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(74, 20);
            this.nudRows.TabIndex = 8;
            this.nudRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRows.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // nudColums
            // 
            this.nudColums.Location = new System.Drawing.Point(14, 151);
            this.nudColums.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColums.Name = "nudColums";
            this.nudColums.Size = new System.Drawing.Size(74, 20);
            this.nudColums.TabIndex = 7;
            this.nudColums.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudColums.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // btnClearPath
            // 
            this.btnClearPath.Location = new System.Drawing.Point(93, 122);
            this.btnClearPath.Name = "btnClearPath";
            this.btnClearPath.Size = new System.Drawing.Size(75, 23);
            this.btnClearPath.TabIndex = 6;
            this.btnClearPath.Text = "Clear Path";
            this.btnClearPath.UseVisualStyleBackColor = true;
            this.btnClearPath.Click += new System.EventHandler(this.btnClearPath_Click);
            // 
            // btnClearField
            // 
            this.btnClearField.Location = new System.Drawing.Point(13, 122);
            this.btnClearField.Name = "btnClearField";
            this.btnClearField.Size = new System.Drawing.Size(75, 23);
            this.btnClearField.TabIndex = 5;
            this.btnClearField.Text = "Clear Field";
            this.btnClearField.UseVisualStyleBackColor = true;
            this.btnClearField.Click += new System.EventHandler(this.btnClearField_Click);
            // 
            // cbxType
            // 
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "Normal",
            "NonWalkable",
            "Start",
            "Target"});
            this.cbxType.Location = new System.Drawing.Point(13, 503);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(121, 21);
            this.cbxType.TabIndex = 4;
            // 
            // chbAllowDiagonal
            // 
            this.chbAllowDiagonal.AutoSize = true;
            this.chbAllowDiagonal.Checked = true;
            this.chbAllowDiagonal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAllowDiagonal.Location = new System.Drawing.Point(94, 16);
            this.chbAllowDiagonal.Name = "chbAllowDiagonal";
            this.chbAllowDiagonal.Size = new System.Drawing.Size(96, 17);
            this.chbAllowDiagonal.TabIndex = 3;
            this.chbAllowDiagonal.Text = "Allow Diagonal";
            this.chbAllowDiagonal.UseVisualStyleBackColor = true;
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(13, 390);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(75, 23);
            this.Generate.TabIndex = 2;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // txtSeed
            // 
            this.txtSeed.Location = new System.Drawing.Point(13, 364);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(100, 20);
            this.txtSeed.TabIndex = 1;
            this.txtSeed.Text = "8754";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Find Path";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // asGrid1
            // 
            this.asGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.asGrid1.Colums = 2;
            this.asGrid1.Location = new System.Drawing.Point(10, 10);
            this.asGrid1.Name = "asGrid1";
            this.asGrid1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.asGrid1.Rows = 2;
            this.asGrid1.Seed = 8754;
            this.asGrid1.Size = new System.Drawing.Size(800, 800);
            this.asGrid1.TabIndex = 0;
            // 
            // chbInstant
            // 
            this.chbInstant.AutoSize = true;
            this.chbInstant.Location = new System.Drawing.Point(93, 40);
            this.chbInstant.Name = "chbInstant";
            this.chbInstant.Size = new System.Drawing.Size(84, 17);
            this.chbInstant.TabIndex = 10;
            this.chbInstant.Text = "Gen. Instant";
            this.chbInstant.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1210, 850);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.asGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColums)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private asGrid asGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.TextBox txtSeed;
        private System.Windows.Forms.CheckBox chbAllowDiagonal;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Button btnClearPath;
        private System.Windows.Forms.Button btnClearField;
        private System.Windows.Forms.Button btnInitTiles;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.NumericUpDown nudColums;
        private System.Windows.Forms.CheckBox chbInstant;
    }
}

