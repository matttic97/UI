namespace ReševanjeLabirinta
{
    partial class ReševanjeLabirinta
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
            this.opnFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblHeading2 = new System.Windows.Forms.Label();
            this.lblHeading1 = new System.Windows.Forms.Label();
            this.pnRight = new System.Windows.Forms.Panel();
            this.lblSolvedMatrix = new System.Windows.Forms.Label();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.lblLabMatrix = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblSelectedFile = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.mainPanel.SuspendLayout();
            this.pnRight.SuspendLayout();
            this.pnLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // opnFileDialog
            // 
            this.opnFileDialog.FileName = "opnFileDialog";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.lblHeading2);
            this.mainPanel.Controls.Add(this.lblHeading1);
            this.mainPanel.Controls.Add(this.pnRight);
            this.mainPanel.Controls.Add(this.pnLeft);
            this.mainPanel.Location = new System.Drawing.Point(12, 68);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(802, 447);
            this.mainPanel.TabIndex = 2;
            // 
            // lblHeading2
            // 
            this.lblHeading2.AutoSize = true;
            this.lblHeading2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHeading2.Location = new System.Drawing.Point(534, 18);
            this.lblHeading2.Name = "lblHeading2";
            this.lblHeading2.Size = new System.Drawing.Size(157, 24);
            this.lblHeading2.TabIndex = 2;
            this.lblHeading2.Text = "Rešitev labirinta";
            // 
            // lblHeading1
            // 
            this.lblHeading1.AutoSize = true;
            this.lblHeading1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHeading1.Location = new System.Drawing.Point(103, 18);
            this.lblHeading1.Name = "lblHeading1";
            this.lblHeading1.Size = new System.Drawing.Size(164, 24);
            this.lblHeading1.TabIndex = 0;
            this.lblHeading1.Text = "Labirint (matrika)";
            // 
            // pnRight
            // 
            this.pnRight.AutoScroll = true;
            this.pnRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnRight.Controls.Add(this.lblSolvedMatrix);
            this.pnRight.Location = new System.Drawing.Point(411, 54);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(388, 390);
            this.pnRight.TabIndex = 1;
            // 
            // lblSolvedMatrix
            // 
            this.lblSolvedMatrix.AutoSize = true;
            this.lblSolvedMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSolvedMatrix.Location = new System.Drawing.Point(4, 4);
            this.lblSolvedMatrix.Name = "lblSolvedMatrix";
            this.lblSolvedMatrix.Size = new System.Drawing.Size(0, 20);
            this.lblSolvedMatrix.TabIndex = 0;
            // 
            // pnLeft
            // 
            this.pnLeft.AutoScroll = true;
            this.pnLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLeft.Controls.Add(this.lblLabMatrix);
            this.pnLeft.Location = new System.Drawing.Point(3, 54);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(402, 390);
            this.pnLeft.TabIndex = 0;
            // 
            // lblLabMatrix
            // 
            this.lblLabMatrix.AutoSize = true;
            this.lblLabMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLabMatrix.Location = new System.Drawing.Point(4, 4);
            this.lblLabMatrix.Name = "lblLabMatrix";
            this.lblLabMatrix.Size = new System.Drawing.Size(0, 16);
            this.lblLabMatrix.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnImport.Location = new System.Drawing.Point(15, 16);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(134, 37);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Izberi labirint";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblFile.Location = new System.Drawing.Point(161, 21);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(87, 24);
            this.lblFile.TabIndex = 4;
            this.lblFile.Text = "Datoteka:";
            // 
            // lblSelectedFile
            // 
            this.lblSelectedFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSelectedFile.Location = new System.Drawing.Point(254, 21);
            this.lblSelectedFile.Name = "lblSelectedFile";
            this.lblSelectedFile.Size = new System.Drawing.Size(163, 24);
            this.lblSelectedFile.TabIndex = 5;
            this.lblSelectedFile.Text = "/";
            // 
            // comboBox
            // 
            this.comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(550, 19);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(131, 26);
            this.comboBox.TabIndex = 6;
            this.comboBox.Text = "Izberi algoritem";
            // 
            // btnSort
            // 
            this.btnSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSort.Location = new System.Drawing.Point(687, 13);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(127, 37);
            this.btnSort.TabIndex = 7;
            this.btnSort.Text = "Poišči rešitev";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(464, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Algoritem:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(423, 519);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(223, 19);
            this.progressBar1.TabIndex = 9;
            // 
            // ReševanjeLabirinta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 542);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.lblSelectedFile);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReševanjeLabirinta";
            this.Text = "ReševanjeLabirinta";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.pnRight.ResumeLayout(false);
            this.pnRight.PerformLayout();
            this.pnLeft.ResumeLayout(false);
            this.pnLeft.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog opnFileDialog;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel pnRight;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Label lblHeading2;
        private System.Windows.Forms.Label lblHeading1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblSelectedFile;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Label lblLabMatrix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSolvedMatrix;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

